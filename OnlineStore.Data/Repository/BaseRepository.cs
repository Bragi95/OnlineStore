using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public abstract class BaseRepository
    {
        public IDbConnection DbConnection { get; set; }
        public QueryFactory db { get; set; }
        public BaseRepository()
        {
            db = new QueryFactory(DbConnection, new SqlServerCompiler());
        }     
    }
}
