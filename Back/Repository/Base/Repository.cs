using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Base
{
    public abstract class Repository
    {
        protected string CONNECTION = @"Data Source=localhost;Database=SiteMercado;Integrated Security=sspi;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(CONNECTION);
        }
    }
}
