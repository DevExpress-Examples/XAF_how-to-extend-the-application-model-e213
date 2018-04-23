Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Namespace ExtendModel.Module
	Public NotInheritable Partial Class ExtendModelModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of IModelListView, IModelListViewExtender)()
			extenders.Add(Of IModelColumn, IModelColumnExtender)()
		End Sub
	End Class
End Namespace
