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

    enum ActionType {
        idle,
        run,
        die,    
    }


    class Player : Image {
        public int Frame {get; set;} = 0;
        public ActionType Action { get; set; } = ActionType.idle;

        // Define size of player 
        public Player() {
            this.Width = 80;
            this.Height = 80;
        }
        
        public void SetSource() {
            string path = Environment.CurrentDirectory;
            this.Source = new BitmapImage(
                new Uri(string.Format(@"{0}\Bitmaps\Adventurer\Individual Sprites\adventurer-{1}-0{2}.png", path,this.Action,GetActionFrame())));     
        }

        private int GetActionFrame() {
            return this.Action switch
            {
                ActionType.run => this.Frame%6,
                ActionType.die => this.Frame%4, 
                _ => this.Frame % 4,
            };

        }

       

     
    }
}
