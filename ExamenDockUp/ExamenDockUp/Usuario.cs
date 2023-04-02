using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDockUp
{
    public class Usuario
    {
        private string _usuario; //Nombre de usuario
        private string _nombre; //Nombre Personal
        private string _clave;
        private string _cargo;
        public Usuario()
        {
            _usuario = "";
            _nombre = "";
            _clave = "";
            _cargo = "";
        }
        public Usuario(string Usuario, string Clave, bool Admin)
        {
            _nombre = "Nombre";
            _usuario = Usuario;
            _clave = Clave;
            if (Admin)
            {
                _cargo = "Administrador";
            }
            else
            {
                _cargo = "Empleado";
            }
        }
        public string NombreUsuario { get { return _usuario; } set { _usuario = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Clave { get { return _clave; } set { _clave = value; } }
        public string Cargo { get { return _cargo; } set { _cargo = value; } }
    }
}
