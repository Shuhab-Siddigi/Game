using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using System.Linq;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Threading;

namespace Game {

    static class Settings {

        static public int WindowHeight { get; } = 600;
        static public int WindowWidth { get; } = 800;

       


    }

    public partial class GameWindow : Window {

        // Game tick 
       
        static Player player = new Player();
        
        Stopwatch FrameCounter = new Stopwatch();




        public GameWindow() {

            InitializeComponent();
            startGame();
        }

        private void startGame() {

            
            CompositionTarget.Rendering += OnUpdate;
            Scene.Children.Add(player);
            FrameCounter.Start();

        }

        // Player movement

        private void Scene_KeyDown(object sender, KeyEventArgs e) {

            if (e.Key == Key.D) {
                player.Action = ActionType.run;
                player.xPos += 4;
            }
            if (e.Key == Key.A) {
                player.Action = ActionType.run;
                player.xPos -= 4;
            }
            if (e.Key == Key.W) {
                player.Action = ActionType.jump;
                player.yPos -= 4;
            }
            if (e.Key == Key.S) {
                player.Action = ActionType.crouch;
                player.yPos += 4;
            }


        }

        private void Scene_KeyUp(object sender, KeyEventArgs e) {

            player.Action = ActionType.idle;

       

        }


        private void OnUpdate(object sender, EventArgs e) {

            
            if (FrameCounter.ElapsedMilliseconds > player.ActionTime()) {
                
                player.SetSource();
                player.Frame += 1;
                FrameCounter.Restart();

            }

        }




    }
}
