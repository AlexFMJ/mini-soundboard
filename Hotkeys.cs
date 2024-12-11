using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace soundboard_sandbox
{
    internal class Hotkeys
    {
        private static Dictionary<Keys, Sfx> assignedKeys = new Dictionary<Keys, Sfx>();

        // used as a flag to update sfx hotkey info in library
        public enum assignStatus
        {
            Unassigned  = 0,
            Assigned    = 1,
            Overwritten = 2,
        }

        // assigns hotkeys if not already recorded. Prompts user otherwise
        public assignStatus AssignHotkey(Sfx sound)
        {
            var status = assignStatus.Unassigned;

            if (sound.HKeyInfo == null) return status;

            if (assignedKeys.ContainsKey(sound.HKeyInfo.KeyData))
            {
                status = UnsetHotkey(sound.HKeyInfo.KeyData);
            }
            else
            {
                assignedKeys[sound.HKeyInfo.KeyData] = sound;
                status = assignStatus.Assigned;
            }

            return status;
        }

        // Unset specified hotkey if in dictionary already
        public assignStatus UnsetHotkey(Keys hotkeyData)
        {
            assignStatus status = assignStatus.Unassigned;

            if (assignedKeys.ContainsKey(hotkeyData))
            {
                string message = $"That hotkey is currently assigned to {assignedKeys[hotkeyData]}{Environment.NewLine}" +
                    $"Would you like to unset it? This cannot be undone.";

                MessageBoxButtons yesnoBtns = MessageBoxButtons.YesNo;
                DialogResult result;

                // raise a message with yes or no prompt
                result = MessageBox.Show(message, "Unset existing hotkey?", yesnoBtns);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveHotkeyEntry(hotkeyData);
                    status = assignStatus.Overwritten;
                }
            }
            return status;
        }

        // Removes hotkey from dictionary if it exists
        public void RemoveHotkeyEntry(Keys hotkeyData)
        {
            // return if not in dictionary
            if (!assignedKeys.ContainsKey(hotkeyData)) return;

            // get index of the current Sfx with the hotkey
            int index = Program.sfxLibBindSource.IndexOf(assignedKeys[hotkeyData]);

            // remove hotkey from sfxLibBindSource
            Program.sfxLibrary[index].ClearHotkeyFields();

            // remove hotkey from dictionary
            assignedKeys.Remove(hotkeyData);
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

        // formats Keys into familiar "modifier + key" string format
        public string KeysToString(KeyEventArgs currentHotkey)
        {
            // modifiers
            string ctrl = "";
            string alt = "";
            string shift = "";

            if (currentHotkey.Control)
                ctrl = "ctrl + ";
            if (currentHotkey.Alt)
                alt = "alt + ";
            if (currentHotkey.Shift)
                shift = "shift + ";

           return $"{ctrl}{alt}{shift}{currentHotkey.KeyCode}";
        }

        public void ClearAllHotkeys()
        {
            // TODO add message box asking for confirmation
            assignedKeys.Clear();
        }
    }
}
