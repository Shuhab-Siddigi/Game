using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;

namespace Game {
    class Input{

        public static bool S { get; set; } = false;
        public static bool D { get; set; } = false;
        public static bool W { get; set; } = false;
        public static bool A { get; set; } = false;
        public static bool Space { get; set; } = false;
        public static bool Shift { get; set; } = false;


        public static void Update() {
            if (Keyboard.IsKeyDown(Key.W)) {
                D = true;
               // Trace.WriteLine("W");
            } else D = false;
            if (Keyboard.IsKeyDown(Key.A)) {
                A = true;
               // Trace.WriteLine("A");
            } else A = false;
            if (Keyboard.IsKeyDown(Key.S)) {
                S = true;
               // Trace.WriteLine("S");
            } else S = false;
            if (Keyboard.IsKeyDown(Key.D)) {
                D = true;
               //  Trace.WriteLine("D"); 
            } else D = false;
            if (Keyboard.IsKeyDown(Key.Space)) {
                Space = true;
               // Trace.WriteLine("Space");
            } else Space = false;
            if (Keyboard.IsKeyDown(Key.LeftShift)) {
                Shift = true;
               // Trace.WriteLine("Shift");
            } else Shift = false;

      

        }



    }
}
