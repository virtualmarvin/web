using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("outputSpacer")]
    public class OutputSpacerTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var value = "&nbsp;";
            var label = "&nbsp;";

            var labelContent = $"<label class='col-sm-4 col-form-label'>{label}</label>";
            var valueContent = $"<div class='col-sm-8 col-form-text'>{value}</div>";

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(valueContent);
        }
    }
}
