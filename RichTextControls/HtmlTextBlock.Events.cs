using RichTextControls.EventsArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using LinkClickedEventArgs = RichTextControls.EventsArgs.LinkClickedEventArgs;
using Microsoft.UI.Xaml.Input;

namespace RichTextControls
{
    public partial class HtmlTextBlock
    {
        private void Hyperlink_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            LinkHandled((string)sender.GetValue(HyperlinkUrlProperty), true);
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs args)
        {
            LinkHandled(((HyperlinkButton)sender).GetValue(HyperlinkUrlProperty).ToString(), true);
        }
        /// <summary>
        /// Fired when a user taps one of the image elements
        /// </summary>
        private void NewImagelink_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string hyperLink = (string)(sender as ImageEx.ImageEx).GetValue(HyperlinkUrlProperty);
            bool isHyperLink = (bool)(sender as ImageEx.ImageEx).GetValue(IsHyperlinkProperty);
            LinkHandled(hyperLink, isHyperLink,(ImageEx.ImageEx)sender);
        }

        /// <summary>
        /// Fired when a link element in the markdown was tapped.
        /// </summary>
        public event EventHandler<LinkClickedEventArgs> LinkClicked;

        /// <summary>
        /// Fired when an image element in the markdown was tapped.
        /// </summary>
        public event EventHandler<LinkClickedEventArgs> ImageClicked;
    }
}
