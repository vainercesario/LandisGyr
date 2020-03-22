using System;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Interfaces.Service;
using Test_LandisGyr._3_Domain.Model;

namespace Test_LandisGyr._3_Domain.Service
{
    public class EndPointService : IEndPointService
    {
        private readonly IEndPointDAO _endPointDAO;

        public EndPointService(IEndPointDAO endPointDAO)
        {
            _endPointDAO = endPointDAO;
        }

        public bool Delete(EndPoint obj)
        {
            try
            {
                if (_endPointDAO.Find(obj.SerialNumber) == null)
                {
                    throw new Exception("Sorry! EndPoint not found..");
                }

                _endPointDAO.Delete(obj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Edit(EndPoint oldObj, EndPoint newObj)
        {
            try
            {
                if (_endPointDAO.Find(newObj.SerialNumber) == null)
                {
                    throw new Exception("Sorry! EndPoint not found..");
                }

                _endPointDAO.Edit(oldObj, newObj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool Insert(EndPoint obj)
        {
            try
            {
                if (_endPointDAO.Find(obj.SerialNumber) != null)
                {
                    throw new Exception("Sorry! The record already exists in memory.");
                }

                _endPointDAO.Insert(obj);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
