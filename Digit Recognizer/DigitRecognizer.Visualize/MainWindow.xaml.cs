using System;
using System.Collections.Generic;
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
using DigitRecognizer.Core;

namespace DigitRecognizer.Visualize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Observation[] _training;
        private int _idx;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 28; i++)
            {
                digitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) });
            }

            for (int i = 0; i < 28; i++)
            {
                digitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10) });
            }

            _training = DataReader.ReadObservations(@"Data\validate.csv");
            _idx = 0;
            RenderGrid();
        }

        private void RenderGrid()
        {
            txtDigit.Text = _training[_idx].Label;

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    var pixelColor = (byte) (255 - (_training[_idx].Pixels[j + (i*28)]));
                    var rectangle = new Rectangle
                    {
                        Fill = new SolidColorBrush(Color.FromArgb(255, pixelColor, pixelColor, pixelColor))
                    };

                    digitGrid.Children.Add(rectangle);
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
