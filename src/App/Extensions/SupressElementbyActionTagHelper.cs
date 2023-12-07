using Microsoft.AspNetCore.Razor.TagHelpers;

namespace App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-action" )]
    public class SupressElementbyActionTagHelper: TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SupressElementbyActionTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-action")]
        public string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           if(context == null)
            {
                throw new ArgumentNullException("context");
            }
           if(output == null)
            {
                throw new ArgumentNullException("output");
            }

           var action = _contextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (ActionName.Contains(action)) return;

            output.SuppressOutput();
        }
    }
}
