﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace soundboard_sandbox
{
    // create class to store sfx data
    // includes filepath, hotkey, length, volume, etc.
    public class Sfx
    {
        //// class vars
        public string Name { get; set; }
        public string FilePath { get; set; }         // TODO change filepath type to Path
        public string Hotkey { get; set; }      // TODO use proper hotkey var type
        public double Volume { get; set; }       // 0.0 - 1.0
        // TODO public List<string> Tags { get; set; }
        // TODO public MIDI KEY

        // TODO create overloaded method with tags
        public Sfx(string name, string hotkey, string filePath)
        {
            this.Name = name;
            this.FilePath = filePath;
            this.Hotkey = hotkey;   // can be empty
            this.Volume = 1.0;
            //this.filePath = getFilePath(filePath);
        }
        private Sfx() { } // default constructor for serialization

        // parse the filepath and assign it to the filePath var
        //private string getFilePath(string newFilePath)
        //{
        //    // TODO exception handling
        //    filePath = Path.GetFullPath(filePath);
        //    return "";
        //}
    }
}
