using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AccesoDatos.Conexion
{
    public class ConnectionBD
    {
        private SqlConnection C = new SqlConnection("Data Source=.;Initial Catalog=crud_capas;Integrated Security=True");

        public SqlConnection OpenConnection()
        {
            if (C.State == ConnectionState.Closed) C.Open();
            return C;
        }

        public SqlConnection CloseConnection()
        {
            if (C.State == ConnectionState.Open) C.Close();
            return C;
        }

    }
}
