#pragma checksum "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a3d27b1c1ad6851a83d77321696ed3e2a61d660"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teklif_StokSecim), @"mvc.1.0.view", @"/Views/Teklif/StokSecim.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Teklif/StokSecim.cshtml", typeof(AspNetCore.Views_Teklif_StokSecim))]
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
#line 1 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui;

#line default
#line hidden
#line 2 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui.Models;

#line default
#line hidden
#line 3 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui.Extensions;

#line default
#line hidden
#line 4 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Entity;

#line default
#line hidden
#line 5 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#line 6 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui.Identity;

#line default
#line hidden
#line 8 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Entity.Dto;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a3d27b1c1ad6851a83d77321696ed3e2a61d660", @"/Views/Teklif/StokSecim.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a9b965b7c95906ff5f0d26cde38805766186f33", @"/Views/_ViewImports.cshtml")]
    public class Views_Teklif_StokSecim : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StokSecimModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Teklif", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StokSecim", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 97, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h1>Stok Listesi</h1>\r\n        <hr />\r\n");
            EndContext();
#line 7 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
         if (Model.KayitInsert)
        {

#line default
#line hidden
            BeginContext(164, 99, true);
            WriteLiteral("            <a href=\"/teklif/create\" class=\"btn btn-primary btn-sm mr-2\">Teklif Sayfas??na D??n</a>\r\n");
            EndContext();
#line 10 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
        }
        else if(Model.KayitUpdate)
        {

#line default
#line hidden
            BeginContext(321, 97, true);
            WriteLiteral("            <a href=\"/teklif/edit\" class=\"btn btn-primary btn-sm mr-2\">Teklif Sayfas??na D??n</a>\r\n");
            EndContext();
#line 14 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
        }

#line default
#line hidden
            BeginContext(429, 428, true);
            WriteLiteral(@"        <hr />
        <table class=""table table-bordered my-3"">
            <thead>
                <tr>
                    <td>Stok Kodu</td>
                    <td>Stok Ad??</td>
                    <td>Birim Fiyat</td>
                    <td>Fiyat</td>
                    <td>Stok Miktar??</td>
                    <td style=""width:180px;""></td>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 28 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                 if (Model.ListelenecekKayitlar.ToList().Count > 0)
                {
                    

#line default
#line hidden
#line 30 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                     foreach (var item in Model.ListelenecekKayitlar)
                    {

#line default
#line hidden
            BeginContext(1039, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(1102, 8, false);
#line 33 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                           Write(item.Kod);

#line default
#line hidden
            EndContext();
            BeginContext(1110, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1150, 12, false);
#line 34 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                           Write(item.StokAdi);

#line default
#line hidden
            EndContext();
            BeginContext(1162, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1202, 15, false);
#line 35 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                           Write(item.FiyatBirim);

#line default
#line hidden
            EndContext();
            BeginContext(1217, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1257, 10, false);
#line 36 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                           Write(item.Fiyat);

#line default
#line hidden
            EndContext();
            BeginContext(1267, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1307, 16, false);
#line 37 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                           Write(item.StokMiktari);

#line default
#line hidden
            EndContext();
            BeginContext(1323, 73, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1396, 117, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62dc072cbbb048b7b33804a7c220d38e", async() => {
                BeginContext(1506, 3, true);
                WriteLiteral("Se??");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 39 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1513, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 42 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                    }

#line default
#line hidden
#line 42 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                     
                }
                else
                {

#line default
#line hidden
            BeginContext(1664, 118, true);
            WriteLiteral("                    <div class=\"alert alert-warning \">\r\n                        ??r??n Yok\r\n                    </div>\r\n");
            EndContext();
#line 49 "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Teklif\StokSecim.cshtml"
                }

#line default
#line hidden
            BeginContext(1801, 60, true);
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StokSecimModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
