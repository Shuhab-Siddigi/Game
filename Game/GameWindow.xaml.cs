using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game {

    static class GlobalSettings {

        static public int WindowHeight { get; } = 1920;
        static public int WindowWidth { get; } = 1080;
        

    }

    public partial class GameWindow : Window {

       
        
        Player player = new Player(200,200,50,50);
        Block block = new Block(100,500,50,50);
        Block block1 = new Block(300, 500,50,50);

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
            Scene.Children.Add(block1);
            Scene.Children.Add(block1.HitBoxRender);

        }

        private void OnUpdate(object sender, EventArgs e) {

            
            player.Update();
            block.Update();
            block1.Update();
            

            if (player.HitBox.IntersectsWith(block.HitBox)) {
                player.HitBoxRender.Stroke = Brushes.Red;
            }
            if (player.HitBox.IntersectsWith(block1.HitBox)) {
                player.HitBoxRender.Stroke = Brushes.Red;
            }

        }

    }
}
