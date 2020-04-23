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
    public partial class VentanaPrincipal : Form
    {
        Conexion conexion = new Conexion();
        public VentanaPrincipal()
        {
            InitializeComponent();
        }


        private void PET_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.mascotaNuevo(textdueño.Text, textraza.Text, textnombre2.Text, textedad.Text));
            
        }

        private void CLIN_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.clienteNuevo(textdni.Text, textnombre.Text, texttelefono.Text));
        }
    }
}
