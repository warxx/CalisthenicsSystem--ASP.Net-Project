using System.Web.Mvc;

namespace CalisthenicsSystem.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageUrl, string width = null, string height = null, string alt = null, string @class = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("width", width);
            builder.MergeAttribute("height", height);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttribute("class", @class);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}