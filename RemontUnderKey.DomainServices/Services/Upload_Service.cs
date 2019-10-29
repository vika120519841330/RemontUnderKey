using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Upload_Service : IUpload
    {
        private readonly IUpload_Repository repository;
        public Upload_Service(IUpload_Repository _repository)
        {
            this.repository = _repository;
        }
        public IEnumerable<Upload_Domain> GetAllUpload()
        {
            var uploads = repository.GetAllUpload()
                .Select(_ => _.UploadFromInfraToDomain())
                .ToList()
                ;
            return uploads;
        }

        public Upload_Domain GetUpload(int? id)
        {
            var comment = repository.GetUpload(id)
                .UploadFromInfraToDomain()
                ;
            return comment;
        }

        public int? CreateUpload(Upload_Domain inst)
        {
            return repository.CreateUpload(inst.UploadFromDomainToInfra());
        }

        public void UpdateUpload(Upload_Domain inst)
        {
            repository.UpdateUpload(inst.UploadFromDomainToInfra());
        }
        public void DeleteUpload(int? id)
        {
            repository.DeleteUpload(id);
        }
    }
}
