using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using System.Linq;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Threading;

namespace Game {

    static class Settings {

        static public int WindowHeight { get; } = 600;
        static public int WindowWidth { get; } = 800;

    }

    public partial class GameWindow : Window {

        Player player = new Player();
        Block block = new Block();
        PlayerControls SetControls = new PlayerControls();
        Rectangle rectangle1 = new Rectangle();
        Rectangle rectangle2 = new Rectangle();
        Rect rect1 = new Rect();
        Rect rect2 = new Rect();

        public GameWindow() {

            InitializeComponent();
            startGame();
        }

        private void startGame() {
           
            CompositionTarget.Rendering += OnUpdate;
            Scene.Children.Add(player);
            Scene.Children.Add(block);
        }

        private void OnUpdate(object sender, EventArgs e) {

            SetControls.Movement(player);
            Canvas.SetLeft(block, 400);
            Canvas.SetTop(block, 330);
            block.SetSource();

            Bounds(player, block);


        }

        private void Bounds(Player player,Block block) {

            // Player 
            
            rectangle1.Width = player.Width/2;
            rectangle1.Height = player.Height;
            rectangle1.Stroke = Brushes.Black;

            if (!Scene.Children.Contains(rectangle1)) {
                Scene.Children.Add(rectangle1);
            }

            Canvas.SetLeft(rectangle1, Canvas.GetLeft(player)+(player.Width/2));
            Canvas.SetTop(rectangle1, Canvas.GetTop(player));

            rect1.Width = rectangle1.Width;
            rect1.Height = rectangle1.Height;
            rect1.X = Canvas.GetLeft(player) + (player.Width / 2);
            rect1.Y    = Canvas.GetTop(player);

            // block

            rectangle2.Width = block.Width;
            rectangle2.Height = block.Height;
            rectangle2.Stroke = Brushes.Black;

            if (!Scene.Children.Contains(rectangle2)) {
                Scene.Children.Add(rectangle2);
            }

            Canvas.SetLeft(rectangle2, Canvas.GetLeft(block));
            Canvas.SetTop(rectangle2, Canvas.GetTop(block));

            rect2.Width = rectangle2.Width;
            rect2.Height = rectangle2.Height;
            rect2.X = Canvas.GetLeft(block);
            rect2.Y = Canvas.GetTop(block);

            if (rect1.IntersectsWith(rect2)) {
                rectangle1.Stroke = Brushes.Red;
            }

        }



    }
}
