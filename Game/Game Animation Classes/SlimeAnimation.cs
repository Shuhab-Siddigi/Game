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
                slime.HitBox.X = slime.HitBox.X - 7;
                Canvas.SetLeft(slime.HitBoxRender, Canvas.GetLeft(slime.HitBoxRender) - 7);

            } else {
                slime.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(1, 1);
                slime.RenderTransform = flippedPlayer;
            }
        }
    }
}
