using Game.Game_Animation_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game {
    class PlayerControls {

        int LockFrame = 0;
        Stopwatch FrameCounter = new Stopwatch();
        Animation animation = new Animation();
        
        public PlayerControls(){
            FrameCounter.Start();
        }
        public void Movement(Player player) {

            


            if (FrameCounter.ElapsedMilliseconds > player.ActionTime()) {
                 
                 player.isIdle = false;
                 player.isWalking = false;
                 player.isRunning  = false;
                 player.isJumping  = false;
                 player.isCrouching = false;

                if (LockFrame == 0) {
                    
                   
                    
                    if ((Input.D || Input.A) && Input.Shift) {
                        player.Action = ActionType.run;
                        player.isRunning = true;
                        player.X += (Input.D ? 6 : -4);
                    } else if (Input.D || Input.A) {
                        player.Action = ActionType.walk;
                        player.isWalking = true;
                        player.X += (Input.D ? 3 : -2);
                    } else if (Input.Space||Input.W) {
                        player.Action = ActionType.jump;
                            player.Y -= 4;
                        
                        player.isJumping = true;

                    } else if (Input.S) {
                        player.Action = ActionType.crouch;
                        player.isCrouching = true;
                    } else {
                        player.Action = ActionType.idle;
                        player.isIdle = true;
                    }
                    
                } else {
                  LockFrame--;
                }

                animation.PlayerAnimation(player);

                FrameCounter.Restart();



            }

            if (player.isFalling && player.Action != ActionType.jump && LockFrame == 0) {
                    player.Y += 2 ;
            }


        }

    }
}
