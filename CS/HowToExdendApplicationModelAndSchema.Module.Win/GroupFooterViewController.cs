using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.ExpressApp.Model;


namespace HowToExdendApplicationModelAndSchema.Module.Win
{
    public partial class GroupFooterViewController : ViewController{
        public GroupFooterViewController(){
            InitializeComponent();
            RegisterActions(components);
        }
        private void GroupFooterViewController_Activated(object sender, EventArgs e){
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
            View.InfoSynchronized += new EventHandler(View_InfoSynchronized);
        }
        private void View_InfoSynchronized(object sender, EventArgs e){
            ListView lv = View as ListView;
            if (lv != null){
                IModelListViewExtender modelListView = lv.Model as IModelListViewExtender;
                if(modelListView != null && modelListView.IsGroupFooterVisible) {
                    //Access the current List View's Grid List Editor
                    //if the IsGroupFooterVisible attribute is set to true for the current List View
                    GridListEditor le = lv.Editor as GridListEditor;
                    if (le != null){
                        //Access the Grid List Editor's current Grid View
                        GridView gridView = le.GridView;
                        for (int i = 0; i < gridView.GroupSummary.Count; i++){
                            IModelColumnExtender modelColumn = lv.Model.Columns[gridView.GroupSummary[i].FieldName] as IModelColumnExtender;
                            if(modelColumn != null)
                                //Set the currently set summary type for the GroupFooterSummaryType attribute of the corresponding column
                                modelColumn.GroupFooterSummaryType = gridView.GroupSummary[i].SummaryType;
                        }
                    }
                }
            }
        }
        private void View_ControlsCreated(object sender, EventArgs e){
            ListView lv = View as ListView;
            if (lv != null) {
                IModelListViewExtender modelListView = lv.Model as IModelListViewExtender;
                if(modelListView != null && modelListView.IsGroupFooterVisible) {
                    //Access the current List View's Grid List Editor
                    //if the IsGroupFooterVisible attribute is set to true for the current List View
                    GridListEditor le = lv.Editor as GridListEditor;
                    if (le != null){
                        //Access the Grid List Editor's current Grid View
                        GridView gridView = le.GridView;
                        //Set the groop footer visible
                        gridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                        foreach(IModelColumn modelColumn in lv.Model.Columns) {
                            IModelColumnExtender modelColumnExtender = modelColumn as IModelColumnExtender;
                            if(modelColumnExtender != null) {
                                GridColumn gridColumn = gridView.Columns[modelColumn.ModelMember.MemberInfo.BindingName];
                                gridView.GroupSummary.Add(modelColumnExtender.GroupFooterSummaryType, modelColumn.Id, gridColumn);
                            }
                        }
                    }
                }
            }
        }
    }
}
