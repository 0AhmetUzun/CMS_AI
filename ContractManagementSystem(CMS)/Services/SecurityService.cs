using System;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Services;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ContractManagementSystem_CMS_.Services
{
    public static class SecurityService
    {
        private const int Pbkdf2Iterations = 100_000;
        private const int SaltBytes = 16;

        public static bool IsPinEnabled()
        {
            string? val = GetSetting("PinEnabled");
            return string.Equals(val, "true", StringComparison.OrdinalIgnoreCase);
        }

        public static int GetIdleTimeoutMinutes()
        {
            string? val = GetSetting("IdleTimeoutMinutes");
            if (int.TryParse(val, out int mins) && mins > 0)
                return mins;
            return 10;
        }

        public static void SetIdleTimeoutMinutes(int minutes)
        {
            if (minutes < 1) minutes = 1;
            if (minutes > 60) minutes = 60;
            SetSetting("IdleTimeoutMinutes", minutes.ToString());
        }

        public static void SetPin(string pin)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltBytes);
            byte[] hash = DeriveHash(pin, salt);

            SetSetting("PinSalt", Convert.ToBase64String(salt));
            SetSetting("PinHash", Convert.ToBase64String(hash));
            SetSetting("PinEnabled", "true");
        }

        public static bool VerifyPin(string pin)
        {
            if (!IsPinEnabled()) return true;

            string? saltB64 = GetSetting("PinSalt");
            string? hashB64 = GetSetting("PinHash");
            if (string.IsNullOrEmpty(saltB64) || string.IsNullOrEmpty(hashB64))
                return false;

            byte[] salt = Convert.FromBase64String(saltB64);
            byte[] expected = Convert.FromBase64String(hashB64);
            byte[] actual = DeriveHash(pin, salt);

            if (actual.Length != expected.Length)
                return false;

            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }

        public static void DisablePin()
        {
            SetSetting("PinEnabled", "false");
            SetSetting("PinHash", "");
            SetSetting("PinSalt", "");
        }

        private static byte[] DeriveHash(string pin, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(
                pin, salt, Pbkdf2Iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(32);
        }

        private static string? GetSetting(string key)
        {
            try
            {
                using var db = new SqlConnection(DatabaseHelper.GetConnectionString());
                db.Open();
                return db.ExecuteScalar<string?>(
                    "SELECT SettingValue FROM AppSettings WHERE SettingKey = @k",
                    new { k = key });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[SecurityService] Ayar okuma hatası ({key}): {ex.Message}");
                return null;
            }
        }

        private static void SetSetting(string key, string value)
        {
            using var db = new SqlConnection(DatabaseHelper.GetConnectionString());
            db.Open();
            int cnt = db.ExecuteScalar<int>(
                "SELECT COUNT(*) FROM AppSettings WHERE SettingKey = @k",
                new { k = key });
            if (cnt == 0)
                db.Execute("INSERT INTO AppSettings (SettingKey, SettingValue) VALUES (@k, @v)",
                    new { k = key, v = value });
            else
                db.Execute("UPDATE AppSettings SET SettingValue = @v WHERE SettingKey = @k",
                    new { k = key, v = value });
        }

        public sealed class IdleMonitor : IMessageFilter, IDisposable
        {
            private readonly System.Windows.Forms.Timer _timer;
            private DateTime _lastActivity;
            private Action? _onIdle;
            private int _timeoutMs;
            private bool _active;
            private bool _registered;

            public IdleMonitor()
            {
                _timer = new System.Windows.Forms.Timer();
                _timer.Tick += Timer_Tick;
                _timer.Interval = 5000;
            }

            public void Start(Action onIdle)
            {
                _onIdle = onIdle;
                _timeoutMs = SecurityService.GetIdleTimeoutMinutes() * 60_000;
                _lastActivity = DateTime.Now;
                _timer.Enabled = true;
                _active = true;
                if (!_registered)
                {
                    Application.AddMessageFilter(this);
                    _registered = true;
                }
            }

            public void Stop()
            {
                _active = false;
                _timer.Enabled = false;
                if (_registered)
                {
                    Application.RemoveMessageFilter(this);
                    _registered = false;
                }
            }

            public void Reset()
            {
                _lastActivity = DateTime.Now;
                if (_active && !_timer.Enabled)
                    _timer.Enabled = true;
            }

            private void Timer_Tick(object? sender, EventArgs e)
            {
                if (!_active) return;
                _timeoutMs = SecurityService.GetIdleTimeoutMinutes() * 60_000;
                if ((DateTime.Now - _lastActivity).TotalMilliseconds >= _timeoutMs)
                {
                    _timer.Enabled = false;
                    _onIdle?.Invoke();
                }
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (!_active) return false;

                const int WM_MOUSEMOVE = 0x0200;
                const int WM_KEYDOWN = 0x0100;
                const int WM_MOUSEWHEEL = 0x020A;
                const int WM_LBUTTONDOWN = 0x0201;
                const int WM_RBUTTONDOWN = 0x0204;

                if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_KEYDOWN ||
                    m.Msg == WM_MOUSEWHEEL || m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN)
                {
                    _lastActivity = DateTime.Now;
                }
                return false;
            }

            public void Dispose()
            {
                Stop();
                _timer.Dispose();
            }
        }
    }
}
