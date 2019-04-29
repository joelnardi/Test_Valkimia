using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringLocal";

        private SqlConnection _sqlConn;
        public SqlConnection SqlConn
        {
            set
            { _sqlConn = value; }
            get
            { return _sqlConn; }
        }

        protected void OpenConnection()
        {
            string config = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            SqlConn = new SqlConnection(config);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }
    }
}