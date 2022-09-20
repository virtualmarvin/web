using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Marvin.Web.TagHelpers
{
    [HtmlTargetElement("aggregate", Attributes = ValueAttributeName)]
    public class AggregateTagHelper : TagHelper
    {
        private const string ValueAttributeName = "value";
        private const string HrefAttributeName = "href";

        [HtmlAttributeName(ValueAttributeName)]
        public int Value { get; set; } = 0;

        [HtmlAttributeName(HrefAttributeName)]
        public string? Href { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AggregateTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var request = _httpContextAccessor.HttpContext!.Request;

            if (Value == 0)
            {
                output.TagName = "div";
                output.Attributes.RemoveAll("href");
                output.Attributes.SetAttribute("class", "pl-6");
            }
            else if (Value > 0)
            {
                output.TagName = "a";
                output.Attributes.Add("class", "btn btn-xs btn-light");
                output.Attributes.Add("href", Href);
            }

            output.Attributes.RemoveAll("value");
            output.PostContent.SetContent(Value.ToString());
        }
    }
}


