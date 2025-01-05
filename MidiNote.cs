using NAudio.Midi;
//using System;

namespace mini_soundboard
{
    public class MidiNote
    {
        public int Channel { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public MidiNote() { }

        public MidiNote(NoteEvent note)
        {
            this.Channel = note.Channel;
            this.Number = note.NoteNumber;
            this.Name = note.NoteName;
        }

        public MidiNote(int channel, int number, string name)
        {
            this.Channel = channel;
            this.Number = number;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"Channel: {Channel} - Number: {Number} - Name: {Name}";
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MidiNote)) { return false; }
            else
            { return this.Name == ((MidiNote)obj).Name; }
        }
    }
}
