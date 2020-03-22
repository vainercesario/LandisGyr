using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using EndPoint = Test_LandisGyr._3_Domain.Model.EndPoint;

namespace Test_LandisGyr._4_Data
{
    /// <summary>
    /// Class inherits from Operation to perform data storage actions for the EndPoint class.
    /// </summary>
    public class EndPointDAO : BaseDAO<EndPoint>, IEndPointDAO
    {
        /*
        public EndPointDAO(List<EndPoint> context)
            :base(context)
        {

        }
        */

        public EndPointDAO()
        {

        }

        /// <summary>
        /// Method used for Find of EndPoint Class.
        /// </summary>
        /// <param name="serialNumber">Value for find.</param>
        /// <returns>Generic Class.</returns>
        public override EndPoint Find(string serialNumber)
        {
            var dataAux =
                from endPoint in data
                where endPoint.SerialNumber == serialNumber
                select endPoint;

            return dataAux.FirstOrDefault();
        }

        /// <summary>
        /// Method used for Edition of EndPoint Class.
        /// </summary>
        /// <param name="oldObj">Original EndPoint.</param>
        /// <param name="newObj">EndPoint with information for editing.</param>
        public override bool Edit(EndPoint oldObj, EndPoint newObj)
        {
            try
            {
                data.Find(e => e.SerialNumber == oldObj.SerialNumber).SwitchState = newObj.SwitchState;
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine($"Error occurred while editing the record. Technical info: {ex.ToString()}");
                return false;
            }
            
        }


    }
}
