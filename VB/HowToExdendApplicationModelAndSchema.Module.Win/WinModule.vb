Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

<ToolboxItemFilter("Xaf.Platform.Win")> _
Partial Public NotInheritable Class [HowToExdendApplicationModelAndSchemaWindowsFormsModule]
	Inherits ModuleBase
	Public Sub New()
		InitializeComponent()
    End Sub

    Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
        MyBase.ExtendModelInterfaces(extenders)
        extenders.Add(Of IModelListView, IModelListViewExtender)()
        extenders.Add(Of IModelColumn, IModelColumnExtender)()
    End Sub
End Class

