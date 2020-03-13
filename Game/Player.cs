using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Game {

    enum ActionType {
        idle,
        run,
        die,
        jump,
        crouch,
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
                new Uri(string.Format(@"{0}\Bitmaps\adventurer-{1}-{2}.png", path,this.Action,GetActionFrame().ToString("00"))));     
        }

        private int GetActionFrame() {
            return this.Action switch
            {
                ActionType.run => this.Frame%6,
                ActionType.die => this.Frame%4,
                ActionType.jump => this.Frame %4,
                ActionType.crouch => this.Frame % 4,
                _ => this.Frame % 4,
            };

        }

       

     
    }
}
