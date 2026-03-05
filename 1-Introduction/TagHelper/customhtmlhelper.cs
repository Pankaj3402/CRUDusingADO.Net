using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _1_Introduction.helper
{
    public static class customhtmlhelper
    {

        public static IHtmlContent Button(this IHtmlHelper html, string type, string value, string cls)
        {
            //TagBuilder button = new TagBuilder("input");

            //button.Attributes.Add("type", type);
            //button.Attributes.Add("value", value);
            //button.Attributes.Add("class", cls);

            string button = $"<input type='{type}' value='{value}' class='{cls}' />";

            HtmlContentBuilder htmlContent = new HtmlContentBuilder();

            htmlContent.AppendHtml(button);

            return htmlContent;

        }

    }
    
}
