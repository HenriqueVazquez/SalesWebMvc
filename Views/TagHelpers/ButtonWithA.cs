using Microsoft.AspNetCore.Razor.TagHelpers;

namespace System
{
    [HtmlTargetElement("button-a")]
    public class ButtonWithA : TagHelper
    {
        public string Route { get; set; }
        public string IconClass { get; set; }
        public string Text { get; set; }
        public string Class { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var buttonContent = $@"<a href=""{Route}"" class=""btn btn-primary mt-2 rounded-pill d-flex justify-content-center align-items-center gap-2 btpadding"">                                               
                 <div class=""d-flex d-inline-flex {Class} align-self-center h-22"">
                 <i class=""{IconClass}""></i>
                 <p class=""ms-2 h6"">{Text}</p>
                 </div>
                </a>";
            output.Content.SetHtmlContent(buttonContent);
        }
    }
}
