using System;
using Test_LandisGyr._1_UI.InputsComponents;
using Test_LandisGyr._2_Application.Interface;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Interfaces.Service;
using Test_LandisGyr._3_Domain.Service;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr._1_UI.Template
{
    public class Edit : Inputs.Inputs, IExecution
    {
        private readonly IEndPointDAO _endPointDao;
        private readonly IEndPointService _endPointService;

        public Edit(IEndPointDAO endPointDao, IEndPointService endPointService)
        {
            _endPointService = endPointService;
            _endPointDao = endPointDao;
        }

        public void Run()
        {
            Console.Clear();

            Components.Title("FORM OF INSERT ENDPOINT:");

            Console.WriteLine("Enter the serial number of the Endpoint to be edited:");
            var result = Console.ReadLine();
            var endPoint = _endPointDao.Find(result);

            if (endPoint != null)
            {
                Console.WriteLine();
                Console.WriteLine("EndPoint in editing:");

                Console.WriteLine(endPoint.ToString());

                Console.WriteLine("Enter new data");
                Console.WriteLine();
                var newEndPoint = Components.Edition(endPoint);

                var ret = _endPointService.Edit(endPoint, newEndPoint);

                if (ret)
                {
                    Console.WriteLine();
                    Console.WriteLine("SUCCESS! Press Enter to return...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("NOT EXECUTED! Press enter to return...");
                    Console.ReadKey();
                }
                
            }
            else
            {
                Console.WriteLine(@"
EndPoint not found. 

Press Enter to return...");

                Console.ReadKey();
            }
            
        }
    }
}
