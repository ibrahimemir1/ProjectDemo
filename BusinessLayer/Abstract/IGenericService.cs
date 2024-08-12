using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {

        void insert(T t);
        List<T> GetAll();
        T GetById(int id);
        void Update(T t);
        void Remove(T t);
    }
}
