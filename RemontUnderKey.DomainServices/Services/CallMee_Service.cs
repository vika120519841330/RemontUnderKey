using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class CallMee_Service : ICallMee
    {
        private readonly ICallMee_Repository repository;
        public CallMee_Service(ICallMee_Repository _repository)
        {
            this.repository = _repository;
        }
        public IEnumerable<CallMee_Domain> GetAllCallMee()
        {
            var calls = repository.GetAllCallMee()
                .Select(_ => _.CallMeeFromInfraToDomain())
                .ToList()
                ;
            return calls;
        }

        public CallMee_Domain GetCallMee(int id)
        {
            var comment = repository.GetCallMee(id)
                .CallMeeFromInfraToDomain()
                ;
            return comment;
        }

        public void CreateCallMee(CallMee_Domain inst)
        {
            repository.CreateCallMee(inst.CallMeeFromDomainToInfra());
        }

        public void UpdateCallMee(CallMee_Domain inst)
        {
            repository.UpdateCallMee(inst.CallMeeFromDomainToInfra());
        }
        public void DeleteCallMee(int id)
        {
            repository.DeleteCallMee(id);
        }
    }
}
