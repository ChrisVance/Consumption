using System.Drawing;

namespace Consumption.Consumers
{
    class MarkZeroConsumer: IConsumer
    {
        private long id;
        private Point position;

        public void Initialize(long id, Point p)
        {
            this.id = id;
            this.position = p;
        }

        public string ExecuteTurn(World world)
        {
            return "South";
        }
    }
}
