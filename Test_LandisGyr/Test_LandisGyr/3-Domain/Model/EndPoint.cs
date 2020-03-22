namespace Test_LandisGyr._3_Domain.Model
{
    public class EndPoint
    {
        public string SerialNumber { get; set; }
        public EnumMeterModelId MeterModelId { get; set; } 
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public EnumSwitchState SwitchState { get; set; }

        public override string ToString()
        {
            var endPoint = string.Format(@"
++++++++++++++++++++++++ENDPOINT++++++++++++++++++++++++
Serial Number: {0}
Meter Model Id: {1}
Meter Number: {2}
Meter Firmware Version: {3}
Switch State: {4}
++++++++++++++++++++++++++++++++++++++++++++++++++++++++",
                SerialNumber,
                MeterModelId,
                MeterNumber,
                MeterFirmwareVersion,
                SwitchState
            );

            return endPoint;
        }
    }
}
