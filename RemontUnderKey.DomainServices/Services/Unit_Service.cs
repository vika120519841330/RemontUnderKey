using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Unit_Service : IUnit
    {
        private readonly IUnit_Repository repository;
        public Unit_Service(IUnit_Repository _repository)
        {
            this.repository = _repository;
        }

        public IEnumerable<UnitOfJob_Domain> GetAllUnits()
        {
            var units = repository.GetAllUnits()
                .Select(_ => _.UnitOfJobFromInfraToDomain())
                .ToList()
                ;
            return units;
        }

        public UnitOfJob_Domain GetUnit(int id)
        {
            var unit = repository.GetUnit(id)
                .UnitOfJobFromInfraToDomain()
                ;
            return unit;
        }

        public void CreateUnit(UnitOfJob_Domain inst)
        {
            repository.CreateUnit(inst.UnitOfJobFromDomainToInfra());
        }

        public void UpdateUnit(UnitOfJob_Domain inst)
        {
            repository.UpdateUnit(inst.UnitOfJobFromDomainToInfra());
        }
        public void DeleteUnit(int id)
        {
            repository.DeleteUnit(id);
        }
    }
}
