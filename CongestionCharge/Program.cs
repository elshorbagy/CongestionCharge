using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CongestionCharge
{
    class Program
    {
        static void Main()
        {
            try
            {
                var index = 1;
                var outPut = new StringBuilder();

                var data = new[]
                {
                    "Car: 24/04/2008 11:32 - 24/04/2008 14:42",
                    "Motorbike: 24/04/2008 17:00 - 24/04/2008 22:11",
                    "Van: 25/04/2008 10:23 - 28/04/2008 09:02",
                };

                var service = BuildDependencies.Build();
                var calculateCharges = service.GetService<ICalculateCharges>();
                
                foreach (var entryData in data)
                {
                    Console.WriteLine("INPUT " + index + Environment.NewLine + entryData);
                    outPut.Append(calculateCharges.Charge(entryData) + Environment.NewLine);
                    Console.WriteLine("OUTPUT " + index + " " + outPut);
                    outPut.Clear();
                    index++;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.ReadKey();
        }
    }
}