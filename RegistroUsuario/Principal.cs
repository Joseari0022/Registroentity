using Microsoft.Win32;
using SistemaGonzalez.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroUsuario
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroUsuarios ru = new RegistroUsuarios();
            ru.MdiParent = this.MdiParent;
            ru.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.ConsultaUsuario cu = new Consultas.ConsultaUsuario();
            cu.MdiParent = this.MdiParent;
            cu.Show();
        }
    }
}
