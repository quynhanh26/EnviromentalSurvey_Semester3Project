#pragma checksum "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45080022a7064ca15c99ed66164c868616f696ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Seminar_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Seminar/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45080022a7064ca15c99ed66164c868616f696ed", @"/Areas/Admin/Views/Seminar/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1daad97f620738587fb0904a310e973a7d71c147", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Seminar_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#nullable restore
#line 1 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""col-lg-12 grid-margin stretch-card"">
    <div class=""card"">
        <div class=""card-body"">
            <h4 class=""card-title"">Seminar Table</h4>
            <table class=""table table-hover"" id=""tableSeminar"">
                <thead>
                    <tr>
                        <th> Seminar </th>
                        <th> Presenter </th>
                        <th> Time </th>
                        <th> Status </th>
                        <th> Action </th>
                    </tr>
                </thead>
                <tbody id=""tbobySeminar"">
");
#nullable restore
#line 20 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                     if (ViewBag.listSeminarDTO != null)
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                         foreach (var seminar in ViewBag.listSeminarDTO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td hidden>");
#nullable restore
#line 24 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                                      Write(seminar.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "45080022a7064ca15c99ed66164c868616f696ed5447", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1004, "~/img/seminar/", 1004, 14, true);
#nullable restore
#line 26 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
AddHtmlAttributeValue("", 1018, seminar.Img, 1018, 12, false);

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
            WriteLiteral(" ");
#nullable restore
#line 26 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                                                                                                Write(seminar.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>");
#nullable restore
#line 28 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                               Write(seminar.NamePresenters);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 29 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                               Write(seminar.Day.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n");
#nullable restore
#line 30 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                                 if (seminar.Day < DateTime.Now && seminar.Status)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><label class=\"badge badge-gradient-success\">Completed</label></td>\n");
#nullable restore
#line 33 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                                }
                                else if (seminar.Day >= DateTime.Now && seminar.Status)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><label class=\"badge badge-gradient-warning\">Coming soon</label></td>\n");
#nullable restore
#line 37 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><label class=\"badge badge-gradient-danger\">False</label></td>\n");
#nullable restore
#line 41 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <td>
                                    <button class=""btn btn-gradient-danger delSeminar""><i class=""mdi mdi-account-remove""></i></button>
                                    <button class=""btn btn-gradient-warning"">
                                        <a");
            BeginWriteAttribute("href", " href=\"", 2276, "\"", 2326, 2);
            WriteAttributeValue("", 2283, "/admin/seminar/detail?idSeminar=", 2283, 32, true);
#nullable restore
#line 45 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
WriteAttributeValue("", 2315, seminar.Id, 2315, 11, false);

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
#line 51 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Seminar\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n            </table>\n        </div>\n    </div>\n</div>");
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