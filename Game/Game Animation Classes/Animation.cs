using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Game.Game_Animation_Classes {
    class Animation {
        Stopwatch FrameCounter = new Stopwatch();
        public Animation() {
            FrameCounter.Start();
        }

        public void PlayerAnimation(Player player) {





            // Setting the PNG to the player
            player.SetSource();
            // Next Player Frame 
            player.Frame += 1;
            // Movement for the player on the Canvas

            FrameCounter.Restart();
        }
    }
}
