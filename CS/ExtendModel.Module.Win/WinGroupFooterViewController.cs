using System;
using DevExpress.Data;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace ExtendModel.Module.Win {
    public class WinGroupFooterViewController : ViewController<ListView> {
        private void View_InfoSynchronized(object sender, EventArgs e) {
            IModelListViewExtender modelListView = View.Model as IModelListViewExtender;
            if(modelListView != null && modelListView.IsGroupFooterVisible) {
                GridListEditor gridListEditor = View.Editor as GridListEditor;
                if(gridListEditor != null) {
                    GridView gridView = gridListEditor.GridView;
                    for(int i = 0; i < gridView.GroupSummary.Count; i++) {
                        IModelColumnExtender modelColumn = View.Model.Columns[gridView.GroupSummary[i].FieldName] as IModelColumnExtender;
                        if(modelColumn != null) {
                            modelColumn.GroupFooterSummaryType = gridView.GroupSummary[i].SummaryType;
                        }
                    }
                }
            }
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            IModelListViewExtender modelListView = View.Model as IModelListViewExtender;
            if(modelListView != null && modelListView.IsGroupFooterVisible) {
                GridListEditor gridListEditor = View.Editor as GridListEditor;
                if(gridListEditor != null) {
                    GridView gridView = gridListEditor.GridView;
                    gridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                    foreach(IModelColumn modelColumn in View.Model.Columns) {
                        IModelColumnExtender modelColumnExtender = modelColumn as IModelColumnExtender;
                        if(modelColumnExtender != null && modelColumnExtender.GroupFooterSummaryType != SummaryItemType.None) {
                            GridColumn gridColumn = gridView.Columns[modelColumn.ModelMember.MemberInfo.BindingName];
                            gridView.GroupSummary.Add(modelColumnExtender.GroupFooterSummaryType, modelColumn.Id, gridColumn);
                        }
                    }
                }
            }
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.ModelSaved += View_InfoSynchronized;
        }
        protected override void OnDeactivated() {
            View.ModelSaved -= View_InfoSynchronized;
            base.OnDeactivated();
        }
    }
}
