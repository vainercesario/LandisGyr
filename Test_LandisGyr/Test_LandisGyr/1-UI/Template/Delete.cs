using System;
using Test_LandisGyr._1_UI.InputsComponents;
using Test_LandisGyr._2_Application.Interface;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Interfaces.Service;
using Test_LandisGyr._3_Domain.Service;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr._1_UI.Template
{
    public class Delete : IExecution
    {
        private readonly IEndPointDAO _endPointDao;
        private readonly IEndPointService _endPointService;

        public Delete(IEndPointDAO endPointDao, IEndPointService endPointService)
        {
            _endPointService = endPointService;
            _endPointDao = endPointDao;
        }

        public void Run()
        {

            Console.Clear();

            Components.Title("DELETE ENDPOINT:");

            Console.WriteLine("Enter the serial number of the Endpoint to be deleted:");
            var result = Console.ReadLine();
            var endPoint = _endPointDao.Find(result);

            if (endPoint != null)
            {
                Console.WriteLine();
                Console.WriteLine("EndPoint in editing:");

                Console.WriteLine(endPoint.ToString());

                Console.WriteLine();
                string typeit;
                do
                {
                    Console.Write("Proceed with the exclusion? (Y/N):");
                    typeit = Console.ReadLine();
                } while (typeit.ToUpper() != "Y" && typeit.ToUpper() != "N");

                if (typeit.ToUpper() == "Y")
                {
                    _endPointDao.Delete(endPoint);
                    Console.WriteLine(@"
EndPoint Deleted!  

Press Enter to return...");
                    Console.ReadKey();

                }
            }
            else
            {
                Console.WriteLine("EndPoint not found. Press Enter to return...");
                Console.ReadKey();
            }
        }
    }
}
