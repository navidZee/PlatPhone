#pragma checksum "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\SiteConfiguration\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0a42c032f324877f1900731ed88bc3415f1cd86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SiteConfiguration_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/SiteConfiguration/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0a42c032f324877f1900731ed88bc3415f1cd86", @"/Areas/Admin/Views/SiteConfiguration/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f4aac41cce2bb45cfed320401ec95d0117d59b3", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_SiteConfiguration_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PlatPhone.DataLayer.SiteConfiguration>>
    {
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
#line 2 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\SiteConfiguration\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <section class=""panel"">
            <section class=""Panel_Withe_Body row"" style=""margin:7px 2px 2px 0;"">
                <div class=""row"">
                    <div class=""col-md-2"" style=""margin-bottom:8px"">
                        تظیمات درگاه ریزن پال
                    </div>
                </div>
                <div class=""row"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0a42c032f324877f1900731ed88bc3415f1cd863839", async() => {
                WriteLiteral(@"
                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"">عنوان سایت در درگاه</label>
                            <div class=""col-lg-4"">
                                <input type=""text"" id=""siteTitle"" name=""siteTitle""");
                BeginWriteAttribute("value", " value=\'", 800, "\'", 874, 1);
#nullable restore
#line 20 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\SiteConfiguration\Index.cshtml"
WriteAttributeValue("", 808, Model.Where(g => g.Key == "TitleZarinPal").FirstOrDefault().Value, 808, 66, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" />
                            </div>

                            <label class=""col-lg-2 control-label"">مرچن کد وصل شدن به درگاه</label>
                            <div class=""col-lg-4"">
                                <input type=""text"" id=""siteMerchanId""");
                BeginWriteAttribute("value", " value=\'", 1160, "\'", 1239, 1);
#nullable restore
#line 25 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\SiteConfiguration\Index.cshtml"
WriteAttributeValue("", 1168, Model.Where(g => g.Key == "MerchantIDZarinPal").FirstOrDefault().Value, 1168, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control "" />
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"" style=""margin-top: 12px;"">ایمیل درگاه</label>
                            <div class=""col-lg-4"">
                                <input type=""text"" id=""siteEmail"" style=""margin-top: 15px;""");
                BeginWriteAttribute("value", " value=\'", 1641, "\'", 1715, 1);
#nullable restore
#line 31 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\SiteConfiguration\Index.cshtml"
WriteAttributeValue("", 1649, Model.Where(g => g.Key == "EmailZarinPal").FirstOrDefault().Value, 1649, 66, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control form-control-file"" />
                            </div>
                        </div>
                        <input type=""button"" class=""btn btn-info "" onclick=""sendInfo()"" value=""ذخیره"" style=""float: left;margin-top: 15px;margin-left: 16px;"" />
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </section>\r\n        </section>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function sendInfo() {
            var array = [];
            array.push({ Key: ""TitleZarinPal"", Value: $(""input#siteTitle"").val() });
            array.push({ Key: ""MerchantIDZarinPal"", Value: $(""input#siteMerchanId"").val() });
            array.push({ Key: ""EmailZarinPal"", Value: $(""input#siteEmail"").val() });
            var postData = { values: array };
            console.log(array);
            $.ajax({
                type: ""POST"",
                url: ""/Admin/SiteConfiguration/PostSiteConfiguration"",
                data: { siteConfigurations: array },
                success: function (result) {

                    if (result == ""OK"") {
                        alertOK();
                    }

                }, error: function () {}
            });
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PlatPhone.DataLayer.SiteConfiguration>> Html { get; private set; }
    }
}
#pragma warning restore 1591
