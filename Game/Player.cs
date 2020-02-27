using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Game {



    class Player : Image {

        
            public double xPosition { get; set; } = 0;
            public float yPosition { get; set; } = 0;

        public Player() {

            this.Width = 100;
            this.Height = 100;
            

        }

        public void setAction(int action, int counter) {

            String path = Environment.CurrentDirectory;
            String act = "idle";
            switch (action) {
                case 1:
                    act = "run";
                    break;
                case 2:
                    act = "die";
                    break;
                default:
                    act = "idle";
                    break;
            }

            this.Source = new BitmapImage(new Uri(string.Format(@"{0}\Bitmaps\Adventurer\Individual Sprites\adventurer-" + act + "-0" + counter + ".png", path)));           
        }

        public void update() {
            Canvas.SetLeft(this, this.xPosition);
            Canvas.SetTop(this, this.yPosition);
        }

     
    }
}
