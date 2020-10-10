using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagoTechincalTest.Data
{
    public class AirplaneRepository : IAirplaneRepository
    {
        public bool Add(Airplane entity)
        {
            try
            {
                using (var database = new MagoModelEntity())
                {
                    database.Airplanes.Add(entity);
                    database.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Airplane Get(Airplane airplane)
        {
            Airplane foundPlane;
            try
            {
                using (var database = new MagoModelEntity())
                {
                    foundPlane = database.Airplanes.Where(x => x.Model == airplane.Model && x.Type == airplane.Type).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return foundPlane;
        }
    }
}
