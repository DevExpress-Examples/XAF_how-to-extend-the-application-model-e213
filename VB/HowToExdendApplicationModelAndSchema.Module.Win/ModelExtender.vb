Imports System
Imports System.ComponentModel
Imports DevExpress.Data

Public Interface IModelListViewExtender
    Property IsGroupFooterVisible() As Boolean
End Interface

Public Interface IModelColumnExtender
    <DefaultValue(SummaryItemType.None)> Property GroupFooterSummaryType() As SummaryItemType
End Interface