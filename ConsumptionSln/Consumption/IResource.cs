using System;
using System.Drawing;

namespace Consumption
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public interface IResource
    {
        Point Position();
        Boolean IsConsumed();
        Boolean Consume();
    }
}