#pragma checksum "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e53d97743f1e5fa7440299ad7f96e669010d2f22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\_ViewImports.cshtml"
using SallyPieShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e53d97743f1e5fa7440299ad7f96e669010d2f22", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10be48c176ad0e814b8d0ccedd61aaa7f7859467", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <img class=\"card-img\"");
            BeginWriteAttribute("src", " src=\"", 161, "\"", 191, 1);
#nullable restore
#line 11 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
WriteAttributeValue("", 167, Model.ImageThumbnailUrl, 167, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 192, "\"", 209, 1);
#nullable restore
#line 11 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
WriteAttributeValue("", 198, Model.Name, 198, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card-text\">\r\n            <h3 class=\"text-right\">");
#nullable restore
#line 13 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
                              Write(Model.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <h3>\r\n                ");
#nullable restore
#line 15 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <h4>");
#nullable restore
#line 17 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
           Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <p>");
#nullable restore
#line 18 "D:\Documents\University\Programming\SallyPieShop\SallyPieShop\Views\Home\Details.cshtml"
          Write(Model.LongDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pie> Html { get; private set; }
    }
}
#pragma warning restore 1591
