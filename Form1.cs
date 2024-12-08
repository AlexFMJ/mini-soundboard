using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace soundboard_sandbox
{
    public partial class MainForm : Form
    {
        // establish NAudio objects
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        // List to be bound
        static List<Sfx> soundLibrary = new List<Sfx>();

        // BindingSource allows for automatic refreshing of data on listBox
        // when adding or removing items from soundLibrary list
        BindingSource soundLibBindSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            // initialize the output device here 
            // we will frequently use it
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackStopped;
        }

        // opens new form to enter new sfx information
        private void AddSFX_Click(object sender, EventArgs e)
        {
            // the using block will correctly dispose of the form when closed
            using (OpenFileForm addSfxForm = new OpenFileForm())
            { 
                // Checks that the 'Add' button was used to close
                // the form, not the cancel button
                if (addSfxForm.ShowDialog() == DialogResult.OK)
                {
                    // calls these methods from Form2
                    soundLibBindSource.Add(new Sfx(
                        addSfxForm.GetName(),
                        addSfxForm.GetHotkey(),
                        addSfxForm.GetPath()
                    ));
                }
            }
        }

        // delete currently selected sfx from sounds list object
        private void DeleteSFX_Click(object sender, EventArgs e)
        {
            int rowIndex;

            // prevent error when clicking delete with no selection
            if (sfxGridView.CurrentRow == null)
                return;
            else
                rowIndex = sfxGridView.CurrentRow.Index;

            // verifies that a valid index is selected
            if (rowIndex >= 0 && rowIndex < soundLibrary.Count)
            {
                Console.WriteLine($"Removing item: {soundLibrary[rowIndex].Name} at index {rowIndex}");
                
                // must use RemoveAt to access by index
                soundLibBindSource.RemoveAt(rowIndex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set data source to bind
            soundLibBindSource.DataSource = soundLibrary;

            // set the binding source to the list box
            sfxGridView.DataSource = soundLibBindSource;
            sfxGridView.AutoGenerateColumns = true;

            // auto screen sizing approach courtesy of https://www.youtube.com/watch?v=bKnpxTulUIs
            // set form size based on primary display resolution
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            // set size of form to half that size (50%)
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));
        }

        private void editSFXBtn_Click(object sender, EventArgs e)
        {
            // TODO EDIT SOUND (work on after getting audio playback)
        }

        private void play_audio_btn_Click(object sender, EventArgs e)
        {
            // TODO tweak this for hotkey activation!
            Console.WriteLine(outputDevice.PlaybackState);

            // TODO REMOVE THIS, breaks easily
            //if (outputDevice.PlaybackState != PlaybackState.Stopped)
            //{
            //    // call the stop method
            //    outputDevice?.Stop();
                
            //    // loop until playback state has stopped
            //    // check every 5ms (max wait should be 100ms)
            //    while (outputDevice.PlaybackState != PlaybackState.Stopped) Thread.Sleep(5);
            //}

            string currentFilePath;

            // check for currently selected audio file, if null return.
            if (sfxGridView.CurrentRow == null) return;
            else
            {
                // get currently selected audio path
                currentFilePath = soundLibrary[sfxGridView.CurrentRow.Index].FilePath;
                Console.WriteLine("Current File Path:");
                Console.WriteLine(currentFilePath);
            }

            //if (outputDevice == null)
            //{
            //    outputDevice = new WaveOutEvent();
            //    outputDevice.PlaybackStopped += OnPlaybackStopped;
            //}

            // if no audio file has been established, set path to current selection
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(currentFilePath);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        private void stop_audio_btn_Click(object sender, EventArgs e)
        {
            // checks that an output device exists before calling stop method
            outputDevice?.Stop();
        }

        // cleanly dispose of all audio playback resources when finished
        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            Console.WriteLine("Playback Stopped");
            // check if output device is null
            if (outputDevice != null)
            {
                //outputDevice.Dispose();
                //outputDevice = null;
                audioFile.Dispose();
                audioFile = null;
            }
        }
    }
}
