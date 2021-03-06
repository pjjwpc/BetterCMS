﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestoreContentVersionCommand.cs" company="Devbridge Group LLC">
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

using BetterCms.Core.Exceptions.Mvc;
using BetterCms.Core.Security;

using BetterCms.Module.Pages.Content.Resources;
using BetterCms.Module.Pages.Models;
using BetterCms.Module.Pages.Services;
using BetterCms.Module.Pages.ViewModels.Content;

using BetterCms.Module.Root;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Services;

using BetterModules.Core.Web.Mvc.Commands;

using NHibernate.Linq;

namespace BetterCms.Module.Pages.Command.History.RestoreContentVersion
{
    /// <summary>
    /// Command for restoring page content version
    /// </summary>
    public class RestoreContentVersionCommand : CommandBase, ICommand<RestorePageContentViewModel, ChangedContentResultViewModel>
    {
        /// <summary>
        /// Gets or sets the content service.
        /// </summary>
        /// <value>
        /// The content service.
        /// </value>
        public IContentService contentService { get; set; }

        /// <summary>
        /// Gets or sets the widget service.
        /// </summary>
        /// <value>
        /// The widget service.
        /// </value>
        public IWidgetService WidgetService { get; set; }

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// <c>true</c>, if successfully restored.
        /// </returns>
        public ChangedContentResultViewModel Execute(RestorePageContentViewModel request)
        {
            var content = Repository
                .AsQueryable<Root.Models.Content>(p => p.Id == request.PageContentId)
                .Fetch(f => f.Original)
                .First();

            var contentType = content.GetType();
            if (contentType == typeof(HtmlContentWidget) || contentType == typeof(ServerControlWidget))
            {
                AccessControlService.DemandAccess(Context.Principal, RootModuleConstants.UserRoles.Administration);
            }
            else
            {
                AccessControlService.DemandAccess(Context.Principal, RootModuleConstants.UserRoles.PublishContent);
                if (content.Original != null)
                {
                    var pageContent = Repository.AsQueryable<Root.Models.PageContent>()
                            .Where(x => x.Content.Id == content.Original.Id && !x.IsDeleted)
                            .Fetch(x => x.Page)
                            .ThenFetchMany(x => x.AccessRules)
                            .ToList()
                            .FirstOrDefault();

                    if (pageContent != null)
                    {
                        AccessControlService.DemandAccess(pageContent.Page, Context.Principal, AccessLevel.ReadWrite);

                        // Check if user has confirmed the deletion of regions in content.
                        if (!request.IsUserConfirmed && pageContent.Page.IsMasterPage)
                        {
                            var hasAnyChildren = contentService.CheckIfContentHasDeletingChildren(pageContent.Page.Id, content.Original.Id, ((HtmlContent)content).Html);
                            if (hasAnyChildren)
                            {
                                var message = PagesGlobalization.RestoreContent_ContentHasChildrenContents_RegionDeleteConfirmationMessage;
                                var logMessage = string.Format("User is trying to restore content with regions which has children contents. Confirmation is required. PageContentId: {0}, ContentId: {1}, PageId: {2}",
                                       pageContent.Id, content.Id, pageContent.Page.Id);
                                throw new ConfirmationRequestException(() => message, logMessage);
                            }
                        }
                    }
                }
            }

            var restoredContent = contentService.RestoreContentFromArchive(content);

            UnitOfWork.Commit();

            Events.RootEvents.Instance.OnContentRestored(restoredContent);

            var response = new ChangedContentResultViewModel
                {
                    ContentId = restoredContent.Id,
                    DesirableStatus = restoredContent.Status,
                    Title = restoredContent.Name,
                    ContentVersion = restoredContent.Version
                };

            //if (request.IncludeChildRegions)
            //{
                response.Regions = WidgetService.GetWidgetChildRegionViewModels(restoredContent);
            //}

            return response;
        }
    }
}