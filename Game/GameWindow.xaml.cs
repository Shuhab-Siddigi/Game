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

    static class Settings {

        static public int WindowHeight { get; } = 600;
        static public int WindowWidth { get; } = 800;

    }

    public partial class GameWindow : Window {

        

        // Game tick 
        DispatcherTimer GameTick = new DispatcherTimer();

        // Player Instances
        private double yPos = 0;

        // Game Instances
        Background background = new Background();
        
        public GameWindow() {
    
            InitializeComponent();
            
            GameTick.Tick += gameTickUpdater;
            GameTick.Interval = new TimeSpan(0, 0, 0, 0,50);
            string path = Environment.CurrentDirectory;
            
            startGame();

        }

        private void startGame() {

            background.SetSource();
            



            Canvas.SetTop(Player, (Settings.WindowHeight/2)-Player.Height);
            Canvas.SetLeft(Player,(Settings.WindowWidth/2)-Player.Width);
            
            GameTick.Start();
            
        }


        // Player movement

        private void Scene_KeyDown(object sender, KeyEventArgs e) {
            
            if(e.Key == Key.D) {
                Player.Action = ActionType.run;
                
            }
            if (e.Key == Key.W) {
                Player.Action = ActionType.jump;    
            }
            if(e.Key == Key.S) {
                Player.Action = ActionType.crouch;
            }
        
            
        }

        private void Scene_KeyUp(object sender, KeyEventArgs e) {

            Player.Action = ActionType.idle;
        
        }

        private void gameTickUpdater(object sender, EventArgs e) {
            
            
            Player.SetSource();
            Canvas.SetTop(Player, Canvas.GetTop(Player) - yPos);
            Player.Frame += 1;


        }

    
        


    }
}
