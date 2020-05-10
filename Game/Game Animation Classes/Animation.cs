using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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

        public void PlayerAnimation(Player player, Rect Hitbox, System.Windows.Shapes.Rectangle HitBoxRender) {

            FlipPlayer(player, Hitbox, HitBoxRender);
            

            if (PlayerFrameCounter.ElapsedMilliseconds > player.ActionTime()) {
                
                if (LockFrame == 0) {

                   

                    if (player.isFalling) {
                        player.Action = ActionType.fall;
                        player.Y += 7;
                        
                        if (Input.D && !player.isBlockedRight) {
                            player.Y += 1;
                            player.X += 10;
                        } else if (Input.A && !player.isBlockedLeft) {
                            player.Y += 1;
                            player.X -= 10;
                        } 
                        
                    } else if (player.isRunning) {
                        player.Action = ActionType.run;
                        if(Input.D && !player.isBlockedRight) {
                            player.X += 6;
                        } else if ( Input.A && !player.isBlockedLeft) {
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
                    }  else if (player.isCrouching) {
                        player.Action = ActionType.crouch;
                    
                    } else {
                        player.Action = ActionType.idle;
                    }
                
                } else {
                    LockFrame--;
                    if(player.Frame > 2) {
                        player.Frame = 3;
                    }
                   
                }

                if (player.Action == ActionType.jump && !player.isBlockedAbove) {
                    player.Y -= 10;
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

        private void FlipPlayer(Player player, Rect Hitbox, System.Windows.Shapes.Rectangle HitBoxRender) {
            // Inverts Image 
            if (!player.isRight) {
                player.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(-1, 1);
                player.RenderTransform = flippedPlayer;
                // Move Hitbox -10 px
                player.HitBox.X = player.HitBox.X-7;
                Canvas.SetLeft(player.HitBoxRender,Canvas.GetLeft(player.HitBoxRender)-7);
                
            } else {
                player.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flippedPlayer = new ScaleTransform(1, 1);
                player.RenderTransform = flippedPlayer;
            }
        }
    }
}
