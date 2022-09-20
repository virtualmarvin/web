using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("outputField", Attributes = ValueAttributeName)]
    public class OutputFieldTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string ValueAttributeName = "value";
 
        [HtmlAttributeName(LabelAttributeName)]
        public string? Label { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public ModelExpression Value { get; set; } = null!;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var value = Value?.Model?.ToString();
            var label = Label ?? Value?.Metadata?.DisplayName ?? Value?.Name ?? "";

            var encoder = HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs });
            value = encoder.Encode(value ?? "");
            label = encoder.Encode(label ?? "");

            var labelContent = $"<label class='col-sm-4 col-form-label'>{label}</label>";
            var valueContent = $"<div class='col-sm-8 col-form-text'>{value}</div>";

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(valueContent);
        }
    }
}
