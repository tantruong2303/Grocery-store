#pragma checksum "E:\grocery-store\Views\Containers\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e564d0dd4a569f55d2dd93aaafb81a5d02276648"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Containers_Home), @"mvc.1.0.view", @"/Views/Containers/Home.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e564d0dd4a569f55d2dd93aaafb81a5d02276648", @"/Views/Containers/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4787e2bf596517cbd42acf11f503cf4b3e860901", @"/Views/_ViewImports.cshtml")]
    public class Views_Containers_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\grocery-store\Views\Containers\Home.cshtml"
  
    ViewData["Title"] = Routers.Home.Title;
    List<Product> products = (List<Product>)ViewData["products"];
    List<Product> carts = (List<Product>)ViewData["cartItems"];
    Double total = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""flex flex-col justify-center flex-1 px-2 py-8 mb-24 space-y-4 md:flex-row md:space-x-4 md:space-y-0"">
    <div class=""space-y-2"">
        <h1 class=""text-xl font-semibold "">Product List</h1>
        <div class=""grid gap-2 md:grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 fade-in"">
");
#nullable restore
#line 14 "E:\grocery-store\Views\Containers\Home.cshtml"
             foreach (var product in products)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\grocery-store\Views\Containers\Home.cshtml"
                 if (product.Status == ProductStatus.ACTIVE)
                {
                    var updateLink = $"{@Routers.UpdateProduct.Link}?productId={@product.ProductId}";
                    var activeColor = product.Status == ProductStatus.ACTIVE ? "text-green-500" : "text-red-500";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"flex items-center justify-between p-2 space-x-2 bg-white rounded-lg shadow-lg\">\r\n                        <div class=\"w-16 h-16 overflow-hidden border-2 rounded-full \">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1101, "\"", 1124, 1);
#nullable restore
#line 22 "E:\grocery-store\Views\Containers\Home.cshtml"
WriteAttributeValue("", 1107, product.ImageUrl, 1107, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1125, "\"", 1144, 1);
#nullable restore
#line 22 "E:\grocery-store\Views\Containers\Home.cshtml"
WriteAttributeValue("", 1131, product.Name, 1131, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"block object-cover w-full h-full\" />\r\n                        </div>\r\n                        <div class=\"w-1/2 text-left\">\r\n                            <p class=\"font-semibold first-letter\">");
#nullable restore
#line 25 "E:\grocery-store\Views\Containers\Home.cshtml"
                                                             Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"max-lines\">");
#nullable restore
#line 26 "E:\grocery-store\Views\Containers\Home.cshtml"
                                            Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"font-medium text-yellow-600\">$");
#nullable restore
#line 27 "E:\grocery-store\Views\Containers\Home.cshtml"
                                                               Write(product.RetailPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1625, "\"", 1681, 3);
            WriteAttributeValue("", 1632, "/cart/add?productId=", 1632, 20, true);
#nullable restore
#line 30 "E:\grocery-store\Views\Containers\Home.cshtml"
WriteAttributeValue("", 1652, product.ProductId, 1652, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1670, "&quantity=1", 1670, 11, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                        class=\"inline-block px-2 py-1 text-white bg-blue-600 rounded-md\">Add to Cart</a>\r\n\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 35 "E:\grocery-store\Views\Containers\Home.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "E:\grocery-store\Views\Containers\Home.cshtml"
                 


            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"space-y-2\">\r\n        <h1 class=\"text-xl font-semibold\">My Cart</h1>\r\n        <div class=\"space-y-2 md:w-101\" id=\"mycart\">\r\n");
#nullable restore
#line 45 "E:\grocery-store\Views\Containers\Home.cshtml"
             if (carts == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"flex items-center justify-between p-2 space-x-2 bg-white rounded-md shadow-lg fade-in\">\r\n                    <p class=\"font-semibold\">Empty cart</p>\r\n                </div>\r\n");
#nullable restore
#line 50 "E:\grocery-store\Views\Containers\Home.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "E:\grocery-store\Views\Containers\Home.cshtml"
                 foreach (var cartItem in carts)
                {
                    total += cartItem.Quantity * cartItem.RetailPrice;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"flex items-center justify-between p-2 space-x-2 bg-white rounded-lg shadow-lg fade-in\">\r\n                        <div class=\"w-16 h-16 overflow-hidden border-2 rounded-full \"><img");
            BeginWriteAttribute("src", " src=\"", 2709, "\"", 2733, 1);
#nullable restore
#line 57 "E:\grocery-store\Views\Containers\Home.cshtml"
WriteAttributeValue("", 2715, cartItem.ImageUrl, 2715, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"mi\"\r\n                        class=\"block object-cover\"></div>\r\n                        <div class=\"flex-1 space-y-1\">\r\n                            <p class=\"font-semibold first-letter\">");
#nullable restore
#line 60 "E:\grocery-store\Views\Containers\Home.cshtml"
                                                             Write(cartItem.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <div class=\"flex space-x-2\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3038, "\"", 3096, 3);
            WriteAttributeValue("", 3045, "/cart/add?productId=", 3045, 20, true);
#nullable restore
#line 62 "E:\grocery-store\Views\Containers\Home.cshtml"
WriteAttributeValue("", 3065, cartItem.ProductId, 3065, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3084, "&quantity=-1", 3084, 12, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                            class=\"flex items-center justify-center w-6 h-6 font-semibold bg-blue-100\">-</a>\r\n                                <p>");
#nullable restore
#line 64 "E:\grocery-store\Views\Containers\Home.cshtml"
                              Write(cartItem.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3302, "\"", 3359, 3);
            WriteAttributeValue("", 3309, "/cart/add?productId=", 3309, 20, true);
#nullable restore
#line 65 "E:\grocery-store\Views\Containers\Home.cshtml"
WriteAttributeValue("", 3329, cartItem.ProductId, 3329, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3348, "&quantity=1", 3348, 11, true);
            EndWriteAttribute();
            WriteLiteral(@"
                            class=""flex items-center justify-center w-6 h-6 font-semibold bg-blue-100"">+</a>
                            </div>
                        </div>
                        <div>

                            <p class=""flex-1 font-medium text-right text-yellow-600"">$");
#nullable restore
#line 71 "E:\grocery-store\Views\Containers\Home.cshtml"
                                                                                  Write(cartItem.Quantity *
                        cartItem.RetailPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 75 "E:\grocery-store\Views\Containers\Home.cshtml"

                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "E:\grocery-store\Views\Containers\Home.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div
                class=""fixed z-50 w-full px-2 py-4 space-y-2 font-semibold transform -translate-x-1/2 bg-white border rounded-lg shadow-2xl bottom-4 md:w-101 left-1/2"">
                <div class=""flex items-center justify-between"">
                    <p>Total</p>
                    <p class=""text-blue-600"">$");
#nullable restore
#line 82 "E:\grocery-store\Views\Containers\Home.cshtml"
                                         Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div><a class=\"block w-full px-2 py-2 text-center text-white bg-blue-600 rounded-md\"\r\n                    href=\"#mycart\">View\r\n                    My Cart</a>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
