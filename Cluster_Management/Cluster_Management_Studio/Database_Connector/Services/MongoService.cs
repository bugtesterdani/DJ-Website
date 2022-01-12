using Database_Connector.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Connector.Services
{
    public class MongoService : IDatabase<bool>
    {
        public bool InsertQuery(InsertMessage model)
        {
            throw new NotImplementedException();
        }

        List<Tuple<string, object>> IDatabase<bool>.GetQuery(GetMessage model)
        {
            throw new NotImplementedException();
        }
    }
}
