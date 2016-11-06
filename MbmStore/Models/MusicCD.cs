using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace MbmStore.Models
{

    [Table("MusicCD")]
    public class MusicCD : Product
    {
        private List<Track> tracks = new List<Track>();

        public string Artist { get; set; }
        public string Label { get; set; }
        public short Released { get; set; }

        public virtual List<Track> Tracks
        {
            get { return tracks; }
            set { tracks = value; }
        }

        public void AddTrack(Track track)
        {
            tracks.Add(track);
        }




        public MusicCD() { }

        public MusicCD(string artist, string title, decimal price, short released)
            : base(title, price)
        {
            Artist = artist;
            Released = released;
        }

        public TimeSpan GetPlayingTime()
        {
            TimeSpan ts = TimeSpan.Parse("00:00");

            foreach (Track track in this.Tracks)
            {
                ts += track.Length;
            }
            return ts;

        }
    }
}