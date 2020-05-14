using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game  {
    
    enum BlockType {
        yellow = 0,
        grey = 1,
    }

    class Block : Image { 
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public static int blocksize { get; set; } = 20;
        public BlockType Type { get; set; } = BlockType.yellow;

        private BlockControls controls = new BlockControls();

        private static Dictionary<BlockType, BitmapImage> Sources = new Dictionary<BlockType,BitmapImage>();

        public Rect HitBox = new Rect();
        public Rectangle HitBoxRender = new Rectangle();

        public Block(int SpawnPositionX, int SpawnPositionY) {
            this.Width = blocksize;
            this.Height = blocksize;
            this.X = SpawnPositionX;
            this.Y = SpawnPositionY;
            this.Stretch = System.Windows.Media.Stretch.Fill;
        }
      
        public void SetSource() {
            this.Source = Block.Sources[this.Type];
        }
      
        static Block() {

            // Create a path to the bitmaps
            string path = Environment.CurrentDirectory;

            foreach (BlockType type in Enum.GetValues(typeof(BlockType))) {
              
                Block.Sources.Add(type, new BitmapImage(
                     new Uri(string.Format(@"{0}\Blocks\block-{1}.png", path, type.ToString()))
                ));
                
            }
        }

        public void CollisionBox() {
            HitBox.Width = this.Width;
            HitBox.Height = this.Height;
            HitBox.X = Canvas.GetLeft(this);
            HitBox.Y = Canvas.GetTop(this);
        }

        public void CollisionBoxRender() {
            HitBoxRender.Width = this.HitBox.Width;
            HitBoxRender.Height = this.HitBox.Height; 
            Canvas.SetLeft(HitBoxRender, HitBox.X);
            Canvas.SetTop(HitBoxRender, HitBox.Y);
        }

        public void DefaultSettings() {
            HitBoxRender.Stroke = Brushes.Black;
        }

        public void Update(Player player) {
            this.CollisionBox();
            this.CollisionBoxRender();
            controls.Movement(this,player);
            Canvas.SetLeft(this, this.X); // position X of player
            Canvas.SetTop(this, this.Y);  // position Y of player
        }
    }

    
}



