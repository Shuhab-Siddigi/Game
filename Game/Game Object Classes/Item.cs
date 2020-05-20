using Game.Game_Control_Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game.Game_Object_Classes {


    enum ItemType {
        apple = 0,
        monkey = 1,
    }
    class Item : GameObject<ItemType>{

        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public static int itemsize { get; set; } = 20;
        public ItemType Type { get; set; } = ItemType.apple;

        private ItemControls controls = new ItemControls();

        private static Dictionary<ItemType, BitmapImage> Sources = new Dictionary<ItemType, BitmapImage>();

        public Item(int SpawnPositionX, int SpawnPositionY,ItemType type,int itemsize) {
            this.Width = itemsize;
            this.Height = itemsize;
            this.X = SpawnPositionX;
            this.Y = SpawnPositionY;
            this.Type = type;

            this.Stretch = System.Windows.Media.Stretch.Fill;
            if (type == ItemType.monkey) {
                this.Width = 1*itemsize;
                this.Height = 2*itemsize;
            }
           
        }

        public void SetSource() {
            this.Source = Item.Sources[this.Type];
        }

        static Item() {

            // Create a path to the bitmaps
            string path = Environment.CurrentDirectory;

            foreach (ItemType type in Enum.GetValues(typeof(ItemType))) {

                Item.Sources.Add(type, new BitmapImage(
                     new Uri(string.Format(@"{0}\GameObjects\{1}.png", path, type.ToString()))
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

        public new void DefaultSettings() {
            base.DefaultSettings();
            this.hit = false;
        }

        public void Update(Player player) {
            this.CollisionBox();
            this.CollisionBoxRender();
            controls.Movement(this, player);
            Canvas.SetLeft(this, this.X); // position X of player
            Canvas.SetTop(this, this.Y);  // position Y of player
            CollisionDetection.ItemCollision(player, this);
        }
    }
}
