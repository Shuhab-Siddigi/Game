
using Game.Game_Control_Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game.Game_Object_Classes {
    enum ActionType {
        idle,
        die,
        hurt,
        move,
        attack,
      
    }
    class Slime : GameObject<ActionType> {

            
            
            private SlimeControls slimecontrols = new SlimeControls();

        // Create a Dictionary to hold all frames for each Actions
        private static Dictionary<ActionType, int> ActionTypeFrames = new Dictionary<ActionType, int>() {
            {ActionType.idle,   4},
            {ActionType.die,    4},
            {ActionType.hurt,   3},
            {ActionType.move,    4},
             {ActionType.attack,    5},

        };

            // Define size of player 
            public Slime(int SpawnPositionX, int SpawnPositionY, int Width, int Height) {
                this.Width = Width;
                this.Height = Height;
                this.Stretch = System.Windows.Media.Stretch.Fill;
                X = SpawnPositionX;
                Y = SpawnPositionY;
            }

            // Static Constructor to load all the images to a Dictonary
            static Slime() {

                // Create a path to the bitmaps
                string path = Environment.CurrentDirectory;

                foreach (ActionType action in Enum.GetValues(typeof(ActionType))) {

                    Slime.Sources.Add(action, new List<BitmapImage>());

                    for (int frame = 0; frame < ActionTypeFrames[action]; frame++) {

                        Slime.Sources[action].Add(new BitmapImage(
                            new Uri(string.Format(@"{0}\Slime\slime-{1}-{2}.png", path, action, frame.ToString("00")))
                        ));
                    }
                }
            }

            public void SetSource() {

                this.Source = Slime.Sources[this.Action][GetActionFrame()];
            }

            private int GetActionFrame() {
                return this.Action switch
                {
                    ActionType.move => this.Frame % 4,
                    ActionType.die => this.Frame % 4,
                    ActionType.hurt => this.Frame % 3,
                    ActionType.attack => this.Frame % 5,
                    _ => this.Frame % 4,
                };

            }

            // Set the time for each action in Millis
            public int ActionTime() {

                return this.Action switch
                {
                    ActionType.move => 80,
                    ActionType.hurt => 80,
                    ActionType.die => 70,
                    ActionType.attack => 70,
                    _ => 200,
                };

            }

            public void CollisionBox() {
                HitBox.Width = this.Width;
                HitBox.Height = this.Height / 2;
                HitBox.X = Canvas.GetLeft(this);
                HitBox.Y = Canvas.GetTop(this) + (this.Height/2);
            }

            // Add this to the Canvas if To set the CollisionBox Visible
            public void CollisionBoxRender() {
                HitBoxRender.Width = this.HitBox.Width;
                HitBoxRender.Height = this.HitBox.Height;
                Canvas.SetLeft(HitBoxRender, HitBox.X);
                Canvas.SetTop(HitBoxRender, HitBox.Y);
            }


            public void Update() {
                Canvas.SetLeft(this, this.X); // position X of player
                Canvas.SetTop(this, this.Y);  // position Y of player
                this.CollisionBox();
                this.CollisionBoxRender();
                slimecontrols.Movement(this);
                // If the player is not touching anything

            }

        }
    }

