using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Game.Game_Animation_Classes {
    class Animation {
        Stopwatch PlayerFrameCounter = new Stopwatch();
        Stopwatch BlockFrameCounter = new Stopwatch();
        int LockFrame = 0;
        public Animation() {
            PlayerFrameCounter.Start();
            BlockFrameCounter.Start();
        }

        public void PlayerAnimation(Player player) {

            if (Input.A) { 
            player.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform flippedPlayer = new ScaleTransform(-1, 1);
            player.RenderTransform = flippedPlayer;
            } else {
                player.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(1, 1);
                player.RenderTransform = flippedPlayer;
            }

            if (PlayerFrameCounter.ElapsedMilliseconds > player.ActionTime()) {

                if(LockFrame == 0) { 

                    if (player.isFalling) {
                        player.Action = ActionType.fall;
                        player.Y += 3;
                        if(Input.D || Input.A) {
                            player.Y += 1;
                            player.X += (Input.D ? 2 : -2);
                        }

                    } else if (player.isRunning) {
                        player.Action = ActionType.run;
                        player.X += (Input.D ? 6 : -4);
                        if (Input.A) {  
                        }
                    } else if (player.isCrouchWalking) {
                        player.Action = ActionType.crouchwalk;
                        player.X += (Input.D ? 4 : -4);
                    } else if (player.isJumping && !player.isFalling) {
                        player.Action = ActionType.jump;
                        player.Frame = 0;
                        LockFrame = 3;
                    } else if (player.isWalking) {
                        player.Action = ActionType.walk;
                        player.X += (Input.D ? 3 : -2);
                    }  else if (player.isCrouching) {
                        player.Action = ActionType.crouch;
                    
                    } else {
                        player.Action = ActionType.idle;
                    }
                
                } else {
                    LockFrame--;
                }

                if (player.Action == ActionType.jump) {
                    player.Y -= 9;
                    if (Input.D || Input.A) {
                        player.X += (Input.D ? 2 : -2);
                    }
                }

               

                // Setting the PNG to the player
                player.SetSource();
                // Next Player Frame 
                player.Frame += 1;
                // Movement for the player on the Canvas
                PlayerFrameCounter.Restart();
            }
        }

        public void BlockAnimation(Block block, Player player) {

            if (BlockFrameCounter.ElapsedMilliseconds > 40) {
               

                if (block.X <= -block.Width) {
                    block.X = GlobalSettings.ScreenWidth;
                }


                block.SetSource();
                // Next Player Frame 
                // Movement for the player on the Canvas
                //Canvas.SetLeft(block, block.X);
                //Canvas.SetTop(block, block.Y);

                BlockFrameCounter.Restart();
            }



        }
    }
}
