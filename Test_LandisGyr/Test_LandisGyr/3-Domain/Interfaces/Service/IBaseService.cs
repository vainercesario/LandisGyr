using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_LandisGyr._3_Domain.Interfaces.Service
{
    public interface IBaseService<T>
    {
        bool Insert(T obj);
        bool Edit(T oldObj,T newObj);
        bool Delete(T obj);
    }
}
