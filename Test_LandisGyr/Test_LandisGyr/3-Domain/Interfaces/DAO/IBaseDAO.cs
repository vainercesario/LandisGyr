using System.Collections.Generic;

namespace Test_LandisGyr._3_Domain.Interfaces.DAO
{
    public interface IBaseDAO<T>
    {
        bool Insert(T obj);

        bool Edit(T oldObj, T newObj);

        bool Delete(T obj);

        List<T> ListAll();

        T Find(string serialNumber);
        
    }
}
