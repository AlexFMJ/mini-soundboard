using NAudio.Midi;
using System.Windows.Forms;

namespace mini_soundboard
{
    // replaces KeyEventArgs to allow for serialization with a default constructor
    public class HotkeyInfo
    {
        public enum HKType
        {
            none = 0,
            keyboard = 1,
            midi = 2,
        }

        private string _keyString;
        private Keys _keyData;
        private HKType _type = HKType.none;
        private MidiNote _note;

        public Keys KeyData
        {
            get { return _keyData; }
            set
            { 
                _keyData = value; 
                SetHotkeyString();
                _type = HKType.keyboard;
            }
        }
        public string KeyString 
        { 
            get {  return _keyString; } 
        }

        public MidiNote MidiNote
        {
            get { return _note; }
            set
            {
                _note = value;
                _type = HKType.midi;
                _keyString = MidiNote.Name;
            }
        }
        public HKType Type { get { return _type; } }

        // Constructors
        public HotkeyInfo() { }
        public HotkeyInfo(Keys keyData)
        {
            KeyData = keyData;
            _type = HKType.keyboard;
        }
        public HotkeyInfo(NoteEvent note)
        {
            // assign MidiNote properties
            MidiNote = new MidiNote(note);

            // change HotkeyInfo properties to match
            _keyString = MidiNote.Name;
            _type = HKType.midi;
        }
        
        // Sets _hotkeyString to match the assigned data
        public void SetHotkeyString()
        {
            string tempString = "";

            if (Type == HKType.midi) { _keyString = MidiNote.Name; return; }

            // assign empty string and return if keydata is None
            if (KeyData == Keys.None)
            {
                _keyString = tempString;
                return;
            }

            // using the Keys.Modifiers bitmask to return only modifier keys if used
            // the ( & ) symbol is the bitwise AND operator used as an "intersect" bitmask operator
            Keys modifiersUsed = KeyData & Keys.Modifiers;

            // use Keys.[modifierName] as a bitmask, if it matches, that key was pressed
            if ((modifiersUsed & Keys.Control) == Keys.Control)
            {
                tempString += "ctrl + ";
            }
            if ((modifiersUsed & Keys.Alt) == Keys.Alt)
            {
                tempString += "alt + ";
            }
            if ((modifiersUsed & Keys.Shift) == Keys.Shift)
            {
                tempString += "shift + ";
            }

            // add the character to the end
            // the NOT (~) operator creates an inverted bitmask
            // combined with the AND operator, it only returns the non-modifier Keys data (aka. the char)
            tempString += (KeyData & ~Keys.Modifiers);

            // assign keystring
            _keyString = tempString;

            return;
        }
    }
}
