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
    public class GivenAJetToParkWithThreeJumbos
    {
        private ParkingReservationService _subject;
        private string _result;
        private Mock<IReservationRepository> _reservationRepo;

        [SetUp]
        public void WhenTwoJumbosAirplanesAreParked()
        {
            var airplaneRepo = new Mock<IAirplaneRepository>();
            _reservationRepo = new Mock<IReservationRepository>();
            airplaneRepo.Setup(x => x.Get(It.Is<Airplane>(x => x.Model == "B777" && x.Type == "JET"))).Returns(new Airplane
            {
                Type = "JET",
                Size = 50
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
                new Reservation{
                    PlaneType = "JUMBO",
                    Slots = 25
                },
            });

            _subject = new ParkingReservationService(airplaneRepo.Object, _reservationRepo.Object);
            _result = _subject.AddParkingReservation(new AirplaneParkingRequest
            {
                Type = "JET",
                Model = "B777"
            });
        }

        [Test]
        public void ThenThePlaneCanNotPark()
        {
            Assert.That(_result, Is.EqualTo("Plane can park."));
        }
    }
}