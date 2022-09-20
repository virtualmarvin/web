using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("outputCheckBox", Attributes = ValueAttributeName)]
    public class OutputCheckBoxTagHelper : TagHelper
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

        protected IHtmlGenerator Generator { get; }

        public OutputCheckBoxTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string input = "";

            var helper = new InputTagHelper(Generator);
            helper.ViewContext = ViewContext;
            helper.For = Value;

            helper.Init(context);
            helper.Process(context, output);

            string ischecked = Value?.Model?.ToString() == "True" ? "checked='checked'" : "";
            input = $"<input type='checkbox' disabled='disabled' {ischecked} >";

            output.Attributes.Clear();
            output.PostContent.Clear();
            output.Content.Clear();

            var value = Value?.Model?.ToString();
            var label = Label ?? Value?.Metadata?.DisplayName ?? Value?.Name ?? "";

            var encoder = HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs });
            value = encoder.Encode(value ?? "");
            label = encoder.Encode(label ?? "");

            var labelContent = $"<label for='{Value?.Name}' class='col-sm-4 col-form-label'>{label}</label>";
            var valueContent = $"<div class='col-sm-8 col-form-checkbox'>{input}</div>";

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(valueContent);
        }
    }
}
