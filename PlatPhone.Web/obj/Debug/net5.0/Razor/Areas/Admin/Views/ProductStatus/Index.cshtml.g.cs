#pragma checksum "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\ProductStatus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691c55fd98f81c96a86fb554e114024de3d8019d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductStatus_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductStatus/Index.cshtml")]
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
#line 1 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\_ViewImports.cshtml"
using PlatPhone.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"691c55fd98f81c96a86fb554e114024de3d8019d", @"/Areas/Admin/Views/ProductStatus/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f4aac41cce2bb45cfed320401ec95d0117d59b3", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ProductStatus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\ProductStatus\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Header", async() => {
                WriteLiteral("\r\n<link href=\"/Style/CustomeStyle.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            WriteLiteral(@"
<div id=""ProductTableRow""></div>

<div id=""BasicModal"" class=""modal fade bd-example-modal-lg"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog modal-lg MyModal"" id=""MyModal"">
        <div class=""modal-content"" id=""ContentModal""></div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"/admin_section/js/jquery.stepy.js\"></script>\r\n    <script src=\"/Script/ProductStatus/Index.js\"></script>\r\n");
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
