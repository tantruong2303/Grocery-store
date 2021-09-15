#pragma checksum "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6712f3358b593c8bde9d5f104714d2743169486"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Containers_Product_UpdateProduct), @"mvc.1.0.view", @"/Views/Containers/Product/UpdateProduct.cshtml")]
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
#line 1 "E:\grocery-store\Views\_ViewImports.cshtml"
using Backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\grocery-store\Views\_ViewImports.cshtml"
using Backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\grocery-store\Views\_ViewImports.cshtml"
using Backend.Views.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6712f3358b593c8bde9d5f104714d2743169486", @"/Views/Containers/Product/UpdateProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4787e2bf596517cbd42acf11f503cf4b3e860901", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Product_UpdateProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex-1 px-4 py-8 mx-2 my-2 space-y-8 bg-white rounded-md shadow-lg md:mx-0 md:w-96 bg-opacity-90 md:flex-none fade-in"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
  
    ViewData["Title"] = Routers.UpdateProduct.Title;
    Product product = (Product)ViewData["product"];

    var name = new FormField() { Label = "Product Name", Field = "name", Type = "text", Value = product.Name };
    var descirption = new FormField()
    {
        Label = "Description",
        Field = "description",
        Type = "text",
        Value = product.Description
    };
    var status = new FormField()
    {
        Label = "Status",
        Field = "status",
        Type = "text",
        Value = product.Status
    };
    var originalPrice = new FormField()
    {
        Label = "Original Price",
        Field = "originalPrice",
        Type = "number",
        Value = product.OriginalPrice.ToString()
    };
    var retailPrice = new FormField()
    {
        Label = "Retail Price",
        Field = "retailPrice",
        Type = "number",
        Value = product.RetailPrice.ToString()
    };
    var quantity = new FormField()
    {
        Label = "Quantity",
        Field = "quantity",
        Type = "number",
        Value = product.Quantity.ToString()
    };
    var file = new FormField() { Label = "Product Image", Field = "file", Type = "file" };
    var categoryId = new FormField()
    {
        Label = "Category ID",
        Field = "categoryId",
        Type = "text",
        Value = product.CategoryId
    };

    var updateBtn = new FormField() { Label = "Update Product" };

    var actionLink = $"{Routers.UpdateProduct.Link}?productId={product.ProductId}";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"flex items-center justify-center flex-1 \">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6712f3358b593c8bde9d5f104714d27431694866393", async() => {
                WriteLiteral("\r\n        <h1 class=\"text-4xl font-semibold text-center\">Update Product</h1>\r\n        <div class=\"flex justify-center max-h-64\">\r\n            <img");
                BeginWriteAttribute("src", " src=\"", 1995, "\"", 2018, 1);
#nullable restore
#line 61 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
WriteAttributeValue("", 2001, product.ImageUrl, 2001, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"product\" id=\"pre-photo\" class=\"inline-block object-cover w-full \" />\r\n        </div>\r\n        ");
#nullable restore
#line 63 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
   Write(await Html.PartialAsync("~/Views/Components/Form/FormMsg.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"space-y-4\">\r\n            ");
#nullable restore
#line 65 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/FormMsg.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 66 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 67 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", descirption));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 68 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", originalPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 69 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", retailPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 70 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", quantity));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 71 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/FormCategories.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 72 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
       Write(await Html.PartialAsync("~/Views/Components/Form/TextFiled.cshtml", file));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"flex items-center space-x-2\">\r\n                <label class=\"font-medium\">Status: </label>\r\n                ");
#nullable restore
#line 75 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
           Write(Html.RadioButton("status", ProductStatus.ACTIVE,(product.Status == ProductStatus.ACTIVE)));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>Active\r\n                </span>\r\n                ");
#nullable restore
#line 77 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
           Write(Html.RadioButton("status", ProductStatus.INACTIVE,(product.Status ==
                ProductStatus.INACTIVE)));

#line default
#line hidden
#nullable disable
                WriteLiteral("<span>Inactive</span>\r\n            </div>\r\n\r\n        </div>\r\n        ");
#nullable restore
#line 82 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
   Write(await Html.PartialAsync("~/Views/Components/Form/FormBtn.cshtml", updateBtn));

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
#line 57 "E:\grocery-store\Views\Containers\Product\UpdateProduct.cshtml"
AddHtmlAttributeValue("", 1671, actionLink, 1671, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<script>
    document.getElementById(""file"").addEventListener(
        ""change"",
        function () {
            const reader = new FileReader();
            reader.onload = function () {
                const dataURL = reader.result;
                const output = document.getElementById(""pre-photo"");
                output.src = dataURL;
            };
            reader.readAsDataURL(this.files[0]);
        },
        false
    );
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
