#pragma checksum "C:\Users\90543\Documents\GitHub\Asp.Net_Mvc_fromDemandtoOrder\Senfoni.Satis.Webui\Views\Shared\_search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4e7da95f02ff49f76878f8465288537cb2d574a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__search), @"mvc.1.0.view", @"/Views/Shared/_search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_search.cshtml", typeof(AspNetCore.Views_Shared__search))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4e7da95f02ff49f76878f8465288537cb2d574a", @"/Views/Shared/_search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a9b965b7c95906ff5f0d26cde38805766186f33", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 129, true);
            WriteLiteral("<div class=\"card mt-3\">\r\n    <div class=\"card-header\">\r\n        <h5>Arama</h5>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        ");
            EndContext();
            BeginContext(129, 288, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0aeeafe80544718970c4c0a8ded0323", async() => {
                BeginContext(153, 257, true);
                WriteLiteral(@"
            <div class=""form-group"">
                <input name=""q"" type=""text"" class=""form-control"" placeholder=""Arama"">
            </div>
            
            <button type=""submit"" class=""btn btn-danger btn-sm btn-block"">Ara</button>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(417, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
