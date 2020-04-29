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
        public PlayerControls(){
            FrameCounter.Start();
        }
        public void Movement(Player player) {

            bool D = Keyboard.IsKeyDown(Key.D);
            bool A = Keyboard.IsKeyDown(Key.A);
            bool S = Keyboard.IsKeyDown(Key.S);
            bool W = Keyboard.IsKeyDown(Key.W);
            bool J = Keyboard.IsKeyDown(Key.J);
            bool K = Keyboard.IsKeyDown(Key.K);
            bool I = Keyboard.IsKeyDown(Key.I);
            bool L = Keyboard.IsKeyDown(Key.L);
            bool Space = Keyboard.IsKeyDown(Key.Space);
            bool Shift = Keyboard.IsKeyDown(Key.LeftShift);

            if (FrameCounter.ElapsedMilliseconds > player.ActionTime()) {

                 player.isIdle = false;
                 player.isWalking = false;
                 player.isRunning  = false;
                 player.isJumping  = false;
                 player.isCrouching = false;

                if (LockFrame == 0) {
                    if ((D || A) && Shift) {
                        player.Action = ActionType.run;
                        player.isRunning = true;
                    } else if (D || A) {
                        player.Action = ActionType.walk;
                        player.isWalking = true;
                    } else if (Space||W) {
                        player.Action = ActionType.jump;
                        LockFrame = 4;
                        player.isJumping = true;
                    } else if (S) {
                        player.Action = ActionType.crouch;
                        player.isCrouching = true;
                    } else {
                        player.Action = ActionType.idle;
                        player.isIdle = true;
                    }
                } else {
                    LockFrame--;
                }
                // Setting the PNG to the player
                player.SetSource();
                // Next Player Frame 
                player.Frame += 1;
                // Movement for the player on the Canvas
                FrameCounter.Restart();
            }
           
        }
    }
}
