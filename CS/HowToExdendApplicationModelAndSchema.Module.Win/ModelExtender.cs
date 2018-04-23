using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Data;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;

namespace HowToExdendApplicationModelAndSchema.Module.Win {
    public interface IModelListViewExtender {
        bool IsGroupFooterVisible { get;set;}
    }

    public interface IModelColumnExtender {
        [DefaultValue(SummaryItemType.None)]
        SummaryItemType GroupFooterSummaryType { get;set;}
    }
}
