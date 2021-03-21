using System;
using System.Collections.Generic;
using Solid.SingleResponsibility;
using Solid.OpenClosed;
namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLID Principles:");

            var principles = new List<IPrinciple>()
            {
                new Srp(),
                new Ocp()

            };
            principles.ForEach(type =>
            {
                Console.WriteLine($"- {type.Principle()}");
                Console.WriteLine($"- {type.Definition()}");   
            });
            Console.Read();
        }
    }
}
