using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace mini_soundboard
{
    public partial class editSfxForm : Form
    {
        HotkeyInfo hotkeyInfo;
        Sfx currentSound;

        public editSfxForm(Sfx inputSound)
        {
            currentSound = inputSound;
            InitializeComponent();
        }

        // On form load, populate elements
        private void editSfxForm_Load(object sender, EventArgs e)
        {
            sfxFilePathTxt.Text = currentSound.FilePath;
            sfxNameTxt.Text = currentSound.Name;
            if (currentSound.HotkeyInfo != null)
            {
                hotkeyInfo = currentSound.HotkeyInfo;
                sfxSetHotkeyBtn.ForeColor = Color.Black;
                sfxSetHotkeyBtn.Text = hotkeyInfo.KeyString;
            }
            float volume = (currentSound.VolumeFloat * 100);
            sfxVolumeTrackBar.Value = (int)volume;
            volumeValLbl.Text = sfxVolumeTrackBar.Value.ToString();
        }

        private void editSfxCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editSfxConfirmBtn_Click(object sender, EventArgs e)
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
            using (OpenFileDialog openSoundFile = new OpenFileDialog())
            {
                openSoundFile.Title = "Load Sound File";
                openSoundFile.Filter = "Supported File Types (.mp3, .m4a, .aac .wav)|*.mp3;*.MP3;*.m4a;*.M4A*.aac;*.AAC;*.wav;*.WAV" +
                                       "|aac Files|*.aac;*.AAC" +
                                       "|mp3 Files|*.mp3;*.MP3" +
                                       "|m4a Files|*m4a;.M4A" +
                                       "|wav Files|*.wav;*.WAV";

                // open file for reading
                if (openSoundFile.ShowDialog() == DialogResult.OK)
                {
                    // TODO file path checks
                    // once path is selected, its returned as a string
                    string path = openSoundFile.FileName;

                    string name = Path.GetFileNameWithoutExtension(path);

                    if (path != null)
                    {
                        // fills text box on form
                        sfxFilePathTxt.Text = path;

                        // set default file name to SafeFileName
                        sfxNameTxt.Text = name;
                    }
                }
            }
            // select addSfxConfirmBtn when returning to form
            editSfxConfirmBtn.Focus();
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
            if (hotkeyInfo == null || hotkeyInfo.KeyData == Keys.None)
            {
                sfxSetHotkeyBtn.ForeColor = Color.Gray;
                sfxSetHotkeyBtn.Text = "click to set Hotkey";
            }
            else
            {
                sfxSetHotkeyBtn.ForeColor = Color.Black;
                sfxSetHotkeyBtn.Text = hotkeyInfo.KeyString;
            }
        }

        private void sfxSetHotkeyBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (Program.ReservedKeys.Contains(e.KeyCode)) return;

            // if hotkeys overlap, ask to unset old hotkey
            if (Program.localHotkeys.CheckForConflict(e.KeyData) == Hotkeys.assignStatus.In_Use)
            {
                // if in use, return early
                this.ActiveControl = null;
                return;
            }

            // otherwise assign the hotkey as needed
            if (hotkeyInfo == null)
            {
                hotkeyInfo = new HotkeyInfo(e.KeyData);
            }
            else
            {
                hotkeyInfo.KeyData = e.KeyData;
            }

            // remove focus from button
            this.ActiveControl = null;
        }

        private void unsetHKBtn_Click(object sender, EventArgs e)
        {
            if (this.hotkeyInfo != null)
            {
                if (Program.localHotkeys.CheckForConflict(hotkeyInfo.KeyData) == Hotkeys.assignStatus.Removed)
                {
                    hotkeyInfo = null;
                    sfxSetHotkeyBtn.Text = "click to set Hotkey";
                    return;
                }
            }
            else
            {
                hotkeyInfo = null;
                sfxSetHotkeyBtn.Text = "click to set Hotkey";
            }
        }

        // ==== FORM GETTERS to be accessed in MainForm ====
        public string GetName()
        {
            return sfxNameTxt.Text;
        }

        public HotkeyInfo GetHotkeyInfo()
        {
            return hotkeyInfo;
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
    }
}
