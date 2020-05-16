using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.Game_Animation_Classes {
    class PlayerAnimation {

        Stopwatch PlayerFrameCounter = new Stopwatch();
        int LockFrame = 0;
        
        public PlayerAnimation() {
            PlayerFrameCounter.Start();
        }


        public void Animation(Player player) {

            FlipPlayer(player);


            if (PlayerFrameCounter.ElapsedMilliseconds > player.ActionTime()) {

                if (LockFrame == 0) {

                    if (player.isFalling) {
                        player.Action = ActionType.fall;
                        player.Y += 9;




                        if (Input.D && !player.isBlockedRight) {
                            player.Y += 1;
                            player.X += 10;
                        } else if (Input.A && !player.isBlockedLeft) {
                            player.Y += 1;
                            player.X -= 10;
                        }

                    } else if (player.isRunning) {
                        player.Action = ActionType.run;
                        if (Input.D && !player.isBlockedRight) {
                            player.X += 6;
                        } else if (Input.A && !player.isBlockedLeft) {
                            player.X -= 6;
                        }
                    } else if (player.isCrouchWalking) {
                        player.Action = ActionType.crouchwalk;
                        if (Input.D && !player.isBlockedRight) {
                            player.X += 4;
                        } else if (Input.A && !player.isBlockedLeft) {
                            player.X -= 4;
                        }
                    } else if (player.isJumping && !player.isFalling) {
                        player.Action = ActionType.jump;
                        player.Frame = 0;
                        LockFrame = 10;
                    } else if (player.isWalking) {
                        player.Action = ActionType.walk;
                        if (Input.D && !player.isBlockedRight) {
                            player.X += 3;
                        } else if (Input.A && !player.isBlockedLeft) {
                            player.X -= 3;
                        }
                    } else if (player.isCrouching) {
                        player.Action = ActionType.crouch;

                    } else {
                        player.Action = ActionType.idle;
                    }

                } else {
                    LockFrame--;
                    if (player.Frame > 2) {
                        player.Frame = 3;
                    }

                }

                if (player.Action == ActionType.jump && !player.isBlockedAbove) {
                    player.Y -= 7;

                    if (Input.D && !player.isBlockedRight) {
                        player.X += 9;
                    } else if (Input.A && !player.isBlockedLeft) {
                        player.X -= 9;
                    }
                } else if (player.isBlockedAbove) {
                    player.isFalling = true;
                    LockFrame = 0;
                }


            


                player.SetSource();
                player.Frame += 1;

                PlayerFrameCounter.Restart();
            }
        }

        private void FlipPlayer(Player player) {
            // Inverts Image 
            if (!player.isRight) {
                player.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(-1, 1);
                player.RenderTransform = flippedPlayer;
                // Move Hitbox -10 px
                player.HitBox.X = player.HitBox.X - 7;
                Canvas.SetLeft(player.HitBoxRender, Canvas.GetLeft(player.HitBoxRender) - 7);

            } else {
                player.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(1, 1);
                player.RenderTransform = flippedPlayer;
            }
        }


        public void GODMODE(Player player) {
            if (Input.D) {
                player.Action = ActionType.idle;
                player.X += 2;
            }
            if (Input.A) {
                player.Action = ActionType.idle;
                player.X -= 2;
            }
            if (Input.S) {
                player.Action = ActionType.idle;
                player.Y += 2;
            }
            if (Input.W) {
                player.Action = ActionType.idle;
                player.Y -= 2;
            }
            player.SetSource();
            player.Frame += 1;


        }


        private void WalkingLeft(Player player) {
        
        }
    }
}
