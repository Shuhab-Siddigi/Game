using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game {



    enum ActionType {
        idle,
        walk,
        run,
        die,
        jump,
        crouch,
        fall,
        crouchwalk,
    }

    class Player : Image {
        public int Frame { get; set; } = 0;
        public ActionType Action { get; set; } = ActionType.idle;

        public double X { get; set; } = 0; // Position X
        public double Y {get; set;} = 0;   // Position Y 
        
        private static Dictionary<ActionType, List<BitmapImage>> Sources = new Dictionary<ActionType, List<BitmapImage>>();

        private PlayerControls playercontrols = new PlayerControls();

        public Rectangle HitBoxRender  = new Rectangle();
        public Rect HitBox  = new Rect();

        public bool isIdle { get; set; } = false;
        public bool isFalling { get; set; } = false;
        public bool isWalking { get; set; } = false;
        public bool isRunning { get; set; } = false;
        public bool isJumping { get; set; } = false;
        public bool isCrouching { get; set; } = false;
        public bool isCrouchWalking { get; set; } = false;
        public bool isBlockedLeft { get; set; } = false;
        public bool isBlockedRight { get; set; } = false;
        public bool isBlockedBellow { get; set; } = false;
        public bool isBlockedAbove { get; set; } = false;
        



        // Create a Dictionary to hold all frames for each Actions
        private static Dictionary<ActionType, int> ActionTypeFrames = new Dictionary<ActionType, int>() {
            {ActionType.idle,   4},
            {ActionType.die,    4},
            {ActionType.jump,   4},
            {ActionType.crouch, 4},
            {ActionType.walk,    6},
            {ActionType.run,    6},
            {ActionType.fall,    2},
            {ActionType.crouchwalk, 6},
        };

        // Define size of player 
        public Player(int SpawnPositionX, int SpawnPositionY,int Width,int Height) {
            this.Width = Width;
            this.Height = Height;
            this.Stretch = System.Windows.Media.Stretch.UniformToFill;
            X = SpawnPositionX;
            Y = SpawnPositionY;
        }

        // Static Constructor to load all the images to a Dictonary
        static Player() {

            // Create a path to the bitmaps
            string path = Environment.CurrentDirectory;

            foreach (ActionType action in Enum.GetValues(typeof(ActionType))) {

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
                ActionType.walk => this.Frame % 6,
                ActionType.run => this.Frame % 6,
                ActionType.die => this.Frame % 4,
                ActionType.jump => this.Frame % 4,
                ActionType.crouch => this.Frame % 4,
                ActionType.crouchwalk => this.Frame % 6,
                ActionType.fall => this.Frame % 2,
                _ => this.Frame % 4,
            };

        }

        // Set the time for each action in Millis
        public int ActionTime() {

            return this.Action switch
            {
                ActionType.walk   =>    80,
                ActionType.run    =>    80,
                ActionType.die    =>    70,
                ActionType.jump   =>    100,
                ActionType.crouch =>    250,
                ActionType.crouchwalk=> 250,
                ActionType.fall   =>    60,
                _                 =>    200,
            };

        }

        public void CollisionBox() {
            HitBox.Width = this.Width / 2;
            HitBox.Height = this.Height - 10;
            HitBox.X = Canvas.GetLeft(this) + (this.Width / 2);
            HitBox.Y = Canvas.GetTop(this) + 10;
        }

        // Add this to the Canvas if To set the CollisionBox Visible
        public void CollisionBoxRender() {
            HitBoxRender.Width = this.HitBox.Width;
            HitBoxRender.Height = this.HitBox.Height;
   
            Canvas.SetLeft(HitBoxRender, HitBox.X);
            Canvas.SetTop(HitBoxRender, HitBox.Y);         
        }

        public void DefaultSettings() {
            this.isWalking = false;
            this.isRunning = false;
            this.isJumping = false;
            this.isCrouching = false;
            this.isBlockedLeft = false;
            this.isBlockedRight = false;
            this.isBlockedBellow = false;
            this.isBlockedAbove = false;
            this.isCrouchWalking = false;

            this.isFalling = true;

            HitBoxRender.Stroke = Brushes.Black;
        }

        public void Update() {
            Canvas.SetLeft(this, this.X); // position X of player
            Canvas.SetTop(this, this.Y);  // position Y of player
            this.CollisionBox();
            this.CollisionBoxRender();
            playercontrols.Movement(this);
            // If the player is not touching anything
            
        }

    }
}
