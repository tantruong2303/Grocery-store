#pragma checksum "E:\server\grocery-store\Views\Containers\Category\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "586fe3e1d428d967112d29d11fceb0decc8cc265"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Containers_Category_Category), @"mvc.1.0.view", @"/Views/Containers/Category/Category.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"586fe3e1d428d967112d29d11fceb0decc8cc265", @"/Views/Containers/Category/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4787e2bf596517cbd42acf11f503cf4b3e860901", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Category_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
  
    ViewData["Title"] = Routers.Category.Title;
    List<Category> categories = (List<Category>)ViewData["categories"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"p-2 \">\r\n\r\n    <div>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 174, "\"", 209, 1);
#nullable restore
#line 9 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
WriteAttributeValue("", 181, Routers.CreateCategory.Link, 181, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n            class=\"inline-block p-2 font-medium text-white duration-300 bg-blue-600 rounded-sm hover:bg-blue-800\">Create\r\n            New Catagory</a>\r\n    </div>\r\n    ");
#nullable restore
#line 13 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
Write(await Html.PartialAsync("~/Views/Components/Form/FormMsg.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <table class=""my-2 bg-white border border-black fade-in"">
        <thead>
            <tr>
                <th class=""p-2 border border-black"">Name</th>
                <th class=""p-2 border border-black"">Description</th>
                <th class=""p-2 border border-black"">Status</th>
                <th class=""p-2 border border-black"">Update</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 24 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
             foreach (var category in categories)
            {
                var updateLink = $"{@Routers.UpdateCategory.Link}?categoryId={@category.CategoryId}";
                var deleteLink = $"{@Routers.DeleteCategory.Link}?categoryId={@category.CategoryId}";
                var activeColor = category.Status == CategoryStatus.ACTIVE ? "text-green-500" : "text-red-500";

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"p-2 text-center border border-black max-h-16\">");
#nullable restore
#line 30 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
                                                                        Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"p-2 text-center border border-black\">");
#nullable restore
#line 31 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
                                                               Write(category.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td");
            BeginWriteAttribute("class", " class=\"", 1487, "\"", 1566, 7);
            WriteAttributeValue("", 1495, "p-2", 1495, 3, true);
            WriteAttributeValue(" ", 1498, "text-center", 1499, 12, true);
            WriteAttributeValue(" ", 1510, "lowercase", 1511, 10, true);
            WriteAttributeValue(" ", 1520, "border", 1521, 7, true);
            WriteAttributeValue(" ", 1527, "border-black", 1528, 13, true);
            WriteAttributeValue(" ", 1540, "first-letter", 1541, 13, true);
#nullable restore
#line 32 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
WriteAttributeValue(" ", 1553, activeColor, 1554, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
                                                                                                   Write(category.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"p-2 text-center border border-black\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1709, "\"", 1727, 1);
#nullable restore
#line 35 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
WriteAttributeValue("", 1716, updateLink, 1716, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                        class=\"inline-block p-2 font-medium text-white duration-300 bg-blue-600 rounded-sm hover:bg-blue-800\">Update</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 42 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
     if (categories.Count <= 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-xl\">List is empty</div>\r\n");
#nullable restore
#line 45 "E:\server\grocery-store\Views\Containers\Category\Category.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
