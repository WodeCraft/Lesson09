using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models {

    public class Track {

        public int TrackId {get; set; }
        public string Title {get; set; }
        public string Composer { get; set; }
        public TimeSpan Length { get; set; }

        public Track(string title, TimeSpan length) {
            Title = title;
            Length = length;
            Composer = "";
        }

		public Track() { }
		
        public Track(string title, TimeSpan length, string composer) {
            Title = title;
            Length = length;
            Composer = composer;
        }
    }
}