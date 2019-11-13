using System;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.Domain.Interfaces;

namespace RemontUnderKey.Web.Mappers
{
    public static class UploadPhoto_Domain_View
    {
        static IObject objService;
        public static UploadPhoto_View UploadPhotoFromDomainToView(this UploadPhoto_Domain @this)
        {
            if (@this != null)
            {
                return new UploadPhoto_View()
                {
                    Id = @this.Id,
                    File = @this.File,
                    FileName = @this.FileName,
                    FileType = @this.FileType,
                    Repareobject_ViewId = @this.Repareobject_DomainId,
                    TitleOfRepareObject = GetTitle(@this.Repareobject_DomainId)
                };
            }
            else
            {
                return null;
            }
        }
        public static UploadPhoto_Domain UploadPhotoFromViewToDomain(this UploadPhoto_View @this)
        {
            if (@this != null)
            {
                return new UploadPhoto_Domain()
                {
                    Id = @this.Id,
                    File = @this.File,
                    FileName = @this.FileName,
                    FileType = @this.FileType,
                    Repareobject_DomainId = @this.Repareobject_ViewId,
                };
            }
            else
            {
                return null;
            }
        }
        // вспомогательный мтод для получение наименования обьекта ремонта по его id
        public static string GetTitle(int? id)
        {
            return objService.GetTitleOfObjectById(id);
        }
    }
}
