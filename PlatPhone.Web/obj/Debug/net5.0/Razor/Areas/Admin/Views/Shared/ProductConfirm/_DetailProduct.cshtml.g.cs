#pragma checksum "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ce136c835db495023bfd07f66835019847c2508"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_ProductConfirm__DetailProduct), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/ProductConfirm/_DetailProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ce136c835db495023bfd07f66835019847c2508", @"/Areas/Admin/Views/Shared/ProductConfirm/_DetailProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f4aac41cce2bb45cfed320401ec95d0117d59b3", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_ProductConfirm__DetailProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<PlatPhone.DataLayer.Product, List<PlatPhone.DataLayer.Category>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
    <script language=""javascript"" type=""text/javascript"">
        $(function () {
            $(""#file"").change(function () {
                $(""#dvPreview"").html("""");
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                if (regex.test($(this).val().toLowerCase())) {
                    if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                        $(""#dvPreview"").show();
                        $(""#dvPreview"")[0].filters.item(""DXImageTransform.Microsoft.AlphaImageLoader"").src = $(this).val();
                    }
                    else {
                        if (typeof (FileReader) != ""undefined"") {
                            $(""#dvPreview"").show();
                            $(""#dvPreview"").append(""<img />"");
                            var reader = new FileReader();
                            ");
                WriteLiteral(@"reader.onload = function (e) {
                                $(""#dvPreview img"").attr(""src"", e.target.result);
                            }
                            reader.readAsDataURL($(this)[0].files[0]);
                        } else {
                            alert(""This browser does not support FileReader."");
                        }
                    }
                } else {
                    alert(""Please upload a valid image file."");
                }
            });
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Header", async() => {
                WriteLiteral(@"
    <style type=""text/css"">
        #dvPreview {
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=image);
            min-height: 400px;
            min-width: 400px;
            /*display: none;*/
            border: dashed;
            margin-left: 10%;
        }
    </style>
");
            }
            );
            WriteLiteral(@"
<!-- page start-->
<div class=""row"">
    <div class=""col-lg-12"">
        <section class=""panel"">
            <header class=""panel-heading"">
                ?????????? ??????????
            </header>
            <div class=""panel-body"">             
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ce136c835db495023bfd07f66835019847c25086656", async() => {
                WriteLiteral("\r\n\r\n                    <input id=\"Id\" name=\"Id\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2381, "\"", 2404, 1);
#nullable restore
#line 59 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 2389, Model.Item1.Id, 2389, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <input id=\"ImageUrl\" name=\"ImageUrl\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2478, "\"", 2507, 1);
#nullable restore
#line 60 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 2486, Model.Item1.ImageUrl, 2486, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">

                    <fieldset title=""?????????? ??????"" class=""step"" id=""default-step-0"">
                        <legend></legend>
                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"">?????? ??????????</label>
                            <div class=""col-lg-10"">
                                <input name=""Name"" disabled=""disabled"" id=""Name"" type=""text"" class=""form-control"" placeholder=""?????? ???????? ??????????""");
                BeginWriteAttribute("value", " value=\"", 2969, "\"", 2994, 1);
#nullable restore
#line 67 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 2977, Model.Item1.Name, 2977, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                        </div>

                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"">?????????? ??????????</label>
                            <div class=""col-lg-10"">
                                <input name=""Keyword"" disabled=""disabled"" id=""Keyword"" type=""text"" class=""form-control"" placeholder=""?????????? ??????????""");
                BeginWriteAttribute("value", " value=\"", 3403, "\"", 3431, 1);
#nullable restore
#line 74 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 3411, Model.Item1.Keyword, 3411, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                        </div>

                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"">???????? ????????</label>
                            <div class=""col-lg-4"">
                                <select id=""CategoryId"" disabled=""disabled"" name=""CategoryId"" class=""form-control m-bot15"">
");
#nullable restore
#line 82 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                     foreach (var item in Model.Item2)
                                    {
                                        if (item.Parent == 0)
                                        {
                                            int idParent = item.Id;


#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <optgroup");
                BeginWriteAttribute("label", " label=\"", 4158, "\"", 4176, 1);
#nullable restore
#line 88 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 4166, item.Name, 4166, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 89 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                                 foreach (var item2 in Model.Item2)
                                                {
                                                    if (item2.Parent == idParent)
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ce136c835db495023bfd07f66835019847c250811534", async() => {
#nullable restore
#line 93 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                                                             Write(item2.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                                           WriteLiteral(item2.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 94 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                                    }
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </optgroup>\r\n");
#nullable restore
#line 97 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </select>

                            </div>
                            <label class=""col-lg-2 control-label"">??????????</label>
                            <div class=""col-lg-4"">
                                <input id=""DisCount"" name=""DisCount"" type=""number"" min=""0"" max=""100"" class=""form-control"" placeholder=""??????????""");
                BeginWriteAttribute("value", " value=\"", 5158, "\"", 5187, 1);
#nullable restore
#line 104 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 5166, Model.Item1.Discount, 5166, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                        </div>


                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"">????????</label>
                            <div class=""col-lg-4"">
                                <input id=""Price"" name=""Price"" type=""text"" class=""form-control"" placeholder=""???????? ??????????""");
                BeginWriteAttribute("value", " value=\"", 5565, "\"", 5591, 1);
#nullable restore
#line 112 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 5573, Model.Item1.Price, 5573, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                            <label class=""col-lg-2 control-label"">?????????? ?????????? ???? ??????????</label>
                            <div class=""col-lg-4"">
                                <input id=""Inventory"" disabled=""disabled"" name=""Inventory"" type=""text"" class=""form-control"" placeholder=""?????????? ?????????? ???? ??????????""");
                BeginWriteAttribute("value", " value=\"", 5937, "\"", 5967, 1);
#nullable restore
#line 116 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 5945, Model.Item1.Inventory, 5945, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            </div>
                        </div>

                    </fieldset>

                    <fieldset title=""?????????? ??????????"" class=""step"" id=""default-step-2"">
                        <legend></legend>
                        <div class=""form-group"">
                            <label class=""col-lg-2 control-label"">??????????????</label>
                            <div class=""col-lg-10"">
                                <textarea disabled=""disabled"" id=""Description"" name=""Description"" class=""form-control"" cols=""60"" rows=""6"">");
#nullable restore
#line 127 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
                                                                                                                                     Write(Model.Item1.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</textarea>
                            </div>
                        </div>
                    </fieldset>

                    <div class=""form-group"">
                        <label class=""col-lg-2 control-label""> ?????? ??????????</label>
                        <div class=""col-lg-10"">
                            <img");
                BeginWriteAttribute("src", " src=\"", 6877, "\"", 6937, 1);
#nullable restore
#line 135 "G:\Project\Students\PlatPhone\PlatPhone.Web\Areas\Admin\Views\Shared\ProductConfirm\_DetailProduct.cshtml"
WriteAttributeValue("", 6883, "/Image/Uploade/ProductImage/"+Model.Item1.ImageUrl, 6883, 54, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width:200px\" alt=\"?????? ?????????? ???????? ??????\" />\r\n                        </div>\r\n                    </div>\r\n                    <input type=\"button\" onclick=\"UpdatePrice()\" style=\"float:left\" class=\" btn btn-danger\" value=\"??????????\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </section>
    </div>
</div>
<!-- page end-->

<script>

    $(function () {
        $('#default').stepy({
            backLabel: '????????',
            block: true,
            nextLabel: '????????',
            titleClick: true,
            titleTarget: '.stepy-tab'
        });
    });
</script>
















");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<PlatPhone.DataLayer.Product, List<PlatPhone.DataLayer.Category>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
