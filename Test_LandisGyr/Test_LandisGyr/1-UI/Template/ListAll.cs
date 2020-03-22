using System;
using Test_LandisGyr._1_UI.InputsComponents;
using Test_LandisGyr._2_Application.Interface;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr._1_UI.Template
{
    public class ListAll : IExecution
    {
        private readonly IEndPointDAO _endPointDao;

        public ListAll(IEndPointDAO endPointDao)
        {
            _endPointDao = endPointDao;
        }

        public void Run()
        {
            Console.Clear();
            Components.Title("LIST ALL OF THE ENDPOINT:");

            foreach (var item in _endPointDao.ListAll())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("Press Enter to return...");
            Console.ReadKey();
        }
    }
}
