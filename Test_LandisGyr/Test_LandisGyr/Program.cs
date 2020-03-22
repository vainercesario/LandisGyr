using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using Test_LandisGyr._1_UI.Inputs;
using Test_LandisGyr._1_UI.InputsComponents;
using Test_LandisGyr._1_UI.Template;
using Test_LandisGyr._2_Application.Interface;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Interfaces.Service;
using Test_LandisGyr._3_Domain.Model;
using Test_LandisGyr._3_Domain.Service;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr
{
    class Program
    {
        static readonly Container container;
        static List<EndPoint> data = new List<EndPoint>();

        /// <summary>
        /// Initialize Program and DI
        /// </summary>
        static Program()
        {
            container = new Container();

            //container.Register<IEndPointDAO>(() => new EndPointDAO(data), Lifestyle.Singleton);

            container.Register<IEndPointDAO, EndPointDAO>(Lifestyle.Singleton);
            container.Register<IEndPointService, EndPointService>(Lifestyle.Singleton);
            container.Register<Insert>(Lifestyle.Singleton);
            container.Register<Edit>(Lifestyle.Singleton);
            container.Register<Delete>(Lifestyle.Singleton);
            container.Register<ListAll>(Lifestyle.Singleton);
            container.Register<Find>(Lifestyle.Singleton);

            container.Verify();
        }

        static void Main(string[] args)
        {
            IExecution itemSelected;

            while (true)
            {
                string option = "";
                int valueOption = 0;
                int limiteMenu = Components.GetEnumDescriptions<EnumTipoMenu>().Count()+1;

                while (!(valueOption < limiteMenu && valueOption > 0))
                {
                    do
                    {
                        PrintMenu.View();
                        Console.Write("Enter this valid option: ");
                        option = Console.ReadLine();
                    } while (!int.TryParse(option, out valueOption));
                }

                itemSelected = Run(valueOption);
                
            }

        }

        private static IExecution Run(int option)
        {
            IExecution itemSelected;

            switch (option)
            {
                case (int)EnumTipoMenu.Insert:
                    itemSelected = container.GetInstance<Insert>();
                    break;
                case (int)EnumTipoMenu.Edit:
                    itemSelected = container.GetInstance<Edit>();
                    break;
                case (int)EnumTipoMenu.Delete:
                    itemSelected = container.GetInstance<Delete>();
                    break;
                case (int)EnumTipoMenu.ListAll:
                    itemSelected = container.GetInstance<ListAll>();
                    break;
                case (int)EnumTipoMenu.Find:
                    itemSelected = container.GetInstance<Find>();
                    break;
                default:
                    itemSelected = Activator.CreateInstance<Exit>();
                    break;
            }

            itemSelected.Run();

            return itemSelected;
        }
    }
}
