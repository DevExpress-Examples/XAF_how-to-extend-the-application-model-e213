using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;

namespace ExtendModel.Module {
    public sealed partial class ExtendModelModule : ModuleBase {
        public ExtendModelModule() {
            InitializeComponent();
        }
        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelListView, IModelListViewExtender>();
            extenders.Add<IModelColumn, IModelColumnExtender>();
        }
    }
}
