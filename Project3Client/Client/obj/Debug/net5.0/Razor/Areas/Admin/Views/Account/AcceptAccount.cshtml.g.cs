#pragma checksum "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54d1cde5060d17f3762f09153513f9266e3cf2ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account_AcceptAccount), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/AcceptAccount.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54d1cde5060d17f3762f09153513f9266e3cf2ed", @"/Areas/Admin/Views/Account/AcceptAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1daad97f620738587fb0904a310e973a7d71c147", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Account_AcceptAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
  
    ViewData["Title"] = "AcceptAccount";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-lg-12 grid-margin stretch-card"">
    <div class=""card"">
        <div class=""card-body"">
            <h4 class=""card-title"">List Account</h4>
            <table class=""table table-striped"" id=""tableAcc"">
                <thead>
                    <tr>
                        <th>Username</th>
                        <th> Id People </th>
                        <th> Date </th>
                        <th> Role </th>
                        <th> Account </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 22 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                     if (ViewBag.listAccount != null)
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                         foreach (var acc in ViewBag.listAccount)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "54d1cde5060d17f3762f09153513f9266e3cf2ed5182", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 921, "~/img/avatar/", 921, 13, true);
#nullable restore
#line 27 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
AddHtmlAttributeValue("", 934, acc.Img, 934, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 27 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                                                                                         Write(acc.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>");
#nullable restore
#line 29 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                               Write(acc.IdPeople);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 30 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                               Write(acc.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 31 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                               Write(acc.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n                                    <button class=\"btn btn-gradient-warning\">\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1358, "\"", 1435, 4);
            WriteAttributeValue("", 1365, "/admin/account/detailAccount?idAccount=", 1365, 39, true);
#nullable restore
#line 34 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
WriteAttributeValue("", 1404, acc.Id, 1404, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1411, "&&idPerson=", 1411, 11, true);
#nullable restore
#line 34 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
WriteAttributeValue("", 1422, acc.IdPeople, 1422, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            <i class=""mdi mdi-format-list-bulleted menu-icon""></i>
                                        </a>
                                    </button>
                                </td>
                            </tr>
");
#nullable restore
#line 40 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Account\AcceptAccount.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n            </table>\n        </div>\n    </div>\n</div>\n\n");
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