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
        Player player = new Player(10,100,50,50);
        List<Block> VerticalBlocks = new List<Block>();
        List<Block> HorizontalBlocks = new List<Block>();
        List<Image> BlocksCollisionBoxs = new List<Image>();
       
        // Create side rects

        public GameWindow() {

            InitializeComponent();
 
            startGame();
        }

        private void startGame() {

           
            CompositionTarget.Rendering += OnUpdate;
            Scene.Width = GlobalSettings.ScreenWidth;
            Scene.Height = GlobalSettings.ScreenHeight;
            Window.Width = GlobalSettings.ScreenWidth-4;
            Window.Height = GlobalSettings.ScreenHeight-1;


            for(int i = 0; i < (GlobalSettings.ScreenWidth/20); i++) { 
                VerticalBlocks.Add(new Block(Block.blocksize * i,0));
                VerticalBlocks.Add(new Block(Block.blocksize * i, GlobalSettings.ScreenHeight-60));
                // Blocks.Add(new Block(Block.blocksize * i, GlobalSettings.ScreenWidth));
            }
            for (int i = 0; i < (GlobalSettings.ScreenHeight / 20) + 1; i++) {
                HorizontalBlocks.Add(new Block(0, Block.blocksize * i));
                HorizontalBlocks.Add(new Block(GlobalSettings.ScreenWidth-40, Block.blocksize * i));

            }


            foreach (Block block in HorizontalBlocks) {
                Scene.Children.Add(block);
                Scene.Children.Add(block.HitBoxRender);
            }
            foreach (Block block in VerticalBlocks) {
                Scene.Children.Add(block);
                Scene.Children.Add(block.HitBoxRender);
            }

            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);

        }

        private void OnUpdate(object sender, EventArgs e) {

           

            player.DefaultSettings();
           
        
            for (int i = 0; i < VerticalBlocks.Count; i++) {
                VerticalBlocks[i].DefaultSettings();
                collision.BlockCollision(player, VerticalBlocks[i]);
                VerticalBlocks[i].Opacity = 0.25;
            }
            for (int i = 0; i < VerticalBlocks.Count; i++) {
                VerticalBlocks[i].Update(player);
            }
            for (int i = 0; i < HorizontalBlocks.Count; i++) {
                HorizontalBlocks[i].DefaultSettings();
                collision.BlockCollision(player, HorizontalBlocks[i]);
                HorizontalBlocks[i].Opacity = 0.25;
            }
            for (int i = 0; i < HorizontalBlocks.Count; i++) {
                HorizontalBlocks[i].Update(player);
            }

            player.Update();

        }
     

       
    }
}
