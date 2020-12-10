using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Interfaces
{
    public interface IBaseService<T> where T: class
    {
        IEnumerable<T> GetAll();
        Task Add(T model);
        Task Delete(int id);
        T GetById(int id);
    }
}
