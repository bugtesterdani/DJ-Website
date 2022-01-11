using Data.Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace Data.Services
{
    public class Cluster_Get : ICluster<List<Tuple<string, object>>>
    {
        public List<Tuple<string, object>> Get(GetMessage model)
        {
            return new List<Tuple<string, object>>();
        }
    }
}
