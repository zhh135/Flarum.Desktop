
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEx;

namespace RichTextControls.EventsArgs
{
    public class LinkClickedEventArgs : EventArgs
    {
        internal LinkClickedEventArgs(string link,ImageEx.ImageEx image = null)
        {
            Link = link;
            ImageEx = image;
        }

        /// <summary>
        /// Gets the link that was tapped.
        /// </summary>
        public string Link { get; }
        public ImageEx.ImageEx ImageEx { get; }
    }
}
