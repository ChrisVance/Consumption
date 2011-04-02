using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Consumption
{
    class Resource: IResource
    {
        private Point position;
        private Boolean consumed;

        public Resource(Point position)
        {
            this.position = position;
            consumed = false;
        }

        public Boolean IsConsumed() { return consumed; }

        // @TODO: Handle Race condition on checking and setting consumed
        // @TODO: Might it be better to throw an error if the resource cannot be consumed?
        public Boolean Consume()
        {
            if (!consumed)
            {
                consumed = true;
                return consumed;
            }
            else
            {
                return false;
            }
        }

        public Point Position()
        {
            return position;
        }
    }
}
