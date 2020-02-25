using System.Windows;
using System.Drawing.Imaging;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Threading;

namespace Game
{

    public partial class GameWindow : Window {

        int xPos = 0;
        int yPos = 0;

        Player player = new Player(0,0);

        public GameWindow() {
           
            
            InitializeComponent();

            // Game tick 
            DispatcherTimer Timer = new DispatcherTimer();

            Timer.Tick += new EventHandler(gameUpdate);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer.Start();


            Scene.Children.Add(player);











        }


        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {

            if (e.Key == System.Windows.Input.Key.W) { this.yPos -= 3; Trace.WriteLine("UP "  + yPos); }
            if (e.Key == System.Windows.Input.Key.S) { this.yPos += 3; Trace.WriteLine("DOWN" + yPos); }
            if (e.Key == System.Windows.Input.Key.D) { this.xPos += 3; Trace.WriteLine("LEFT" + xPos); }
            if (e.Key == System.Windows.Input.Key.A) { this.xPos -= 3; Trace.WriteLine("RIGHT"+ xPos); }


        }

        private void gameUpdate(object sender, EventArgs e) {

            Canvas.SetLeft(player, xPos);
            Canvas.SetTop(player, yPos);
           
           
       




        }




    }
}
