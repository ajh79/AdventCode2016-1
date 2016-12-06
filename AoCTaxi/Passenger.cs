using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AoCTaxi
{
    public class Passenger
    {
        public int StepsTaken { get; set; }
        public Coord CurrentCoord { get; set; }
        public Direction Facing { get; set; }
        public List<Coord> History { get; set; }

        public Passenger()
        {
            Facing = Direction.North;
            CurrentCoord = new Coord
            {
                X = 0,
                Y = 0
            };
        }

        public int DistanceFromStart()
        {
            return Math.Abs(CurrentCoord.X) + Math.Abs(CurrentCoord.Y);
        }
    }

    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

}