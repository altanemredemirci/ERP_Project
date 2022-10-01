using ERP.DataAccessLayer.EF;
using ERP.Entity;
using System;
using System.Collections.Generic;
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
            return repo_unit.Insert(model);
        }
    }
}
