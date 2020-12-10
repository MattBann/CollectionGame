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
using CollectionGameLibrary;

namespace CollectionGameInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameboardClass Gameboard;

        private static Dictionary<int,Color> TileColour = new Dictionary<int,Color> ()
        {
            {2,Colors.Beige},
            {4,Colors.Wheat},
            {8,Colors.BurlyWood},
            {16,Colors.DarkKhaki},
            {32,Colors.DarkGoldenrod},
            {64,Colors.Chocolate},
            {128,Colors.Goldenrod},
            {256,Colors.DarkOrange},
            {512,Colors.Gold},
            {1024,Colors.GreenYellow},
            {2048,Colors.Green}
        };
        
        public MainWindow()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(GameboardKeyDown);

            Gameboard = new GameboardClass();
            Gameboard.Active = true;
        }

        public void UpdateBoard()
        {
            if (!Gameboard.Active)
            {
                //End game
                TestLabel.Content = "Fail";
            }

            else
            {
                GameGrid.Children.Clear();
                foreach (Tile tile in Gameboard.Grid)
                {
                    TextBox gridTile = new TextBox() {Background = new SolidColorBrush(TileColour[tile.value]) , TextAlignment = TextAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center};
                    gridTile.Text = tile.value.ToString();
                    gridTile.Foreground = new SolidColorBrush(Colors.Black);
                    gridTile.FontSize = 20;
                    Grid.SetColumn(gridTile,tile.x);
                    Grid.SetRow(gridTile,tile.y);
                    GameGrid.Children.Add(gridTile);
                    
                }
            }
        }

        private void GameboardKeyDown(object sender, KeyEventArgs e)
        {

            TestLabel.Content = e.Key.ToString();
            switch (e.Key)
            {

                case Key.Left:
                case Key.A:
                    Gameboard.MoveLeft();
                    break;
                case Key.Down:
                case Key.S:
                    Gameboard.MoveDown();
                    break;
                case Key.Right:
                case Key.D:
                    Gameboard.MoveRight();
                    break;
                case Key.Up:
                case Key.W:
                    Gameboard.MoveUp();
                    break;
            }

            UpdateBoard();
        }
    }
}
