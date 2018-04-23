using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace HowToExdendApplicationModelAndSchema.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            HowToExdendApplicationModelAndSchemaWindowsFormsApplication application = new HowToExdendApplicationModelAndSchemaWindowsFormsApplication();
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            {
                application.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            try
            {
                application.Setup();
                application.Start();
            }
            catch (Exception e)
            {
                application.HandleException(e);
            }
        }
    }
}
