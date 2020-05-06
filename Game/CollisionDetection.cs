using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            bool Right = player.Right == intersection.Right;
            bool Left = player.Left == intersection.Left;


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
                player.isFalling = false;
                Trace.WriteLine("Below");
            }
            if (EdgeHit[CollisionEdge.Above]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                
                Trace.WriteLine("Above");
            }
            if (EdgeHit[CollisionEdge.Left]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedLeft = true;
                Trace.WriteLine("Left");
            }
            if (EdgeHit[CollisionEdge.Right]) {
                player.HitBoxRender.Stroke = Brushes.Red;
                block.HitBoxRender.Stroke = Brushes.Red;
                player.isBlockedRight = true;
                Trace.WriteLine("Right");
                
            }
            Trace.WriteLine("\n");
            Trace.WriteLine("\n");
            Trace.WriteLine("\n");


        }


    



    }



}
