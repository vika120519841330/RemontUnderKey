using RemontUnderKey.Domain.Models;
using RemontUnderKey.Infrastructure.Models;


namespace RemontUnderKey.DomainServices.Mappers
{
    public static class Upload_Infra_Domain
    {
        public static Upload_Domain UploadFromInfraToDomain(this Upload_Infra @this)
        {
            if (@this != null)
            {
                return new Upload_Domain()
                {
                    Id = @this.Id,
                    Comment_DomainId = @this.Comment_InfraId,
                    FileName = @this.FileName,
                    File = @this.File
                };
            }
            else
            {
                return null;
            }
        }
        public static Upload_Infra UploadFromDomainToInfra(this Upload_Domain @this)
        {
            if (@this != null)
            {
                return new Upload_Infra()
                {
                    Id = @this.Id,
                    Comment_InfraId = @this.Comment_DomainId,
                    FileName = @this.FileName,
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
