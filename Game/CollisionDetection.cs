using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Numerics;
using System.Windows;
using Game.Game_Object_Classes;

namespace Game {

    

    class CollisionDetection {

     

        public enum CollisionEdge {
            Above = 0,
            Below = 1,
            Right = 2,
            Left = 3,
        }

        public Dictionary<CollisionEdge, bool> CollisionPoint(Rect player, Rect rect) {

            Rect intersection = Rect.Intersect(player, rect);
            if (intersection.IsEmpty) {
                return new Dictionary<CollisionEdge, bool>() {
                    { CollisionEdge.Above,   false },
                    { CollisionEdge.Below,   false },
                    { CollisionEdge.Right,   false },
                    { CollisionEdge.Left,    false },
                };
            }

           

            bool Above = player.Top == intersection.Top;
            bool Below = player.Bottom == intersection.Bottom;
            bool Right = player.Right == intersection.Right && !Above;
            bool Left = player.Left == intersection.Left && !Above;


            return new Dictionary<CollisionEdge, bool>() {
                { CollisionEdge.Above,   Above },
                { CollisionEdge.Below,   Below },
                { CollisionEdge.Right,   Right },
                { CollisionEdge.Left,    Left  },
            };

        }

       

        public void BlockCollision(Player player, Block block) {
            
            // Change parameters so it checks if the player is intersecting with the box
            // And not the other way around.
            Dictionary<CollisionEdge,bool> EdgeHit = CollisionPoint(block.HitBox,player.HitBox);

            if (EdgeHit[CollisionEdge.Below]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedAbove = true;
                //    Trace.WriteLine("Below");
            }
            if (EdgeHit[CollisionEdge.Above]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedBellow = true;
                // Trace.WriteLine("Above Block");
            }
            if (EdgeHit[CollisionEdge.Left]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedLeft = true;
                // Trace.WriteLine("Left Block");
            }
            if (EdgeHit[CollisionEdge.Right]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedRight = true;
                // Trace.WriteLine("Right Block");
                
            }
            
        }

        public void WallCollision(Player player,Wall wall) {
           
            // Change parameters so it checks if the player is intersecting with the box
            // And not the other way around.
            Dictionary<CollisionEdge, bool> EdgeHit = CollisionPoint(wall.WallHitBox, player.HitBox);

            if (EdgeHit[CollisionEdge.Below]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedAbove = true;
                 Trace.WriteLine("Wall Below");
            } 
            if (EdgeHit[CollisionEdge.Above]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedBellow = true;
                 Trace.WriteLine(" Wall Above");
            } 
            if (EdgeHit[CollisionEdge.Left]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedRight = true;
                 Trace.WriteLine(" Wall Left");
            } 
            if (EdgeHit[CollisionEdge.Right]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedLeft = true;
                 Trace.WriteLine(" Wall Right");
            }

        }








    }



}
