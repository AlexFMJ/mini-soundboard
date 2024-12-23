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
                _keyString = CreateHotkeyString();
            }
        }
        public string KeyString 
        { 
            get {  return _keyString; } 
            set
            {
                _keyString = CreateHotkeyString();
            }
        }

        public HotkeyInfo() { }
        public HotkeyInfo(Keys keyCode, Keys keyData)
        {
            this.KeyData = keyData;
            KeyString = CreateHotkeyString();
        }
        
        public string CreateHotkeyString()
        {
            string tempString = "";

            // using the Modifiers bitmask to return only modifier keys if used
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

            Console.WriteLine(tempString);

            return tempString;
        }
    }
}
