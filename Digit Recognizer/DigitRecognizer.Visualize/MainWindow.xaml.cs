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

namespace DigitRecognizer.Visualize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var loadData = "9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,48,143,186,244,143,31,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,83,209,253,252,252,252,252,192,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,166,241,252,253,252,170,162,252,252,113,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,61,234,252,252,243,121,44,2,21,245,252,122,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,252,252,243,163,50,0,0,0,5,101,88,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,105,234,252,210,88,0,0,0,0,74,199,240,43,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,185,252,210,21,0,4,12,41,231,249,252,252,55,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,242,252,218,154,154,184,252,253,252,252,248,184,22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,209,252,252,252,252,252,252,253,252,252,196,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,57,142,95,142,61,81,253,252,209,20,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,177,255,230,86,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,12,124,252,245,57,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,135,252,252,86,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,79,248,252,233,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,231,252,202,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,20,175,248,252,136,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,109,252,252,159,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,33,218,252,252,192,141,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,132,252,252,252,205,74,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,132,252,252,146,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            var commaSeparated = loadData.Split(',');


            var pixels =
                commaSeparated
                    .Skip(1)
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

            txtDigit.Text = commaSeparated[0].ToString();

            for (int i = 0; i < 28; i++)
            {
                digitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10) });
            }

            for (int i = 0; i < 28; i++)
            {
                digitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10) });
            }

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    var pixelColor = (byte)(255 - (pixels[j + (i * 28)]));
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
    }
}
