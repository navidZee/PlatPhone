#pragma checksum "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c008821a5fec853c9e180d150fcc30d8aca5313c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_ListNews), @"mvc.1.0.view", @"/Views/News/ListNews.cshtml")]
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
#line 1 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\_ViewImports.cshtml"
using PlatPhone.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c008821a5fec853c9e180d150fcc30d8aca5313c", @"/Views/News/ListNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f4aac41cce2bb45cfed320401ec95d0117d59b3", @"/Views/_ViewImports.cshtml")]
    public class Views_News_ListNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PlatPhone.DataLayer.News>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
  
    ViewBag.Title = "ListNews";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <div class=""sub_header_in color-bg-primary"">
        <div class=""container"">
            <h1>آخرین اخبار</h1>
        </div>
    </div>
    <div class=""container margin_60_35"">
        <div class=""row"">
            <div class=""col-lg-12"">
");
#nullable restore
#line 15 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
                 foreach (var item in Model.OrderByDescending(p => p.CreateDate))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"strip list_view\">\r\n                        <div class=\"row no-gutters\">\r\n                            <div class=\"col-lg-5\">\r\n                                <figure>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 679, "\"", 711, 2);
            WriteAttributeValue("", 686, "/News/DetailNews/", 686, 17, true);
#nullable restore
#line 21 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
WriteAttributeValue("", 703, item.Id, 703, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 717, "\"", 759, 2);
            WriteAttributeValue("", 723, "/Image/Uploade/NewsImage/", 723, 25, true);
#nullable restore
#line 21 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
WriteAttributeValue("", 748, item.Image, 748, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 778, "\"", 784, 0);
            EndWriteAttribute();
            WriteLiteral(@"><div class=""read_more""><span>خواندن خبر</span></div></a>
                                </figure>
                            </div>
                            <div class=""col-lg-7"">
                                <div class=""wrapper"">
                                    <ul>
                                        <h3><a");
            BeginWriteAttribute("href", " href=\"", 1118, "\"", 1150, 2);
            WriteAttributeValue("", 1125, "/News/DetailNews/", 1125, 17, true);
#nullable restore
#line 27 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
WriteAttributeValue("", 1142, item.Id, 1142, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
                                                                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                                        <small>");
#nullable restore
#line 28 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
                                          Write(item.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                        <small>");
#nullable restore
#line 29 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
                                          Write(item.KeyWord);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                    </ul>\r\n                                </div>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 36 "G:\Project\Students\PlatPhone\PlatPhone.Web\Views\News\ListNews.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PlatPhone.DataLayer.News>> Html { get; private set; }
    }
}
#pragma warning restore 1591
