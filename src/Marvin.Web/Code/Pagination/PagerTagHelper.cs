using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Marvin.Web
{
    [HtmlTargetElement("a", Attributes = PageAttributeName)]
    public class PagerTagHelper : TagHelper
    {
        private const string PageAttributeName = "page";

        [HtmlAttributeName(PageAttributeName)]
        public ModelExpression Page { get; set; } = null!;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (((dynamic)(ViewContext.View)).RazorPage.Model is not PagedModel)
            {
                throw new InvalidCastException("<a page=''></a> TagHelper requires that the @model derives from PagedModel");
            }

            int page = int.Parse(Page.Model.ToString() ?? "0");

            var tagBuilder = new TagBuilder("a");
            tagBuilder.AddCssClass("btn btn-sm btn-light btn-rounded");
            tagBuilder.MergeAttribute("href", "javascript:void(0);");

            if (page == -1)
            {
                tagBuilder.AddCssClass("disabled");
            }
            else
            {
                tagBuilder.MergeAttribute("data-page", page.ToString());
            }

            output.MergeAttributes(tagBuilder);
        }
    }
}
