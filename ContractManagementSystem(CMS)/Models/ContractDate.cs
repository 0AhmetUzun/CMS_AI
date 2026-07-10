using System;

namespace ContractManagementSystem_CMS_.Models
{
    public class ContractDate
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string DateType { get; set; } = "";
        public DateTime DateValue { get; set; }
        public int ReminderDays { get; set; } = 30;
        public bool IsNotified { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }

        public int DaysRemaining => (int)Math.Ceiling((DateValue - DateTime.Today).TotalDays);

        public string DateTypeDisplayName => DateType switch
        {
            "Bitis" => "📅 Bitiş Tarihi",
            "FesihBildirim" => "⏰ Fesih Bildirim Son Tarihi",
            "Odeme" => "💰 Ödeme Tarihi",
            "Yenileme" => "🔄 Yenileme Bildirim Son Tarihi",
            _ => DateType
        };

        public bool IsPast => DaysRemaining < 0;

        public string? ContractName { get; set; }
    }
}
