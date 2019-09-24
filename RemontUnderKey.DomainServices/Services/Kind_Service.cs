using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Kind_Service : IKind
    {
        private readonly IKind_Repository repository;
        public Kind_Service(IKind_Repository _repository)
        {
            this.repository = _repository;
        }

        public IEnumerable<KindOfJob_Domain> GetAllKinds()
        {
            IEnumerable<KindOfJob_Domain> kinds = repository.GetAllKinds()
                .Select(_ => _.KindOfJobFromInfraToDomain())
                .ToList()
                ;
            return kinds;
        }

        public KindOfJob_Domain GetKind(int id)
        {
            var kind = repository.GetKind(id)
                .KindOfJobFromInfraToDomain()
                ;
            return kind;
        }

        public void CreateKind(KindOfJob_Domain inst)
        {
            repository.CreateKind(inst.KindOfJobFromDomainToInfra());
        }

        public void UpdateKind(KindOfJob_Domain inst)
        {
            repository.UpdateKind(inst.KindOfJobFromDomainToInfra());
        }
        public void DeleteKind(int id)
        {
            repository.DeleteKind(id);
        }
    }
}
