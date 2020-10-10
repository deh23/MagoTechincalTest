using MagoTechincalTest;
using MagoTechincalTest.Data;
using MagoTechincalTest.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MagoTechincalTests
{
    public class GivenParkingReservations
    {
        private List<Reservation> _result;

        [SetUp]
        public void WhenFourAirPlanesAreParked()
        {
            var reservationRepo = new Mock<IReservationRepository>();

            reservationRepo.Setup(x => x.GetAll()).Returns(new List<Reservation>
            {
                new Reservation(),
                new Reservation(),
                new Reservation(),
                new Reservation()
            });

            var subject = new ParkingReservationService(null, reservationRepo.Object);
            _result = subject.GetAll();
        }

        [Test]
        public void ThenFourResvertionsAreReturned()
        {
            Assert.That(_result.Count, Is.EqualTo(4));
        }
    }
}