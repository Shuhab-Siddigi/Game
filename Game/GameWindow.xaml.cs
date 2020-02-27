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



        Player player = new Player();

        int counter = 0;


        public GameWindow() {




          
            InitializeComponent();

            // Game tick 
            DispatcherTimer Timer = new DispatcherTimer();
         
            Timer.Tick += new EventHandler(elementUpdater);
            Timer.Interval = new TimeSpan(0, 0, 0, 0,5);
            Timer.Start();

            
            Scene.Children.Add(player);
         



        }
        // Player movement

        private void movePlayer(object sender, KeyEventArgs e) {

            if (e.Key == Key.W) {
                player.yPosition -= 10;
                Trace.WriteLine("UP");
            }
           
            if (e.Key == Key.S) {
                player.yPosition += 10;
                
                Trace.WriteLine("Down");
            }
            if (e.Key == Key.D) {
                player.xPosition += 10;
                counter++;
                Trace.WriteLine("Right");
            }
            if (e.Key == Key.A) {
                
                player.xPosition -= 10;
                Trace.WriteLine("Left");
            }
            if (counter >= 5) {
                counter = 0;
            }
        }

        private void elementUpdater(object sender, EventArgs e) {

            
            player.update();
            player.setAction(1, counter);
            
            
            Trace.WriteLine("Element timer");
        }

    
        


    }
}
