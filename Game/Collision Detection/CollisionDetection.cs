using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Game.Game_Object_Classes;

namespace Game {

    

    static class CollisionDetection {


        public enum CollisionEdge {
            Above = 0,
            Below = 1,
            Right = 2,
            Left = 3,
        }

        public static Dictionary<CollisionEdge, bool> CollisionPoint(Rect player, Rect rect) {


            bool Below = (player.Bottom >= rect.Top) && (player.Bottom <= rect.Top+10)  && (player.Right >= rect.Left) && (player.Left <= rect.Right); 
            bool Above = (player.Top >= rect.Bottom-10) && (player.Top <= rect.Bottom ) && (player.Right >= rect.Left) && (player.Left <= rect.Right);
            bool Right = (player.Right >= rect.Left) && (player.Right <= rect.Left + 10) && (player.Bottom >= rect.Top) && (player.Top <= rect.Bottom) && (!Below && !Above);
            bool Left = (player.Left >= rect.Right - 10) && (player.Left <= rect.Right) && (player.Bottom >= rect.Top) && (player.Top <= rect.Bottom)  && (!Below && !Above);

            return new Dictionary<CollisionEdge, bool>() {
                { CollisionEdge.Above,   Above },
                { CollisionEdge.Below,   Below },
                { CollisionEdge.Right,   Right },
                { CollisionEdge.Left,    Left  },
            };

        }

        /*
        public void BlockCollision(Player player, Block block) {
            
            
            Dictionary<CollisionEdge,bool> EdgeHit = CollisionPoint(player.HitBox, block.HitBox);
            
            if (EdgeHit[CollisionEdge.Below]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedBellow = true;
                //    Trace.WriteLine("Below");
            }
            if (EdgeHit[CollisionEdge.Above]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedAbove = true;
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
        */
        public static void WallCollision<T>(GameObject<T> gameObject,Wall wall) {
           
            Dictionary<CollisionEdge, bool> EdgeHit = CollisionPoint(gameObject.HitBox, wall.WallHitBox );
            if (EdgeHit[CollisionEdge.Below]) {
                gameObject.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                gameObject.isBlockedBellow = true;
               
                // Trace.WriteLine("Wall Below");
            } 
            if (EdgeHit[CollisionEdge.Above]) {
                gameObject.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                gameObject.isBlockedAbove = true;
                
                // Trace.WriteLine(" Wall Above");
            } 
            if (EdgeHit[CollisionEdge.Left]) {
                gameObject.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                gameObject.isBlockedLeft = true;
                // Trace.WriteLine(" Wall Left");
            } 
            if (EdgeHit[CollisionEdge.Right]) {
                gameObject.HitBoxRender.Stroke = Brushes.Red;
                wall.HitBoxRender.Stroke = Brushes.Red;
                gameObject.isBlockedRight = true;
                // Trace.WriteLine(" Wall Right");
            }
           
        }


        public static void SlimeCollision(Player player, Slime slime) {
            Dictionary<CollisionEdge, bool> EdgeHit = CollisionPoint(player.HitBox, slime.HitBox);
            if ((EdgeHit[CollisionEdge.Below] || EdgeHit[CollisionEdge.Above] || EdgeHit[CollisionEdge.Left] || EdgeHit[CollisionEdge.Right] ) && player.isAttacking1) {
                slime.hit = true;
                Trace.WriteLine("HIT");
            }
        }


    }



}
