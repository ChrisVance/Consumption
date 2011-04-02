using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Consumption.Consumers;

namespace Consumption
{
    public partial class Form1 : Form
    {
        private World world;
        Graphics graphicsObj;
        Timer updateTimer;

        public Form1()
        {
            InitializeComponent();
            graphicsObj = this.CreateGraphics();
            world = new World();
        }

        private void btnCreateWorld_Click(object sender, EventArgs e)
        {
            IConsumer c1 = new MarkZeroConsumer();
            c1.Initialize(1, new Point(1, 1));
            world.AddConsumer(c1, new Point(1, 1));

            IConsumer c2 = new NascarConsumer();
            c2.Initialize(2, new Point(3, 3));
            world.AddConsumer(c2, new Point(3, 3));

            IConsumer c3 = new Planner();
            c3.Initialize(3, new Point(7, 6));
            world.AddConsumer(c3, new Point(7, 6));

            IResource r1 = new Resource(new Point(5, 5));
            world.AddResource(r1);

            IResource r2 = new Resource(new Point(4, 1));
            r2.Consume();
            world.AddResource(r2);

            updateTimer = new Timer();
            updateTimer.Interval = 500;
            updateTimer.Tick += new EventHandler(UpdateWorld);
            updateTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (world != null)
            {
                world.Render(graphicsObj);
            }
        }

        private void UpdateWorld(object sender, EventArgs e)
        {
            updateTimer.Stop();

            //foreach (ConsumerHolder ch in world.Consumers())
            //{
            //    try
            //    {
            //        ch.UpdatePosition(ch.GetConsumer().ExecuteTurn(world));
            //    }
            //    catch (InvalidPositionUpdateException)
            //    {
            //        // @TODO: What should happen if the consumer tries to move to an invalid location?  Should the framework tell the consumer to move back/where it is?
            //    }
            //}

            //world.Render(graphicsObj);

            updateTimer.Start();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (world != null)
            {
                world.Render(graphicsObj);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ConsumerHolder ch in world.Consumers())
            {
                try
                {
                    ch.UpdatePosition(ch.GetConsumer().ExecuteTurn(world));
                }
                catch (InvalidPositionUpdateException)
                {
                    // @TODO: What should happen if the consumer tries to move to an invalid location?  Should the framework tell the consumer to move back/where it is?
                }
            }

            world.Render(graphicsObj);
        }
    }
}