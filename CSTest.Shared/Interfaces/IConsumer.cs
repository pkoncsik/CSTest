using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSTest.Shared.Model;

namespace CSTest.Shared.Interfaces
{
    public interface IConsumer
    {
        void ReadNext(Trade trade); 
    }
}
