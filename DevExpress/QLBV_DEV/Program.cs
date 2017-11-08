using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace QLBV_DEV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "Quan mem quan ly thuoc - TKV", out result);
            if (!result)
            {
                MessageBox.Show("Phần mềm đang được chạy, vui lòng kiểm lại...", "Phần mềm quản lý thuốc - TKV");
                return;
            }
            CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");

            // The following line provides localization for the application's user interface.  
            Thread.CurrentThread.CurrentUICulture = culture;

            // The following line provides localization for data formats.  
            Thread.CurrentThread.CurrentCulture = culture;

            // Set this culture as the default culture for all threads in this application.  
            // Note: The following properties are supported in the .NET Framework 4.5+ 
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            culture.NumberFormat.CurrencySymbol = "VNĐ"; // ₫
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            DevExpress.Utils.FormatInfo.AlwaysUseThreadFormat = true;


            Application.Run(new frmLogin());
        }
    }
}
