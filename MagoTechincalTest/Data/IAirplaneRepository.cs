using System.Collections.Generic;

namespace MagoTechincalTest.Data
{
    public interface IAirplaneRepository
    {
        bool Add(Airplane airplane);
        Airplane Get(Airplane id);
    }
}