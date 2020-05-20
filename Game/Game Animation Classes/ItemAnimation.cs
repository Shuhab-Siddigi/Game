using Game.Game_Object_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game.Game_Animation_Classes {
    class ItemAnimation {
        Stopwatch  ItemFrameCounter = new Stopwatch();
        public ItemAnimation() {

            ItemFrameCounter.Start();

        }

        public void Animation(Item item, Player player) {

            if (ItemFrameCounter.ElapsedMilliseconds > 40) {


                item.SetSource();
                // Next Player Frame 
                // Movement for the player on the Canvas
                //Canvas.SetLeft(block, block.X);
                //Canvas.SetTop(block, block.Y);

                ItemFrameCounter.Restart();
            }



        }
    }
}
