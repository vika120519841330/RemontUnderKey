using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Unit_Repository : IUnit_Repository
    {
        private readonly MyContext context;
        public Unit_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<UnitOfJob_Infra> GetAllUnits()
        {
            var units = context.Units
                .ToList()
                ;
            return units;
        }

        public UnitOfJob_Infra GetUnit(int id)
        {
            var unit = context.Units
                .FirstOrDefault(_ => _.Id == id)
                ;
            return unit;
        }

        public void CreateUnit(UnitOfJob_Infra inst)
        {
            context.Units.Add(inst);
            context.SaveChanges();
        }

        public void UpdateUnit(UnitOfJob_Infra inst)
        {
            var tempInst = context.Units.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.TitleOfUnit = inst.TitleOfUnit;
            context.SaveChanges();
        }
        public void DeleteUnit(int id)
        {
            var tmp = context.Units.Find(id);
            context.Units.Remove(tmp);
            context.SaveChanges();
        }
    }
}
