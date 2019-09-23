using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Type_Service : IType
    {
        private readonly IType_Repository repository;
        public Type_Service(IType_Repository _repository)
        {
            this.repository = _repository;
        }

        public IEnumerable<TypeOfObject_Domain> GetAllTypes()
        {
            var types = repository.GetAllTypes()
                .Select(_ => _.TypeOfObjectFromInfraToDomain())
                .ToList()
                ;
            return types;
        }

        public TypeOfObject_Domain GetTypeOfObject(int id)
        {
            var typeofobj = repository.GetTypeOfObject(id)
                .TypeOfObjectFromInfraToDomain()
                ;
            return typeofobj;
        }

        public void CreateTypeOfObject(TypeOfObject_Domain inst)
        {
            repository.CreateTypeOfObject(inst.TypeOfObjectFromDomainToInfra());
        }

        public void UpdateTypeOfObject(TypeOfObject_Domain inst)
        {
            repository.UpdateTypeOfObject(inst.TypeOfObjectFromDomainToInfra());
        }
        public void DeleteTypeOfObject(int id)
        {
            repository.DeleteTypeOfObject(id);
        }
    }
}
