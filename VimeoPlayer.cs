using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Core.Player
{
    public class VimeoPlayer : X.Media.WebPlayer.Player
    {
        private string url;

        public VimeoPlayer(string url)
            : base(url)
        {

        }

        public override void Initilize(string url)
        {
            throw new NotImplementedException();
        }

        public override HtmlString Render()
        {
            //var regex = new Regex("/https?:\\/\\/(?:www\\.)?vimeo.com\\/(?:channels\\/(?:\\w+\\/)?|groups\\/([^\\/]*)\\/videos\\/|album\\/(\\d+)\\/video\\/|)(\\d+)(?:$|\\/|\\?)/");
            var regex = new Regex("vimeo\\.com/(?:.*#|.*/(videos|.*)/)?([0-9]+)");
            
            var match = regex.Match(_url);

            string id;

            if (match.Success)
            {
                //id = match.Groups[1].Value;
                id = match.Groups[match.Groups.Count - 1].Value;
            }
            else
            {
                return new HtmlString("Cannot load player");
            }

            var embedUrl = String.Format("//player.vimeo.com/video/{0}", id);

            var str =
                String.Format(
                    "<iframe src=\"{0}?byline=0&amp;portrait=0\" width=\"{1}\" height=\"{2}\" frameborder=\"0\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>",
                    embedUrl, Width, Height);


            return new HtmlString(str);
        }
    }
}
