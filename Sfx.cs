using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soundboard_sandbox
{
    // create class to store sfx data
    // includes filepath, hotkey, length, volume, etc.
    public class Sfx
    {
        // class vars
        // note: XmlSerializer requires public fields to function
        public string Name { get; set; }
        public string FilePath { get; set; }         // TODO change filepath type to Path
        public string Hotkey { get; set; }      // TODO use proper hotkey var type
        public float Volume { get; set; }       // 0.0 - 1.0
        // TODO public List<string> Tags { get; set; }
        // TODO public MIDI KEY

        // TODO create overloaded method with tags
        public Sfx(string name, string hotkey, string filePath, float volume)
        {
            this.Name = name;
            this.FilePath = filePath;
            this.Hotkey = hotkey;   // can be empty
            this.Volume = volume;
            //this.filePath = getFilePath(filePath);
        }
        private Sfx() { } // default constructor for XmlSerializer

        // custom toString
        public override string ToString()
        {
            return $"{Name} - {FilePath} - {Hotkey}";
        }

        // parse the filepath and assign it to the filePath var
        //private string getFilePath(string newFilePath)
        //{
        //    // TODO exception handling
        //    filePath = Path.GetFullPath(filePath);
        //    return "";
        //}
    }
}
