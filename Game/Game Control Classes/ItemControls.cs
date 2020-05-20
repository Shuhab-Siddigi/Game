using Game.Game_Animation_Classes;
using Game.Game_Object_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Game_Control_Classes {
    class ItemControls {

        ItemAnimation itemAnimation = new ItemAnimation();

        public void Movement(Item item,Player player) {


            itemAnimation.Animation(item, player);

        }

    }
}
