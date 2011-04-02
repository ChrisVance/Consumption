using System.Collections.Generic;
using System.Drawing;

namespace Consumption
{
    public class World
    {
        private List<ConsumerHolder> m_consumers;
        private List<IResource> m_resources;

        public World()
        {
            m_consumers = new List<ConsumerHolder>();
            m_resources = new List<IResource>();
        }

        public void AddConsumer(IConsumer c, Point p)
        {
            m_consumers.Add(new ConsumerHolder(c, p));
        }

        public void AddResource(IResource resource)
        {
            m_resources.Add(resource);
        }

        public List<ConsumerHolder> Consumers()
        {
            return m_consumers;
        }

        public List<IResource> Resources()
        {
            return m_resources;
        }

        public void Render(Graphics gfx)
        {
            gfx.Clear(Form1.DefaultBackColor);

            Pen myPen = new Pen(Color.RoyalBlue, 2);
            Rectangle rect = new Rectangle(0, 0, 50, 50);
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    gfx.DrawRectangle(myPen, rect);
                    rect.Offset(0, 50);
                }

                rect.Offset(50, 0);
            }

            Point cp;
            foreach (ConsumerHolder ch in m_consumers)
            {
                cp = ch.GetPosition();
                cp.X *= 50;
                cp.Y *= 50;

                // Offset to match the center of the grid spot.
                cp.Offset(-25, -25);

                // Factor in the size of the object.
                cp.Offset(-1 * (ch.Strength / 2), -1 * (ch.Strength / 2));

                Pen pen = new Pen(Color.DarkRed, 2);
                Rectangle cr = new Rectangle(cp, new Size(ch.Strength, ch.Strength));
                gfx.DrawEllipse(pen, cr);
            }

            Point rp;
            foreach (IResource res in m_resources)
            {
                rp = res.Position();
                rp.X *= 50;
                rp.Y *= 50;

                // Offset to match the center of the grid spot.
                rp.Offset(-25, -25);

                Pen pen = null;
                if (res.IsConsumed())
                {
                    pen = new Pen(Color.Gray, 2);
                }
                else
                {
                    pen = new Pen(Color.Tomato, 2);
                }
                Rectangle cr = new Rectangle(rp, new Size(5, 5));
                gfx.DrawRectangle(pen, cr);
            }
        }
    }
}
