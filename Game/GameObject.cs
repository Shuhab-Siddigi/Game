using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game {
    class GameObject<Actions> : Image {

        public double X { get; set; } = 0; // Position X
        public double Y { get; set; } = 0;   // Position Y 
        public bool isIdle { get; set; } = false;
        public bool isBlockedLeft { get; set; } = false;
        public bool isBlockedRight { get; set; } = false;
        public bool isBlockedBellow { get; set; } = false;
        public bool isBlockedAbove { get; set; } = false;
        public bool isRight { get; set; } = false;
        public bool isFalling { get; set; } = false;

        public Rectangle HitBoxRender = new Rectangle();

        public Rect HitBox = new Rect();

        protected static Dictionary<Actions, List<BitmapImage>> Sources = new Dictionary<Actions, List<BitmapImage>>();

        public int Frame { get; set; } = 0;
        public Actions Action { get; set; }
        public void DefaultSettings() {
            this.isBlockedLeft = false;
            this.isBlockedRight = false;
            this.isBlockedBellow = false;
            this.isBlockedAbove = false;
       

            this.isFalling = true;

            HitBoxRender.Stroke = Brushes.Black;
        }


    }
}
