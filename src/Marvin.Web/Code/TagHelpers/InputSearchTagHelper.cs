using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("inputSearch", Attributes = ValueAttributeName)]
    public class InputSearchTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string ValueAttributeName = "value";
        private const string PlaceholderAttributeName = "placeholder";
      
        [HtmlAttributeName(LabelAttributeName)]
        public string? Label { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public ModelExpression Value { get; set; } = null!;

        [HtmlAttributeName(PlaceholderAttributeName)]
        public string? Placeholder { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        protected IHtmlGenerator Generator { get; }

        public InputSearchTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string input = "";

            string labelCss = "col-sm-4";
            string controlCss = "col-sm-8";

            var helper = new InputTagHelper(Generator);
            helper.ViewContext = ViewContext;
            helper.For = Value;

            helper.Init(context);
            helper.Process(context, output);

            using (var writer = new StringWriter())
            {
                output.TagName = "input";
                output.Attributes.Add("class", "form-control typeahead");
                output.Attributes.Add("placeholder", Placeholder ?? "");

                output.Attributes.RemoveAt(output.Attributes.IndexOfName("value"));
                output.Attributes.RemoveAt(output.Attributes.IndexOfName("type"));
                output.Attributes.RemoveAt(output.Attributes.IndexOfName("name"));
                output.Attributes.RemoveAt(output.Attributes.IndexOfName("id"));

                output.Content.SetHtmlContent("<span class='search-icon icon-magnifier'></span>");

                output.Attributes.Add("value", "");
                output.Attributes.Add("type", "text");
                output.Attributes.Add("id", Value.Name + "Input");
                output.Attributes.Add("name", Value.Name + "Input");

                output.WriteTo(writer, HtmlEncoder.Default);
                input = writer.ToString(); 
                input = input.Replace(@"class=""input-validation-error""", "");
            }

            output.Attributes.Clear();
            output.PostContent.Clear();
            output.Content.Clear();

            var validateBuilder = Generator.GenerateValidationMessage(
                ViewContext,
                Value.ModelExplorer,
                Value.Name + "Input",
                message: null,
                tag: null,
                htmlAttributes: null);

            string req = (input.IndexOf("data-val-required") > -1) ? "<span class='required'>*</span>" : "";

            var label = Label ?? Value?.Metadata?.DisplayName ?? Value?.Name ?? "";
            var labelContent = $"<label for='{Value?.Name}' class='{labelCss} col-form-label'>{req}{label}</label>";

            string hiddenName = $"<input type='hidden' name='{Value?.Name}' id='{Value?.Name}' value='{Value?.Model}' />";
            string hiddenType = $"<input type='hidden' name='{Value?.Name}Type' id='{Value?.Name}Type' value='' />";

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass(controlCss);
            divBuilder.InnerHtml.AppendHtml(input);
            divBuilder.InnerHtml.AppendHtml(validateBuilder);
            divBuilder.InnerHtml.AppendHtml(hiddenName);
            divBuilder.InnerHtml.AppendHtml(hiddenType);

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(divBuilder);
        }
    }
}
