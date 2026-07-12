using System;
using System.Windows.Forms;
using ContractManagementSystem_CMS_.Forms;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                DatabaseHelper.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Veritabani olusturulamadi:\n\n{ex.Message}\n\n{ex.InnerException?.Message}",
                    "Veritabani Hatasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (SecurityService.IsPinEnabled())
            {
                using (var lockScreen = new LockScreenForm(LockMode.Startup))
                {
                    if (lockScreen.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            Application.Run(new MainScreen());
        }
    }
}
