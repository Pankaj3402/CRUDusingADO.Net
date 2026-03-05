using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _1_Introduction
{
    [HtmlTargetElement("*",Attributes="highlite")]
    public class HighliteTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           
            output.Attributes.Add("style","background-color:pink");
        }
    }
}
