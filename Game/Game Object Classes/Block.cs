﻿using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game  {


 

    class Block : Image {
        public int Frame { get; set; } = 0;
        public double xPos { get; set; } = 0;
        public double yPos { get; set; } = 0;

        public Block() {
            this.Width = 50;
            this.Height = 50;
        }

        public void SetSource() {
            string path = Environment.CurrentDirectory;
            this.Source = new BitmapImage(
                new Uri(string.Format(@"{0}\Blocks\block-{1}.png", path, GetBlockFrame().ToString("00"))));
        }

        private int GetBlockFrame() {
            return this.Frame % 2;
        }
    }

    
}
