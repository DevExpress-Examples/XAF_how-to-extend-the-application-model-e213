using DevExpress.Data;
using System.ComponentModel;

namespace ExtendModel.Module {
    public interface IModelListViewExtender {
        bool IsGroupFooterVisible { get;set;}
    }
    public interface IModelColumnExtender {
        [DefaultValue(SummaryItemType.None)]
        SummaryItemType GroupFooterSummaryType { get;set;}
    }
}
