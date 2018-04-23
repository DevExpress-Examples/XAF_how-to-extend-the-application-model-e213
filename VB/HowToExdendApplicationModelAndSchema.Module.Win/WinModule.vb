Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.ComponentModel

Imports DevExpress.ExpressApp

<ToolboxItemFilter("Xaf.Platform.Win")> _
Partial Public NotInheritable Class [HowToExdendApplicationModelAndSchemaWindowsFormsModule]
	Inherits ModuleBase
	Public Sub New()
		InitializeComponent()
    End Sub
    Public Overrides Function GetSchema() As Schema
        Const CommonTypeInfos As String = _
           "<Element Name=""Application"">" + _
              "<Element Name=""Views"" >" + _
                 "<Element Name=""ListView"" >" + _
                    "<Attribute Name=""IsGroupFooterVisible"" Choice=""True,False""/>" + _
                      "<Element Name=""Columns"" >" + _
                         "<Element Name=""ColumnInfo"" >" + _
                            "<Attribute Name=""GroupFooterSummaryType"" Choice=""Sum,Min,Max,Count,Average,Custom,None"" />" + _
                         "</Element>" + _
                      "</Element>" + _
                   "</Element>" + _
              "</Element>" + _
           "</Element>"
        Return New Schema(New DictionaryXmlReader().ReadFromString(CommonTypeInfos))
    End Function
End Class

