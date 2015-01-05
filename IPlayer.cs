using System.Web;

namespace X.Media.WebPlayer
{
    public interface IPlayer
    {
        int Height { get; set; }
        int Width { get; set; }

        void Initilize(string url);
        HtmlString Render();
    }
}
