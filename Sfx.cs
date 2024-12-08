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
        string name;
        string hotkey;      // TODO how to store hotkey?
        int volume;         // 0-100?
        string filePath;
        string[] tags;

        // TODO ? create overloaded method with tags
        public Sfx(string name, string hotkey, string filePath)
        {
            this.name = name;   // TODO CLEAN NAME
            this.hotkey = hotkey;   // can be empty
            this.filePath = filePath;
            //this.filePath = getFilePath(filePath);
        }

        // must make accessors public for listbox to read
        public string Name
        { 
            get { return this.name; } 
        }
        public string Hotkey
        {
            get { return this.hotkey; }
        }
        public string FilePath
        {
            get { return this.filePath; }
        }
        public string[] Tags
        {
            get { return this.tags; }
        }

        // parse the filepath and assign it to the filePath var
        private string getFilePath(string newFilePath)
        {
            // TODO exception handling
            filePath = Path.GetFullPath(filePath);
            return "";
        }
    }
}
