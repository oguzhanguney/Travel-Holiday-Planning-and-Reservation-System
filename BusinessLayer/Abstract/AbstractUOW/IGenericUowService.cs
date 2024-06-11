using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUOW
{
    public interface IGenericUowService<T>
    {
        void TInsert(T t);
        void TUpdate(T t);
        //aynı aynda birden fazla kaydı güncellemek için:
        void TMultiUpdate(List<T> t);
        T TGetByID(int id);
    }
}
