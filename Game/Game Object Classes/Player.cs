using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game {



    enum PlayerActionType {
        idle,
        walk,
        run,
        die,
        jump,
        crouch,
        fall,
        crouchwalk,
        attack1,

    }

    class Player : GameObject<PlayerActionType> {
        
        

        private PlayerControls playercontrols = new PlayerControls();

        public bool isWalking { get; set; } = false;
        public bool isRunning { get; set; } = false;
        public bool isJumping { get; set; } = false;
        public bool isCrouching { get; set; } = false;
        public bool isCrouchWalking { get; set; } = false;

        public bool isAttacking1 { get; set; } = false;
 


        // Create a Dictionary to hold all frames for each Actions
        private static Dictionary<PlayerActionType, int> ActionTypeFrames = new Dictionary<PlayerActionType, int>() {
            {PlayerActionType.idle,   4},
            {PlayerActionType.die,    4},
            {PlayerActionType.jump,   4},
            {PlayerActionType.crouch, 4},
            {PlayerActionType.walk,    6},
            {PlayerActionType.run,    6},
            {PlayerActionType.fall,    2},
            {PlayerActionType.crouchwalk, 6},
             {PlayerActionType.attack1, 5},
        };

        // Define size of player 
        public Player(int SpawnPositionX, int SpawnPositionY,int Width,int Height) {
            this.Width = Width;
            this.Height = Height;
            this.Stretch = System.Windows.Media.Stretch.UniformToFill;
            X = SpawnPositionX;
            Y = SpawnPositionY;
            this.Action = PlayerActionType.idle;
        }

        // Static Constructor to load all the images to a Dictonary
        static Player() {

            // Create a path to the bitmaps
            string path = Environment.CurrentDirectory;

            foreach (PlayerActionType action in Enum.GetValues(typeof(PlayerActionType))) {

                Player.Sources.Add(action, new List<BitmapImage>());

                for (int frame = 0; frame < ActionTypeFrames[action]; frame++) {

                    Player.Sources[action].Add(new BitmapImage(
                        new Uri(string.Format(@"{0}\Player\adventurer-{1}-{2}.png", path, action, frame.ToString("00")))
                    ));
                }
            }
        }

        public void SetSource() {

            this.Source = Player.Sources[this.Action][GetActionFrame()];
        }

        private int GetActionFrame() {
            return this.Action switch
            {
                PlayerActionType.walk => this.Frame % 6,
                PlayerActionType.run => this.Frame % 6,
                PlayerActionType.die => this.Frame % 4,
                PlayerActionType.jump => this.Frame % 4,
                PlayerActionType.crouch => this.Frame % 4,
                PlayerActionType.crouchwalk => this.Frame % 6,
                PlayerActionType.fall => this.Frame % 2,
                PlayerActionType.attack1 => this.Frame % 5,
                _ => this.Frame % 4,
            };

        }

        // Set the time for each action in Millis
        public int ActionTime() {

            return this.Action switch
            {
                PlayerActionType.walk   =>    80,
                PlayerActionType.run    =>    80,
                PlayerActionType.die    =>    70,
                PlayerActionType.jump   =>    35,
                PlayerActionType.crouch =>    250,
                PlayerActionType.crouchwalk=> 250,
                PlayerActionType.fall   =>    60,
                PlayerActionType.attack1 => 175, // 150
                _                 =>    200,
            };

        }

        public void CollisionBox() {
            HitBox.Width = this.Width / 2;
            HitBox.Height = this.Height - 10;
            HitBox.X = Canvas.GetLeft(this) + (this.Width / 2);
            HitBox.Y = Canvas.GetTop(this) + 10;

            if (this.isCrouching || this.isCrouchWalking) {
                HitBox.Height = (this.Height - 10) / 2;
                HitBox.Y = Canvas.GetTop(this) + 10 + HitBox.Height;
            }

        }

        // Add this to the Canvas if To set the CollisionBox Visible
        public void CollisionBoxRender() {
            HitBoxRender.Width = this.HitBox.Width;
            HitBoxRender.Height = this.HitBox.Height;
            Canvas.SetLeft(HitBoxRender, HitBox.X);
            Canvas.SetTop(HitBoxRender, HitBox.Y);         
        }

        public new void DefaultSettings() {
            base.DefaultSettings();
            this.isWalking = false;
            this.isRunning = false;
            this.isJumping = false;
            this.isCrouching = false;
            this.isCrouchWalking = false;
            
        }

        public void Update() {
            Canvas.SetLeft(this, this.X); // position X of player
            Canvas.SetTop(this, this.Y);  // position Y of player
            playercontrols.Movement(this);
            this.CollisionBox();
            this.CollisionBoxRender();
            
            
            
        }

    }
}
