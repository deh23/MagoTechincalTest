using MagoTechincalTest.Controllers;
using MagoTechincalTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MagoTechincalTest.Models
{
    public class ParkingReservationService
    {
        public readonly IAirplaneRepository _airplaneRepository;
        private readonly IReservationRepository _reservationRepository;

        public Dictionary<PlaneType, int> Reservations { get; set; }
        public const int MAX_PARKING_SLOTS = 100;
        public int _currentSlotsReserved { get; set; }

        public ParkingReservationService(IAirplaneRepository airplaneRepository, IReservationRepository reservationRepository)
        {
            _airplaneRepository = airplaneRepository;
            _reservationRepository = reservationRepository;

            Reservations = new Dictionary<PlaneType, int>();
            Reservations.Add(PlaneType.JET, 0);
            Reservations.Add(PlaneType.JUMBO_PROPS, 0);
        }

        public string AddParkingReservation(AirplaneParkingRequest request)
        {
            var airplane = _airplaneRepository.Get(new Airplane
            {
                Model = request.Model.Trim(),
                Type = request.Type.Trim()
            });

            if (airplane == null)
            {
                return "We don't know the plane you are trying to park";
            }

            var currentReservations = _reservationRepository.GetAll();
            CurrentRevesrations(currentReservations);

            if (_currentSlotsReserved > 75)
            {
                return "Could Not reserve.";
            }

            var mappedPlaneType = MapPlaneType(airplane.Type);

            if (_currentSlotsReserved > 50 && mappedPlaneType == PlaneType.JET)
            {
                return "Could Not reserve.";
            }

            return AddResveration(airplane);
        }

        private PlaneType MapPlaneType(string type)
        {
            switch (type.ToUpper())
            {
                case "JUMBO":
                case "PROPS":
                    return PlaneType.JUMBO_PROPS;
                case "JETS":
                    return PlaneType.JET;
            }

            return PlaneType.DEFAULT;
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        private string AddResveration(Airplane airplane)
        {
            var reservation = new Reservation
            {
                PlaneId = airplane.Id,
                PlaneType = airplane.Type,
                Slots = airplane.Size
            };

            _reservationRepository.Add(reservation);
            return "Plane can park.";
        }

        public void RemoveParkingReservation(int id)
        {
            var reservation = _reservationRepository.Get(id);
            _reservationRepository.Remove(reservation);
        }

        private void CurrentRevesrations(List<Reservation> currentReservations)
        {
            if (currentReservations.Count > 0)
            {
                foreach (var resveration in currentReservations)
                {
                    var mappedPlaneType = MapPlaneType(resveration.PlaneType);
                    Reservations[mappedPlaneType] += (int)mappedPlaneType;
                    _currentSlotsReserved += (int)mappedPlaneType;
                }
            }
        }
    }
}
