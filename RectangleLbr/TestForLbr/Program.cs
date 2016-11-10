using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RectangleLbr;

namespace TestForLbr
{
    class Program
    {
        static void Main(string[] args)
        {
            MyRectangle rect = new MyRectangle(8,4);
            Console.WriteLine(rect.GetArea());
            Console.WriteLine(rect.GetPerimeter());
            Console.WriteLine(rect.About());
            Console.WriteLine("----");
            Random
            MyVolumeRectangle vrect = new MyVolumeRectangle(2,1,4);
            Console.WriteLine(vrect.GetArea());
            Console.WriteLine(vrect.GetPerimeter());
            Console.WriteLine(vrect.GetVolume());
            Console.WriteLine(vrect.About());
            Console.ReadLine();

        }
    }
}
