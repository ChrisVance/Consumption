using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Consumption.Consumers
{
    class Planner : IConsumer
    {
        private long id;
        private Point currentPosition;
        private Point nextResourcePosition;
        List<String> path;

        public void Initialize(long id, Point p)
        {
            this.id = id;
            this.currentPosition = p;
        }

        public string ExecuteTurn(World world)
        {
            try
            {
                nextResourcePosition = LocateResource(world);
                path = GeneratePathOffsets(nextResourcePosition);
            }
            catch (NoValidResourcesException)
            { }

            if (path != null && path.Count > 0)
            {
                String move = path[0];
                path.RemoveAt(0);
                return move;
            }

            // Default movement if no resource found.
            return "South";
        }

        private List<String> GeneratePathOffsets(Point target)
        {
            if (target == null)
            {
                throw new NoValidResourcesException();
            }
            else if (path != null)
            {
                return path;
            }

            // Figure out the difference in locations.
            Point positionDiff = new Point(target.X - currentPosition.X, target.Y - currentPosition.Y);

            // Develop a set of moves to get to the resource point.
            List<String> output = new List<String>();
            while (positionDiff.X > 0)
            {
                output.Add("East");
                positionDiff.X--;
            }

            while (positionDiff.X < 0)
            {
                output.Add("West");
                positionDiff.X++;
            }

            while (positionDiff.Y > 0)
            {
                output.Add("South");
                positionDiff.Y--;
            }

            while (positionDiff.Y < 0)
            {
                output.Add("North");
                positionDiff.Y++;
            }

            return output;
        }

        private void TestFunction()
        {
            string foo = "";
        }

        /// <summary>
        /// Return the first unconsumed resource found, or throw exception if no unconsumed resources exist.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        private Point LocateResource(World world)
        {
            if (!nextResourcePosition.IsEmpty)
            {
                return nextResourcePosition;
            }

            foreach (IResource res in world.Resources())
            {
                if (!res.IsConsumed())
                    return res.Position();
            }

            throw new NoValidResourcesException();
        }

        internal class NoValidResourcesException : Exception
        {
        }
    }
}
