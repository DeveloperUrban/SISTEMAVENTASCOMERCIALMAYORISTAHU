using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Capa_Presentacion
{
    public partial class Frm_Usuarios : Form
    {
        Conexion con = new Conexion();
        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        public void ValidarCajasTexto()
        {
            if(txtNombreApellidos.Text=="")
            {
                
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //con.AbrirConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SP_INSERTAR_USUARIO",con.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDOS",);
        }
    }
}
