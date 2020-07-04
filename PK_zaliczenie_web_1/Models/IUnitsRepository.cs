using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PK_zaliczenie_web_1.Models
{
    public interface IUnitsRepository
    {
        Units GetUnits(int Id);
        IEnumerable<Units> GetAllUnits();

        Units Add_unit(Units unit);

        Units Update(Units unit_change);

        Units Delete(int Id);
    }
}
