#pragma checksum "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dfd0c6574ba33ef099d386302a938f0d8efda87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "E:\dotnet\InterviewBoard\Views\_ViewImports.cshtml"
using InterviewBoard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\dotnet\InterviewBoard\Views\_ViewImports.cshtml"
using InterviewBoard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dfd0c6574ba33ef099d386302a938f0d8efda87", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49901732e0adbb25372eed8990cf7f8c84fec8de", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
#line 1 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<header>\r\n    <nav>\r\n        ");
#nullable restore
#line 8 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
   Write(Html.Partial("NavMenu", (string)@ViewBag.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </nav>\r\n</header>\r\n\r\n<div class=\"grid-container\" style=\"margin-left: 300px\">\r\n\r\n");
#nullable restore
#line 14 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
     foreach (var post in ViewBag.Posts)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card grid-item\" style=\"margin-left: 00px\">\r\n            <div class=\"container\">\r\n                <h4 style=\"margin-top : 20px\"><b>");
#nullable restore
#line 18 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
                                            Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n                <p style=\"margin-top: 25px\">");
#nullable restore
#line 19 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
                                       Write(post.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 20 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
                 if (ViewBag.Role == "golam")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4dfd0c6574ba33ef099d386302a938f0d8efda874794", async() => {
                WriteLiteral("\r\n                        <input class=\"btn btn-danger\" style=\"margin-top: 8px; cursor: pointer; display: block; margin-left: 8px\" value=\"Apply\" id=\"apply\"");
                BeginWriteAttribute("onclick", " onclick=\"", 742, "\"", 777, 4);
                WriteAttributeValue("", 752, "clickApply(", 752, 11, true);
#nullable restore
#line 23 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"
WriteAttributeValue("", 763, post.PostId, 763, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 775, ")", 775, 1, true);
                WriteAttributeValue(" ", 776, "", 777, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n     \r\n                          \r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n");
#nullable restore
#line 27 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <script>
                    function clickApply(id) {
                        var request = new XMLHttpRequest(); 

                        request.open('GET', ""/post/apply?id="" + id, true); 
                        request.setRequestHeader(""Content-Type"", ""application/json""); 

                        request.onload = function () { 
                            var data = JSON.parse(this.response); 
                            console.log(data.result); 
                            if (data.result === ""OK"") { 

                                window.location.replace(""/home/index"");                            
                            } else { 
                                window.location.replace(""/home/index""); 
                            } 
                        } 
                        request.send(); 
                    } 
                </script> 

            </div> 
        </div> 
");
#nullable restore
#line 52 "E:\dotnet\InterviewBoard\Views\Home\Index.cshtml"

    } 

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
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
