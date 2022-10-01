using ERP.DataAccessLayer.EF;
using ERP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessLogicLayer
{
    public class UnitManager
    {
        private Repository<Unit> repo_unit = new Repository<Unit>();

        public List<Unit> GetUnits()
        {
            return repo_unit.List();
        }

        public int AddUnit(Unit model)
        {
            Unit unit = repo_unit.Find(i => i.Name == model.Name);

            if (unit != null)
            {
                return 0;
            }

            return repo_unit.Insert(model);
        }

        public Unit GetUnitById(int id)
        {
            return repo_unit.Find(i=> i.Id==id);
        }
    }
}
