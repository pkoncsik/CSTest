using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTest.Shared.Interfaces
{
    public interface IQueue<T>
    {
        void Queue(T item);


        T DeQueue();
    }
}
