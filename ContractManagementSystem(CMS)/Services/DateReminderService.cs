using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class DateReminderService
    {
        private readonly DatabaseService _dbService;

        public DateReminderService()
        {
            _dbService = new DatabaseService();
        }

        public DateReminderService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        // --- Türetme ve Kaydetme ---

        public void SaveDatesFromExtractions(int contractId, Dictionary<string, string> extractions)
        {
            var dates = DeriveDates(contractId, extractions);
            foreach (var d in dates)
            {
                UpsertDate(d);
            }
        }

        public List<ContractDate> DeriveDates(int contractId, Dictionary<string, string> extractions)
        {
            var result = new List<ContractDate>();

            DateTime? baslangic = TryParseDate(Get(extractions, "BaslangicTarihi"));
            DateTime? bitis = TryParseDate(Get(extractions, "BitisTarihi"));
            int fesihSure = ParseDays(Get(extractions, "FesihBildirimSuresi"));
            int yenilemeSure = ParseDays(Get(extractions, "YenilemeBildirimSuresi"));
            string yenileme = Get(extractions, "Yenileme") ?? "";
            int odemeVade = ParseDays(Get(extractions, "OdemeVadesi"));

            if (bitis.HasValue)
            {
                result.Add(MakeDate(contractId, "Bitis", bitis.Value, 30));
            }

            if (bitis.HasValue && fesihSure > 0)
            {
                result.Add(MakeDate(contractId, "FesihBildirim", bitis.Value.AddDays(-fesihSure), fesihSure));
            }

            if (bitis.HasValue && yenileme.IndexOf("otomatik", StringComparison.OrdinalIgnoreCase) >= 0 && yenilemeSure > 0)
            {
                result.Add(MakeDate(contractId, "Yenileme", bitis.Value.AddDays(-yenilemeSure), yenilemeSure));
            }

            if (baslangic.HasValue && odemeVade > 0)
            {
                result.Add(MakeDate(contractId, "Odeme", baslangic.Value.AddDays(odemeVade), 7));
            }

            return result;
        }

        private ContractDate MakeDate(int contractId, string type, DateTime value, int reminderDays)
        {
            return new ContractDate
            {
                ContractId = contractId,
                DateType = type,
                DateValue = value,
                ReminderDays = reminderDays
            };
        }

        private string? Get(Dictionary<string, string> dict, string key)
        {
            return dict != null && dict.TryGetValue(key, out var v) ? v : null;
        }

        // --- Veritabanı İşlemleri ---

        private void UpsertDate(ContractDate date)
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                var existing = db.QueryFirstOrDefault<ContractDate>(
                    "SELECT * FROM ContractDates WHERE ContractId = @ContractId AND DateType = @DateType",
                    new { date.ContractId, date.DateType });

                if (existing == null)
                {
                    db.Execute(
                        "INSERT INTO ContractDates (ContractId, DateType, DateValue, ReminderDays, IsNotified, Note, CreatedAt) " +
                        "VALUES (@ContractId, @DateType, @DateValue, @ReminderDays, 0, NULL, GETDATE())",
                        new { date.ContractId, date.DateType, date.DateValue, date.ReminderDays });
                }
            }
        }

        public List<ContractDate> GetAllDates()
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                return db.Query<ContractDate>(
                    "SELECT cd.*, c.FileName AS ContractName FROM ContractDates cd " +
                    "INNER JOIN Contracts c ON c.Id = cd.ContractId ORDER BY cd.DateValue")
                    .ToList();
            }
        }

        public List<ContractDate> GetUpcomingDates(int withinDays, bool includePast = false)
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string sql = "SELECT cd.*, c.FileName AS ContractName FROM ContractDates cd " +
                             "INNER JOIN Contracts c ON c.Id = cd.ContractId " +
                             "WHERE cd.DateValue >= @Start ";
                if (!includePast)
                    sql += "AND cd.DateValue <= @End ";
                sql += "ORDER BY cd.DateValue";

                DateTime start = includePast ? DateTime.Today.AddDays(-3650) : DateTime.Today;
                DateTime end = DateTime.Today.AddDays(withinDays);

                return db.Query<ContractDate>(sql, new { Start = start, End = end }).ToList();
            }
        }

        public void AddManualDate(ContractDate date)
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                db.Execute(
                    "INSERT INTO ContractDates (ContractId, DateType, DateValue, ReminderDays, IsNotified, Note, CreatedAt) " +
                    "VALUES (@ContractId, @DateType, @DateValue, @ReminderDays, 0, @Note, GETDATE())",
                    new { date.ContractId, date.DateType, date.DateValue, date.ReminderDays, date.Note });
            }
        }

        public void UpdateDate(ContractDate date)
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                db.Execute(
                    "UPDATE ContractDates SET DateType = @DateType, DateValue = @DateValue, " +
                    "ReminderDays = @ReminderDays, Note = @Note WHERE Id = @Id",
                    new { date.DateType, date.DateValue, date.ReminderDays, date.Note, date.Id });
            }
        }

        public void DeleteDate(int id)
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                db.Execute("DELETE FROM ContractDates WHERE Id = @Id", new { Id = id });
            }
        }

        public void MarkNotified(int id)
        {
            using (var db = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                db.Execute("UPDATE ContractDates SET IsNotified = 1 WHERE Id = @Id", new { Id = id });
            }
        }

        public List<ContractListItem> GetAllContracts()
        {
            return _dbService.GetAllContracts();
        }

        // --- Tarih Parse Yardımcıları ---

        public DateTime? TryParseDate(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Trim() == "Bulunamadı")
                return null;

            string s = input.Trim();

            var cultures = new[] { new CultureInfo("tr-TR"), CultureInfo.InvariantCulture };
            string[] formats =
            {
                "dd.MM.yyyy", "d.M.yyyy", "dd/MM/yyyy", "d/M/yyyy",
                "dd MM yyyy", "d MM yyyy", "yyyy-MM-dd", "yyyy.MM.dd",
                "dd.MM.yy", "d.M.yy"
            };

            foreach (var ci in cultures)
            {
                if (DateTime.TryParseExact(s, formats, ci, DateTimeStyles.None, out var dt))
                    return dt;
            }

            // Türkçe ay adlı biçim: "15 Temmuz 2026"
            if (DateTime.TryParse(s, new CultureInfo("tr-TR"), DateTimeStyles.None, out var trDt))
                return trDt;

            if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out var invDt))
                return invDt;

            return null;
        }

        public int ParseDays(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Trim() == "Bulunamadı")
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(input, @"(\d+)");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int days))
                return days;

            return 0;
        }
    }
}
