using Game.Game_Object_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.Game_Animation_Classes {
    class SlimeAnimation {

        Stopwatch SlimeFrameCounter = new Stopwatch();


        public SlimeAnimation() {
            SlimeFrameCounter.Start();
        }

       
        public void Animation(Slime slime) {

            FlipSlime(slime);

            if (SlimeFrameCounter.ElapsedMilliseconds > slime.ActionTime()) {

                if (slime.isFalling) {
                    slime.Y += 4;
                }
                if (slime.isBlockedBellow) {
                    if(!slime.isRight) {
                        slime.X += 5;
                        slime.Action = SlimeActionType.move;
                    }else {
                        slime.X -= 5;
                        slime.Action = SlimeActionType.move;
                    }
                    if (slime.isBlockedLeft) {
                        slime.isRight = false;
                    }else if (slime.isBlockedRight) {
                        slime.isRight = true;
                    }
                }

                


                slime.SetSource();
                slime.Frame += 1;

                SlimeFrameCounter.Restart();
            }
        }

        private void FlipSlime(Slime slime) {
            // Inverts Image 
            if (!slime.isRight) {
                slime.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(-1, 1);
                slime.RenderTransform = flippedPlayer;
                // Move Hitbox -10 px
                slime.HitBox.X = slime.HitBox.X - 1;
                Canvas.SetLeft(slime.HitBoxRender, Canvas.GetLeft(slime.HitBoxRender) - 1);

            } else {
                slime.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(1, 1);
                slime.RenderTransform = flippedPlayer;
            }
        }
    }
}
