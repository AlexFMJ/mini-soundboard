using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_soundboard
{
    // create class to store sfx data
    // includes name, filepath, hotkey, volume, etc.
    public class Sfx
    {
        // ==== CLASS FIELDS ====
        private HotkeyInfo _hotkeyInfo;

        // note: XmlSerializer requires public fields to function
        public string Name { get; set; }
        public string FilePath { get; set; }
        public HotkeyInfo HotkeyInfo
        {
            get { return _hotkeyInfo; } 
            set
            {
                _hotkeyInfo = value;

                // add hotkey if assigned
                Program.localHotkeys.AssignHotkey(this);
            }
        }
        public string Hotkey
        {
            get { return _hotkeyInfo.KeyString; }
        }
        public float VolumeFloat { get; set; }       // 0.0 - 1.0
        public string Volume { get; set; }

        // TODO public List<string> Tags { get; set; }
        // TODO public MIDI KEY

        public Sfx(string name, string filePath, HotkeyInfo hotkeyInfo, float volumefloat)
        {
            this.Name = name;
            this.FilePath = filePath;
            this.HotkeyInfo = hotkeyInfo;
            setVolume(volumefloat);
        }
       
        public Sfx() { }    // default constructor for XmlSerializer

        public void setVolume(float volumefloat)
        {
            if (volumefloat < 0 || volumefloat > 1)
            {
                throw new ArgumentOutOfRangeException("Value must be between 0.00 and 1.00");
            }
            else
            {
                this.VolumeFloat = volumefloat;
                this.Volume = $"{volumefloat * 100}%";
            }
        }

        // Clears all information about hotkeys from this Sfx instance
        public void ClearHotkeyFields()
        {
            this.HotkeyInfo = null;

            int index = Program.sfxLibBindSource.IndexOf(this);

            // refreshes data for that sfx in the gui
            Program.sfxLibBindSource.ResetItem(index);
        }

        // Overrides ToString, only returning name
        public override string ToString()
        {
            //return $"{Name} - {FilePath} - {Hotkey}";
            return Name;
        }

        // TODO file path parsing
    }
}
