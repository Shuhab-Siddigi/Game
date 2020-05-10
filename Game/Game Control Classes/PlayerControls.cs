using Game.Game_Animation_Classes;
using System.Drawing;
using System.Windows;


namespace Game {
    class PlayerControls {
        
        Animation animation = new Animation();

        public void Movement(Player player,Rect Hitbox, System.Windows.Shapes.Rectangle HitBoxRender) {

            if (player.isBlockedBellow) {
                player.isFalling = false;
            }

            if (Input.Space || Input.W) {
                player.isJumping = true;
            } 
            else if ((Input.D || Input.A) && Input.Shift) {
                player.isRunning = true;
            } else if (Input.S && (Input.D || Input.A)) {
                player.isCrouchWalking = true;
            } else if ((Input.D || Input.A)) {
                player.isWalking = true;
            } 
             else if (Input.S) {
                player.isCrouching = true;
            } else {
                player.isIdle = true;
            }

            animation.PlayerAnimation(player,Hitbox,HitBoxRender);

        }


    }

    
}
