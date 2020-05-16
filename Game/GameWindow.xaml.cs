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


        Slime slime = new Slime(500,550,25,25);
        Player player = new Player(10,450,50,50);
        Wall TopWall = new Wall(Block.blocksize*0, Block.blocksize*0, 39, 1);
        Wall BottomWall = new Wall(Block.blocksize * 0, Block.blocksize * 29, 39, 1);
        Wall LeftWall = new Wall(Block.blocksize * 0, Block.blocksize * 0, 1, 30);
        Wall RightWall = new Wall(Block.blocksize * 38, Block.blocksize * 0, 1, 30);


        Wall MidWall1 = new Wall(Block.blocksize * 10, Block.blocksize * 25, 5, 1);
        Wall MidWall2 = new Wall(Block.blocksize * 28, Block.blocksize * 27, 5, 1);
        Wall MidWall3 = new Wall(Block.blocksize * 2, Block.blocksize * 22, 5, 1);
        Wall MidWall4 = new Wall(Block.blocksize * 14, Block.blocksize * 19, 5, 1);
        Wall MidWall5 = new Wall(Block.blocksize * 20, Block.blocksize * 23, 5, 1);


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
           
            AddPlayer(player);
            AddWall(TopWall);
            AddWall(BottomWall);
            AddWall(LeftWall);
            AddWall(RightWall);
            AddWall(MidWall1);
            AddWall(MidWall2);
            AddWall(MidWall3);
            AddWall(MidWall4);
            AddWall(MidWall5);

            AddSlime(slime);
            
        }

        private void OnUpdate(object sender, EventArgs e) {

            Input.Update();
            
            // Default settings
            slime.DefaultSettings();
            player.DefaultSettings(); 

            // Update Settings

            TopWall.Update(player,slime);
            BottomWall.Update(player, slime);  
            LeftWall.Update(player, slime);       
            RightWall.Update(player, slime);
            MidWall1.Update(player, slime);
            MidWall2.Update(player, slime);
            MidWall3.Update(player, slime);
            MidWall4.Update(player, slime);
            MidWall5.Update(player, slime);
            player.Update();
            slime.Update();

        }

        private void AddWall(Wall wall) {
           
            foreach (Block block in wall) {
                Scene.Children.Add(block);
            }
            Scene.Children.Add(wall.HitBoxRender);
        }

        private void AddPlayer(Player player) {
            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);
        }

        private void AddBlock(Block block) {
            Scene.Children.Add(block);
            Scene.Children.Add(block.HitBoxRender);
        }

        private void AddSlime(Slime slime) {
            Scene.Children.Add(slime);
            Scene.Children.Add(slime.HitBoxRender);
        }

       
    }
}
