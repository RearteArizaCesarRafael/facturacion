using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlmacenRafa.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void facturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nuevaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNuevaFactura nuevo = new FrmNuevaFactura();
            nuevo.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
