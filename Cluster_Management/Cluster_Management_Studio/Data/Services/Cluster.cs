using Data.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class Cluster<T> : ICluster<T>
    {
        public T Get(GetMessage model)
        {
            throw new NotImplementedException();
        }
    }
}
