using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soundboard_sandbox
{
    public partial class OpenFileForm : Form
    {
        public OpenFileForm()
        {
            InitializeComponent();
        }

        private void getSfxPath(object sender, EventArgs e)
        {
            // calls the actual dialog box
            openFileDialog1.ShowDialog();

            // once path is selected, its returned as a string
            string path = openFileDialog1.FileName;
            string name = Path.GetFileNameWithoutExtension(path);

            if (path != null)
            {
                sfxFilePathTxt.Text = path;

                // set default file name to SafeFileName
                sfxNameTxt.Text = name;
            }

            // TODO create hotkey method in separate cs file
        }

        private void addSfxCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSfxConfirmBtn_Click(object sender, EventArgs e)
        {
            // TODO: PREVENT SUBMISSION IF ALL FIELDS ARE NOT FILLED
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // -- FORM GETTERS to be accessed in MainForm --
        public string GetName() 
        {
            return sfxNameTxt.Text;
        }

        public string GetHotkey()
        {
            //TODO
            //if (hotkey != null)
            //    return hotkey;
            //else
            //    return null;

            return "ctrl + h";
        }

        public string GetPath()
        {
            if (sfxFilePathTxt.Text != null)
                return sfxFilePathTxt.Text;
            else 
                return null;
        }

    }
}
