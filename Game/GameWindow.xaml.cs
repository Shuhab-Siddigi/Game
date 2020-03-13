using System.Windows;
using System.Drawing.Imaging;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Game {

    public partial class GameWindow : Window {


        // Game tick 
        DispatcherTimer GameTick = new DispatcherTimer();
        
        // Player Instances

        
        public GameWindow() {
    
            InitializeComponent();
            
            GameTick.Tick += gameTickUpdater;
            GameTick.Interval = new TimeSpan(0, 0, 0, 0,20);
            string path = Environment.CurrentDirectory;
            
            startGame();

        }

        private void startGame() {

            Canvas.SetTop(Player, 100);
            Canvas.SetLeft(Player, 100);

            GameTick.Start();
            
        }


        // Player movement

        private void Scene_KeyDown(object sender, KeyEventArgs e) {
            
            if(e.Key == Key.D) {
                Player.Frame += 1;
            }
            
        }

        private void Scene_KeyUp(object sender, KeyEventArgs e) {

        }

        private void gameTickUpdater(object sender, EventArgs e) {

            Player.SetSource();
            
        }

    
        


    }
}
