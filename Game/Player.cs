using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Game {

  

    class Player : Image {

        // Movement values for the player 
        private readonly int height = 50;
        private readonly int width = 50;

        private int startPositionX = 0;
        private int startPositionY = 0;
        // A tick for each player 

           DispatcherTimer Timer = new DispatcherTimer();




        public Player(int startPositionX, int startPositionY) {

            BitmapImage action = new BitmapImage();
            
            action.BeginInit();
            action.UriSource = new Uri(@"C:\Users\shuha\Source\Repos\Game\Game\Bitmaps\Adventurer\Individual Sprites\adventurer-attack1-00.png", UriKind.RelativeOrAbsolute);
            action.EndInit();
            this.Stretch = Stretch.UniformToFill;
            this.Source = action;
            
            this.Width = width;
            this.Height = height;


            Canvas.SetLeft(this, this.startPositionX);
            Canvas.SetTop(this, this.startPositionY);


            
            Timer.Tick += new EventHandler(update);
            // Set the update rate      //Y  H  M  S  MS
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 60 FPS 
            Timer.Start();
            
            
          

        }

        
  


        
        private void update(object sender, EventArgs e) {

            Trace.WriteLine("Player UP");
            Canvas.SetLeft(this,this.startPositionX);
            Canvas.SetTop(this, this.startPositionY);

        
        }
        

    }
}
