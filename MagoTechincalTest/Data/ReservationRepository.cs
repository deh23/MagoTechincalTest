using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagoTechincalTest.Data
{
    public class ReservationRepository : IReservationRepository
    {
        public bool Add(Reservation reservation)
        {
            try
            {
                using (var database = new MagoModelEntity())
                {
                    database.Reservations.Add(reservation);
                    database.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Reservation> GetAll()
        {
            List<Reservation> reservations = new List<Reservation>(); 
            using (var database = new MagoModelEntity())
            {
                reservations = database.Reservations.ToList();
            }
            return reservations;
        }

        public Reservation Get(int id)
        {
            Reservation reservation;
            try
            {
                using (var database = new MagoModelEntity())
                {
                    reservation = database.Reservations.Where(x => x.Id == id).SingleOrDefault();
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return reservation;
        }

        public void Remove(Reservation reservation)
        {
            using (var database = new MagoModelEntity())
            {
                database.Reservations.Remove(reservation);
            }
        }


    }
}
