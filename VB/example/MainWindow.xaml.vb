Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Editors
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace example
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class


	Public Class Helper

        Public Shared ReadOnly MaxLinesProperty As DependencyProperty = DependencyProperty.RegisterAttached("MaxLines", GetType(Integer), GetType(Helper), New FrameworkPropertyMetadata(AddressOf MaxLinesPropertyChanged))
		Public Shared Sub SetMaxLines(ByVal element As UIElement, ByVal value As Integer)
			element.SetValue(MaxLinesProperty, value)
		End Sub
		Public Shared Function GetMaxLines(ByVal element As UIElement) As Integer
			Return CInt(Fix(element.GetValue(MaxLinesProperty)))
		End Function

		Private Shared Sub MaxLinesPropertyChanged(ByVal source As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			AddHandler (CType(source, TextEdit)).Loaded, AddressOf Helper_Loaded
		End Sub

		Private Shared Sub Helper_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim editor As TextEdit = TryCast(sender, TextEdit)
			CType(editor.EditCore, TextBox).MaxLines = CInt(Fix(editor.GetValue(Helper.MaxLinesProperty)))
		End Sub

	End Class
End Namespace
