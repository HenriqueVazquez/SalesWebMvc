using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SalesWebMvc.Models;

namespace SalesWebMvc.TagHelpers
{
    [HtmlTargetElement("input-component")]
    public class InputComponent : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public string Label { get; set; }
        public ModelExpression Teste { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var fieldContent = $@"<div class='form-group'>
                <label asp-for=""{Teste}"" class='control-label"">{Label}</label>
                <input asp-for=""{Teste}"" class=""form-control""/>
                <span asp-validation-for='{Teste}' class='text-danger'></span>
            </div>";

            output.Content.SetHtmlContent(fieldContent);
        }
    }
}