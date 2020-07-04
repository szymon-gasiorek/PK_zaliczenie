using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Models
{
    public class SQLUnitRepository : IUnitsRepository
    {
        private readonly AppDbContext _context;

        public SQLUnitRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Units Add_unit(Units unit)
        {
            _context.units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Units Delete(int Id)
        {
            Units unit = _context.units.Find(Id);
            if (unit != null)
            {
                _context.units.Remove(unit);
                _context.SaveChanges();
            }
            return unit;
        }

        public IEnumerable<Units> GetAllUnits()
        {
            return _context.units;
        }

        public Units GetUnits(int Id)
        {
            return _context.units.Find(Id);
        }

        public Units Update(Units unit_change)
        {
            var unit = _context.units.Attach(unit_change);
            unit.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return unit_change;
        }
    }
}
