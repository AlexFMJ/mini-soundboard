using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace soundboard_sandbox
{
    public partial class MainForm : Form
    {
        // ==== NAudio Objects:
        private WaveOutEvent outputDevice;  // soundcard
        private AudioFileReader audioFile;  // audio file to be read

        static List<Sfx> sfxLibrary = new List<Sfx>();  // List to be bound

        // BindingSource allows for automatic refreshing of data on listBox
        // when adding or removing items from soundLibrary list
        BindingSource sfxLibBindSource = new BindingSource();

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
            sfxLibBindSource.DataSource = sfxLibrary;

            // set the binding source to the list box
            sfxGridView.DataSource = sfxLibBindSource;
            sfxGridView.AutoGenerateColumns = true;
            // set default column width
            sfxGridView.Columns[0].FillWeight = 37; // name
            sfxGridView.Columns[1].FillWeight = 47; // file path
            sfxGridView.Columns[2].FillWeight = 8;  // hotkey
            sfxGridView.Columns[3].FillWeight = 8;  // volume level


            // auto screen sizing approach courtesy of https://www.youtube.com/watch?v=bKnpxTulUIs
            // set form size based on primary display resolution
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            // set size of form to half that size (50%)
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));
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
                    // calls these methods from OpenFileForm
                    sfxLibBindSource.Add(new Sfx(
                        addSfxForm.GetName(),
                        addSfxForm.GetHotkey(),
                        addSfxForm.GetPath(),
                        addSfxForm.GetVolume()
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
            if (rowIndex >= 0 && rowIndex < sfxLibrary.Count)
            {
                Console.WriteLine($"Removing item: {sfxLibrary[rowIndex].Name} at index {rowIndex}");

                // must use RemoveAt to access by index
                sfxLibBindSource.RemoveAt(rowIndex);
            }
        }

        private void editSFXBtn_Click(object sender, EventArgs e)
        {
            // TODO EDIT SOUND (work on after getting audio playback)
        }


        // ==== SAVE AND LOAD SFX LIBRARIES ====
        // serialize library and save to XML file
        private void saveSFXLibraryBtn(object sender, EventArgs e)
        {
            // call save file dialog
            saveFileDialog1.ShowDialog();

            // once path is selected, its returned as a string
            string path = saveFileDialog1.FileName;

            serializer(path);
        }

        // deserialize XML library file
        private void loadSFXLibraryBtn(object sender, EventArgs e)
        {
            // TODO
            // open file for reading
            openFileDialog1.ShowDialog();

            string path = openFileDialog1.FileName;
            deserializer(path);
        }

        // XmlSerializer
        private string serializer(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sfx>));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, sfxLibrary);
            }
            return path;
        }

        // XmlDeserializer
        private string deserializer(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Sfx>));
            using (FileStream reader = new FileStream(path, FileMode.Open))
            {
                sfxLibrary = (List<Sfx>)deserializer.Deserialize(reader);
            }
            sfxLibBindSource.DataSource = sfxLibrary;
            return path;
        }


        // ==== AUDIO PLAYBACK ====
        private void playSelectedAudio(object sender, EventArgs e)
        {
            Sfx selectedSfx;

            Console.WriteLine(outputDevice.PlaybackState);

            // If file is currently playing, stop playback and cleanup
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                stopAudio(sender, e);
            }
            
            string currentFilePath;

            // TODO tweak this for hotkey activation!
            // check for currently selected audio file, if null return.
            if (sfxGridView.CurrentRow == null) return;
            else
            {
                selectedSfx = sfxLibrary[sfxGridView.CurrentRow.Index] as Sfx;
                // get currently selected audio path
                currentFilePath = selectedSfx.FilePath;
                Console.WriteLine("Current File Path:");
                Console.WriteLine(currentFilePath);
            }

            // if no audio file has been established, set path to current selection
            if (audioFile == null)
            {
                Console.WriteLine("audioFile is null. Making new audio file");
                audioFile = new AudioFileReader(currentFilePath);
                audioFile.Volume = selectedSfx.Volume;
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
        private void stopAudio(object sender, EventArgs e)
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
                          sfxLibBindSource[rowIndexFromMouseDown],
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
                    rowIndexOfItemUnderMouseToDrop = sfxLibBindSource.Count - 1;
                    break;
            }

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                Sfx rowToMove = e.Data.GetData(typeof(Sfx)) as Sfx;
                sfxLibBindSource.RemoveAt(rowIndexFromMouseDown);
                sfxLibBindSource.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
        }
    }
}
