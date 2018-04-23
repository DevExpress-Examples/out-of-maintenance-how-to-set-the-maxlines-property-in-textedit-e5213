using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }


    public class Helper
    {

        public static readonly DependencyProperty MaxLinesProperty = DependencyProperty.RegisterAttached("MaxLines", typeof(int), typeof(Helper), new FrameworkPropertyMetadata(MaxLinesPropertyChanged));
        public static void SetMaxLines(UIElement element, int value)
        {
            element.SetValue(MaxLinesProperty, value);
        }
        public static int GetMaxLines(UIElement element)
        {
            return (int)element.GetValue(MaxLinesProperty);
        }

        private static void MaxLinesPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((TextEdit)source).Loaded += Helper_Loaded;
        }

        static void Helper_Loaded(object sender, RoutedEventArgs e)
        {
            TextEdit editor = sender as TextEdit;
            ((TextBox)editor.EditCore).MaxLines = (int)editor.GetValue(Helper.MaxLinesProperty);
        }

    }
}
