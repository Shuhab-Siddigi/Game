using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Game {

    static class GlobalSettings {

        static public int WindowHeight { get; set; }
        static public int WindowWidth { get; set; }
        
        
    }

    public partial class GameWindow : Window {
        
        

        Player player = new Player(200,200,50,50);
        List<Block> Blocks = new List<Block>();
        List<Image> BlocksCollisionBoxs = new List<Image>();
         static double temp = 0;
        

        
        public GameWindow() {

            InitializeComponent();
 
            startGame();
        }

        private void startGame() {
           
            CompositionTarget.Rendering += OnUpdate;

            for(int i = 0; i < 19; i++) {
                Blocks.Add(new Block(0 + 50 * i, 525, 50, 50));
                Scene.Children.Add(Blocks[i]);
                Scene.Children.Add(Blocks[i].HitBoxRender);
            }
            
            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);

        }

        private void OnUpdate(object sender, EventArgs e) {
            // Update objects first then do stuff order matters!
            player.Update();

           
            for (int i = 0; i < Blocks.Count; i++) {
                temp = Canvas.GetLeft(Blocks[i]);
                 
                Blocks[i].Update();

                if (i % 2 == 0) {
                    Blocks[i].Type = BlockType.grey;
                } 
                if (player.HitBox.IntersectsWith(Blocks[i].HitBox)) {
                    player.HitBoxRender.Stroke = Brushes.Red;
                    Blocks[i].HitBoxRender.Stroke = Brushes.Red;
                    player.Y -= 1;
                } else {
                    player.Y += 0.02;
                }
               
                    //block.Opacity = 0.25;
                
                
            }

            
           






        }

    }
}
