using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class D_Usuario
    {
        // E_Usuario objUsuario = new E_Usuario();
        Conexion con = new Conexion();
        public void InsertUsuario(E_Usuario _Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO", con.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDOS", _Usuario.NombresApellidos);
            cmd.Parameters.AddWithValue("@LOGIN", _Usuario.Login);
            cmd.Parameters.AddWithValue("@PASSWORD", _Usuario.Password);
            cmd.Parameters.AddWithValue("@ICONO", _Usuario.Icon);
            cmd.Parameters.AddWithValue("@NOMBRE_ICON", _Usuario.NombreIcon);
            cmd.Parameters.AddWithValue("@CORREO", _Usuario.Correo);
            cmd.Parameters.AddWithValue("@ROL", _Usuario.Rol);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
    }

    }
}
