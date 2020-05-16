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


        Slime slime = new Slime(100,150,50,50);
        Player player = new Player(10,450,50,50);
        Wall TopWall = new Wall(Block.blocksize*0, Block.blocksize*0, 39, 1);
        Wall BottomWall = new Wall(Block.blocksize * 0, Block.blocksize * 29, 39, 1);
        Wall LeftWall = new Wall(Block.blocksize * 0, Block.blocksize * 0, 1, 30);
        Wall RightWall = new Wall(Block.blocksize * 38, Block.blocksize * 0, 1, 30);


        Wall MidWall1 = new Wall(Block.blocksize * 3, Block.blocksize * 26, 6, 1);
        Wall MidWall2 = new Wall(Block.blocksize * 23, Block.blocksize * 20, 1, 5);
        Wall MidWall3 = new Wall(Block.blocksize * 12, Block.blocksize * 26, 6, 1);
        Wall MidWall4 = new Wall(Block.blocksize * 9, Block.blocksize * 23, 6, 1);
        Wall MidWall5 = new Wall(Block.blocksize * 20, Block.blocksize * 26, 6, 1);
        Wall MidWall6 = new Wall(Block.blocksize * 17, Block.blocksize * 23, 6, 1);
        Wall MidWall7 = new Wall(Block.blocksize * 1, Block.blocksize * 20, 28, 1);
        Wall MidWall8 = new Wall(Block.blocksize * 11, Block.blocksize * 24 , 1, 5);
        Wall MidWall9 = new Wall(Block.blocksize * 0, Block.blocksize * 0, 0, 0);
        Wall MidWall10 = new Wall(Block.blocksize * 0, Block.blocksize * 0,0, 0);



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
            AddSlime(slime);
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
            AddWall(MidWall6);
            AddWall(MidWall7);
            AddWall(MidWall8);
            AddWall(MidWall9);
            AddWall(MidWall10);
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
            MidWall6.Update(player, slime);
            MidWall7.Update(player, slime);
            MidWall8.Update(player, slime);
            MidWall9.Update(player, slime);
            MidWall10.Update(player, slime);

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
