Imports DevExpress.Xpf.Editors
Imports System.Windows
Imports System.Windows.Controls

Namespace example

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class Helper

        Public Shared ReadOnly MaxLinesProperty As DependencyProperty = DependencyProperty.RegisterAttached("MaxLines", GetType(Integer), GetType(Helper), New FrameworkPropertyMetadata(AddressOf MaxLinesPropertyChanged))

        Public Shared Sub SetMaxLines(ByVal element As UIElement, ByVal value As Integer)
            element.SetValue(MaxLinesProperty, value)
        End Sub

        Public Shared Function GetMaxLines(ByVal element As UIElement) As Integer
            Return CInt(element.GetValue(MaxLinesProperty))
        End Function

        Private Shared Sub MaxLinesPropertyChanged(ByVal source As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            AddHandler CType(source, TextEdit).Loaded, AddressOf Helper_Loaded
        End Sub

        Private Shared Sub Helper_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim editor As TextEdit = TryCast(sender, TextEdit)
            CType(editor.EditCore, TextBox).MaxLines = CInt(editor.GetValue(MaxLinesProperty))
        End Sub
    End Class
End Namespace
