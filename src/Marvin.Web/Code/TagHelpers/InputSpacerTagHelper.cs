using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("inputSpacer")]
    public class InputSpacerTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string input = "";

            output.Attributes.Clear();
            output.PostContent.Clear();
            output.Content.Clear();

            var label = "&nbsp;";
            var labelContent = $"<label for='' class='col-sm-4 col-form-label'>{label}</label>";

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("col-sm-8");
            divBuilder.InnerHtml.AppendHtml(input);

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(divBuilder);
        }
    }
}
