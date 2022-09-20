using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("inputDropDown", Attributes = ValueAttributeName)]
    [HtmlTargetElement("inputDropDown", Attributes = ItemsAttributeName)]
    public class InputDropDownTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string ValueAttributeName = "value";
        private const string ItemsAttributeName = "items";

        [HtmlAttributeName(LabelAttributeName)]
        public string? Label { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public ModelExpression Value { get; set; } = null!;

        [HtmlAttributeName(ItemsAttributeName)]
        public IEnumerable<SelectListItem> Items { get; set; } = null!;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        protected IHtmlGenerator Generator { get; }

        public InputDropDownTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string input = "";

            string labelCss = "col-sm-4";
            string controlCss = "col-sm-8";

            var helper = new SelectTagHelper(Generator);
            helper.ViewContext = ViewContext;
            helper.For = Value;
            helper.Items = Items;

            helper.Init(context);
            helper.Process(context, output);

            using (var writer = new StringWriter())
            {
                output.TagName = "select";
                output.Attributes.Add("class", "form-select");

                output.WriteTo(writer, HtmlEncoder.Default);
                input = writer.ToString();
                input = input.Replace(@"class=""input-validation-error""", "");
            }

            output.Attributes.Clear();
            output.PostContent.Clear();
            output.Content.Clear();

            string req = (input.IndexOf("data-val-required") > -1) ? "<span class='required'>*</span>" : "";

            var label = Label ?? Value?.Metadata?.DisplayName ?? Value?.Name ?? "";
            var labelContent = $"<label for='{Value?.Name}' class='{labelCss} col-form-label'>{req}{label}</label>";

            var validateBuilder = Generator.GenerateValidationMessage(
                    ViewContext,
                    Value?.ModelExplorer,
                    Value?.Name,
                    message: null,
                    tag: null,
                    htmlAttributes: null);

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass(controlCss);
            divBuilder.InnerHtml.AppendHtml(input);
            divBuilder.InnerHtml.AppendHtml(validateBuilder);

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(divBuilder);
        }
    }
}
