using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenDockUp
{
    public partial class FormLogin : Form
    {
        /*este String (path) debe cambiarse por cualquier otra direccion en su 
        computador personal para que funcione Correctamente*/

        private string _path = "";
        private int _posicionUser = -1;
        private List<Usuario> _usuarios = new List<Usuario>();
        public FormLogin()
        {
            InitializeComponent();
        }
        public string Path { set { _path = value; } get { return _path; } }
        public int Posicion { set { _posicionUser = value; } get { return _posicionUser; } }
        public List<Usuario> ListaUsuarios { set { _usuarios = value; } get { return _usuarios; } }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try { _usuarios = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText(_path)); }
            catch
            {
                _usuarios.Add(new Usuario("A", "A", true));
                MessageBox.Show("Es primera vez que se inicia el Programa.\nLos Datos para Ingresar como Administrador son:\n\nUsuario: A\nClave: A");
            }
        }
        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool Incorrecto = true;
            for (int i = 0; i<_usuarios.Count; i++)
            {
                if (_usuarios[i].NombreUsuario == txtUsuario.Text && _usuarios[i].Clave == txtClave.Text)
                {
                    this.DialogResult = DialogResult.OK;
                    _posicionUser = i;
                    this.Close();
                    Incorrecto = false;
                    break;
                }
            }
            if(Incorrecto) MessageBox.Show("Usuario y/o Clave Incorrectas");
        }

        #region PlaceHolder
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.ForeColor == Color.Silver)
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }
        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.ForeColor == Color.Silver)
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
            }
        }

        #endregion
    }
}
/*MessageBox.Show("A Continuacion escoja una ubicacion para Guardar Datos de usuario:");
               if (BusquedaCarpeta.ShowDialog() == DialogResult.OK)
               {
                   File.WriteAllText(BusquedaCarpeta.SelectedPath + "/Direccion.txt",BusquedaCarpeta.SelectedPath);
                   _pathLogin = BusquedaCarpeta.SelectedPath + "/Users.json";
               }
               else Application.Exit();*/
