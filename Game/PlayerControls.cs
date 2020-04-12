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
                        player.xPos += (D ? 4 : -4);
                    } else if (D || A) {
                        player.Action = ActionType.walk;
                        player.xPos += (D ? 2 : -2);
                    } else if (Space) {
                        player.Action = ActionType.jump;
                        player.yPos -= 4;
                        LockFrame = 4;
                    } else if (S) {
                        player.Action = ActionType.crouch;
                        player.yPos += 4;
                    } else {
                        player.Action = ActionType.idle;
                    }
                } else {
                    LockFrame--;
                }

                player.SetSource();

                player.Frame += 1;
                FrameCounter.Restart();

            }
            Canvas.SetLeft(player, player.xPos);
            Canvas.SetTop(player, player.yPos);
        }
    }
}
