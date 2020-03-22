using System;
using System.Linq;

namespace Test_LandisGyr._2_Application.Validator
{
    /// <summary>
    /// Validate of Type for Input
    /// </summary>
    public static class TypeOfInput
    {
        /// <summary>
        /// Verify this input is Numeric
        /// </summary>
        /// <param name="input">Value to verification.</param>
        /// <returns>True|False</returns>
        public static bool isNumeric(object input)
        {
            try
            {
                return int.TryParse((string)input, out int aux);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify this input is MeterModelId
        /// </summary>
        /// <param name="input">Value to verification.</param>
        /// <returns>True|False</returns>
        public static bool isMeterModelId(object input)
        {
            try
            {
                var numeric = int.TryParse((string)input, out int val);
                if (numeric)
                    switch (val)
                    {
                        case (int)EnumMeterModelId.NSX1P2W:
                        case (int)EnumMeterModelId.NSX1P3W:
                        case (int)EnumMeterModelId.NSX2P2W:
                        case (int)EnumMeterModelId.NSX3P4W:
                            return true;
                        default:
                            return false;
                    }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Verify this input is SwitchState
        /// </summary>
        /// <param name="input">Value to verification.</param>
        /// <returns>True|False</returns>
        public static bool isSwitchState(object input)
        {
            try
            {
                var numeric = int.TryParse((string)input, out int val);
                if (numeric)
                    switch (val)
                    {
                        case (int)EnumSwitchState.Disconnected:
                        case (int)EnumSwitchState.Connected:
                        case (int)EnumSwitchState.Armed:
                            return true;
                        default:
                            return false;
                    }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
