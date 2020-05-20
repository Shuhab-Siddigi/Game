using Game.Game_Animation_Classes;
using System.Diagnostics;
using System.Windows;


namespace Game {
    class PlayerControls {
        
        PlayerAnimation playerAnimation = new PlayerAnimation();

        public void Movement(Player player) {

            if (player.isBlockedBellow) {
                player.isFalling = false;
            }

            if (Input.A) {
                player.isRight = false;
            }else if (Input.D) {
                player.isRight = true;
            }

            if (Input.W) {
                player.isJumping = true;
            } else if (Input.Space) {
                player.isAttacking1 = true;
            } else if ((Input.D || Input.A) && Input.Shift) {
                player.isRunning = true;
            } else if (Input.S && (Input.D || Input.A)) {
                player.isCrouchWalking = true;
            } else if ((Input.D || Input.A)) {
                player.isWalking = true;
            } else if (Input.S) {
                player.isCrouching = true;
            } else {
                player.isIdle = true;
            }

            //playerAnimation.GODMODE(player);
            playerAnimation.Animation(player);
            
        }


    }

    
}
