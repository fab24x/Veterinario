﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinario
{
    public partial class VentanaLogin : Form
    {
        Conexion conexion = new Conexion();
        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.logear(textuser.Text, textpass.Text))
            {
                VentanaPrincipal v = new VentanaPrincipal();
                MessageBox.Show("Todo bien y yo que me alegro");
                v.Show();
                
                
            }
            else
            {
                MessageBox.Show("No me la cuelas puerco");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentanaNuevoUser u = new VentanaNuevoUser();
            u.Show();
        }

    }
}
