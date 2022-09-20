using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("outputLink", Attributes = ValueAttributeName)]
    public class OutputLinkTagHelper : TagHelper
    {
        private const string LabelAttributeName = "label";
        private const string ValueAttributeName = "value";
        private const string TypeAttributeName = "type";
        private const string NameAttributeName = "name";
        private const string QueryStringAttributeName = "querystring";

        [HtmlAttributeName(LabelAttributeName)]
        public string? Label { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public ModelExpression Value { get; set; } = null!;

        [HtmlAttributeName(NameAttributeName)]
        public ModelExpression Name { get; set; } = null!;

        [HtmlAttributeName(TypeAttributeName)]
        public string? Type { get; set; }

        [HtmlAttributeName(QueryStringAttributeName)]
        public string? QueryString { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        protected IHtmlGenerator Generator { get; }
        private ICache Cache { get; }

        public OutputLinkTagHelper(IHtmlGenerator generator, ICache cache)
        {
            Generator = generator;
            Cache = cache;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Clear();
            output.PostContent.Clear();
            output.Content.Clear();

            var value = Value?.Model?.ToString();
            var name = Name?.Model?.ToString();

            var encoder = HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs });
            value = encoder.Encode(value ?? "");
            name = encoder.Encode(name ?? "");

            string queryString = string.IsNullOrEmpty(QueryString) ? "" : "?" + QueryString;
            string href = string.IsNullOrEmpty(Type) ? "javascript:void(0);" : Cache.MetaTypes[Type].Url + "/" + value + queryString;
            string input = $"<a class='table-list-link' href='{href}'>{name}</a>";

            var label = Label ?? Value?.Metadata?.DisplayName ?? Value?.Name ?? "";
            var labelContent = $"<label for='{Value?.Name}' class='col-sm-4 col-form-label'>{label}</label>";

            var valueContent = $"<div class='col-sm-8 col-form-text'>{input}</div>";

            output.TagName = "div";
            output.Attributes.Add("class", "form-group row");

            output.Content.AppendHtml(labelContent);
            output.Content.AppendHtml(valueContent);
        }
    }
}
