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
    
    #line 28 "..\..\Views\Category\CategoriesTemplate.cshtml"
    using BetterCms.Module.Root;
    
    #line default
    #line hidden
    
    #line 29 "..\..\Views\Category\CategoriesTemplate.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    #line 30 "..\..\Views\Category\CategoriesTemplate.cshtml"
    using BetterCms.Module.Root.Mvc;
    
    #line default
    #line hidden
    
    #line 31 "..\..\Views\Category\CategoriesTemplate.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Category/CategoriesTemplate.cshtml")]
    public partial class _Views_Category_CategoriesTemplate_cshtml : System.Web.Mvc.WebViewPage<BetterCms.Module.Root.ViewModels.Category.CategoryTemplateViewModel>
    {
        public _Views_Category_CategoriesTemplate_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 34 "..\..\Views\Category\CategoriesTemplate.cshtml"
   var canEdit = (ViewContext.Controller as CmsControllerBase).SecurityService.IsAuthorized(RootModuleConstants.UserRoles.EditContent); 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Category\CategoriesTemplate.cshtml"
                            Write(RootGlobalization.CategoriesTemplate_AddCategories_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 37 "..\..\Views\Category\CategoriesTemplate.cshtml"
Write(Html.Tooltip(Model.TooltipDescription));

            
            #line default
            #line hidden
WriteLiteral("\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"bcms-js-categories-select\"");

WriteLiteral(" />\r\n\r\n<div");

WriteLiteral(" class=\"bcms-single-tag-holder\"");

WriteLiteral(" data-bind=\"foreach: items\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"bcms-single-tag\"");

WriteLiteral(" >\r\n        <div");

WriteLiteral(" data-bind=\"text: $data.text\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" class=\"bcms-single-tag-remove\"");

WriteLiteral(" data-bind=\"");

            
            #line 43 "..\..\Views\Category\CategoriesTemplate.cshtml"
                                                   Write(canEdit ? "click: $parent.remove" : string.Empty);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Category\CategoriesTemplate.cshtml"
                                                                                                       Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    </div>\r\n    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-bind=\"attr: { name: \'Categories[\'+ $index() +\'].key\', value: $data.id }\"");

WriteLiteral("/>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
