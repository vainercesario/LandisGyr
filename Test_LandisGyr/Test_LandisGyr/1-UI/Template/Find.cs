using System;
using Test_LandisGyr._1_UI.InputsComponents;
using Test_LandisGyr._2_Application.Interface;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr._1_UI.Template
{

    public class Find : IExecution
    {
        private readonly IEndPointDAO _endPointDao;

        public Find(IEndPointDAO endPointDao)
        {
            _endPointDao = endPointDao;
        }

        public void Run()
        {
            Console.Clear();

            Components.Title("FIND ENDPOINT:");

            Console.WriteLine("Enter the serial number of the Endpoint:");
            var result = Console.ReadLine();
            var endPoint = _endPointDao.Find(result);

            if (endPoint != null)
            {
                Console.WriteLine(endPoint.ToString());
                Console.WriteLine();
                Console.WriteLine("Press Enter to return...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(@"
EndPoint not found. 

Press Enter to return...");
                Console.ReadKey();
            }
        }
    }
}
