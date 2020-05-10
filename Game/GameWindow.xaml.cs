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
using Game.Game_Object_Classes;

namespace Game {

    

    public partial class GameWindow : Window {
       
        CollisionDetection collision = new CollisionDetection();
        Player player = new Player(10,450,50,50);
        Wall TopWall = new Wall(Block.blocksize*0, Block.blocksize*0, 39, 1);
        Wall BottomWall = new Wall(Block.blocksize * 0, Block.blocksize * 29, 39, 1);
        Wall LeftWall = new Wall(Block.blocksize * 0, Block.blocksize * 0, 1, 30);
        Wall RightWall = new Wall(Block.blocksize * 38, Block.blocksize * 0, 1, 30);
       

       


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
            
            // Add objects to the screen
            
            
            foreach (Block block in TopWall) {
                Scene.Children.Add(block);
            }
                       
            foreach (Block block in BottomWall) {
                Scene.Children.Add(block);
            }
            
            foreach (Block block in LeftWall) {
                Scene.Children.Add(block);
            }
            
            foreach (Block block in RightWall) {
                Scene.Children.Add(block);
            }


            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);
            Scene.Children.Add(TopWall.HitBoxRender);
            Scene.Children.Add(BottomWall.HitBoxRender);
            Scene.Children.Add(LeftWall.HitBoxRender);
            Scene.Children.Add(RightWall.HitBoxRender);

        }

        private void OnUpdate(object sender, EventArgs e) {

            

            Input.Update();
            player.DefaultSettings(); 
            TopWall.Update(player);
            BottomWall.Update(player);  
            LeftWall.Update(player);       
            RightWall.Update(player);
            player.Update();


        }



    }
}
