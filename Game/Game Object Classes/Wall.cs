using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game.Game_Object_Classes {

    public enum WallType {
        LeftWall,
        RightWall,
        TopWall,
        BottomWall,
    }
    
    class Wall : List<Block>{

        public Rect WallHitBox = new Rect();
        public Rectangle HitBoxRender = new Rectangle();
        CollisionDetection collision = new CollisionDetection();

        private int Width = 0;
        private int Height = 0;
        private int X = 0;
        private int Y = 0;
        private int HitBoxWidth = 0;
        private int WallHitBoxHeight = 0;

        public Wall(int X,int Y,int Width, int Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.HitBoxWidth = Width*Block.blocksize;
            this.WallHitBoxHeight = Height*Block.blocksize;
            LoadWalls();
        }


        private void LoadWalls() {

            for(int i = 0; i < this.Width; i++) {
                for (int j = 0; j < this.Height; j++) {
                    this.Add(new Block(this.X + Block.blocksize * i, this.Y + Block.blocksize * j));
                }
            }
            
        }

        private void CollisionBox() {
            WallHitBox.X = this.X;
            WallHitBox.Y = this.Y;
            WallHitBox.Width = this.HitBoxWidth;
            WallHitBox.Height = this.WallHitBoxHeight;
        }

        private void CollisionBoxRender() {
           
            HitBoxRender.Width = WallHitBox.Width;
            HitBoxRender.Height = WallHitBox.Height;
            Canvas.SetLeft(HitBoxRender, WallHitBox.X);
            Canvas.SetTop(HitBoxRender, WallHitBox.Y);

        }

        public void Update(Player player,List<Slime> Slimes) {
            HitBoxRender.Stroke = Brushes.Black;
            
            foreach (Block block in this) {
                block.Update(player);
            }
            
            CollisionBox();
            CollisionBoxRender();
            collision.WallCollision(player, this);
            
            foreach(Slime slime in Slimes) {
                collision.WallCollision(slime, this);
            }
           

        }

    }
}
