#pragma checksum "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf8ec2c396c6cc4078861b5b9a2f9759460f29ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_RoleEdit), @"mvc.1.0.view", @"/Views/Admin/RoleEdit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/RoleEdit.cshtml", typeof(AspNetCore.Views_Admin_RoleEdit))]
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
#line 1 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui;

#line default
#line hidden
#line 2 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui.Models;

#line default
#line hidden
#line 3 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui.Extensions;

#line default
#line hidden
#line 4 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Entity;

#line default
#line hidden
#line 5 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#line 6 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Satis.Webui.Identity;

#line default
#line hidden
#line 8 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\_ViewImports.cshtml"
using Senfoni.Entity.Dto;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf8ec2c396c6cc4078861b5b9a2f9759460f29ea", @"/Views/Admin/RoleEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a9b965b7c95906ff5f0d26cde38805766186f33", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_RoleEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleDetails>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RoleEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(20, 86, true);
            WriteLiteral("\r\n<h1>Edit Role</h1>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(106, 2009, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "952bdfe12a384b44b813be6960dfee6d", async() => {
                BeginContext(157, 56, true);
                WriteLiteral("\r\n            <h6 class=\"bg-info text-white p-1\">Add to ");
                EndContext();
                BeginContext(214, 15, false);
#line 8 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                                                 Write(Model.Role.Name);

#line default
#line hidden
                EndContext();
                BeginContext(229, 53, true);
                WriteLiteral("</h6>\r\n            <input type=\"hidden\" name=\"RoleId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 282, "\"", 304, 1);
#line 9 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 290, Model.Role.Id, 290, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(305, 53, true);
                WriteLiteral(" />\r\n            <input type=\"hidden\" name=\"RoleName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 358, "\"", 382, 1);
#line 10 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 366, Model.Role.Name, 366, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(383, 64, true);
                WriteLiteral(" />\r\n            <table class=\"table table-bordered table-sm\">\r\n");
                EndContext();
#line 12 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                 if (Model.NonMembers.Count() == 0)
                {

#line default
#line hidden
                BeginContext(519, 127, true);
                WriteLiteral("                    <tr>\r\n                        <td colspan=\"2\">Bütün Kullanıcılar Role Ait</td>\r\n                    </tr>\r\n");
                EndContext();
#line 17 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                }
                else
                {
                    foreach (var user in Model.NonMembers)
                    {

#line default
#line hidden
                BeginContext(789, 62, true);
                WriteLiteral("                        <tr>\r\n                            <td>");
                EndContext();
                BeginContext(852, 13, false);
#line 23 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                           Write(user.UserName);

#line default
#line hidden
                EndContext();
                BeginContext(865, 133, true);
                WriteLiteral("</td>\r\n                            <td style=\"width:150px;\">\r\n                                <input  type=\"checkbox\" name=\"IdsToAdd\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 998, "\"", 1014, 1);
#line 25 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 1006, user.Id, 1006, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1015, 71, true);
                WriteLiteral(" />\r\n                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 28 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                    }
                }

#line default
#line hidden
                BeginContext(1128, 101, true);
                WriteLiteral("            </table>\r\n            <hr />\r\n\r\n            <h6 class=\"bg-info text-white p-1\">Remove to ");
                EndContext();
                BeginContext(1230, 15, false);
#line 33 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                                                    Write(Model.Role.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1245, 66, true);
                WriteLiteral("</h6>\r\n            <table class=\"table table-bordered table-sm\">\r\n");
                EndContext();
#line 35 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                 if (Model.Members.Count() == 0)
                {

#line default
#line hidden
                BeginContext(1380, 122, true);
                WriteLiteral("                    <tr>\r\n                        <td colspan=\"2\">Role Ait Kullanıcı Yok</td>\r\n                    </tr>\r\n");
                EndContext();
#line 40 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                }
                else
                {
                    foreach (var user in Model.Members)
                    {

#line default
#line hidden
                BeginContext(1642, 62, true);
                WriteLiteral("                        <tr>\r\n                            <td>");
                EndContext();
                BeginContext(1705, 13, false);
#line 46 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                           Write(user.UserName);

#line default
#line hidden
                EndContext();
                BeginContext(1718, 135, true);
                WriteLiteral("</td>\r\n                            <td style=\"width:150px;\">\r\n                                <input type=\"checkbox\" name=\"IdsToDelete\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1853, "\"", 1869, 1);
#line 48 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
WriteAttributeValue("", 1861, user.Id, 1861, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1870, 71, true);
                WriteLiteral(" />\r\n                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 51 "C:\Users\90543\source\repos\SenfoniWeb\Senfoni.Satis.Webui\Views\Admin\RoleEdit.cshtml"
                    }
                }

#line default
#line hidden
                BeginContext(1983, 125, true);
                WriteLiteral("            </table>\r\n            \r\n            <button type=\"submit\" class=\"btn btn-primary\">Save Changes</button>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2115, 20, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
