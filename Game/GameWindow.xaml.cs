using System.Windows;
using System.Drawing;
using System;

// For some reason bitmaps cannot be used unless the newest version is found.
// which can be found by pressing on Graphics and installing from below!!
/*
public abstract void (Graphics g){

}
*/

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window {



        public GameWindow() {
            InitializeComponent();
            Bitmap image1 = new Bitmap(@"C:\Users\shuha\Source\Repos\Game\Game\Bitmaps\Adventurer\Individual Sprites\adventurer-attack1-00.png", true);


        }

       


    
    }
}
