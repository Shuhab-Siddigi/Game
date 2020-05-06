using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;

namespace Game {

  

    public partial class GameWindow : Window {


        CollisionDetection collision = new CollisionDetection();
        Player player = new Player(200,100,50,50);
        List<Block> Blocks = new List<Block>();
        List<Image> BlocksCollisionBoxs = new List<Image>();

        
        

        
        public GameWindow() {

            InitializeComponent();
 
            startGame();
        }

        private void startGame() {

           
            CompositionTarget.Rendering += OnUpdate;


            for(int i = 0; i < 18; i++) {
                Blocks.Add(new Block(50 * i, 400, 50, 50));
                
            }
            
            for (int j = 0; j < 19/3; j++) {
                Blocks.Add(new Block(50 * j*3, 350, 50, 50));
            }
            

            foreach(Block block in Blocks) {
                Scene.Children.Add(block);
                Scene.Children.Add(block.HitBoxRender);
            }

            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);

        }

        private void OnUpdate(object sender, EventArgs e) {

           

            player.DefaultSettings();
           
        
            for (int i = 0; i < Blocks.Count; i++) {
                Blocks[i].DefaultSettings();
                collision.BlockCollision(player, Blocks[i]);
                Blocks[i].Opacity = 0.25;
            }
            for (int i = 0; i < Blocks.Count; i++) {
                Blocks[i].Update(player);
            }

            player.Update();

        }
     

       
    }
}
