#pragma checksum "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20c7363ba4d9835ce3b90b5905c1cb962826f832"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fraud_Index), @"mvc.1.0.view", @"/Views/Fraud/Index.cshtml")]
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
#line 1 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\_ViewImports.cshtml"
using AIProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\_ViewImports.cshtml"
using AIProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20c7363ba4d9835ce3b90b5905c1cb962826f832", @"/Views/Fraud/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1e35024d8f0bd11d7c4f23f36cd71f307787d68", @"/Views/_ViewImports.cshtml")]
    public class Views_Fraud_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UploadCsv", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
  
    ViewData["Title"] = "Upload CSV";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .tooltip-wrapper {
        position: relative;
        display: inline-block;
        cursor: pointer;
    }

        .tooltip-wrapper .tooltip-text {
            visibility: hidden;
            width: 180px;
            background-color: #333;
            color: #fff;
            text-align: center;
            border-radius: 5px;
            padding: 8px;
            position: absolute;
            z-index: 100;
            bottom: 125%; /* Tooltip appears above */
            left: 50%;
            transform: translateX(-50%);
            opacity: 0;
            transition: opacity 0.3s ease;
            font-size: 14px;
            pointer-events: none;
            white-space: normal;
        }

        .tooltip-wrapper:hover .tooltip-text {
            visibility: visible;
            opacity: 1;
        }

    /* Circular icon button */
    .help-icon-btn {
        width: 22px;
        height: 22px;
        border-radius: 50%;
        background-color: l");
            WriteLiteral(@"ightslategray;
        color: white;
        border: none;
        font-size: 18px;
        font-weight: bold;
        line-height: 32px;
        text-align: center;
        vertical-align: middle;
        cursor: pointer;
        padding: 0;
        display: inline-flex;
        align-items: center;
        justify-content: center;
    }

        .help-icon-btn:hover {
            background-color: #0056b3;
        }
</style>
<div class=""card"">
    <div class=""card-header nav-link"">
        <i class=""fas fa-table me-1""></i>
        <h3 class=""text-info text-lg-left"">");
#nullable restore
#line 63 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
                                      Write(Resource.FraudDetection);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"card-body\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20c7363ba4d9835ce3b90b5905c1cb962826f8326308", async() => {
                WriteLiteral("\r\n            <h5>\r\n                <i class=\"fas fa-file\"></i> ");
#nullable restore
#line 69 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
                                       Write(Resource.SelectACSV);

#line default
#line hidden
#nullable disable
                WriteLiteral("  \r\n                <div class=\"tooltip-wrapper\">\r\n                    <button class=\"help-icon-btn\" type=\"button\">?</button>\r\n                    <div class=\"tooltip-text\">");
#nullable restore
#line 72 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
                                         Write(Resource.TransactionFileProperties);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</div>
                </div>
            </h5>
            <div class=""form-floating mb-5 "">
                <input type=""file"" name=""file"" accept="".csv"" />
                <button type=""submit"" class=""btn-info text-white mb-3"">Upload and Detect</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 81 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
         if (ViewBag.Error != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p style=\"color:red;\">");
#nullable restore
#line 83 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
                             Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 84 "C:\Users\bboylu\source\repos\OPENAI\OPENAI\Views\Fraud\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
