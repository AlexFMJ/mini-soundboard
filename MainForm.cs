using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace soundboard_sandbox
{
    public partial class MainForm : Form
    {
        // ==== NAudio Objects:
        private WaveOutEvent outputDevice;  // soundcard
        private AudioFileReader audioFile;  // audio file to be read

        public MainForm()
        {
            InitializeComponent();

            // initialize the output device here 
            // we will frequently use it
            outputDevice = new WaveOutEvent();
            //outputDevice.PlaybackStopped += OnPlaybackStopped;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set data source to bind
            Program.sfxLibBindSource.DataSource = Program.sfxLibrary;

            // set the binding source to the list box
            sfxGridView.DataSource = Program.sfxLibBindSource;
            sfxGridView.AutoGenerateColumns = true;

            // hide the unformatted hotkey and volume columns 
            sfxGridView.Columns["HKeyInfo"].Visible = false;
            sfxGridView.Columns["VolumeFloat"].Visible = false;


            // set default column width
            sfxGridView.Columns["Name"].FillWeight = 37;
            sfxGridView.Columns["FilePath"].FillWeight = 47;
            sfxGridView.Columns["Hotkey"].FillWeight = 8;
            sfxGridView.Columns["Volume"].FillWeight = 8;
           

            // set text alignment for hotkey and volume
            sfxGridView.Columns["Hotkey"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // hotkey
            sfxGridView.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // volume level


            // auto screen sizing approach courtesy of https://www.youtube.com/watch?v=bKnpxTulUIs
            // set form size based on primary display resolution
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            // set size of form to half that size (50%)
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));
        }

        // ==== UI BOTTON FUNCTIONS ====
        // opens new form to enter new sfx information
        private void AddSFX_Click(object sender, EventArgs e)
        {
            // the using block will correctly dispose of the form when closed
            using (addSfxForm addSfxForm = new addSfxForm())
            {
                Sfx sound;

                // Checks that 'Add' button closed the form
                if (addSfxForm.ShowDialog() == DialogResult.OK)
                {
                    // calls these methods from addSfxForm
                    sound = new Sfx(
                        addSfxForm.GetName(),
                        addSfxForm.GetHotkeyString(),
                        new HotkeyEventInfo(
                            addSfxForm.GetHotkeyEventArgs().KeyCode,
                            addSfxForm.GetHotkeyEventArgs().KeyData),
                        addSfxForm.GetPath(),
                        addSfxForm.GetVolume()
                    );
                    // add it to the library
                    Program.sfxLibBindSource.Add(sound);
                }
            }
            // remove focus from button
            this.ActiveControl = null;
        }

        // delete currently selected sfx from sounds list object
        private void DeleteSFX_Click(object sender, EventArgs e)
        {
            int rowIndex;

            // prevent error when clicking delete with no selection
            if (sfxGridView.CurrentRow == null)
            {
                // remove focus from button
                this.ActiveControl = null;
                return;
            }
            else
                rowIndex = sfxGridView.CurrentRow.Index;

            // verifies that a valid index is selected
            if (rowIndex >= 0 && rowIndex < Program.sfxLibrary.Count)
            {
                Console.WriteLine($"Removing item: {Program.sfxLibrary[rowIndex].Name} at index {rowIndex}");

                // must use RemoveAt to access by index
                Program.sfxLibBindSource.RemoveAt(rowIndex);
            }

            // remove focus from button
            this.ActiveControl = null;
        }
        private void PlaySelectedAudio_Clicked(object sender, EventArgs e)
        {
            Sfx selectedSfx;

            // check for currently selected audio file, if null return.
            if (sfxGridView.CurrentRow == null) return;
            else
            {
                selectedSfx = Program.sfxLibrary[sfxGridView.CurrentRow.Index] as Sfx;

                PlaySfx(selectedSfx);
            }

            this.ActiveControl = null;
        }

        private void StopAudio_Clicked(object sender, EventArgs e)
        {
            StopAudio();
            this.ActiveControl = null;
        }

        private void EditSFXBtn_Click(object sender, EventArgs e)
        {
            // TODO EDIT SOUND (work on after getting audio playback)
            // remove focus from button
            //this.ActiveControl = null;
        }


        // ==== SAVE AND LOAD SFX LIBRARIES ====
        // serialize library and save to XML file
        private void SaveSFXLibraryBtn(object sender, EventArgs e)
        {
            // call save file dialog
            saveFileDialog1.ShowDialog();

            // once path is selected, its returned as a string
            string path = saveFileDialog1.FileName;

            // stop early if canceled
            if (path == "" || path == null) return;

            SaveLibToXML(path);
        }

        // deserialize XML library file
        private void LoadSFXLibraryBtn(object sender, EventArgs e)
        {
            // open file for reading
            openFileDialog1.ShowDialog();

            string path = openFileDialog1.FileName;

            // stop early if canceled
            if (path == "" || path == null) return;
            Console.WriteLine(path);

            // clear old hotkeys
            Program.localHotkeys.ClearAllHotkeys();

            LoadLibFromXML(path);
        }

        // XmlSerializer
        private string SaveLibToXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sfx>));
            try
            {
                using (TextWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, Program.sfxLibrary);
                }
            }
            catch (InvalidOperationException)
            {
                string message = $"Unable to save file at location:{Environment.NewLine}'{path}'{Environment.NewLine}File may be corrupt.";
                MessageBox.Show(message);
                return null;
            }
            return path;
        }

        // XmlDeserializer
        private string LoadLibFromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Sfx>));
            try
            {
                using (FileStream reader = new FileStream(path, FileMode.Open))
                {
                    Program.sfxLibrary = (List<Sfx>)deserializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException)
            {
                string message = $"Unable to load selected file at:{Environment.NewLine}'{path}'{Environment.NewLine}File may be corrupt.";
                MessageBox.Show(message, "Unable to load XML file.");
                return null;
            }
            // reestablish the datasource from the sfx library
            Program.sfxLibBindSource.DataSource = Program.sfxLibrary;
            return path;
        }


        // ==== AUDIO PLAYBACK ====
        private void PlaySfx(Sfx selectedSfx)
        {
            // If file is currently playing, stop playback and cleanup
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                StopAudio();
            }

            // check for currently selected audio file, if null return.
            if (selectedSfx.FilePath == null) return;
            else
            {
                Console.WriteLine("Current File Path:");
                Console.WriteLine(selectedSfx.FilePath);
            }

            // if no audio file has been established or the filename is different
            // set path to current selection
            if (audioFile == null || audioFile.FileName != selectedSfx.FilePath)
            {
                Console.WriteLine("audioFile is null. Making new audio file");
                audioFile = new AudioFileReader(selectedSfx.FilePath);
                audioFile.Volume = selectedSfx.VolumeFloat;
                outputDevice.Init(audioFile);
            }
            else
            {
                // otherwise restart the audio file from the beginning
                audioFile.Position = 0;
            }
            Console.WriteLine("Playing file");
            outputDevice.Play();
        }

        private void StopAudio()
        {
            Console.WriteLine("Stopping current audio");
            outputDevice?.Stop();

            // wait for PlaybackState stopped
            while (outputDevice.PlaybackState != PlaybackState.Stopped)
            {
                Console.WriteLine("Waiting for stopped state");
                Thread.Sleep(10);
            }
            // Cleanup
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
                return;
            }
        }


        // ==== DATAGRIDVIEW DRAG AND DROP ====
        // reference https://www.inforbiro.com/blog/c-datagridview-drag-and-drop-rows-reorder
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void sfxGridView_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = sfxGridView.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(
                          new Point(
                            e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)),
                      dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void sfxGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = sfxGridView.DoDragDrop(
                          Program.sfxLibBindSource[rowIndexFromMouseDown],
                          DragDropEffects.Move);
                }
            }
        }

        private void sfxGridView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void sfxGridView_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = sfxGridView.PointToClient(new Point(e.X, e.Y));

            // Get the info of the item the mouse is below.
            DataGridView.HitTestInfo indexInfo = sfxGridView.HitTest(clientPoint.X, clientPoint.Y);

            // Check what part of the DataGridView (if any) is below the mouse
            switch (indexInfo.Type)
            {
                // If it's a cell, set to rowIndex of that cell
                case DataGridViewHitTestType.Cell:
                    rowIndexOfItemUnderMouseToDrop = indexInfo.RowIndex;
                    break;
                // If it's a column header, set to top of list
                case DataGridViewHitTestType.ColumnHeader:
                    rowIndexOfItemUnderMouseToDrop = 0;
                    break;
                // If it's anything else, set index to end of list
                default:
                    rowIndexOfItemUnderMouseToDrop = Program.sfxLibBindSource.Count - 1;
                    break;
            }

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                Sfx rowToMove = e.Data.GetData(typeof(Sfx)) as Sfx;
                Program.sfxLibBindSource.RemoveAt(rowIndexFromMouseDown);
                Program.sfxLibBindSource.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
        }

        // listen for keypresses
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.Capital) return;

            // print info on keypress
            Console.WriteLine("Code - Data - Value");
            Console.WriteLine($"{e.KeyCode} - {e.KeyData} - {e.KeyValue}");

            // look for object as key in dict
            Sfx selectedSound = Program.localHotkeys.GetHotkeySfx(e.KeyData);
            Console.WriteLine(selectedSound);
            
            // if value is found, run event associated with it (Play audio)
            if (selectedSound != null) PlaySfx(selectedSound);
                

        }

        // If deleting item from GridView, delete listing from hotkey dict as needed
        private void sfxGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Sfx row = e.Row.DataBoundItem as Sfx;
            if (row.HKeyInfo != null)
            {
                Console.WriteLine("Removing hotkey");
                Program.localHotkeys.RemoveHotkeyEntry(row.HKeyInfo.KeyCode);
            }
        }
    }
}
