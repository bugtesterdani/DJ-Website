using Data.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using Database_Connector.Interfaces;
using Database_Connector.Services;

namespace Data.Services
{
    public class Cluster_Get : ICluster<List<Tuple<string, object>>>
    {
        public List<Tuple<string, object>> Get(GetMessage model)
        {
            List<Tuple<string, object>> value = new List<Tuple<string, object>>();

            // Get by MySQL
            try
            {
                IDatabase<int> mySQLDB = new MySQLService();
                value = mySQLDB.GetQuery(model);
            }
            catch { }

            if (value != new List<Tuple<string, object>>())
                return value;

            // Get by MongoDB
            try
            {
                IDatabase<bool> mongoDB = new MongoService();
                value = mongoDB.GetQuery(model);
            }
            catch { }

            return value;
        }
    }
}
