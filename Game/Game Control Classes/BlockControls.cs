using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game {
    class BlockControls {

        Stopwatch FrameCounter = new Stopwatch();

        public BlockControls() {
            FrameCounter.Start();
        }
        public void BlockPosition(Block block) {


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

                if ((D || A) && Shift) {
                    block.X -= (D ? 2 : -2);
                } else if (D || A) {
                    block.X -= (D ? 1 : -1);
                } else if (Space) {
                   // block.Y += 4;
                } else if (S) {
                  //  block.Y -= 4;
                } else {

                }


                if (block.X <= -block.Width) {
                    block.X = 800+block.Width;
                }
                else if (block.X > (800 + block.Width)) {
                    block.X = (-block.Width);
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

