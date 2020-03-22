using System;
using Test_LandisGyr._2_Application.Interface;

namespace Test_LandisGyr._1_UI.Template
{
    public class Exit : IExecution
    {
        public void Run()
        {
            string typeit = "";

            do
            {
                Console.Write("Do you really want to leave? Type it (Y/N):");
                typeit = Console.ReadLine();
            } while (typeit.ToUpper() != "Y" && typeit.ToUpper() != "N");
            
            if(typeit.ToUpper() == "Y")
            {
                Environment.Exit(0);
            }

        }
    }
}
