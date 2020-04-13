using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Game {

    static class GlobalSettings {

        //static public int WindowHeight { get; } = 1920;
        //static public int WindowWidth { get; } = 1080;
        

    }

    public partial class GameWindow : Window {

        Player player = new Player(200,200,50,50);
        List<Image> Blocks = new List<Image>();
        List<Image> BlocksCollisionBoxs = new List<Image>();
        Block block1 = new Block(100, 200, 50, 50);
        public GameWindow() {

            InitializeComponent();
            startGame();
        }

        private void startGame() {
           
            CompositionTarget.Rendering += OnUpdate;

            for(int i = 0; i < 10; i++) {
                Blocks.Add(new Block(0 + 50 * i, 500, 50, 50));
                Scene.Children.Add(Blocks[i]);
            }
            foreach(Block block in Blocks) {
                Scene.Children.Add(block.HitBoxRender);
            }
            Scene.Children.Add(block1);
            Scene.Children.Add(block1.HitBoxRender);
            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);
           
            
        }

        private void OnUpdate(object sender, EventArgs e) {
            // Update objects first then do stuff order matters!
            player.Update();
            block1.Update();

            foreach (Block block in Blocks) {
                block.Update();
                if (player.HitBox.IntersectsWith(block.HitBox)) {
                    block.HitBoxRender.Stroke = Brushes.Red;
                }
            }
            
           




        }

    }
}
