using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace Veterinario
{
    public partial class VentanaNuevoUser : Form
    {
        Conexion conexion = new Conexion();
        public VentanaNuevoUser()
        {
            InitializeComponent();
        }

        private void INST_Click(object sender, EventArgs e)
        {
                String paseito = textpass.Text;
                string myHash = BCrypt.Net.BCrypt.HashPassword(paseito, BCrypt.Net.BCrypt.GenerateSalt());
                MessageBox.Show(conexion.chavalitoNuevo(textuser.Text, textnombre.Text, myHash));
        }

       
    }
}
