using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;

namespace RichTextControls.Generators
{
    public interface ILinkRegister
    {
        /// <summary>
        /// Registers a Hyperlink with a LinkUrl.
        /// </summary>
        /// <param name="newHyperlink">Hyperlink to Register.</param>
        /// <param name="linkUrl">Url to Register.</param>
        void RegisterNewHyperLink(Hyperlink newHyperlink, string linkUrl);
        /// <summary>
        /// Registers a Hyperlink with a LinkUrl.
        /// </summary>
        /// <param name="newHyperlink">Hyperlink to Register.</param>
        /// <param name="linkUrl">Url to Register.</param>
        void RegisterNewHyperLink(HyperlinkButton newHyperlink, string linkUrl);

        /// <summary>
        /// Registers a Hyperlink with a LinkUrl.
        /// </summary>
        /// <param name="newImagelink">ImageLink to Register.</param>
        /// <param name="linkUrl">Url to Register.</param>
        /// <param name="isHyperLink">Is Image an IsHyperlink.</param>
        void RegisterNewHyperLink(ImageEx.ImageEx newImagelink, string linkUrl, bool isHyperLink);
    }
}
