﻿using System;
using System.Linq;

using BetterCms.Core.Mvc.Commands;
using BetterCms.Core.Web;

using BetterCms.Module.ImagesGallery.Models;
using BetterCms.Module.ImagesGallery.ViewModels;
using BetterCms.Module.MediaManager.Models;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Mvc.Helpers;

using NHibernate.Criterion;
using NHibernate.Transform;

namespace BetterCms.Module.ImagesGallery.Command.GetAlbum
{
    public class GetAlbumCommand : CommandBase, ICommand<GetAlbumCommandRequest, AlbumViewModel>
    {
        /// <summary>
        /// The context accessor
        /// </summary>
        private readonly IHttpContextAccessor contextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAlbumCommand" /> class.
        /// </summary>
        /// <param name="contextAccessor">The context accessor.</param>
        public GetAlbumCommand(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public AlbumViewModel Execute(GetAlbumCommandRequest request)
        {
            Album albumAlias = null;
            MediaFolder folderAlias = null;
            MediaImage coverAlias = null;
            AlbumViewModel albumViewModel = null;

            var album = UnitOfWork.Session
                   .QueryOver(() => albumAlias)
                   .Left.JoinAlias(c => c.Folder, () => folderAlias)
                   .Left.JoinAlias(c => c.CoverImage, () => coverAlias)
                   .Where(() => !albumAlias.IsDeleted && !folderAlias.IsDeleted && albumAlias.Id == request.AlbumId)
                   .SelectList(select => select
                       .Select(() => albumAlias.Title).WithAlias(() => albumViewModel.Title)
                       .Select(() => folderAlias.Id).WithAlias(() => albumViewModel.FolderId)
                       .SelectSubQuery(
                           QueryOver.Of<Media>()
                               .Where(c => !c.IsDeleted)
                               .And(c => c.Folder.Id == folderAlias.Id && c.Original == null)
                               .Select(Projections.Max<Media>(c => c.ModifiedOn))
                       ).WithAlias(() => albumViewModel.LastUpdateDate)
                   )
               .TransformUsing(Transformers.AliasToBean<AlbumViewModel>())
               .SingleOrDefault<AlbumViewModel>();


            if (album != null)
            {
                album.Url = ConstructBackUrl(request.AlbumId);

                if (!album.FolderId.HasDefaultValue())
                {
                    album.Images =
                        Repository.AsQueryable<MediaImage>()
                                  .Where(i => i.Folder.Id == album.FolderId && i.Original == null)
                                  .Select(i => new ImageViewModel { Url = i.PublicUrl, Caption = i.Caption ?? i.Title, Title = i.Title })
                                  .OrderBy(i => i.Title)
                                  .ToList();
                    album.ImagesCount = album.Images.Count;
                }
            }
            else
            {
                album = new AlbumViewModel();
            }

            album.LoadCmsStyles = request.WidgetViewModel.GetOptionValue<bool>(ImageGalleryModuleConstants.LoadCmsStylesWidgetOptionKey);

            return album;
        }

        /// <summary>
        /// Constructs the back url.
        /// </summary>
        /// <returns>Back URL</returns>
        private string ConstructBackUrl(Guid id)
        {
            var context = contextAccessor.GetCurrent();
            if (context != null && context.Request.Url != null)
            {
                var url = context.Request.Url.ToString();
                var parameter = string.Format("{0}={1}", ImageGalleryModuleConstants.GalleryAlbumIdQueryParameterName, id.ToString()).ToLower();
                var index = url.ToLower().IndexOf(parameter, StringComparison.InvariantCulture);
                if (index >= 0)
                {
                    url = url.Replace(url.Substring(index, parameter.Length), string.Empty).TrimEnd('?').TrimEnd('&');
                }

                return url;
            }

            return "javascript:history.back()";
        }
    }
}