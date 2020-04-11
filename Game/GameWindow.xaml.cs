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

        Player player = new Player();
        PlayerControls SetControls = new PlayerControls();
        
        public GameWindow() {

            InitializeComponent();
            startGame();
        }

        private void startGame() {

            CompositionTarget.Rendering += OnUpdate;
            Scene.Children.Add(player);
           
        }

        private void OnUpdate(object sender, EventArgs e) {

            SetControls.Movement(player);

        }

    
    }
}
