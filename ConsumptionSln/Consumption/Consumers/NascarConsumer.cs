using System.Drawing;
using System;

namespace Consumption.Consumers
{
    /// <summary>
    /// Turns left after random distances.
    /// </summary>
    class NascarConsumer: IConsumer
    {
        private const double turnThreshold = 0.5d;

        private long id;
        private Point position;
        private string previousDirection;
        private Random rnd;

        public void Initialize(long id, Point p)
        {
            this.id = id;
            this.position = p;
            rnd = new Random();
        }

        // @TODO: Determine if there are thread safety issues/race conditions when checking and modifying the direction.
        // @TODO: Refactor this code so it makes more sense.  Not happy with direction/previousDirection references.
        public string ExecuteTurn(World world)
        {
            if (String.IsNullOrWhiteSpace(previousDirection))
            {
                previousDirection = "South";
                return previousDirection;
            }

            Double turnValue = rnd.NextDouble();
            string direction;

            // If the random value meets the threshold, set a new direction, which after this function exits, will be our previous heading.
            if (turnValue >= turnThreshold)
            {
                switch (previousDirection.ToUpper())
                {
                    case Direction.North:
                        direction = "West";
                        break;
                    case Direction.South:
                        direction = "East";
                        break;
                    case Direction.East:
                        direction = "North";
                        break;
                    case Direction.West:
                    default:
                        direction = "South";
                        break;
                }

                previousDirection = direction;
            }
            else
            {
                // Move in the same direction as before.
                direction = previousDirection;
            }

            return direction;
        }
    }
}
