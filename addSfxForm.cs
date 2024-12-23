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

namespace mini_soundboard
{
    public partial class addSfxForm : Form
    {
        KeyEventArgs currentHotkey;

        public addSfxForm()
        {
            InitializeComponent();
        }

        private void addSfxCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSfxConfirmBtn_Click(object sender, EventArgs e)
        {
            // Prevent submission if path field is not filled
            if (sfxFilePathTxt.Text == "")
            {
                // raise message
                string message = $"No file path was entered.{Environment.NewLine}Would you like to exit without adding a sound effect?";
                MessageBoxButtons yesnoBtns = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, "Missing sfx information!", yesnoBtns);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            // select addSfxConfirmBtn when returning to form
            addSfxConfirmBtn.Focus();
        }

        // -- FORM GETTERS to be accessed in MainForm --
        public string GetName() 
        {
            return sfxNameTxt.Text;
        }

        public string GetHotkeyString()
        {
            string result = "";

            if (currentHotkey != null) 
            {
                result = Program.localHotkeys.KeysToString(currentHotkey);
            }

            return result;
        }

        public KeyEventArgs GetHotkeyEventArgs()
        {
            return currentHotkey;
        }

        public string GetPath()
        {
            if (sfxFilePathTxt.Text != null)
                return sfxFilePathTxt.Text;
            else 
                return null;
        }

        public float GetVolume()
        {
            // NAudio expects a float value between 0.0 - 1.0
            float sfxVolume = (float)sfxVolumeTrackBar.Value / 100;
            Console.WriteLine(sfxVolume.GetType());
            Console.WriteLine(sfxVolume);
            return sfxVolume;
        }

        // reflect value from slider
        private void sfxVolumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            volumeValLbl.Text = sfxVolumeTrackBar.Value.ToString();
        }

        // OnFocus
        private void sfxSetHotkeyBtn_Enter(object sender, EventArgs e)
        {
            sfxSetHotkeyBtn.ForeColor = Color.Red;
            sfxSetHotkeyBtn.Text = "Press a hotkey combination";
        }
        // leave focus
        private void sfxSetHotkeyBtn_Leave(object sender, EventArgs e)
        {
            if (currentHotkey != null)
            {
                sfxSetHotkeyBtn.ForeColor = Color.Black;
                sfxSetHotkeyBtn.Text = Program.localHotkeys.KeysToString(currentHotkey);
            }
            else
            {
                sfxSetHotkeyBtn.ForeColor = Color.Gray;
                sfxSetHotkeyBtn.Text = "click to set Hotkey";
            }
        }

        private void sfxSetHotkeyBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.Capital) return;

            // print info on keypress
            Console.WriteLine("Code - Data - Value");
            Console.WriteLine($"{e.KeyCode} - {e.KeyData} - {e.KeyValue}");

            // if hotkeys overlap, ask to unset old hotkey
            Program.localHotkeys.UnsetHotkey(e.KeyData);

            currentHotkey = e;

            // remove focus from button
            this.ActiveControl = null;
        }
    }
}
