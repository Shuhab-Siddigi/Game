using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game.Game_Animation_Classes {
    class BlockAnimations {

        Stopwatch BlockFrameCounter = new Stopwatch();
       
        public BlockAnimations() {

            BlockFrameCounter.Start();

        }

        public void Animation(Block block, Player player) {

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
