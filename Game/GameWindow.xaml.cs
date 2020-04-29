using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace Game {

  

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
                Blocks.Add(new Block(50 * i, 50*i, 50, 50));
                Scene.Children.Add(Blocks[i]);
                Scene.Children.Add(Blocks[i].HitBoxRender);
            }
            
            Scene.Children.Add(player);
            Scene.Children.Add(player.HitBoxRender);

        }

        private void OnUpdate(object sender, EventArgs e) {

            player.isFalling = true;
            player.isCollidingLeft = true;

            for (int i = 0; i < Blocks.Count; i++) {
                temp = Canvas.GetLeft(Blocks[i]);
                 
                Blocks[i].Update();

                if (i % 2 == 0) {
                    Blocks[i].Type = BlockType.grey;
                }

                if (Collisions(player.HitBox, Blocks[i].HitBox)[CollisionEdge.hitLeft]) {
                    player.HitBoxRender.Stroke = Brushes.Red;
                    Blocks[i].HitBoxRender.Stroke = Brushes.Red;
                    player.isCollidingLeft = true;
                }


                if (Collisions(player.HitBox, Blocks[i].HitBox)[CollisionEdge.hitBelow]) {
                    player.HitBoxRender.Stroke = Brushes.Red;
                    Blocks[i].HitBoxRender.Stroke = Brushes.Red;
                    player.isFalling = false;
                }

                /*
                if (player.HitBox.IntersectsWith(Blocks[i].HitBox)) {
                    player.HitBoxRender.Stroke = Brushes.Red;
                    Blocks[i].HitBoxRender.Stroke = Brushes.Red;
                    player.isFalling = false;
                }
                */

                //block.Opacity = 0.25;

            }

            if(player.isFalling) {
                player.Y += 0.9;
            }

            player.Update();

        }
        public Dictionary<CollisionEdge, bool> Collisions(Rect player, Rect rect) {

            Rect intersection = Rect.Intersect(player, rect);
            if (intersection.IsEmpty) {
                return new Dictionary<CollisionEdge, bool>() {
                    { CollisionEdge.hitAbove,   false },
                    { CollisionEdge.hitBelow,   false },
                    { CollisionEdge.hitRight,   false },
                    { CollisionEdge.hitLeft,    false },
                };
            }

            bool hitAbove = player.Top == intersection.Top;
            bool hitBelow = player.Bottom == intersection.Bottom;
            bool hitRight = player.Right == intersection.Right;
            bool hitLeft = player.Left == intersection.Left;

            return new Dictionary<CollisionEdge,bool>() {
                { CollisionEdge.hitAbove,   hitAbove },
                { CollisionEdge.hitBelow,   hitBelow },
                { CollisionEdge.hitRight,   hitRight },
                { CollisionEdge.hitLeft,    hitLeft  },
            };
        }
        public enum CollisionEdge {
            hitAbove = 0,
            hitBelow = 1,
            hitRight = 2,
            hitLeft = 3,
        }

       
    }
}
