using Game.Game_Animation_Classes;
using Game.Game_Object_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Game_Control_Classes {
    class SlimeControls {


        SlimeAnimation slimeAnimation = new SlimeAnimation();



        public void Movement(Slime slime) {





            slimeAnimation.Animation(slime);

           
        }
    }
}
