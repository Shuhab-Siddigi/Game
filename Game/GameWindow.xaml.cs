﻿using System.Windows;
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


        Slime slime = new Slime(100, 150, 40, 40);
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

            // Add objects to the screen
            AddSlime(slime);
            AddPlayer(player);

            foreach (Wall wall in Walls) {
                AddWall(wall);
            }
        }


        private void OnUpdate(object sender, EventArgs e) {

                Input.Update();

                // Default settings
                slime.DefaultSettings();
                player.DefaultSettings();

                // Update Settings
                foreach (Wall wall in Walls) {
                    wall.Update(player, slime);
                }

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
