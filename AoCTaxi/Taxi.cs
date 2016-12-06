using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace AoCTaxi
{
    public class Taxi
    {
        private Passenger _passenger;

        public Taxi(Passenger passenger)
        {
            _passenger = passenger;
        }

        public void Move(string movement)
        {
            var turning = movement.Substring(0, 1) == "L" ? -1 : 1;
            var distance = int.Parse(movement.Substring(1, movement.Length - 1));
            _passenger.StepsTaken = _passenger.StepsTaken + distance;

            if (_passenger.Facing == Direction.West && turning == 1)
                _passenger.Facing = Direction.North;
            else if (_passenger.Facing == Direction.North && turning == -1)
                _passenger.Facing = Direction.West;
            else
                _passenger.Facing = _passenger.Facing + turning;

            switch (_passenger.Facing)
            {
                case Direction.North:
                    _passenger.CurrentCoord.Y = _passenger.CurrentCoord.Y + distance;
                    break;
                case Direction.East:
                    _passenger.CurrentCoord.X = _passenger.CurrentCoord.X + distance;
                    break;
                case Direction.South:
                    _passenger.CurrentCoord.Y = _passenger.CurrentCoord.Y - distance;
                    break;
                case Direction.West:
                    _passenger.CurrentCoord.X = _passenger.CurrentCoord.X - distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Go(string path)
        {
            path = path.Replace(" ", "");
            var movements = path.Split(',');

            foreach (var movement in movements)
            {
                Move(movement);
            }
        }
    }
}
