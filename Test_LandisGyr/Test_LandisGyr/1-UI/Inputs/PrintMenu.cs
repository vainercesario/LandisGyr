using System;
using Test_LandisGyr._1_UI.InputsComponents;

namespace Test_LandisGyr._1_UI.Inputs
{
    public class PrintMenu
    {
        public static void View()
        {
            Console.Clear();
            int i = 0;
            Components.Title("SELECT THIS OPTION:");

            foreach (var menuItem in Components.GetEnumDescriptions<EnumTipoMenu>())
            {
                Console.WriteLine((++i).ToString() + " - " + menuItem);
            }

            Console.WriteLine();
            Console.WriteLine("===================");
            Console.WriteLine();
        }
    }
}
