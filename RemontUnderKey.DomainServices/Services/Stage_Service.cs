using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Stage_Service : IStage
    {
        private readonly IStage_Repository repository;

        public Stage_Service(IStage_Repository _repository)
        {
            this.repository = _repository;
        }
        public IEnumerable<Stage_Domain> GetAllStages()
        {
            var stages = repository.GetAllStages()
                .Select(_ => _.StageFromInfraToDomain())
                .ToList()
                ;
            return stages;
        }

        public Stage_Domain GetStage(int id)
        {
            var stage = repository.GetStage(id)
                .StageFromInfraToDomain()
                ;
            return stage;
        }

        public void CreateStage(Stage_Domain inst)
        {
            repository.CreateStage(inst.StageFromDomainToInfra());
        }

        public void UpdateStage(Stage_Domain inst)
        {
            repository.UpdateStage(inst.StageFromDomainToInfra());
        }
        public void DeleteStage(int id)
        {
            repository.DeleteStage(id);
        }
    }
}
