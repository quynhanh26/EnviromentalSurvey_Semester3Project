#pragma checksum "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d888d2c522b8d98b7c5a912934627a301801d83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seminar_RegisteredSeminar), @"mvc.1.0.view", @"/Views/Seminar/RegisteredSeminar.cshtml")]
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
#line 1 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d888d2c522b8d98b7c5a912934627a301801d83", @"/Views/Seminar/RegisteredSeminar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fd22fe3589ebdc381df8dd96b3beba49422a762", @"/Views/_ViewImports.cshtml")]
    public class Views_Seminar_RegisteredSeminar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
   ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section id=""schedule"" class=""section-with-bg"" style=""visibility: visible;animation-name: fadeInUp;"">
    <div class=""container"" data-aos=""fade-up"">
        <div class=""section-header"">
            <h2>Event Schedule</h2>
            <p>Here is our event schedule</p>
        </div>
");
#nullable restore
#line 10 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
         if (ViewBag.msg != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>");
#nullable restore
#line 12 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
           Write(ViewBag.msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n");
#nullable restore
#line 13 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
        }
        else
        {

            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
             foreach (var seminar in ViewBag.seminar)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul class=\"nav nav-tabs\" role=\"tablist\" data-aos=\"fade-up\" data-aos-delay=\"100\">\n                    <li class=\"nav-item\">\n                        <a class=\"nav-link active\" href=\"#day-1\" role=\"tab\" data-bs-toggle=\"tab\">");
#nullable restore
#line 21 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
                                                                                            Write(seminar.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n                    </li>\n                </ul>\n");
            WriteLiteral("                <h3 class=\"sub-heading\">\n                    Voluptatem nulla veniam soluta et corrupti consequatur neque eveniet officia. Eius\n                    necessitatibus voluptatem quis labore perspiciatis quia.\n                </h3>\n");
            WriteLiteral(@"                <div class=""tab-content row justify-content-center"" data-aos=""fade-up"" data-aos-delay=""200"">

                    <!-- Schdule Day 1 -->
                    <div role=""tabpanel"" class=""col-lg-9 tab-pane fade show active"" id=""day-1"">

                        <div class=""row schedule-item"">
                            <div class=""col-md-6"">
                                <h3>");
#nullable restore
#line 37 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
                               Write(seminar.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                                <h3>");
#nullable restore
#line 38 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
                               Write(seminar.Presenters);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                                <h3>");
#nullable restore
#line 39 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
                               Write(seminar.TimeStart);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                                <h3>");
#nullable restore
#line 40 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
                               Write(seminar.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                                <h3>");
#nullable restore
#line 41 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
                               Write(seminar.Place);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                            </div>\n                        </div>\n\n\n                    </div>\n                </div>\n");
#nullable restore
#line 48 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\ACER\OneDrive\Desktop\EnviromentSurvey\Project3Client-master\Client\Views\Seminar\RegisteredSeminar.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n\n</section>\n");
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
