#pragma checksum "E:\server\final\grocery-store\Views\Components\Form\FormBtn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b443924d049d64544728a85373d77c25c6f8ac06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Components_Form_FormBtn), @"mvc.1.0.view", @"/Views/Components/Form/FormBtn.cshtml")]
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
#line 1 "E:\server\final\grocery-store\Views\_ViewImports.cshtml"
using Backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\server\final\grocery-store\Views\_ViewImports.cshtml"
using Backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\server\final\grocery-store\Views\_ViewImports.cshtml"
using Backend.Utils.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b443924d049d64544728a85373d77c25c6f8ac06", @"/Views/Components/Form/FormBtn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48f5f22d9a6e26ef591873adf0210c7162d00e84", @"/Views/_ViewImports.cshtml")]
    public class Views_Components_Form_FormBtn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"flex flex-1\">\r\n    <button class=\"inline-block w-full px-4 py-3 align-top btn btn-primary \" id=\"form-btn\">");
#nullable restore
#line 2 "E:\server\final\grocery-store\Views\Components\Form\FormBtn.cshtml"
                                                                                      Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
    <div id=""loading"" class=""hidden text-center"">
        <svg width=""20"" viewBox=""0 0 57 57"" xmlns=""http://www.w3.org/2000/svg"" class=""w-8 h-8"">
            <g fill=""none"" fill-rule=""evenodd"">
                <g transform=""translate(1 1)"">
                    <circle cx=""5"" cy=""50"" r=""5"" fill=""rgb(45, 55, 72)"">
                        <animate attributeName=""cy"" begin=""0s"" dur=""2.2s"" values=""50;5;50;50"" calcMode=""linear""
                            repeatCount=""indefinite""></animate>
                        <animate attributeName=""cx"" begin=""0s"" dur=""2.2s"" values=""5;27;49;5"" calcMode=""linear""
                            repeatCount=""indefinite""></animate>
                    </circle>
                    <circle cx=""27"" cy=""5"" r=""5"" fill=""rgb(45, 55, 72)"">
                        <animate attributeName=""cy"" begin=""0s"" dur=""2.2s"" from=""5"" to=""5"" values=""5;50;50;5""
                            calcMode=""linear"" repeatCount=""indefinite""></animate>
                        <animate attribut");
            WriteLiteral(@"eName=""cx"" begin=""0s"" dur=""2.2s"" from=""27"" to=""27"" values=""27;49;5;27""
                            calcMode=""linear"" repeatCount=""indefinite""></animate>
                    </circle>
                    <circle cx=""49"" cy=""50"" r=""5"" fill=""rgb(45, 55, 72)"">
                        <animate attributeName=""cy"" begin=""0s"" dur=""2.2s"" values=""50;50;5;50"" calcMode=""linear""
                            repeatCount=""indefinite""></animate>
                        <animate attributeName=""cx"" from=""49"" to=""49"" begin=""0s"" dur=""2.2s"" values=""49;5;27;49""
                            calcMode=""linear"" repeatCount=""indefinite""></animate>
                    </circle>
                </g>
            </g>
        </svg>
    </div>
</div>");
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
