#pragma checksum "E:\server\grocery-store\Views\Containers\User\User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4812d626bb4ef0c07d8e4332bcf99b470e68c0a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Containers_User_User), @"mvc.1.0.view", @"/Views/Containers/User/User.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\server\grocery-store\Views\_ViewImports.cshtml"
using Backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\server\grocery-store\Views\_ViewImports.cshtml"
using Backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\server\grocery-store\Views\_ViewImports.cshtml"
using Backend.Views.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\server\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4812d626bb4ef0c07d8e4332bcf99b470e68c0a8", @"/Views/Containers/User/User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4787e2bf596517cbd42acf11f503cf4b3e860901", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_User_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
  
    ViewData["Title"] = Routers.User.Title;
    User user = (User)ViewData["user"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""flex items-center justify-center flex-1 py-2 "">

    <div
        class=""flex-1 px-4 py-16 mx-2 space-y-8 bg-white rounded-md shadow-lg bg-opacity-90 md:mx-0 md:flex-none fade-in"">
        <h1 class=""text-4xl font-bold "">User Information</h1>
        <div class=""space-y-4"">
            <div class=""grid grid-cols-1 space-x-2 md:grid-cols-2"">
                <div class=""col-span-1"">
                    <p class=""font-semibold"">Username</p>
                </div>
                <div class=""col-span-1"">
                    <p>");
#nullable restore
#line 17 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
                  Write(user.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""grid grid-cols-1 space-x-2 md:grid-cols-2"">
                <div class=""col-span-1"">
                    <p class=""font-semibold"">Name</p>
                </div>
                <div class=""col-span-1"">
                    <p class=""first-letter"">");
#nullable restore
#line 25 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
                                       Write(user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""grid grid-cols-1 space-x-2 md:grid-cols-2"">
                <div class=""col-span-1"">
                    <p class=""font-semibold"">Email</p>
                </div>
                <div class=""col-span-1"">
                    <p class=""first-letter"">");
#nullable restore
#line 33 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
                                       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""grid grid-cols-1 space-x-2 md:grid-cols-2"">
                <div class=""col-span-1"">
                    <p class=""font-semibold"">Phone</p>
                </div>
                <div class=""col-span-1"">
                    <p class=""first-letter"">");
#nullable restore
#line 41 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
                                       Write(user.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""grid grid-cols-1 space-x-2 md:grid-cols-2"">
                <div class=""col-span-1"">
                    <p class=""font-semibold"">Address</p>
                </div>
                <div class=""col-span-1"">
                    <p class=""first-letter"">");
#nullable restore
#line 49 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
                                       Write(user.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""grid grid-cols-1 space-x-2 md:grid-cols-2"">
                <div class=""col-span-1"">
                    <p class=""font-semibold "">Role</p>
                </div>
                <div class=""col-span-1"">
                    <p class=""lowercase first-letter"">");
#nullable restore
#line 57 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
                                                 Write(user.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"flex items-center justify-between space-x-2\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 2509, "\"", 2544, 1);
#nullable restore
#line 62 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
WriteAttributeValue("", 2516, Routers.UpdatePassword.Link, 2516, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                class=\"flex-1 p-2 font-medium text-center text-white bg-blue-600\">Update\r\n                Password</a>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 2681, "\"", 2716, 1);
#nullable restore
#line 65 "E:\server\grocery-store\Views\Containers\User\User.cshtml"
WriteAttributeValue("", 2688, Routers.UpdateUserInfo.Link, 2688, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                class=\"flex-1 p-2 font-medium text-center text-white bg-blue-600\">Update\r\n                Information</a>\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
