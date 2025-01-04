using System;

namespace mini_soundboard
{
    // create class to store sfx data
    // includes name, filepath, hotkey, volume, etc.
    public class Sfx
    {
        // ==== CLASS FIELDS ====
        private HotkeyInfo _hotkeyInfo;
        private float _volumeFloat;

        // note: XmlSerializer requires public fields to function
        public string Name { get; set; }
        public string FilePath { get; set; }
        public HotkeyInfo HotkeyInfo
        {
            get { return _hotkeyInfo; } 
            set
            {
                _hotkeyInfo = value;

                // add hotkey when assigned (if not null)
                if (value != null)
                {
                    Program.kbHotkeys.AssignHotkey(this);
                }
            }
        }
        public string Hotkey
        {
            get
            {
                if (_hotkeyInfo == null) return "";
                else return _hotkeyInfo.KeyString;
            }
        }
        public float VolumeFloat 
        {
            get { return _volumeFloat; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("Value must be between 0.00 and 1.00");
                }
                else
                {
                    this._volumeFloat = value;
                    this.Volume = $"{this._volumeFloat * 100}%";
                }
            }
        }       // 0.0 - 1.0
        public string Volume { get; set; }

        // TODO public List<string> Tags { get; set; }

        public Sfx() { }    // default constructor for XmlSerializer

        public Sfx(string name, string filePath, HotkeyInfo hotkeyInfo, float volumefloat)
        {
            this.Name = name;
            this.FilePath = filePath;
            this.HotkeyInfo = hotkeyInfo;
            this.VolumeFloat = volumefloat;
        }
       

        // Clears all information about hotkeys from this Sfx instance
        public void ClearHotkeyFields()
        {
            this.HotkeyInfo = null;

            int index = Program.sfxLibBindSource.IndexOf(this);

            // refreshes data for that sfx in the gui
            Program.sfxLibBindSource.ResetItem(index);
        }

        // TODO file path parsing
    }
}
