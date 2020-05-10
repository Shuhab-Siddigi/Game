using Game.Game_Animation_Classes;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game {
    class BlockControls {

        Animation animation = new Animation();

        public void Movement(Block block,Player player) {
            

                if (Input.D && Input.Shift && !player.isBlockedLeft) {
                 
                } else if (Input.A && Input.Shift && !player.isBlockedRight) {
                } else if (Input.D && !player.isBlockedLeft) {
                } else if (Input.A && !player.isBlockedRight) {
                } else if (Input.W) {
                } else if (Input.S) {
                } else {

                }

                animation.BlockAnimation(block, player);
                
        }
    }
        
        
}


