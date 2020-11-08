using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public abstract class BaseRepository
    {
        public IDbConnection DbConnection { get; set; }
        public QueryFactory db { get; set; }
        public SqlServerCompiler compiler;
        public BaseRepository()
        {
            DbConnection = new SqlConnection("Data Source=localhost;" +
                "Initial Catalog=OnlineStore.DataBase;" +
                "Integrated Security=True;" +
                "Persist Security Info=False;" +
                "Pooling=False;" +
                "MultipleActiveResultSets=False;" +
                "Connect Timeout=60;Encrypt=False;" +
                "TrustServerCertificate=False");
            db = new QueryFactory(DbConnection, new SqlServerCompiler());
            compiler = new SqlServerCompiler();
        }     
    }
}
