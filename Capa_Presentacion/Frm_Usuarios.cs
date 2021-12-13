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
using Capa_Entidades;
using Capa_Logica;
using System.Text.RegularExpressions;

namespace Capa_Presentacion
{
    public partial class Frm_Usuarios : Form
    {
        E_Usuario objUsuario = new E_Usuario();
        L_Usuario objUsuarioL = new L_Usuario();
        
        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        public void LimpiarCajasTexto()
        {
            txtNombreApellidos.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtEmail.Text = "";
            comboRol.Text = "";
            LblAnuncioAvatar.Visible = true;
            LblNombreIcon.Text = "";
        }

        public void listarDataGridUsuario(string buscar)
        {
            DataGridUsuarios.DataSource = objUsuarioL.MostrarUsuario(buscar);
        }

        public bool ValidarCorreo(string email)
        {
            bool correo= Regex.IsMatch(email, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
            return correo;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //con.AbrirConexion();
            if(ValidarCorreo(txtEmail.Text)==false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com","Validacion Correo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtEmail.Focus();
            }
            else
            {
                if (txtNombreApellidos.Text != "")
                {
                    if (txtUsuario.Text != "")
                    {

                        if (txtContrasena.Text != "")
                        {
                            if (comboRol.Text !="")
                            {
                                if (LblAnuncioAvatar.Visible == false)
                                {
                                    try
                                    {
                                        objUsuario.NombresApellidos = txtNombreApellidos.Text;
                                        objUsuario.Login = txtUsuario.Text;
                                        objUsuario.Password = txtContrasena.Text;
                                        objUsuario.Correo = txtEmail.Text;
                                        objUsuario.Rol = comboRol.Text;
                                        objUsuario.Icon = convertirImg();
                                        objUsuario.NombreIcon = LblNombreIcon.Text;
                                        objUsuarioL.InsertUsuario(objUsuario);
                                        LimpiarCajasTexto();
                                        txtNombreApellidos.Focus();
                                        MessageBox.Show("Registro Correctamente","Registro",MessageBoxButtons.OK);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error en llenar los campos" + ex.Message);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Debe selecionar un icono", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else {
                                MessageBox.Show("Debe seleccionar un rol","Registro",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            }
                            

                        }
                        else
                        {
                            MessageBox.Show("Debe un ingresar conraseña", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un nombre de usuario", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar nombres completos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
      
        }

        private byte[] convertirImg()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureAvatar.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox5.Image;
            LblNombreIcon.Text = "1";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox6.Image;
            LblNombreIcon.Text = "2";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox7.Image;
            LblNombreIcon.Text = "3";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox8.Image;
            LblNombreIcon.Text = "4";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox9.Image;
            LblNombreIcon.Text = "5";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox10.Image;
            LblNombreIcon.Text = "6";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox11.Image;
            LblNombreIcon.Text = "7";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureAvatar.Image = pictureBox12.Image;
            LblNombreIcon.Text = "8";
            LblAnuncioAvatar.Visible = false;
            Panel_Icon.Visible = false;
        }
        private void LblAnuncioAvatar_Click(object sender, EventArgs e)
        {
            Panel_Icon.Visible = true;
        }

        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {
            Panel_Icon.Visible = false;
            PanelRegistroUsuario.Visible = false;
            listarDataGridUsuario("");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PanelRegistroUsuario.Visible = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            PanelRegistroUsuario.Visible = true;
            LimpiarCajasTexto();
        }
    }
}
