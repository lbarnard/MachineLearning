using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitRecognizer.Core;

namespace DigitRecognizer.Visualize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Observation[] _training;
        private int _idx;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 28; i++)
            {
                DigitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) });
            }

            for (int i = 0; i < 28; i++)
            {
                DigitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10) });
            }

            _training = DataReader.ReadObservations(@"Data\validate.csv");
            _idx = 0;
            RenderGrid();
        }

        private void RenderGrid()
        {
            TxtDigit.Text = _training[_idx].Label;

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    var pixelColor = (byte) (255 - (_training[_idx].Pixels[j + (i*28)]));
                    var rectangle = new Rectangle
                    {
                        Fill = new SolidColorBrush(Color.FromArgb(255, pixelColor, pixelColor, pixelColor))
                    };

                    DigitGrid.Children.Add(rectangle);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                }
            }
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            if ((_idx+1) < _training.Count())
                _idx++;

            RenderGrid();
        }

        private void BtnPrevious_OnClick(object sender, RoutedEventArgs e)
        {
            if (_idx-- > 0)
                _idx--;

            RenderGrid();
        }
    }
}
