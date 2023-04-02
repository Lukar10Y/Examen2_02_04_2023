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
    public partial class FormFactura : Form
    {
        private string _path = "";
        private List<DatosBase> _compras = new List<DatosBase>();
        private List<Factura> _facturas = new List<Factura>();
        public FormFactura()
        {
            InitializeComponent();
        }
        public List<DatosBase> Compras { get { return _compras; } set { _compras = value; } }
        public string Path { get { return _path;} set { _path = value; } }
        private void FormFactura_Load(object sender, EventArgs e)
        {
            try { _facturas = JsonConvert.DeserializeObject<List<Factura>>(_path); }
            catch { }

            lblNumeroFactura.Text = $"Numero de Factura  {((_facturas.Count+1).ToString()).PadLeft(5,'0')}";
            lblFecha.Text = $"Fecha de Emision:  {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _facturas.Add(new Factura());
            string json = JsonConvert.SerializeObject(_facturas.ToArray(),Formatting.Indented);
            File.WriteAllText(_path, json);
            this.Close();
        }
    }
}
