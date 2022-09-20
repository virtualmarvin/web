using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("inputTextArea", Attributes = ValueAttributeName)]
    public class InputTextAreaTagHelper : TagHelper
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

        public InputTextAreaTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string input = "";

            var helper = new TextAreaTagHelper(Generator);
            helper.ViewContext = ViewContext;
            helper.For = Value;

            helper.Init(context);
            helper.Process(context, output);

            using (var writer = new StringWriter())
            {
                output.TagName = "textarea";
                output.Attributes.Add("class", "form-control");
                output.Attributes.Add("rows", "4");

                output.WriteTo(writer, HtmlEncoder.Default);
                input = writer.ToString();
                input = input.Replace(@"class=""input-validation-error""", "");
            }

            output.Attributes.Clear();
            output.PostContent.Clear();
            output.Content.Clear();

            string req = (input.IndexOf("data-val-required") > -1) ? "<span class='required'>*</span>" : "";

            var label = Label ?? Value?.Metadata?.DisplayName ?? Value?.Name ?? "";
            var labelContent = $"<label for='{Value?.Name}' class='col-sm-4 col-form-label'>{req}{label}</label>";

            var validateBuilder = Generator.GenerateValidationMessage(
                    ViewContext,
                    Value?.ModelExplorer,
                    Value?.Name,
                    message: null,
                    tag: null,
                    htmlAttributes: null);

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("col-sm-8");

            divBuilder.InnerHtml.AppendHtml(input);
            divBuilder.InnerHtml.AppendHtml(validateBuilder);

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(divBuilder);
        }
    }
}
