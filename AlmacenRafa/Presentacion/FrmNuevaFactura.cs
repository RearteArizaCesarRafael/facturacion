using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlmacenRafa.Datos;
using AlmacenRafa.Entidades;

namespace AlmacenRafa.Presentacion
{
    public partial class FrmNuevaFactura : Form
    {
        Factura factura;
        DBHelper gestor;
        public FrmNuevaFactura()
        {
            InitializeComponent();
            factura = new Factura();
            gestor = new DBHelper();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            lblFacturaNro.Text = lblFacturaNro.Text + " " + gestor.ProximaFactura().ToString();
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            CargarProductos();
        }

        private void DgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.CurrentCell.ColumnIndex == 5)
            {
                factura.QuitarDetalle(DgvDetalles.CurrentRow.Index);
                DgvDetalles.Rows.RemoveAt(DgvDetalles.CurrentRow.Index);
                CalcularTotales();
            }
        }

        private void CalcularTotales()
        {
            double total = factura.CalcularTotal();
            txtTotal.Text = total.ToString();
            double dto = total * Convert.ToDouble(txtDescuento.Text) / 100;
        }
        private void CargarProductos()
        {
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_ARTICULOS");
            cboProducto.DataSource = tabla;
            cboProducto.ValueMember = tabla.Columns[0].ColumnName;
            cboProducto.DisplayMember = tabla.Columns[1].ColumnName;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un articulo..."
                                , "Control"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad valida..."
                               , "Control"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Exclamation);
                return;
            }


            foreach (DataGridViewRow fila in DgvDetalles.Rows)
            {
                if (fila.Cells[1].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este articulo ya esta agregado..."
                               , "Control"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Exclamation);
                    return;
                }
            }



            DataRowView item = (DataRowView)cboProducto.SelectedItem;
            int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            Producto p = new Producto(nro, nom, pre);

            int cant = Convert.ToInt32(txtCantidad.Text);
            DetalleFactura detalle = new DetalleFactura(p, cant);

            double subTotal = detalle.CalcularSubtotal();
            factura.AgregarDetalle(detalle);
            DgvDetalles.Rows.Add(detalle.Id_articulo.Id_articulo,
                                   detalle.Id_articulo.Nombre_a,
                                   detalle.Id_articulo.Precio_unitario,
                                   detalle.Cantidad,
                                   subTotal,
                                   "quitar");
            CalcularTotales();

        }

        //private void GrabarFactura()
        //{
        //    factura.Fecha = Convert.ToDateTime(txtFecha.Text);
        //    factura.Id_cliente = txtCliente.Text;
        //    factura.Descuento = Convert.ToDouble(txtDescuento.Text);
        //    if (gestor.ConfirmarFactura(factura))
        //    {
        //        MessageBox.Show("Se grabo con exito la factura..."
        //            , "Control"
        //            , MessageBoxButtons.OK
        //            , MessageBoxIcon.Information);
        //        this.Dispose();
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se pudo grabar la factura..."
        //            , "Error"
        //            , MessageBoxButtons.OK
        //            , MessageBoxIcon.Error);
        //    }

        //}
    }
}
