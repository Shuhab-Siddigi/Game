using Game.Game_Object_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game.Game_Animation_Classes {
    class SlimeAnimation {

        Stopwatch SlimeFrameCounter = new Stopwatch();


        public SlimeAnimation() {
            SlimeFrameCounter.Start();
        }

       
        public void Animation(Slime slime) {
            if (SlimeFrameCounter.ElapsedMilliseconds > slime.ActionTime()) {

                slime.SetSource();
                slime.Frame += 1;

                SlimeFrameCounter.Restart();
        }
        }
    }
}
