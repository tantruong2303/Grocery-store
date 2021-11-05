#pragma checksum "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bd59a6bb6e6c0dbf1fc5d24ed49ecf6f492e288"
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
#line 1 "C:\Users\Lenovo\Desktop\grocery-store\Views\_ViewImports.cshtml"
using Backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\grocery-store\Views\_ViewImports.cshtml"
using Backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bd59a6bb6e6c0dbf1fc5d24ed49ecf6f492e288", @"/Views/Containers/Category/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48f5f22d9a6e26ef591873adf0210c7162d00e84", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Category_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex-1 space-y-2 intro-x"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formFilter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
  
    this.ViewData["Title"] = Routers.Category.Title;
    var categories = (List<Category>)this.ViewData["categories"];
    var total = (int)this.ViewData["total"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"flex-1 min-h-screen px-2 py-2 xl:px-8 xl:py-6 \">\r\n    <div class=\"flex\">\r\n        <!-- BEGIN: Side Menu -->\r\n        ");
#nullable restore
#line 10 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
   Write(await Html.PartialAsync("../../Components/Navbar/NavbarSide.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <!-- END: Side Menu -->
        <!-- BEGIN: Content -->
        <div class=""content"">
            <div class=""mt-5 intro-y box"">
                <div class=""flex flex-col items-center p-5 border-b border-gray-200 sm:flex-row"">
                    <h2 class=""mr-auto text-base font-medium"">
                        Category Manager
                    </h2>

                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8bd59a6bb6e6c0dbf1fc5d24ed49ecf6f492e2885300", async() => {
                WriteLiteral("\r\n                    ");
#nullable restore
#line 22 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
               Write(await Html.PartialAsync("../../Components/Form/FormHidden.cshtml",
                    new { Name = "pageSize", Value = (string) this.Context.Request.Query["pageSize"] ?? "12" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 24 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
               Write(await Html.PartialAsync("../../Components/Form/FormHidden.cshtml",
                    new { Name = "pageIndex",Value = (string) this.Context.Request.Query["pageIndex"] ?? "0" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                <div class=""p-5"" id=""hoverable-table"">
                    <div class=""preview"">
                        <div class=""overflow-x-auto"">
                            <table class=""table"">
                                <thead>
                                    <tr>
                                        <th class=""border border-b-2 dark:border-dark-5 whitespace-nowrap"">#
                                        </th>
                                        <th class=""border border-b-2 dark:border-dark-5 whitespace-nowrap"">Name
                                        </th>
                                        <th class=""border border-b-2 dark:border-dark-5 whitespace-nowrap"">Description
                                        </th>
                                        <th class=""border border-b-2 dark:border-dark-5 whitespace-nowrap"">Stauts</th>
                                        <th class=""border border-b-2 dark:border-dark-5 whitespace-nowrap"">Edit</th>
          ");
            WriteLiteral("                          </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 45 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                                     for (int i = 0; i < categories.Count; i++)
                                    {
                                        var item = categories[i];
                                        var link = $"{Routers.UpdateCategory.Link}?categoryId={item.CategoryId}";


#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr class=\"hover:bg-gray-200\">\r\n                                            <td class=\"border\">");
#nullable restore
#line 51 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"border\">");
#nullable restore
#line 52 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"border\">");
#nullable restore
#line 53 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                                                          Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"border\">\r\n                                                ");
#nullable restore
#line 55 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                                           Write(await Html.PartialAsync("../../Components/Table/Status.cshtml", item.Status
                                            == CategoryStatus.ACTIVE ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td class=\"border\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 3459, "\"", 3471, 1);
#nullable restore
#line 59 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
WriteAttributeValue("", 3466, link, 3466, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mb-2 mr-1 btn btn-primary\"> <i data-feather=\"edit\"\r\n                                                    class=\"w-5 h-5\"></i> </a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 63 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                            ");
#nullable restore
#line 66 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Category\Category.cshtml"
                       Write(await Html.PartialAsync("../../Components/Common/Pagination.cshtml",
                            new { PageIndex = (string) this.Context.Request.Query["pageIndex"] ?? "0", PageSize =
                            (string)
                            this.Context.Request.Query["pageSize"]?? "12", Total = total }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!-- END: Content -->\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n<script src=\"/js/pagination.js\"></script>\r\n\r\n");
            }
            );
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
