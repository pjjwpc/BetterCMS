﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Layouts/OneColumnLayout.cshtml")]
    public partial class _Views_Shared_Layouts_OneColumnLayout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared_Layouts_OneColumnLayout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 28 "..\..\Views\Shared\Layouts\OneColumnLayout.cshtml"
  
    Layout = "~/Areas/bcms-root/Views/Shared/BaseLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"bcms-layout-full\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 33 "..\..\Views\Shared\Layouts\OneColumnLayout.cshtml"
Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

            
            #line 35 "..\..\Views\Shared\Layouts\OneColumnLayout.cshtml"
Write(RenderSection("Scripts", false));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
