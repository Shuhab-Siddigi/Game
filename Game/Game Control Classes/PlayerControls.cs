using Game.Game_Animation_Classes;
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

            if (Input.Space || Input.W) {
                player.isJumping = true;
            } else if ((Input.D || Input.A) && Input.Shift) {
                player.isRunning = true;
            } else if ((Input.S && (Input.D || Input.A)) && !player.isFalling) {
                player.isCrouchWalking = true;
            } else if ((Input.D || Input.A)) {
                player.isWalking = true;
            } else if (Input.S && !player.isFalling) {
                player.isCrouching = true;
            } else {
                player.isIdle = true;
            }

            //playerAnimation.GODMODE(player);
            playerAnimation.Animation(player);

        }


    }

    
}
