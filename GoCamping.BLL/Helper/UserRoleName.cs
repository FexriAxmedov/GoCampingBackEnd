﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using GoCamping.DAL;
using GoCamping.DAL.DBModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GoCamping.BLL.Helper
{
    [HtmlTargetElement("td", Attributes = "user-roles")]
    public class UserRoleName : TagHelper
    {
        public UserManager<AppUser> _userManager { get; set; }
        public UserRoleName(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            AppUser user = await _userManager.FindByIdAsync(UserId);

            IList<string> roles = await _userManager.GetRolesAsync(user);

            string html = string.Empty;

            roles.ToList().ForEach(x =>
            {
                html += $"<span class='badge badge-info' style='color:blue'>  {x}  </span>";
            });

            output.Content.SetHtmlContent(html);

        }
    }

}