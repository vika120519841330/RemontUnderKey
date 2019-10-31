using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Web.Mappers
{
    public static class Upload_Infra_Domain
    {
        public static Upload_View UploadFromDomainToView(this Upload_Domain @this)
        {
            if (@this != null)
            {
                return new Upload_View()
                {
                    Id = @this.Id,
                    Comment_ViewId = @this.Comment_DomainId,
                    FileName = @this.FileName,
                    FileType = @this.FileType,
                    File = @this.File
                };
            }
            else
            {
                return null;
            }
        }
        public static Upload_Domain UploadFromViewToDomain(this Upload_View @this)
        {
            if (@this != null)
            {
                return new Upload_Domain()
                {
                    Id = @this.Id,
                    Comment_DomainId = @this.Comment_ViewId,
                    FileName = @this.FileName,
                    FileType = @this.FileType,
                    File = @this.File
                };
            }
            else
            {
                return null;
            }
        }
    }

}