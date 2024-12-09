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

        private void addSfxCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSfxConfirmBtn_Click(object sender, EventArgs e)
        {
            // Prevent submission if all fields are not filled
            if (sfxFilePathTxt.Text != "")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // raise message
            else
            {
                string message = $"Not all fields have been filled out.{Environment.NewLine}Would you like to exit without adding a sound effect?";
                MessageBoxButtons yesnoBtns = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, "Missing sfx information!", yesnoBtns);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
        }

        // opens system file dialog window and gets selected file path
        private void getSfxPath(object sender, EventArgs e)
        {
            // calls the actual dialog box
            openFileDialog1.ShowDialog();

            // once path is selected, its returned as a string
            string path = openFileDialog1.FileName;
            string name = Path.GetFileNameWithoutExtension(path);

            if (path != null)
            {
                // fills text box on form
                sfxFilePathTxt.Text = path;

                // set default file name to SafeFileName
                sfxNameTxt.Text = name;
            }

            // TODO create hotkey method in separate cs file
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
