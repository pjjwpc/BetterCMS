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
    
    #line 28 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditableGrid/Partial/BooleanCell.cshtml")]
    public partial class _Views_Shared_EditableGrid_Partial_BooleanCell_cshtml : System.Web.Mvc.WebViewPage<BetterCms.Module.Root.Mvc.Grids.EditableGridBooleanColumn>
    {
        public _Views_Shared_EditableGrid_Partial_BooleanCell_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<td");

WriteLiteral(" style=\"width: 100px;\"");

WriteLiteral(" ");

            
            #line 31 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                     Write(Html.Raw(Model.Attributes));

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

            
            #line 32 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
     if (Model.CanBeEdited)
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"bcms-checkbox-holder bcms-pointer\"");

WriteLiteral(" data-bind=\"checked: ");

            
            #line 34 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                         Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral(", enterPress: onSave, afterRender: initInput($element, ");

            
            #line 34 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                 Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral("), escPress: onCancelEdit, visible: isActive() ");

            
            #line 34 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                                                                                 Write(!string.IsNullOrEmpty(Model.FocusIdentifier) ? string.Format(", hasfocus: {0}", Model.FocusIdentifier) : string.Empty);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" />\r\n");

            
            #line 35 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 36 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
     if (Model.ShowValueAsText)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"bcms-tables-link\"");

WriteLiteral(" data-bind=\"text: ");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                   Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral("() === true || ");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                    Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral("() === \'true\' ? \'");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                      Write(RootGlobalization.Button_Yes);

            
            #line default
            #line hidden
WriteLiteral("\' : (");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                         Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral("() === false || ");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                                           Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral("() === \'false\' ? \'");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                                                                              Write(RootGlobalization.Button_No);

            
            #line default
            #line hidden
WriteLiteral("\' : \'&nbsp;\' ) ");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                                                                                                                          Write(!string.IsNullOrEmpty(Model.FocusIdentifier) ? string.Format(", click: onItemSelect.bind($data, {0})", Model.FocusIdentifier) : string.Empty);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 38 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                          Write(Model.CanBeEdited ? ", visible: !isActive()"  : string.Empty);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("></div>\r\n");

            
            #line 39 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"bcms-checkbox-holder\"");

WriteLiteral(" data-bind=\"checked: ");

            
            #line 42 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                            Write(Model.ValueBind);

            
            #line default
            #line hidden
WriteLiteral("() ");

            
            #line 42 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                 Write(!string.IsNullOrEmpty(Model.FocusIdentifier) ? string.Format(", click: onItemSelect.bind($data, {0})", Model.FocusIdentifier) : string.Empty);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 42 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
                                                                                                                                                                                                                                                 Write(Model.CanBeEdited ? ", visible: !isActive()"  : string.Empty);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" />\r\n");

            
            #line 43 "..\..\Views\Shared\EditableGrid\Partial\BooleanCell.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</td>\n");

        }
    }
}
#pragma warning restore 1591
