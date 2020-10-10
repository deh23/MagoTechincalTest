using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using MagoTechincalTest.Data;
using MagoTechincalTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagoTechincalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        public IAirplaneRepository _airplaneRepository;
        public IReservationRepository _reservationRepository;

        public ParkingController(IAirplaneRepository airplaneRepository, IReservationRepository reservationRepository)
        {
            _airplaneRepository = airplaneRepository;
            _reservationRepository = reservationRepository;
        }

        // GET: api/<ParkingController>
        [HttpGet]
        public IActionResult GetParkingReservations()
        {
            var parkingReservation = new ParkingReservationService(_airplaneRepository, _reservationRepository);
            var result = parkingReservation.GetAll();

            return Ok(result);
        }

        // GET api/<ParkingController>
        [HttpPost]
        public IActionResult AddParkingReservation(AirplaneParkingRequest airplane)
        {
            var parkingReservation = new ParkingReservationService(_airplaneRepository, _reservationRepository);
            var result = parkingReservation.AddParkingReservation(airplane);

            return Ok(result);
        }

        // DELETE api/<ParkingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var parkingReservation = new ParkingReservationService(_airplaneRepository, _reservationRepository);
            parkingReservation.RemoveParkingReservation(id);

            return Ok("Removed parking reservation.");
        }
    }
}
