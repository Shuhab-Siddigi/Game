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

                if (LockFrame == 0) {
                    if ((D || A) && Shift) {
                        player.Action = ActionType.run;
                        player.X += (D ? 0.5 : -0.5);
                       
                    } else if (D || A) {
                        player.Action = ActionType.walk;
                        player.X += (D ? 0.25 : -0-5);
                    } else if (Space||W) {
                        player.Action = ActionType.jump;
                        player.Y -= 4;
                        LockFrame = 4;
                    } else if (S) {
                        player.Action = ActionType.crouch;
                        player.Y += 4;
                    } else {
                        player.Action = ActionType.idle;
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
