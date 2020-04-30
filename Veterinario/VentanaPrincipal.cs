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
        DataTable mascota = new DataTable();
        DataTable porDNI = new DataTable();
        public VentanaPrincipal()
        {
            InitializeComponent();
            dataGridView1.DataSource = conexion.getMas();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void PET_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.mascotaNuevo(textdni.Text, textraza.Text, textnombre2.Text, textedad.Text));
            
        }


        private void CLIN_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(conexion.clientNuevo(textdni.Text, textnombre.Text, texttelefono.Text, textemail.Text));
        }

        public void cogerInfo(String dni)
        {
            porDNI = conexion.getDNI(dni);
            dat2.Text = porDNI.Rows[0]["Nombre"].ToString();
            dat3.Text = porDNI.Rows[0]["Telefono"].ToString();
            dat4.Text =  porDNI.Rows[0]["Email"].ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dat1.Text = dataGridView1.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            dat5.Text = dataGridView1.Rows[e.RowIndex].Cells["Raza"].Value.ToString();
            dat6.Text = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            dat7.Text = dataGridView1.Rows[e.RowIndex].Cells["Edad"].Value.ToString();
            String DNI = dat1.Text;
            porDNI = conexion.getDNI(DNI);
            if (porDNI.Rows.Count == 0)
            {
                label2.Text = "Error, escribe el DNI correctamente.";
            }
            else
            {
                cogerInfo(DNI);
            }
        }

    }
}
