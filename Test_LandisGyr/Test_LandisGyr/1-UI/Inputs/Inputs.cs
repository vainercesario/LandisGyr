using System;
using Test_LandisGyr._2_Application.Validator;
using Test_LandisGyr._3_Domain.Model;

namespace Test_LandisGyr._1_UI.Inputs
{
    public class Inputs
    {
        string serial = "";
        string meterModelIdAux = "";
        string meterNumberAux = "";
        string meterFirmwareVersion = "";
        string switchStateAux = "";

        public EndPoint Form()
        {
            do {
                Console.WriteLine("Serial Number: ");
                serial = Console.ReadLine();
            } while (serial == "");


            Console.WriteLine();

            do {
                Console.WriteLine("Meter Model Id (only numbers): (Use this catalog: 16 - NSX1P2W,     17 - NSX1P3W,    18 - NSX2P2W,    19 - NSX3P4W):");
                meterModelIdAux = Console.ReadLine();
            } while (!TypeOfInput.isMeterModelId(meterModelIdAux));
            EnumMeterModelId meterModelId = (EnumMeterModelId)int.Parse(meterModelIdAux);

            Console.WriteLine();

            do
            {
                Console.WriteLine("Meter Number: ");
                meterNumberAux = Console.ReadLine();
            } while (!TypeOfInput.isNumeric(meterNumberAux));
            int meterNumber = int.Parse(meterNumberAux);

            Console.WriteLine();

            do
            {
                Console.WriteLine("Meter Firmware Version: ");
                meterFirmwareVersion = Console.ReadLine();
            } while (meterFirmwareVersion == "");

            Console.WriteLine();

            do
            {
                Console.WriteLine("Switch State (only numbers): (Use this catalog: 0 - Disconnected,    1 - Connected,    2 - Armed):");
                switchStateAux = Console.ReadLine();
            } while (!TypeOfInput.isSwitchState(switchStateAux));
            EnumSwitchState switchState = (EnumSwitchState)int.Parse(switchStateAux);

            var endPoint = new EndPoint();
            endPoint.SerialNumber = serial;
            endPoint.MeterModelId = meterModelId;
            endPoint.MeterNumber = meterNumber;
            endPoint.MeterFirmwareVersion = meterFirmwareVersion;
            endPoint.SwitchState = switchState;

            return endPoint;
        }

    }
}
