#pragma checksum "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82f7e996f0b72f196cb254ae3b9ef0cc98b1f490"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Survey_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Survey/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82f7e996f0b72f196cb254ae3b9ef0cc98b1f490", @"/Areas/Admin/Views/Survey/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1daad97f620738587fb0904a310e973a7d71c147", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Survey_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-lg-12 grid-margin stretch-card"">
    <div class=""card"">
        <div class=""card-body"">
            <div class=""form-group"">
                <h6><label for=""Name"">Name</label></h6>
                <input type=""text"" class=""form-control"" id=""questionOld""");
            BeginWriteAttribute("value", " value=\"", 368, "\"", 393, 1);
#nullable restore
#line 12 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
WriteAttributeValue("", 376, ViewBag.sur.Name, 376, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\n            </div>\n            <div class=\"form-group\">\n                <h6><label for=\"Updated\">Updated</label></h6>\n                <input type=\"text\" class=\"form-control\" id=\"Updated\"");
            BeginWriteAttribute("value", " value=\"", 591, "\"", 644, 1);
#nullable restore
#line 16 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
WriteAttributeValue("", 599, ViewBag.sur.Updated.ToString("dd/MM/yyyy"), 599, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\n            </div>\n            <div class=\"form-group\">\n                <h6><label for=\"object\">Object</label></h6>\n                <input type=\"text\" class=\"form-control\" id=\"object\"");
            BeginWriteAttribute("value", " value=\"", 839, "\"", 892, 1);
#nullable restore
#line 20 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
WriteAttributeValue("", 847, ViewBag.sur.Active ? "Teacher" : "Student", 847, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\n            </div>\n            <div class=\"form-group\">\n                <h6><label for=\"desc\">Description</label></h6>\n                <textarea class=\"form-control\" id=\"desc\"  rows=\"4\" disabled>");
#nullable restore
#line 24 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
                                                                       Write(ViewBag.sur.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
            </div>
            <h4 class=""card-title"">Answer Table</h4>

            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Question</th>
                    </tr>
                </thead>
                <tbody id=""bodyAnswer"">

");
#nullable restore
#line 37 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
                     if (ViewBag.sur.QuestionSurveys != null)
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
                         foreach (var item in ViewBag.sur.QuestionSurveys)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>");
#nullable restore
#line 41 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
                               Write(item.IdQuestion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 42 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
                               Write(item.IdQuestionNavigation.Question1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            </tr>\n");
#nullable restore
#line 44 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Areas\Admin\Views\Survey\Detail.cshtml"
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
