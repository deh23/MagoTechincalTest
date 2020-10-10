using System.Collections.Generic;

namespace MagoTechincalTest.Data
{
    public interface IReservationRepository
    {
        bool Add(Reservation entity);
        List<Reservation> GetAll();
        Reservation Get(int id);
        void Remove(Reservation id);
    }
}