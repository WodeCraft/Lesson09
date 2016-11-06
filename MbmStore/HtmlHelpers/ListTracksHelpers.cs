using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.HtmlHelpers
{
    public static class ListTracksHelpers
    {
        public static HtmlString ListTracks(this HtmlHelper helper, MusicCD cd)
        {
        StringBuilder sb = new StringBuilder();
        sb.Append("<div>");

        sb.Append("<strong> Tracks:</strong>");
        sb.Append("<ol>");

        foreach (Track track in @cd.Tracks)
            {
            sb.Append("<li>" + track.Title + " (" + track.Composer + ") ");
            sb.Append(track.Length.Minutes + ": " + track.Length.Seconds + "</li>");
        }
        sb.Append("</ol>");


        sb.Append("<p><strong>Total playing time</strong>: " + cd.GetPlayingTime().Minutes + ": " + cd.GetPlayingTime().Seconds + "</p>");
        sb.Append("</div>");
        return new HtmlString(sb.ToString());

        }
    }
}
