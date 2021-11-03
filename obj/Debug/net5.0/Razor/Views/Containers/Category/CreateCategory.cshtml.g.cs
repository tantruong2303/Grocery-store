#pragma checksum "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5245bd48d05dcc88a750e19726596c256df5c599"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Containers_Category_CreateCategory), @"mvc.1.0.view", @"/Views/Containers/Category/CreateCategory.cshtml")]
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
#line 1 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\_ViewImports.cshtml"
using Backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\_ViewImports.cshtml"
using Backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5245bd48d05dcc88a750e19726596c256df5c599", @"/Views/Containers/Category/CreateCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48f5f22d9a6e26ef591873adf0210c7162d00e84", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Category_CreateCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("createCategoryForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("p-5 space-y-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
  
    this.ViewData["Title"] = Routers.Category.Title;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"flex-1 min-h-screen px-2 py-2 xl:px-8 xl:py-6\">\r\n    <div class=\"flex\">\r\n        <!-- BEGIN: Side Menu -->\r\n        ");
#nullable restore
#line 9 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
   Write(await Html.PartialAsync("../../Components/Navbar/NavbarSide.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <!-- END: Side Menu -->
        <!-- BEGIN: Content -->
        <div class=""content"">
            <div class=""max-w-sm mt-5 intro-y box"">
                <div class=""flex flex-col items-center p-5 border-b border-gray-200 sm:flex-row dark:border-dark-5"">
                    <h2 class=""mr-auto text-base font-medium"">
                        Create Category
                    </h2>
                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5245bd48d05dcc88a750e19726596c256df5c5995305", async() => {
                WriteLiteral("\r\n                    <div class=\"space-y-2 preview\">\r\n                        ");
#nullable restore
#line 21 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
                   Write(await Html.PartialAsync("../../Components/Form/FormMessage.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <div>\r\n                            <label>Name</label>\r\n                            ");
#nullable restore
#line 24 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
                       Write(await Html.PartialAsync("../../Components/Form/TextField.cshtml", new
                            {Label="Category Name",
                            Field="name",Type="text", Value=""}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div>\r\n                            <label>Description</label>\r\n                            ");
#nullable restore
#line 30 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
                       Write(await Html.PartialAsync("../../Components/Form/TextField.cshtml",new
                            {Label="Description",
                            Field="description",Type="text", Value=""}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </div>
                        <div>
                            <label>Status</label>
                            <div class=""flex flex-col mt-2 sm:flex-row"">
                                <div class=""mr-2 form-check"">
                                    <input id=""radio-switch-4"" class=""form-check-input"" type=""radio"" name=""status""
                                        value=""1"" checked=""checked"">
                                    <label class=""form-check-label"" for=""radio-switch-4"">Active</label>
                                </div>
                                <div class=""mt-2 mr-2 form-check sm:mt-0"">
                                    <input id=""radio-switch-5"" class=""form-check-input"" type=""radio"" name=""status""
                                        value=""0"">
                                    <label class=""form-check-label"" for=""radio-switch-5"">Inactive</label>
                                </div>

                            </div>
           ");
                WriteLiteral("             </div>\r\n                    </div>\r\n\r\n                    ");
#nullable restore
#line 52 "E:\MinhThuan\PRN211\Pagination-2\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
               Write(await Html.PartialAsync("../../Components/Form/FormBtn.cshtml","Create Category"));

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
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n        </div>\r\n        <!-- END: Content -->\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n<script src=\"/js/createCategory.js\"></script>\r\n\r\n");
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
