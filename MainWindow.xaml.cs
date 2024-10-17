using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double brushSize = 5;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ColorBrush_(object sender, SelectionChangedEventArgs e)
        {
            if (ColorBrush.SelectedItem != null)
            {
                DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString((string)((ComboBoxItem)ColorBrush.SelectedItem).Tag);
            }
        }

        private void BrushSize_(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            brushSize = e.NewValue;
            if (DrawingAttributes != null)
            {
                DrawingAttributes.Height = brushSize;
                DrawingAttributes.Width = brushSize;
            }
        }

        private void SetDrawingMode(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (Canvas != null)
            {
                if (DrawRadioButton.IsChecked == true)
                {
                    Canvas.EditingMode = InkCanvasEditingMode.Ink;
                }
                else if (EditRadioButton.IsChecked == true)
                {
                    Canvas.EditingMode = InkCanvasEditingMode.Select;
                }
                else if (EraseRadioButton.IsChecked == true)
                {
                    Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                }
            }

        }
    }
}