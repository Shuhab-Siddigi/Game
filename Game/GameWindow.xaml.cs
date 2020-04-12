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

        public GameWindow() {

            InitializeComponent();
            startGame();
        }

        private void startGame() {
           
            CompositionTarget.Rendering += OnUpdate;
            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);
            Scene.Children.Add(block);
            Scene.Children.Add(block.HitBoxRender);
        }

        private void OnUpdate(object sender, EventArgs e) {

            SetControls.Movement(player);
            Canvas.SetLeft(block, 400);
            Canvas.SetTop(block, 330);
            
            block.SetSource();
            player.Collision();
            player.CollisionBoxRender();
            block.Collision();
            block.CollisionBoxRender();
            

            if (player.HitBox.IntersectsWith(block.HitBox)) {
                player.HitBoxRender.Stroke = Brushes.Red;
            }

        }

   



    }
}
