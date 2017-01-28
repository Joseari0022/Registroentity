using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using SistemaGonzalez;

namespace RegistroUsuario.Consultas
{
    public partial class ConsultaUsuario : Form
    {
        public ConsultaUsuario()
        {
            InitializeComponent();
        }

        private void ConsultaUsuario_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void UsuariodataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Idbutton_Click(object sender, EventArgs e)
        {
            
        }
        
 
        private void Cargar()
        {
            UsuariodataGridView.DataSource = UsuarioBll.GetLista();
        }
    }
}
