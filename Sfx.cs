using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soundboard_sandbox
{
    // create class to store sfx data
    // includes name, filepath, hotkey, volume, etc.
    public class Sfx
    {
        // ==== CLASS FIELDS ====
        // note: XmlSerializer requires public fields to function
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Hotkey { get; set; }
        public KeyEventArgs HotkeyEventArgs { get; set; }
        public float VolumeFloat { get; set; }       // 0.0 - 1.0
        public string Volume { get; set; }
        // TODO public List<string> Tags { get; set; }
        // TODO public MIDI KEY

        public Sfx(string name, string hotkey ,KeyEventArgs hkeventargs, string filePath, float volumefloat)
        {
            this.Name = name;
            this.FilePath = filePath;
            this.Hotkey = hotkey;           // can be null
            this.HotkeyEventArgs = hkeventargs;   // can be null
            this.Volume = $"{volumefloat * 100}%";
            this.VolumeFloat = volumefloat;
        }
        private Sfx() { } // default constructor for XmlSerializer

        // removes all hotkey info from this sfx
        public void ClearHotkeyInfo()
        {
            this.Hotkey = null;
            this.HotkeyEventArgs = null;

            int index = Program.sfxLibBindSource.IndexOf(this);

            // refreshes data for that sfx in the gui
            Program.sfxLibBindSource.ResetItem(index);
        }

        // custom toString
        public override string ToString()
        {
            //return $"{Name} - {FilePath} - {Hotkey}";
            return Name;
        }

        // TODO file path parsing
    }
}
