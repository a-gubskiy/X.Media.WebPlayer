using System;
using System.Text.RegularExpressions;
using System.Web;

namespace X.Media.WebPlayer
{
    public class VimeoPlayer : X.Media.WebPlayer.Player
    {
        private string url;

        public VimeoPlayer(string url)
            : base(url)
        {
        }

        public override HtmlString Render()
        {
            //Vimeo: vimeo\.com/(?:.*#|.*/videos/)?([0-9]+)
            var regex = new Regex("vimeo\\.com/(?:.*#|.*/(videos|.*)/)?([0-9]+)");

            var match = regex.Match(_url);

            string id;

            if (match.Success)
            {
                id = match.Groups[match.Groups.Count - 1].Value;
            }
            else
            {
                return new HtmlString("Cannot load player");
            }

            var embedUrl = String.Format("//player.vimeo.com/video/{0}", id);

            var width = Width == 0 ? "100%" : Width + "px";

            var str =
                String.Format(
                    "<iframe src=\"{0}?byline=0&amp;portrait=0\" width=\"{1}\" height=\"{2}\" frameborder=\"0\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>",
                    embedUrl, width, Height);


            return new HtmlString(str);
        }
    }
}
