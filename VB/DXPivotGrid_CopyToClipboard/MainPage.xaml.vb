Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Windows.Controls
Imports System.Xml.Serialization
Imports DevExpress.Xpf.Bars

Namespace DXPivotGrid_CopyToClipboard
	Partial Public Class MainPage
		Inherits UserControl
		Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
			Dim [assembly] As System.Reflection.Assembly = _
				System.Reflection.Assembly.GetExecutingAssembly()
			Dim stream As Stream = [assembly].GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource
		End Sub
		Private Sub itemCopyToClipboard_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			pivotGridControl1.CopySelectionToClipboard()
		End Sub
		Private Sub PopupMenu_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)
			If pivotGridControl1.Selection.IsEmpty Then
				e.Cancel = True
			End If
		End Sub
	End Class
End Namespace
