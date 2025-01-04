//using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mini_soundboard
{
    internal class Hotkeys
    {
        private static Dictionary<Keys, Sfx> assignedKeys = new Dictionary<Keys, Sfx>();
        private static Dictionary<MidiNote, Sfx> assignedMidi = new Dictionary<MidiNote, Sfx>();

        // used as a flag to update sfx hotkey info in library
        public enum assignStatus
        {
            Unassigned  = 0,
            In_Use      = 1,
            Removed     = 2,
        }

        // assigns hotkeys. Does not check for conflicts
        public assignStatus AssignHotkey(Sfx sound)
        {
            var status = assignStatus.Unassigned;

            if (sound.HotkeyInfo == null) return status;

            switch (sound.HotkeyInfo.Type)
            {
                case HotkeyInfo.HKType.none:
                    return status;
                case HotkeyInfo.HKType.keyboard:
                    if (sound.HotkeyInfo.KeyData == Keys.None) return status;
                    else
                    {
                        // if hotkey is not null
                        assignedKeys[sound.HotkeyInfo.KeyData] = sound;
                        status = assignStatus.In_Use;
                    };
                    break;
                case HotkeyInfo.HKType.midi:
                    if (sound.HotkeyInfo.MidiNote.Number < 0 || sound.HotkeyInfo.MidiNote.Number > 127) return status;
                    else
                    {
                        // if hotkey is valid, assign sfx to midi list
                        assignedMidi[sound.HotkeyInfo.MidiNote] = sound;
                        status = assignStatus.In_Use;
                    };
                    break;
                default:
                    break;
            }
            return status;
        }

        // Unset specified hotkey if already in keyboard dictionary
        public assignStatus CheckForConflict(Keys hotkeyData)
        {
            assignStatus status = assignStatus.Unassigned;

            if (assignedKeys.ContainsKey(hotkeyData))
            {
                status = assignStatus.In_Use;

                string message = $"That hotkey is currently assigned to {assignedKeys[hotkeyData]}{Environment.NewLine}" +
                    $"Would you like to unset it? This cannot be undone.";

                MessageBoxButtons yesnoBtns = MessageBoxButtons.YesNo;
                DialogResult result;

                // raise a message with yes or no prompt
                result = MessageBox.Show(message, "Unset existing hotkey?", yesnoBtns);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    status = RemoveHotkeyEntry(hotkeyData); ;
                }
            }
            return status;
        }
        // Unset specified hotkey if already in MIDI dictionary
        public assignStatus CheckForConflict(MidiNote noteData)
        {
            assignStatus status = assignStatus.Unassigned;

            if (assignedMidi.ContainsKey(noteData))
            {
                status = assignStatus.In_Use;

                string message = $"That hotkey is currently assigned to {assignedMidi[noteData]}{Environment.NewLine}" +
                    $"Would you like to unset it? This cannot be undone.";

                MessageBoxButtons yesnoBtns = MessageBoxButtons.YesNo;
                DialogResult result;

                // raise a message with yes or no prompt
                result = MessageBox.Show(message, "Unset existing hotkey?", yesnoBtns);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    status = RemoveHotkeyEntry(noteData);
                }
            }
            return status;
        }

        // Removes hotkey from dictionary if it exists
        public assignStatus RemoveHotkeyEntry(Keys hotkeyData)
        {
            // return if not in dictionary
            if (!assignedKeys.ContainsKey(hotkeyData)) return assignStatus.Unassigned;

            // get index of the current Sfx with the hotkey
            int index = Program.sfxLibBindSource.IndexOf(assignedKeys[hotkeyData]);

            // remove hotkey from sfxLibBindSource
            Program.sfxLibrary[index].ClearHotkeyFields();

            // remove hotkey from dictionary
            assignedKeys.Remove(hotkeyData);

            return assignStatus.Removed;
        }
        // remove MIDI hotkey
        public assignStatus RemoveHotkeyEntry(MidiNote note)
        {
            // return if not in dictionary
            if (!assignedMidi.ContainsKey(note)) return assignStatus.Unassigned;

            // get index of the current Sfx with the hotkey
            int index = Program.sfxLibBindSource.IndexOf(assignedMidi[note]);

            // remove hotkey from sfxLibBindSource
            Program.sfxLibrary[index].ClearHotkeyFields();

            // remove hotkey from dictionary
            assignedMidi.Remove(note);

            return assignStatus.Removed;
        }

        // returns sfx object of specified hotkey
        public Sfx GetHotkeySfx(Keys hotkeyData)
        {
            try
            {
                return assignedKeys[hotkeyData];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"{hotkeyData.ToString()} is not a hotkey");
                return null;
            }
        }
        // returns sfx object of specified midi input
        public Sfx GetHotkeySfx(MidiNote noteData)
        {
            try
            {
                return assignedMidi[noteData];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"{noteData.ToString()} is not a hotkey");
                return null;
            }
        }

        public void ClearAllHotkeys()
        {
            // TODO add message box asking for confirmation
            assignedKeys.Clear();
            assignedMidi.Clear();
        }
    }
}
