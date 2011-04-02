using System.Drawing;
using System;

namespace Consumption
{
    public class ConsumerHolder
    {
        private IConsumer consumer;
        private Point position;
        private int strength;

        public ConsumerHolder(IConsumer c, Point p)
        {
            this.consumer = c;
            this.position = p;
            this.strength = 10; // Initial strength
        }

        public Point GetPosition()
        {
            return this.position;
        }

        public int Strength
        {
            get { return strength; }
            set { this.strength = value; }
        }

        // @TODO: This function belongs in the framework, not something so close to the consumer.  Move it.
        public void UpdatePosition(String direction)
        {
            switch (direction.ToUpper())
            {
                case Direction.North:
                    if (this.position.Y - 1 >= 0)
                    {
                        this.position.Y--;
                    }
                    else
                    {
                        throw new InvalidPositionUpdateException();
                    }
                    break;
                case Direction.South:
                // @TODO: Determine max edge of world grid.
                //if (this.position.Y - 1 >= 0)
                    {
                        this.position.Y++;
                    }
                    //else
                    //{
                    //    throw new InvalidPositionUpdateException();
                    //}
                    break;
                case Direction.East:
                    // @TODO: Determine max edge of world grid.
                    this.position.X++;
                    break;
                case Direction.West:
                    if (this.position.X - 1 >= 0)
                    {
                        this.position.X--;
                    }
                    else
                    {
                        throw new InvalidPositionUpdateException();
                    }
                    break;
                default:
                    throw new InvalidPositionUpdateException();
            }
        }

        public IConsumer GetConsumer()
        {
            return this.consumer;
        }
    }
}
