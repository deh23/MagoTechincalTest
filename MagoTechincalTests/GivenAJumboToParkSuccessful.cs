using MagoTechincalTest;
using MagoTechincalTest.Controllers;
using MagoTechincalTest.Data;
using MagoTechincalTest.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MagoTechincalTests
{
    public class GivenAJumboToParkSuccessful
    {
        private ParkingReservationService _subject;
        private string _result;
        private Mock<IReservationRepository> _reservationRepo;

        [SetUp]
        public void WhenTwoJumbosAirplanesAreParked()
        {
            var airplaneRepo = new Mock<IAirplaneRepository>();
            _reservationRepo = new Mock<IReservationRepository>();
            airplaneRepo.Setup(x => x.Get(It.Is<Airplane>(x => x.Model == "B747" && x.Type == "JUMBO"))).Returns(new Airplane
            {
                Type = "JUMBO",
                Size = 25
            });


            _reservationRepo.Setup(x => x.GetAll()).Returns(new List<Reservation>
            {
                new Reservation{
                    PlaneType = "jumbo",
                    Slots = 25
                },
                new Reservation{
                    PlaneType = "JUMBO",
                    Slots = 25
                },
            });

            _subject = new ParkingReservationService(airplaneRepo.Object, _reservationRepo.Object);
            _result = _subject.AddParkingReservation(new AirplaneParkingRequest
            {
                Type = "JUMBO",
                Model = "B747"
            });
        }

        [Test]
        public void ThenThePlaneCanPark()
        {
            Assert.That(_result, Is.EqualTo("Plane can park."));
        }
    }
}