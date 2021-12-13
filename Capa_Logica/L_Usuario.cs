using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class L_Usuario
    {

        D_Usuario objUsuario = new D_Usuario();

        public void InsertUsuario(E_Usuario _Usuario)
        {
            objUsuario.InsertUsuario(_Usuario);
        }

        public List<E_Usuario> MostrarUsuario(string buscar)
        {
           return  objUsuario.ListarUsuario(buscar);
        }
    }
}
