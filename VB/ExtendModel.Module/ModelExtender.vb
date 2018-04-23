Imports Microsoft.VisualBasic
Imports DevExpress.Data
Imports System.ComponentModel

Namespace ExtendModel.Module
	Public Interface IModelListViewExtender
		Property IsGroupFooterVisible() As Boolean
	End Interface
	Public Interface IModelColumnExtender
		<DefaultValue(SummaryItemType.None)> _
		Property GroupFooterSummaryType() As SummaryItemType
	End Interface
End Namespace
