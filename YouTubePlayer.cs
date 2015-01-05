using System;
using System.Text.RegularExpressions;
using System.Web;

namespace Core.Player
{
    public class YouTubePlayer : X.Media.WebPlayer.Player
    {
        private string url;

        public YouTubePlayer(string url)
            : base(url)
        {

        }

        public override void Initilize(string url)
        {
            _url = url;
        }

        public override HtmlString Render()
        {
            //Youtube: youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)
            //Vimeo: vimeo\.com/(?:.*#|.*/videos/)?([0-9]+)
           
            var regex = new Regex("youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");


            Match youtubeMatch = regex.Match(_url);
            
            string id;

            if (youtubeMatch.Success)
            {
                id = youtubeMatch.Groups[1].Value;
            }
            else
            {
                return new HtmlString("Cannot load player");
            }

            var embedUrl = String.Format("//www.youtube.com/embed/{0}", id);
            
            var str =
                String.Format(
                    "<iframe width=\"{0}px\" height=\"{1}px\" src=\"{2}\" frameborder=\"0\" allowfullscreen></iframe>",
                    Width, Height, embedUrl);

            return new HtmlString(str);
        }
    }
}
