#pragma checksum "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8e364e511bd70c63154429782986d124edbefe0"
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
#line 1 "E:\MinhThuan\PRN211\restful\grocery-store\Views\_ViewImports.cshtml"
using Backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\MinhThuan\PRN211\restful\grocery-store\Views\_ViewImports.cshtml"
using Backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\MinhThuan\PRN211\restful\grocery-store\Views\_ViewImports.cshtml"
using Backend.Views.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\MinhThuan\PRN211\restful\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8e364e511bd70c63154429782986d124edbefe0", @"/Views/Containers/Category/CreateCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4787e2bf596517cbd42acf11f503cf4b3e860901", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Category_CreateCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex-1 px-4 py-16 mx-2 space-y-8 bg-white rounded-md shadow-lg md:mx-0 md:w-96 bg-opacity-90 md:flex-none fade-in"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
  
    ViewData["Title"] = Routers.CreateCategory.Title;
    var name = new FormField() { Label = "Category Name", Field = "name", Type = "text" };
    var descirption = new FormField() { Label = "Description", Field = "description", Type = "text" };
    var createBtn = new FormField() { Label = "Create Category" };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"flex items-center justify-center flex-1 \">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8e364e511bd70c63154429782986d124edbefe04951", async() => {
                WriteLiteral("\r\n        <h1 class=\"text-4xl font-semibold text-center\">Create Category</h1>\r\n        ");
#nullable restore
#line 12 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
   Write(await Html.PartialAsync("~/Views/Components/Form/FormMsg.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"space-y-4\">\r\n            ");
#nullable restore
#line 14 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 15 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", descirption));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"flex items-center space-x-2\">\r\n                <label class=\"font-medium\">Status: </label>\r\n                ");
#nullable restore
#line 18 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
           Write(Html.RadioButton("status", 1, true));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>Active </span>\r\n                ");
#nullable restore
#line 19 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
           Write(Html.RadioButton("status", 0));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>Inactive</span>\r\n            </div>\r\n        </div>\r\n        ");
#nullable restore
#line 22 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
   Write(await Html.PartialAsync("~/Views/Components/Form/FormBtn.cshtml", createBtn));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 9 "E:\MinhThuan\PRN211\restful\grocery-store\Views\Containers\Category\CreateCategory.cshtml"
AddHtmlAttributeValue("", 416, Routers.CreateCategory.Link, 416, 28, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
