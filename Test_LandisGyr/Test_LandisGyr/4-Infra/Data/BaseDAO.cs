using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Model;
using Test_LandisGyr._4_Infra.Data;

namespace Test_LandisGyr._4_Data
{
    /// <summary>
    /// Base abstract class to centralize data submission in the system.
    /// </summary>
    /// <typeparam name="T">Generic Class</typeparam>
    public abstract class BaseDAO<T> : IBaseDAO<T>
    {
        //private readonly Context context;
        protected static List<T> data = new List<T>();

        public BaseDAO()
        {

        }

        /*
        public BaseDAO(List<T> _context)
        {
            data = _context;
        }
        */
        /// <summary>
        /// Method used for Delete Data of System.
        /// </summary>
        /// <param name="obj">Generic Class.</param>
        public virtual bool Delete(T obj)
        {
            try
            {
                data.Remove(obj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting the record. Technical info: {ex.ToString()}");
                return false;
            }
        }

        /// <summary>
        /// Method used for Edition Data of System.
        /// </summary>
        /// <param name="obj">Old Generic Class.</param>
        /// <param name="newObj">New Generic Class.</param>
        public virtual bool Edit(T obj, T newObj)
        {
            try
            {
                data.Remove(obj);
                data.Add(newObj);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occurred while editing the record. Technical info: {ex.ToString()}");
                return false;
            }
            
        }

        /// <summary>
        /// Method used for Find of Generic Class.
        /// </summary>
        /// <param name="id">Value for find.</param>
        /// <returns>Generic Class.</returns>
        public virtual T Find(string id)
        {
            return data.Find(d => d.Equals(id));
        }

        /// <summary>
        /// Method used for Insertion Data of System.
        /// </summary>
        /// <param name="obj">Generic Class.</param>
        public virtual bool Insert(T obj)
        {
            try
            {
                data.Add(obj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while inserting the record. Technical info: {ex.ToString()}");
                return false;
            }

        }

        /// <summary>
        /// Method used for List All Data of Generic Class of System.
        /// </summary>
        /// <param name="obj">Generic Class.</param>
        public virtual List<T> ListAll()
        {
            return data.ToList();
        }
    }
}
