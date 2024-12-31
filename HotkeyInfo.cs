using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_soundboard
{
    // replaces KeyEventArgs to allow for serialization with a default constructor
    public class HotkeyInfo
    {
        private string _keyString;
        private Keys _keyData;

        public Keys KeyData
        {
            get { return _keyData; }
            set
            { 
                _keyData = value; 
                SetHotkeyString();
            }
        }
        public string KeyString 
        { 
            get {  return _keyString; } 
        }

        public HotkeyInfo() { }
        public HotkeyInfo(Keys keyData)
        {
            this.KeyData = keyData;
        }
        
        // Sets _hotkeyString to match the keyData of this object
        public void SetHotkeyString()
        {
            string tempString = "";

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
