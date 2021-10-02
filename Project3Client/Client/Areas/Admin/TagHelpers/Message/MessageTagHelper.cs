using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client.ServiceAPI;
namespace Client.Areas.Admin.TagHelpers.Message
{
    [HtmlTargetElement("message", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class MessageTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private IHtmlHelper htmlHelper;
        private IAccountAPI accountAPI;
        private ISeminarAPI seminarAPI;
        public MessageTagHelper(IHtmlHelper _htmlHelper, IAccountAPI _accountAPI, ISeminarAPI _seminarAPI)
        {
            htmlHelper = _htmlHelper;
            accountAPI = _accountAPI;
            seminarAPI = _seminarAPI;
        }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);
            output.TagName = "";

            htmlHelper.ViewBag.Count = accountAPI.CountActive() == null ? "0" : accountAPI.CountActive();
            htmlHelper.ViewBag.CountSer = seminarAPI.CountAccept() == null ? "0" : seminarAPI.CountAccept();
            output.Content.SetHtmlContent(await htmlHelper.PartialAsync("TagHelpers/Message/Message"));
        }
    }
}
