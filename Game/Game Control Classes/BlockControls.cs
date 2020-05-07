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
            if (FrameCounter.ElapsedMilliseconds > 40) {

                if (D && Shift && !player.isBlockedLeft) {
                 
                } else if (A && Shift && !player.isBlockedRight) {
                } else if (D && !player.isBlockedLeft) {
                } else if (A && !player.isBlockedRight) {
                } else if (W) {
                } else if (S) {
                } else {

                }


                if (block.X <= -block.Width) {
                    block.X = GlobalSettings.ScreenWidth;
                }

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

