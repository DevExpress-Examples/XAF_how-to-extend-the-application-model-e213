using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;

namespace HowToExdendApplicationModelAndSchema.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class HowToExdendApplicationModelAndSchemaWindowsFormsModule : ModuleBase
    {
        public HowToExdendApplicationModelAndSchemaWindowsFormsModule()
        {
            InitializeComponent();
        }

        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelListView, IModelListViewExtender>();
            extenders.Add<IModelColumn, IModelColumnExtender>();
        }
    }
}
