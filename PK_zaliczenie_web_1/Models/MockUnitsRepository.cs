using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Models
{
    public class MockUnitsRepository : IUnitsRepository
    {
        private List<Units> unitsList;

        public MockUnitsRepository()
        {
            unitsList = new List<Units>()
            {
            
            };
        }

        public Units Add_unit(Units unit)
        {
            // dodaje unit do listy i przypisuje mu najwieksze mozliwe Id
            unit.Id = unitsList.Max(e => e.Id) + 1; 
            unitsList.Add(unit);
            return unit;
        }

        public Units Delete(int Id)
        {
            Units unit = unitsList.FirstOrDefault(e => e.Id == Id);
            if (unit != null)
            {
                unitsList.Remove(unit);
            }
            return unit;
        }

        public IEnumerable<Units> GetAllUnits()
        {
            return unitsList;
        }

        public Units GetUnits(int Id)
        {
            return unitsList.FirstOrDefault(e => e.Id == Id);
        }

        public Units Update(Units unit_change)
        {
            Units unit = unitsList.FirstOrDefault(e => e.Id == unit_change.Id);
            if (unit != null)
            {
                unit.Name = unit_change.Name;
                unit.Attack = unit_change.Attack;
                unit.Defense = unit_change.Defense;
                unit.min_Damage = unit_change.min_Damage;
                unit.max_Damage = unit_change.max_Damage;
                unit.Health = unit_change.Health;
                unit.Faction = unit_change.Faction;
            }
            return unit;
        }
    }
}
