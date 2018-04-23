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
                if (Application.Info.FindChildNode("Views").FindChildNode(lv.Info).GetAttributeBoolValue("IsGroupFooterVisible")){
                    //Access the current List View's Grid List Editor
                    //if the IsGroupFooterVisible attribute is set to true for the current List View
                    GridListEditor le = lv.Editor as GridListEditor;
                    if (le != null){
                        //Access the Grid List Editor's current Grid View
                        GridView gridView = le.GridView;
                        for (int i = 0; i < gridView.GroupSummary.Count; i++){
                            DictionaryNode node = lv.Info.GetChildNode("Columns").FindChildNode("ColumnInfo", "PropertyName", gridView.GroupSummary[i].FieldName);
                            if (node != null)
                                //Set the currently set summary type for the GroupFooterSummaryType attribute of the corresponding column
                                node.SetAttribute("GroupFooterSummaryType", gridView.GroupSummary[i].SummaryType.ToString());
                        }
                    }
                }
            }
        }
        private void View_ControlsCreated(object sender, EventArgs e){
            ListView lv = View as ListView;
            if (lv != null) {
                if (View.Info.GetAttributeBoolValue("IsGroupFooterVisible")){
                    //Access the current List View's Grid List Editor
                    //if the IsGroupFooterVisible attribute is set to true for the current List View
                    GridListEditor le = lv.Editor as GridListEditor;
                    if (le != null){
                        //Access the Grid List Editor's current Grid View
                        GridView gridView = le.GridView;
                        //Set the groop footer visible
                        gridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                        DictionaryNode node = lv.Info.GetChildNode("Columns");
                        for (int i = 0; i < node.ChildNodeCount; i++){
                            //Get the GroupFooterSummaryType attribute value of the current List View
                            string typeName = node.ChildNodes[i].GetAttributeValue("GroupFooterSummaryType");
                            if (typeName != String.Empty){
                                //Get the SummaryItem type that corresponds to the value set to the GroupFooterSummaryType attribute
                                DevExpress.Data.SummaryItemType TypeToReflect = this.GetSummaryType(typeName);
                                string columnName = node.ChildNodes[i].GetAttributeValue("PropertyName");
                                GridColumn gridColumn = gridView.Columns[columnName];
                                //Set the required summary type for the current grid column
                                gridView.GroupSummary.Add(TypeToReflect, columnName, gridColumn);
                            }
                        }
                    }
                }
            }
        }

        private DevExpress.Data.SummaryItemType GetSummaryType(string typeName){
            switch (typeName){
                case "Average":
                    return DevExpress.Data.SummaryItemType.Average;
                case "Count":
                    return DevExpress.Data.SummaryItemType.Count;
                case "Custom":
                    return DevExpress.Data.SummaryItemType.Custom;
                case "Max":
                    return DevExpress.Data.SummaryItemType.Max;
                case "Min":
                    return DevExpress.Data.SummaryItemType.Min;
                case "None":
                    return DevExpress.Data.SummaryItemType.None;
                case "Sum":
                    return DevExpress.Data.SummaryItemType.Sum;
                default:
                    return DevExpress.Data.SummaryItemType.None;
            }
        }
    }
}
