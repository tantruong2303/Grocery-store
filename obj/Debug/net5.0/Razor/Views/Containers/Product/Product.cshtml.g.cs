#pragma checksum "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Product\Product.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbd807a9b308755fcd648bab697cde35620163ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Containers_Product_Product), @"mvc.1.0.view", @"/Views/Containers/Product/Product.cshtml")]
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
using Backend.Views.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\Desktop\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbd807a9b308755fcd648bab697cde35620163ee", @"/Views/Containers/Product/Product.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4787e2bf596517cbd42acf11f503cf4b3e860901", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Product_Product : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"text-center\">\r\n    ");
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\grocery-store\Views\Containers\Product\Product.cshtml"
Write(await Html.PartialAsync("~/Views/Components/Form/FormMsg.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <a href=\"/product/create\">create</a>\r\n    <a href=\"/product/update?productId=477e4029-5784-4635-881b-cf5b2256aba9\">update</a>\r\n    <br>\r\n</div>\r\n");
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