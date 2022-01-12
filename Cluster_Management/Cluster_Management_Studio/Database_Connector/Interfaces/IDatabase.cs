using Models;
using System;
using System.Collections.Generic;

namespace Database_Connector.Interfaces
{
    public interface IDatabase<T>
    {
        public List<Tuple<string, object>> GetQuery(GetMessage model);
        public T InsertQuery(InsertMessage model);
    }
}
