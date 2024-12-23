using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_soundboard
{
    // replaces KeyEventArgs to allow for serialization with a default constructor
    public class HotkeyEventInfo
    {
        public Keys KeyCode { get; set;}
        public Keys KeyData { get; set;}
        public HotkeyEventInfo() { }
        public HotkeyEventInfo(Keys keyCode, Keys keyData)
        {
            this.KeyCode = keyCode;
            this.KeyData = keyData;
        }
    }
}
