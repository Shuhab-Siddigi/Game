using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game  {


 

    class Background : Image {
        public int Frame { get; set; } = 0;

        public Background() {
            this.Width = 80;
            this.Height = 80;
        }

        public void SetSource() {
            string path = Environment.CurrentDirectory;
            this.Source = new BitmapImage(
                new Uri(string.Format(@"{0}\BackgroundItems\block-{1}.png", path, GetLayerFrame().ToString("00"))));
        }

        private int GetLayerFrame() {
            return this.Frame % 2;
        }
    }

    
}
