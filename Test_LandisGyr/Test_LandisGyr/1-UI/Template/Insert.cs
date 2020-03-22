using System;
using Test_LandisGyr._1_UI.InputsComponents;
using Test_LandisGyr._2_Application.Interface;
using Test_LandisGyr._3_Domain.Interfaces.Service;

namespace Test_LandisGyr._1_UI.Template
{
    public class Insert : IExecution
    {
        private readonly IEndPointService _endPointService;

        public Insert(IEndPointService endPointService)
        {
            _endPointService = endPointService;
        }

        public void Run()
        {
            Console.Clear();

            Components.Title("FORM OF INSERT ENDPOINT:");

            var endPoint = Components.Insertion();

            string typeit;
            do
            {
                Console.Write("Proceed with the insertion? (Y/N):");
                typeit = Console.ReadLine();
            } while (typeit.ToUpper() != "Y" && typeit.ToUpper() != "N");

            if (typeit.ToUpper() == "Y")
            {
                var ret = _endPointService.Insert(endPoint);
                if (ret)
                {
                    Console.WriteLine();
                    Console.Write("SUCCESS! Press enter to return...");
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
                Console.WriteLine();
                Console.Write("NOT EXECUTED! Press enter to return...");
                Console.ReadKey();
            }
        }
    }
}
