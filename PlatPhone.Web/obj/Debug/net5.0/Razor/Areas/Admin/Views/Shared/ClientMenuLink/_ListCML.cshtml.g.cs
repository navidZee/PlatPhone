#pragma checksum "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54035c2cf2c4008540e304cf43cf4db3928777db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_ClientMenuLink__ListCML), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/ClientMenuLink/_ListCML.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54035c2cf2c4008540e304cf43cf4db3928777db", @"/Areas/Admin/Views/Shared/ClientMenuLink/_ListCML.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f4aac41cce2bb45cfed320401ec95d0117d59b3", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_ClientMenuLink__ListCML : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PlatPhone.DataLayer.ClientMenuLink>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
  
    int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <section class=""panel"">
            <section class=""Panel_Withe_Body row"" style=""margin:7px 2px 2px 0;"">
                <div class=""row"">
                    <div class=""col-md-2"">
                        <button onclick=""LoadAddEditCML()"" class=""btn btn-block btn-success btn-sm btn-round"" data-toggle=""modal"" data-target="".bd-example-modal-lg"" ");
            WriteLiteral(@">
                            افزودن لینک
                        </button>
                    </div>
                </div>
                <br />
                <table class=""table table-condensed table-hover"" style=""border-radius: 0 0 10px 10px"">
                    <tr>
                        <td class=""font-weight-bold"">#</td>
                        <td>عنوان</td>
                        <td>نمایش/ویرایش/حذف</td>
                    </tr>
");
#nullable restore
#line 24 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
                     foreach (var item in Model)
                    {
                        var myid = item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 28 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 29 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1309, "\"", 1342, 3);
            WriteAttributeValue("", 1319, "LoadDetailCML(", 1319, 14, true);
#nullable restore
#line 31 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
WriteAttributeValue("", 1333, item.Id, 1333, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1341, ")", 1341, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#myModal2\" class=\"btn btn-warning  btn-xs\"><i class=\"icon-eye-open\"></i></button>\r\n                                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1499, "\"", 1533, 3);
            WriteAttributeValue("", 1509, "LoadAddEditCML(", 1509, 15, true);
#nullable restore
#line 32 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
WriteAttributeValue("", 1524, item.Id, 1524, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1532, ")", 1532, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\".bd-example-modal-lg\" class=\"btn btn-primary editBtn btn-xs\"><i class=\"icon-edit\"></i></button>\r\n                                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1704, "\"", 1737, 3);
            WriteAttributeValue("", 1714, "ConfirmDelete(", 1714, 14, true);
#nullable restore
#line 33 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
WriteAttributeValue("", 1728, item.Id, 1728, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1736, ")", 1736, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger detailBtn btn-xs\"><i class=\"icon-trash\"></i></button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 36 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ClientMenuLink\_ListCML.cshtml"
                        i = i + 1;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </section>\r\n        </section>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PlatPhone.DataLayer.ClientMenuLink>> Html { get; private set; }
    }
}
#pragma warning restore 1591
