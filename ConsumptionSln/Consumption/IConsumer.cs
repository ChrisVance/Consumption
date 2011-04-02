using System;
using System.Drawing;

namespace Consumption
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public interface IConsumer
    {
        void Initialize(long id, Point position);
        String ExecuteTurn(World world);
    }
}
