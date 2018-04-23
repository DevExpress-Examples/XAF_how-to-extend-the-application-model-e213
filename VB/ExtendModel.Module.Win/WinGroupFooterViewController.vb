Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Data
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Namespace ExtendModel.Module.Win
	Public Class WinGroupFooterViewController
		Inherits ViewController(Of ListView)
		Private Sub View_InfoSynchronized(ByVal sender As Object, ByVal e As EventArgs)
			Dim modelListView As IModelListViewExtender = TryCast(View.Model, IModelListViewExtender)
			If modelListView IsNot Nothing AndAlso modelListView.IsGroupFooterVisible Then
				Dim gridListEditor As GridListEditor = TryCast(View.Editor, GridListEditor)
				If gridListEditor IsNot Nothing Then
					Dim gridView As GridView = gridListEditor.GridView
					For i As Integer = 0 To gridView.GroupSummary.Count - 1
                        Dim modelColumn As IModelColumnExtender = TryCast(CType(View.Model.Columns, IModelList(of IModelColumn))(gridView.GroupSummary(i).FieldName), IModelColumnExtender)
						If modelColumn IsNot Nothing Then
							modelColumn.GroupFooterSummaryType = gridView.GroupSummary(i).SummaryType
						End If
					Next i
				End If
			End If
		End Sub
		Protected Overrides Overloads Sub OnViewControlsCreated()
			MyBase.OnViewControlsCreated()
			Dim modelListView As IModelListViewExtender = TryCast(View.Model, IModelListViewExtender)
			If modelListView IsNot Nothing AndAlso modelListView.IsGroupFooterVisible Then
				Dim gridListEditor As GridListEditor = TryCast(View.Editor, GridListEditor)
				If gridListEditor IsNot Nothing Then
					Dim gridView As GridView = gridListEditor.GridView
					gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
					For Each modelColumn As IModelColumn In View.Model.Columns
						Dim modelColumnExtender As IModelColumnExtender = TryCast(modelColumn, IModelColumnExtender)
						If modelColumnExtender IsNot Nothing AndAlso modelColumnExtender.GroupFooterSummaryType <> SummaryItemType.None Then
							Dim gridColumn As GridColumn = gridView.Columns(modelColumn.ModelMember.MemberInfo.BindingName)
							gridView.GroupSummary.Add(modelColumnExtender.GroupFooterSummaryType, modelColumn.Id, gridColumn)
						End If
					Next modelColumn
				End If
			End If
		End Sub
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			AddHandler View.ModelSaved, AddressOf View_InfoSynchronized
		End Sub
		Protected Overrides Overloads Sub OnDeactivated()
			RemoveHandler View.ModelSaved, AddressOf View_InfoSynchronized
			MyBase.OnDeactivated()
		End Sub
	End Class
End Namespace
