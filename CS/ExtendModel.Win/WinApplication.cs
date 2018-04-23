using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace ExtendModel.Win {
    public partial class ExtendModelWindowsFormsApplication : WinApplication {
        public ExtendModelWindowsFormsApplication() {
            InitializeComponent();
            DelayedViewItemsInitialization = true;
        }

        private void ExtendModelWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
