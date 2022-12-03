#pragma checksum "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92d9097e2fcd759f8280a4ae68dbf653dac92ba2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_List), @"mvc.1.0.view", @"/Views/Order/List.cshtml")]
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
#line 1 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\_ViewImports.cshtml"
using SportsStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\_ViewImports.cshtml"
using SportsStore.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\_ViewImports.cshtml"
using SportsStore.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d9097e2fcd759f8280a4ae68dbf653dac92ba2", @"/Views/Order/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"878638a5d4ca19856ebdc3849ed8ffd5f45a966a", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkShipped", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
  
    ViewBag.Title = "Orders";
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Unshipped Orders</h4>\r\n");
#nullable restore
#line 8 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
 if (Model.UnshippedOrders.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-bordered table-striped\">\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Zip</th>\r\n            <th colspan=\"2\">Details</th>\r\n            <th></th>\r\n        </tr>\r\n");
#nullable restore
#line 17 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
         foreach (Order o in Model.UnshippedOrders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
               Write(o.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
               Write(o.Zip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <th>Product</th>\r\n                <th>Quantity</th>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92d9097e2fcd759f8280a4ae68dbf653dac92ba25733", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"orderId\"");
                BeginWriteAttribute("value", " value=\"", 737, "\"", 755, 1);
#nullable restore
#line 26 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
WriteAttributeValue("", 745, o.OrderID, 745, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <button type=\"submit\" class=\"btn btn-sm btn-danger\">\r\n                            Ship\r\n                        </button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
             foreach (CartLine line in o.Lines)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"2\"></td>\r\n                    <td>");
#nullable restore
#line 37 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
                   Write(line.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
                   Write(line.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td></td>\r\n                </tr>\r\n");
#nullable restore
#line 41 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 44 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">No Unshipped Orders</div>\r\n");
#nullable restore
#line 48 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Shipped Orders</h4>\r\n\r\n");
#nullable restore
#line 52 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
 if (Model.ShippedOrders.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-bordered table-striped\">\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Zip</th>\r\n            <th colspan=\"2\">Details</th>\r\n        </tr>\r\n");
#nullable restore
#line 60 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
         foreach (Order o in Model.ShippedOrders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 63 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
               Write(o.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 64 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
               Write(o.Zip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <th>Product</th>\r\n                <th>Quantity</th>\r\n            </tr>\r\n");
#nullable restore
#line 68 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
             foreach (CartLine line in o.Lines)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"2\"></td>\r\n                    <td>");
#nullable restore
#line 72 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
                   Write(line.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 73 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
                   Write(line.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 75 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 78 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">No Shipped Orders</div>\r\n");
#nullable restore
#line 82 "D:\Documents\University\Programming\SportsStore_Test\SportsStore\Views\Order\List.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
