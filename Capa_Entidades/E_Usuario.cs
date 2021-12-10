using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
   public  class E_Usuario
    {
        private int idusuario;
        private string nombresApellidos;
        private string login;
        private string password;
        private byte[] icon;
        private string nombreIcon;
        private string correo;
        private string rol;

        public int Idusuario { get => idusuario; set => idusuario = value; }
        public string NombresApellidos { get => nombresApellidos; set => nombresApellidos = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public byte[] Icon { get => icon; set => icon = value; }
        public string NombreIcon { get => nombreIcon; set => nombreIcon = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Rol { get => rol; set => rol = value; }
    }
}
