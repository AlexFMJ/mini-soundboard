﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soundboard_sandbox

// Alex Johnson
// Final Project
//This program is designed to simply play sound effects (of any length) using a graphical interface and hotkeys.
//The user is able to define their own hotkeys when adding a sound to the library.
//They are then able to save and load their sound library for later use.
{
    internal static class Program
    {
        // ==== GLOBAL VARS ====
        public static List<Sfx> sfxLibrary = new List<Sfx>();  // List to be bound

        // BindingSource allows for automatic refreshing of data on listBox
        // when adding or removing items from soundLibrary list
        public static BindingSource sfxLibBindSource = new BindingSource();

        // keybind dict
        public static Hotkeys localHotkeys = new Hotkeys();


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // fix DPI scaling issues
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // fixes DPI scaling
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
