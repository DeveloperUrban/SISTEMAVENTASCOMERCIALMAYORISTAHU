using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Capa_Datos
{
    public class Conexion
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-37R0IU2;DataBase=COMERCIALMAYORISTAHU;Persist Security Info=True;User ID=sa;Password=0p3r@d0r");

        public SqlConnection AbrirConexion()
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public SqlConnection CerrarConexion()
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }

            return con;
        }
    }
}
