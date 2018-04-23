Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace ExtendModel.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As ObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim person1 As Person = ObjectSpace.FindObject(Of Person)(CriteriaOperator.Parse("LastName == 'Devon'"))
			If person1 Is Nothing Then
				person1 = ObjectSpace.CreateObject(Of Person)()
				person1.FirstName = "Ann"
				person1.LastName = "Devon"
				person1.Birthday = New DateTime(1986, 7, 15)
				person1.Save()
			End If
			Dim person2 As Person = ObjectSpace.FindObject(Of Person)(CriteriaOperator.Parse("LastName == 'Clarks'"))
			If person2 Is Nothing Then
				person2 = ObjectSpace.CreateObject(Of Person)()
				person2.FirstName = "Ann"
				person2.LastName = "Clarks"
				person2.Birthday = New DateTime(1980, 6, 30)
				person2.Save()
			End If
			Dim person3 As Person = ObjectSpace.FindObject(Of Person)(CriteriaOperator.Parse("LastName == 'Tellitson'"))
			If person3 Is Nothing Then
				person3 = ObjectSpace.CreateObject(Of Person)()
				person3.FirstName = "Mary"
				person3.LastName = "Tellitson"
				person3.Birthday = New DateTime(1983, 9, 16)
				person3.Save()
			End If
		End Sub
	End Class
End Namespace
