Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Public Class GroupFooterViewController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

	End Sub

    Private Sub GroupFooterViewController_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
        AddHandler View.InfoSynchronized, AddressOf View_InfoSynchronized
    End Sub
    Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = TryCast(View, ListView)
        If Not lv Is Nothing Then
            If View.Info.GetAttributeBoolValue("IsGroupFooterVisible") Then
                'Access the current List View's Grid List Editor
                'if the IsGroupFooterVisible attribute is set to true for the current List View
                Dim le As GridListEditor = TryCast(lv.Editor, GridListEditor)
                If Not le Is Nothing Then
                    'Access the Grid List Editor's current Grid View
                    Dim gridView As GridView = le.GridView
                    'Set the groop footer visible
                    gridView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
                    Dim node As DictionaryNode = lv.Info.GetChildNode("Columns")
                    Dim i As Integer = 0
                    Do While i < node.ChildNodeCount
                        'Get the GroupFooterSummaryType attribute value of the current List View
                        Dim typeName As String = node.ChildNodes(i).GetAttributeValue("GroupFooterSummaryType")
                        If typeName <> String.Empty Then
                            'Get the SummaryItem type that corresponds to the value set to the GroupFooterSummaryType attribute
                            Dim TypeToReflect As DevExpress.Data.SummaryItemType = Me.GetSummaryType(typeName)
                            Dim columnName As String = node.ChildNodes(i).GetAttributeValue("PropertyName")
                            Dim gridColumn As GridColumn = gridView.Columns(columnName)
                            'Set the required summary type for the current grid column
                            gridView.GroupSummary.Add(TypeToReflect, columnName, gridColumn)
                        End If
                        i += 1
                    Loop
                End If
            End If
        End If
    End Sub
    Private Function GetSummaryType(ByVal typeName As String) As DevExpress.Data.SummaryItemType
        Select Case typeName
            Case "Average"
                Return DevExpress.Data.SummaryItemType.Average
            Case "Count"
                Return DevExpress.Data.SummaryItemType.Count
            Case "Custom"
                Return DevExpress.Data.SummaryItemType.Custom
            Case "Max"
                Return DevExpress.Data.SummaryItemType.Max
            Case "Min"
                Return DevExpress.Data.SummaryItemType.Min
            Case "None"
                Return DevExpress.Data.SummaryItemType.None
            Case "Sum"
                Return DevExpress.Data.SummaryItemType.Sum
            Case Else
                Return DevExpress.Data.SummaryItemType.None
        End Select
    End Function
    Private Sub View_InfoSynchronized(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = TryCast(View, ListView)
        If Not lv Is Nothing Then
            If Application.Info.FindChildNode("Views").FindChildNode(lv.Info).GetAttributeBoolValue("IsGroupFooterVisible") Then
                'Access the current List View's Grid List Editor
                'if the IsGroupFooterVisible attribute is set to true for the current List View
                Dim le As GridListEditor = TryCast(lv.Editor, GridListEditor)
                If Not le Is Nothing Then
                    'Access the Grid List Editor's current Grid View
                    Dim gridView As GridView = le.GridView
                    Dim i As Integer = 0
                    Do While i < gridView.GroupSummary.Count
                        Dim node As DictionaryNode = lv.Info.GetChildNode("Columns").FindChildNode("ColumnInfo", "PropertyName", gridView.GroupSummary(i).FieldName)
                        If Not node Is Nothing Then
                            'Set the currently set summary type for the GroupFooterSummaryType attribute of the corresponding column
                            node.SetAttribute("GroupFooterSummaryType", gridView.GroupSummary(i).SummaryType.ToString())
                        End If
                        i += 1
                    Loop
                End If
            End If
        End If
    End Sub
End Class
