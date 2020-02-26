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

namespace Game {

    public partial class GameWindow : Window {



        Player player = new Player();




        public GameWindow() {





            InitializeComponent();

            // Game tick 
            DispatcherTimer Timer = new DispatcherTimer();
            //Timer.Tick += new EventHandler(backgroundUpdater);
            Timer.Tick += new EventHandler(elementUpdater);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Start();

            player.setAction(1, 0);
            Scene.Children.Add(player);




        }
        // Player movement

        private void movePlayer(object sender, KeyEventArgs e) {

            if (e.Key == Key.W) {
                player.yPosition -= 1;
                Trace.WriteLine("UP");
            }
            if (e.Key == Key.A) {
                player.xPosition -= 1;
                Trace.WriteLine("Left");
            }
            if (e.Key == Key.S) {
                 player.yPosition += 1;
                 Trace.WriteLine("Down");
            }
            if (e.Key == Key.D) {
                player.xPosition += 1;
                Trace.WriteLine("Right");
            }
        }

        private void elementUpdater(object sender, EventArgs e) {

            player.update();

            Trace.WriteLine("Element timer");
        }



        /*
        private void backgroundUpdater(object sender, EventArgs e) {
            Scene.Children.Add(new Player());
        
          
            Trace.WriteLine("Background Timer");

        }
        */


    }
}
