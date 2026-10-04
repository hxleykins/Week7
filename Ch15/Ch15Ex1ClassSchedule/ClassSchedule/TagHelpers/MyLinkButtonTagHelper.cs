using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace ClassSchedule.TagHelpers
{
    public class MyLinkButtonTagHelper : TagHelper
    {
        public string? Action { get; set; }
        public string? Controller { get; set; }
        public string? Id { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        private LinkGenerator linkGenerator;

        public MyLinkButtonTagHelper(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            string? action = Action ??
                ViewContext.RouteData.Values["action"]?.ToString();

            string? controller = Controller ??
                ViewContext.RouteData.Values["controller"]?.ToString();

            var id = new { id = Id };

            string? url = linkGenerator.GetPathByAction(
                action,
                controller,
                id);

            string css;

            if (ViewContext.RouteData.Values["id"]?.ToString() == Id)
            {
                css = "btn btn-dark";
            }
            else
            {
                css = "btn btn-outline-dark";
            }

            output.BuildLink(url!, css);
        }
    }
}