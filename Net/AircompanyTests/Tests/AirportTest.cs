using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private readonly List<Plane> _planes = new List<Plane>(PlaneRegistry.Planes);
        private readonly PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);
        private readonly List<Plane> _planesOrderedByMaxLoadCapacity = PlaneRegistry.Planes.OrderBy(x => x.GetMaxLoadCapacity()).ToList();
        [Test]
        public void TransportMilitaryPlanesCanBeDetected()
        {
            var airport = new Airport(_planes);
            var transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();
            Assert.IsTrue(transportMilitaryPlanes.Count!=0);
        }
        [Test]
        public void GetPassengerPlaneWithMaxPassengersCapacityCanBeDetected()
        {
            var airport = new Airport(_planes);
            var expectedPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.IsTrue(expectedPlaneWithMaxPassengersCapacity.Equals(_planeWithMaxPassengerCapacity));
        }
        [Test]
        public void PlanesAreSortedByMaxLoadCapacity()
        {
            var airport = new Airport(_planes);
            var expectedPlanesSortedByMaxLoadCapacity = airport.SortPlanesByMaxLoadCapacity().GetPlanes().ToList();
            Assert.IsTrue(expectedPlanesSortedByMaxLoadCapacity.SequenceEqual(_planesOrderedByMaxLoadCapacity));
        }
    }
}