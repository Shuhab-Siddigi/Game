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
using System.Linq;

namespace Game {

    public partial class GameWindow : Window {

        


        
        
        List<Slime> Slimes = new List<Slime>() {
            new Slime(100, 150, 40, 40),
            new Slime(150, 150, 40, 40),
            new Slime(200, 150, 40, 40),
            new Slime(300, 150, 40, 40),
        };

        Player player = new Player(10, 450, 50, 50);

        List<Wall> Walls = new List<Wall>() {

            new Wall(Block.blocksize* 0, Block.blocksize* 0, 39, 1), // Top wall
            new Wall(Block.blocksize* 0, Block.blocksize* 29, 39, 1), // Bottom wall
            new Wall(Block.blocksize * 0, Block.blocksize * 0, 1, 30), // Left Wall
            new Wall(Block.blocksize* 38, Block.blocksize* 0, 1, 30), // Right Wall
            new Wall(Block.blocksize* 3, Block.blocksize* 26, 6, 1),
            new Wall(Block.blocksize* 23, Block.blocksize* 20, 1, 5),
            new Wall(Block.blocksize* 12, Block.blocksize* 26, 6, 1),
            new Wall(Block.blocksize* 9, Block.blocksize* 23, 6, 1),
            new Wall(Block.blocksize* 20, Block.blocksize* 26, 6, 1),
            new Wall(Block.blocksize* 17, Block.blocksize* 23, 6, 1),
            new Wall(Block.blocksize* 1, Block.blocksize* 20, 28, 1),
            new Wall(Block.blocksize* 11, Block.blocksize* 24, 1, 5),
            new Wall(Block.blocksize* 28, Block.blocksize* 23, 1, 5),
            new Wall(Block.blocksize* 30, Block.blocksize* 26, 5, 1),
            new Wall(Block.blocksize* 33, Block.blocksize* 23, 5, 1),
            new Wall(Block.blocksize* 31, Block.blocksize* 17, 7, 1),
            new Wall(Block.blocksize* 26, Block.blocksize* 14, 9, 1),
            new Wall(Block.blocksize* 26, Block.blocksize* 14, 1, 6),
            new Wall(Block.blocksize* 26, Block.blocksize* 11, 12, 1),

            new Wall(Block.blocksize* 4, Block.blocksize* 16, 12, 1),
            new Wall(Block.blocksize* 14, Block.blocksize* 13, 9, 1),
        };

        List<Item> Items = new List<Item>() {

            new Item(100,200,ItemType.apple,40),
            new Item(200,200,ItemType.apple,40),
            new Item(300,200,ItemType.apple,40),
            new Item(700,120,ItemType.monkey,50),


        };

        public GameWindow() {

            InitializeComponent();

            startGame();
        }

        private void startGame() {

            CompositionTarget.Rendering += OnUpdate;
            
            Scene.Width = GlobalSettings.ScreenWidth;
            Scene.Height = GlobalSettings.ScreenHeight;
            Window.Width = GlobalSettings.ScreenWidth - 4;
            Window.Height = GlobalSettings.ScreenHeight - 1;
           
            foreach (Wall wall in Walls) {
                AddWall(wall);
            }
            // Add objects to the screen
            
            foreach(Slime slime in Slimes) {
                AddSlime(slime);
            }

            foreach (Item item in Items) {
                AddItem(item);
            }



            AddPlayer(player);

           
        }


        private void OnUpdate(object sender, EventArgs e) {

                Input.Update();
            player.DefaultSettings();
                // Default settings
                
            foreach(Slime slime in Slimes) {
                slime.DefaultSettings();
            }
            foreach (Item item in Items) {
                item.DefaultSettings();
            }

            // Update Settings
            foreach (Wall wall in Walls) {
                wall.Update(player, Slimes);
            }

            foreach (Slime slime in Slimes.ToList()) {
                slime.Update(player);
                if (slime.hit) {
                    RemoveSlime(slime);
                }
            }

            foreach (Item item in Items.ToList()) {
                item.Update(player);
                if (item.hit) {
                    RemoveItem(item);
                }
            }

            player.Update();


            
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

        private void AddItem(Item item) {
            Scene.Children.Add(item);
            Scene.Children.Add(item.HitBoxRender);
        }

        private void RemovePlayer(Player player) {
            Scene.Children.Remove(player);
            Scene.Children.Remove(player.HitBoxRender);
        }

        private void RemoveBlock(Block block) {
            Scene.Children.Remove(block);
            Scene.Children.Remove(block.HitBoxRender);
        }

        private void RemoveSlime(Slime slime) {
            Scene.Children.Remove(slime);
            Scene.Children.Remove(slime.HitBoxRender);
            Slimes.Remove(slime);
        }

        private void RemoveItem(Item item) {
            Scene.Children.Remove(item);
            Scene.Children.Remove(item.HitBoxRender);
            Items.Remove(item);
        }





    }
}
