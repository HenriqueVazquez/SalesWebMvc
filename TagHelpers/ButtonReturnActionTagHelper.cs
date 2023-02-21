using Microsoft.AspNetCore.Razor.TagHelpers;




namespace System
{
    [HtmlTargetElement("button-return-action")]
    public class ButtonReturnActionTagHelper : TagHelper
    {


        public string IconClass { get; set; }
        public string Text { get; set; }
        public string Class { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var buttonContent = $@"<button type=""submit"" class=""btn btn-primary mt-2 {Class} button-container rounded-pill d-flex
                                        justify-content-center align-items-center btpadding"">                                               
                                        <div class=""d-flex d-inline-flex align-self-center h-22"">
                                        <i class=""{IconClass}""></i>
                                        <p class=""ms-2 h6"">{Text}</p>
                                        </div>
                                    </button>";
            output.Content.SetHtmlContent(buttonContent);
        }
    }
}
