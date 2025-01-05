using NAudio.Midi;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mini_soundboard
{
    public partial class addSfxForm : Form
    {
        HotkeyInfo hotkeyInfo;
        MidiIn midiIn = null;

        public addSfxForm()
        {
            InitializeComponent();

            midiIn = new MidiIn(Program.midiDeviceIndex);

            // subscribe to midiIn events
            midiIn.ErrorReceived += midiIn_ErrorRecieved;
            midiIn.MessageReceived += midiIn_MessageRecieved;
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
            using (OpenFileDialog openSoundFile = new OpenFileDialog())
            {
                openSoundFile.Title = "Load Sound File";
                openSoundFile.Filter = "Supported File Types (.mp3, .m4a, .aac .wav)|*.mp3;*.MP3;*.m4a;*.M4A*.aac;*.AAC;*.wav;*.WAV"+
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
            addSfxConfirmBtn.Focus();
        }

        // reflect value from slider
        private void sfxVolumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            volumeValLbl.Text = sfxVolumeTrackBar.Value.ToString();
        }

        // SetHotkeyBtn OnFocus
        private void sfxSetHotkeyBtn_Enter(object sender, EventArgs e)
        {
            sfxSetHotkeyBtn.ForeColor = Color.Red;
            sfxSetHotkeyBtn.Text = "Press a hotkey combination";
            midiIn.Start();
        }
        // SetHotkeyBtn leave focus
        private void sfxSetHotkeyBtn_Leave(object sender, EventArgs e)
        {
            //if (hotkeyInfo == null || hotkeyInfo.KeyData == Keys.None)
            if (hotkeyInfo == null || hotkeyInfo.KeyString == "")
            {
                sfxSetHotkeyBtn.ForeColor = Color.Gray;
                sfxSetHotkeyBtn.Text = "click to set Hotkey";
            }
            else
            {
                sfxSetHotkeyBtn.ForeColor = Color.Black;
                sfxSetHotkeyBtn.Text = hotkeyInfo.KeyString;
            }
            midiIn.Stop();
        }

        // record hotkey input to hotkeyDict
        private void sfxSetHotkeyBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (Program.ReservedKeys.Contains(e.KeyCode)) return;

            // if hotkeys overlap, ask to unset old hotkey
            if (Program.HotkeyDict.CheckForConflict(e.KeyData) == Hotkeys.assignStatus.In_Use)
            {
                // if in use, return early
                this.ActiveControl = null;
                return;
            }

            // otherwise assign the hotkey as needed
            hotkeyInfo = new HotkeyInfo(e.KeyData);

            // remove focus from button
            this.ActiveControl = null;
        }

        // ==== MIDI EVENT LISTENER ====
        private void midiIn_ErrorRecieved(object sender, MidiInMessageEventArgs e)
        {
            Console.WriteLine("Error message! " + e.MidiEvent);
        }

        private void midiIn_MessageRecieved(object sender, MidiInMessageEventArgs e)
        {

            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
            {
                try
                {
                    MidiNote note = new MidiNote(e.MidiEvent as NoteEvent);

                    // if hotkeys overlap, ask to unset old hotkey
                    if (Program.HotkeyDict.CheckForConflict(note) == Hotkeys.assignStatus.In_Use)
                    {
                        // if in use, return early
                        this.BeginInvoke(new Action(() => { ActiveControl = null; }));
                        return;
                    }

                    // otherwise assign the hotkey as needed
                    hotkeyInfo = new HotkeyInfo(e.MidiEvent as NoteEvent);

                    // remove focus from button
                    this.BeginInvoke(new Action(() => { ActiveControl = null; }));

                    Console.WriteLine("Received message! " + note);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void disposeMidiDevice()
        {
            if (midiIn != null)
            {
                midiIn.Dispose();
                midiIn = null;
            }
            return;
        }

        private void unsetHKBtn_Click(object sender, EventArgs e)
        {
            Hotkeys.assignStatus status;

            if (this.hotkeyInfo != null)
            {
                status = Hotkeys.assignStatus.In_Use;

                switch (this.hotkeyInfo.Type)
                {
                    case HotkeyInfo.HKType.none:
                        break;
                    case HotkeyInfo.HKType.keyboard:
                        status = Program.HotkeyDict.CheckForConflict(hotkeyInfo.KeyData);
                        break;
                    case HotkeyInfo.HKType.midi:
                        status = Program.HotkeyDict.CheckForConflict(hotkeyInfo.MidiNote);
                        break;
                    default:
                        break;
                }

                if (status == Hotkeys.assignStatus.Removed)
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

        private void addSfxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            disposeMidiDevice();
        }
    }
}
