using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using System.Linq;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Game {

    static class Settings {

        static public int WindowHeight { get; } = 600;
        static public int WindowWidth { get; } = 800;

    }

    public partial class GameWindow : Window {

        // Game tick 
        DispatcherTimer GameTick = new DispatcherTimer();

        // Player Instances
        private double yPos = 0;
        private double xPos = 0;

        // Game Instances
        Rect blocksBounds;
        Rect playerBounds;
        Rectangle r = new Rectangle();
        Rectangle r1 = new Rectangle();

        bool objectHit = false;


        public GameWindow() {

            InitializeComponent();

            GameTick.Tick += gameTickUpdater;
            GameTick.Interval = new TimeSpan(0, 0, 0, 0, 20);
            string path = Environment.CurrentDirectory;

            startGame();

        }

        private void startGame() {


            Canvas.SetTop(Block, 200);
            Canvas.SetLeft(Block, 40);

            Canvas.SetTop(Player, (Settings.WindowHeight / 2) - Player.Height);
            Canvas.SetLeft(Player, (Settings.WindowWidth / 2) - Player.Width);
            yPos = Canvas.GetTop(Player);
            xPos = Canvas.GetLeft(Player);


         

          

            r.Width = Player.Width;
            r.Height = Player.Height;
            r.Stroke = Brushes.Black;
            r.StrokeThickness = 2;
           

            r1.Width = Block.Width;
            r1.Height = Block.Height;
            r1.Stroke = Brushes.Black;
            r1.StrokeThickness = 2;
            

            Scene.Children.Add(r);
            Scene.Children.Add(r1);


            GameTick.Start();

        }

        // Player movement

        private void Scene_KeyDown(object sender, KeyEventArgs e) {

            if (e.Key == Key.D) {
                Player.Action = ActionType.run;
 
                xPos += 4;
            }
            if (e.Key == Key.A) {
                Player.Action = ActionType.run;
                xPos -= 4;
            }
            if (e.Key == Key.W) {
                Player.Action = ActionType.jump;
                yPos -= 4;
            }
            if (e.Key == Key.S) {
                Player.Action = ActionType.crouch;
                yPos += 4;
            }


        }

        private void Scene_KeyUp(object sender, KeyEventArgs e) {

            Player.Action = ActionType.idle;

        }

        private void gameTickUpdater(object sender, EventArgs e) {

      
            playerBounds = new Rect(Canvas.GetLeft(Player) + 10, Canvas.GetTop(Player), Player.Width, Player.Height);
            blocksBounds = new Rect(Canvas.GetLeft(Block), Canvas.GetTop(Block), Block.Width, Player.Height);

            Canvas.SetLeft(r, Canvas.GetLeft(Player) + 10);
            Canvas.SetTop(r, Canvas.GetTop(Player));

            Canvas.SetLeft(r1, Canvas.GetLeft(Block));
            Canvas.SetTop(r1, Canvas.GetTop(Block));

            
            Canvas.SetTop(Player, yPos);

            foreach (var x in Scene.Children.OfType<Image>()) {

                if ((string)x.Tag == "Block") {


                    if (blocksBounds.IntersectsWith(playerBounds)) {
                        r.Stroke = Brushes.Red;
                        r1.Stroke = Brushes.Red;
                        objectHit = true;
                    } else {
                        r.Stroke = Brushes.Black;
                        r1.Stroke = Brushes.Black;
                        objectHit = false;
                    }

                }


            }

           

            Player.SetSource();
            Player.Frame += 1;
            Block.SetSource();
            Block.Frame = 0;



        }
     
    }
}
