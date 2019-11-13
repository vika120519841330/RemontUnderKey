using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.DomainServices.Mappers
{
    public static class UploadPhoto_Infra_Domain
    {
        public static UploadPhoto_Domain UploadPhotoFromInfraToDomain(this UploadPhoto_Infra @this)
        {
            if (@this != null)
            {
                return new UploadPhoto_Domain()
                {
                    Id = @this.Id,
                    File = @this.File,
                    FileName = @this.FileName,
                    FileType = @this.FileType,
                    Repareobject_DomainId = @this.Repareobject_InfraId
                };
            }
            else
            {
                return null;
            }
        }
        public static UploadPhoto_Infra UploadPhotoFromDomainToInfra(this UploadPhoto_Domain @this)
        {
            if (@this != null)
            {
                return new UploadPhoto_Infra()
                {
                    Id = @this.Id,
                    File = @this.File,
                    FileName = @this.FileName,
                    FileType = @this.FileType,
                    Repareobject_InfraId = @this.Repareobject_DomainId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
