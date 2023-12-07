﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "supress-by-claim-value")]
    public class SupressElementByClaimTagHelper:TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SupressElementByClaimTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("supress-by-claim-value")]
        public string IdentityClaimValue { get; set;}

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

            var access = CustomAuthorization.ValidateClaimsUser(_contextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (access) return;

            output.SuppressOutput();

            base.Process(context, output);
        }
    }
}
