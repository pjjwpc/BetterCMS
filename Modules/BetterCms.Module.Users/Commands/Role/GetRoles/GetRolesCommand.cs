﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetRolesCommand.cs" company="Devbridge Group LLC">
// 
// Copyright (C) 2015,2016 Devbridge Group LLC
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// 
// <summary>
// Better CMS is a publishing focused and developer friendly .NET open source CMS.
// 
// Website: https://www.bettercms.com 
// GitHub: https://github.com/devbridge/bettercms
// Email: info@bettercms.com
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Linq;

using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Mvc.Grids.Extensions;
using BetterCms.Module.Root.Mvc.Grids.GridOptions;
using BetterCms.Module.Root.ViewModels.SiteSettings;

using BetterCms.Module.Users.ViewModels.Role;

using BetterModules.Core.DataAccess.DataContext;
using BetterModules.Core.Web.Mvc.Commands;

using NHibernate.Linq;

namespace BetterCms.Module.Users.Commands.Role.GetRoles
{
    public class GetRolesCommand : CommandBase, ICommand<SearchableGridOptions, SearchableGridViewModel<RoleViewModel>>
    {
        public SearchableGridViewModel<RoleViewModel> Execute(SearchableGridOptions request)
        {
            var roles = Repository
               .AsQueryable<Models.Role>()
               .Select(role => new RoleViewModel
                   {
                       Id = role.Id,
                       Version = role.Version,
                       Name = role.Name,
                       Description = role.Description,
                       IsSystematic = role.IsSystematic
                   });

            if (!string.IsNullOrWhiteSpace(request.SearchQuery))
            {

                roles = roles
                            .Where(a => a.Name.Contains(request.SearchQuery.ToLower().ToLowerInvariant()) || 
                                        a.Description != null && a.Description.ToLower().Contains(request.SearchQuery.ToLowerInvariant()));
            }

            request.SetDefaultSortingOptions("Name");
            var count = roles.ToRowCountFutureValue();
            roles = roles.AddSortingAndPaging(request);

            return new SearchableGridViewModel<RoleViewModel>(roles.ToFuture().ToList(), request, count.Value);
        }
    }
}