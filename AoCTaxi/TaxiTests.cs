using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AoCTaxi
{
    [TestFixture]
    public class TaxiTests
    {
        [Test]
        public void NewPassengerFacesNorthAt00()
        {
            var passenger = new Passenger();

            Assert.That(passenger.Facing, Is.EqualTo(Direction.North));
            Assert.That(passenger.CurrentCoord.X, Is.EqualTo(0));
            Assert.That(passenger.CurrentCoord.Y, Is.EqualTo(0));
        }

        [Test]
        public void CanMove1SpaceEastWithInputR1()
        {
            var passenger = new Passenger();
            var taxi = new Taxi(passenger);

            taxi.Move("R1");

            Assert.That(passenger.CurrentCoord.X, Is.EqualTo(1));
            Assert.That(passenger.CurrentCoord.Y, Is.EqualTo(0));
        }

        [Test]
        public void ShouldMoveNorth1WhenFacingWestWithInputR1()
        {
            var passenger = new Passenger {Facing = Direction.West};
            var taxi = new Taxi(passenger);

            taxi.Move("R1");

            Assert.That(passenger.CurrentCoord.X, Is.EqualTo(0));
            Assert.That(passenger.CurrentCoord.Y, Is.EqualTo(1));
        }

        [Test]
        public void ShouldMoveWest1WhenFacingNorthWithInputL1()
        {
            var passenger = new Passenger { Facing = Direction.North };
            var taxi = new Taxi(passenger);

            taxi.Move("L1");

            Assert.That(passenger.CurrentCoord.X, Is.EqualTo(-1));
            Assert.That(passenger.CurrentCoord.Y, Is.EqualTo(0));
        }

        [Test]
        public void ShouldMovePassengerToNewLocationGivenInputs()
        {
            var passenger = new Passenger();
            var taxi = new Taxi(passenger);

            taxi.Go("R2, R2, R2");

            Assert.That(passenger.CurrentCoord.X, Is.EqualTo(0));
            Assert.That(passenger.CurrentCoord.Y, Is.EqualTo(-2));
        }

        [Test]
        public void DistanceFromZeroIs2WhenPassengerAt22()
        {
            var passenger = new Passenger();
            var taxi = new Taxi(passenger);

            passenger.CurrentCoord.X = 2;
            passenger.CurrentCoord.Y = 2;

            Assert.That(passenger.DistanceFromStart, Is.EqualTo(4));
        }

        [Test]
        public void DoTheThing()
        {
            var passenger = new Passenger();
            var taxi = new Taxi(passenger);

            var path = "L5, R1, R4, L5, L4, R3, R1, L1, R4, R5, L1, L3, R4, L2, L4, R2, L4, L1, R3, R1, R1, L1, R1, L5, R5, R2, L5, R2, R1, L2, L4, L4, R191, R2, R5, R1, L1, L2, R5, L2, L3, R4, L1, L1, R1, R50, L1, R1, R76, R5, R4, R2, L5, L3, L5, R2, R1, L1, R2, L3, R4, R2, L1, L1, R4, L1, L1, R185, R1, L5, L4, L5, L3, R2, R3, R1, L5, R1, L3, L2, L2, R5, L1, L1, L3, R1, R4, L2, L1, L1, L3, L4, R5, L2, R3, R5, R1, L4, R5, L3, R3, R3, R1, R1, R5, R2, L2, R5, L5, L4, R4, R3, R5, R1, L3, R1, L2, L2, R3, R4, L1, R4, L1, R4, R3, L1, L4, L1, L5, L2, R2, L1, R1, L5, L3, R4, L1, R5, L5, L5, L1, L3, R1, R5, L2, L4, L5, L1, L1, L2, R5, R5, L4, R3, L2, L1, L3, L4, L5, L5, L2, R4, R3, L5, R4, R2, R1, L5";
            taxi.Go(path);

            Console.WriteLine(passenger.CurrentCoord.X);
            Console.WriteLine(passenger.CurrentCoord.Y);
            Console.WriteLine(passenger.StepsTaken);
            Console.WriteLine(passenger.DistanceFromStart());
        }

        [Test]
        public void ShouldStoreHistoryWhenMovingR2()
        {
            var passenger = new Passenger();
            var taxi = new Taxi(passenger);

            taxi.Move("R2");

            Assert.That(passenger.History.Count, Is.EqualTo(2));
        }
    }
}
