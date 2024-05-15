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

namespace VillagePlacementApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int[,] mapData = GenerateMapData();

            List<Point> villageLocations = FindVillageLocations(mapData);

            foreach (Point location in villageLocations)
            {
                Shape marker;

                if (mapData[(int)location.X, (int)location.Y] == 2) 
                {
                    marker = new Ellipse
                    {
                        Width = 15,
                        Height = 15,
                        Fill = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\Azerty\\Downloads\\village.png")))
                    };
                }
                else
                {
                    marker = new Ellipse
                    {
                        Width = 10,
                        Height = 10,
                        Fill = Brushes.Green,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1
                    };
                }

                Canvas.SetLeft(marker, location.X * 20);
                Canvas.SetTop(marker, location.Y * 20);

                canvas.Children.Add(marker);
            }
        }

        private int[,] GenerateMapData()
        {
            Random random = new Random();
            int[,] map = new int[20, 20]; 

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = (random.Next(100) < 10) ? 2 : 1;
                }
            }

            return map;
        }
        private List<Point> FindVillageLocations(int[,] map)
        {
            List<Point> villageLocations = new List<Point>();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2)
                    {
                        villageLocations.Add(new Point(i, j));
                    }
                }
            }

            return villageLocations;
        }
    }
}

