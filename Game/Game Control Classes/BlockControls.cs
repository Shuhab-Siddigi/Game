using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game {
    class BlockControls {

        Stopwatch FrameCounter = new Stopwatch();

        public BlockControls() {
            FrameCounter.Start();
        }
        public void BlockPosition(Block block,Player player) {


            bool D = Keyboard.IsKeyDown(Key.D);
            bool A = Keyboard.IsKeyDown(Key.A);
            bool S = Keyboard.IsKeyDown(Key.S);
            bool W = Keyboard.IsKeyDown(Key.W);
            bool J = Keyboard.IsKeyDown(Key.J);
            bool K = Keyboard.IsKeyDown(Key.K);
            bool I = Keyboard.IsKeyDown(Key.I);
            bool L = Keyboard.IsKeyDown(Key.L);
            bool Space = Keyboard.IsKeyDown(Key.Space);
            bool Shift = Keyboard.IsKeyDown(Key.LeftShift);

             // Becomes unstable under 30 millis 
            if (FrameCounter.ElapsedMilliseconds > 10) {

                if (D && Shift && !player.isBlockedLeft) {
                    block.X -=  1;
                } else if (A && Shift && !player.isBlockedRight) {
                    block.X +=  1;
                } else if (D && !player.isBlockedLeft) {
                    block.X -=  1;
                } else if (A && !player.isBlockedRight) {
                    block.X += 1;
                } else if (W) {
                    block.Y += 1;
                } else if (S) {
                    block.Y -= 1;
                } else {

                }


                if (block.X < -block.Width*2) {
                    block.X = GlobalSettings.ScreenWidth;
                }

                if (block.X > GlobalSettings.ScreenWidth+block.Width) {
                    block.X = -block.Width*2;
                }


                // ResizeMode="NoResize"

                block.SetSource();
                // Next Player Frame 
                // Movement for the player on the Canvas
                Canvas.SetLeft(block, block.X);
                Canvas.SetTop(block, block.Y);


                FrameCounter.Restart();
            }
        }
        
        
    }
}

