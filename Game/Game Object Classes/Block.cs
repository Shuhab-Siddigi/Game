using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game  {
    
    enum BlockType {
        yellow = 0,
        grey = 1,
    }

    class Block : Image { 
        public double xPos { get; set; } = 0;
        public double yPos { get; set; } = 0;
        public BlockType Type { get; set; } = BlockType.yellow;

        private static Dictionary<BlockType, BitmapImage> Sources = new Dictionary<BlockType,BitmapImage>();

        public Rectangle HitBoxRender = new Rectangle();
        public Rect HitBox = new Rect();

        public Block() {
            this.Width = 50;
            this.Height = 50;
        }
      
        public void SetSource() {
            this.Source = Block.Sources[this.Type];
        }
      
        static Block() {

            // Create a path to the bitmaps
            string path = Environment.CurrentDirectory;
            

            foreach (BlockType type in Enum.GetValues(typeof(BlockType))) {
                Trace.WriteLine(type.ToString());
                Block.Sources.Add(type, new BitmapImage(
                     new Uri(string.Format(@"{0}\Blocks\block-{1}.png", path, type.ToString()))
                ));
                
            }
        }

        
        public void Collision() {

            HitBox.Width = this.Width;
            HitBox.Height = this.Height;
            HitBox.X = Canvas.GetLeft(this);
            HitBox.Y = Canvas.GetTop(this);

        }

        public void CollisionBoxRender() {
            HitBoxRender.Width = this.HitBox.Width;
            HitBoxRender.Height = this.HitBox.Height;
            HitBoxRender.Stroke = Brushes.Black;
            Canvas.SetLeft(HitBoxRender, HitBox.X);
            Canvas.SetTop(HitBoxRender, HitBox.Y);

        }
    }

    
}
