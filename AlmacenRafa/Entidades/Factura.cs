using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenRafa.Entidades
{
    internal class Factura
    {
        public int Id_factura { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_forma_pago { get; set; }
        public int Id_cliente { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        public List<DetalleFactura> Detalles { get; set; }

        public Factura() 
        {
            Detalles = new List<DetalleFactura>();
        }
        public void AgregarDetalle(DetalleFactura detalle)
        {
            Detalles.Add(detalle);
        }
        public void QuitarDetalle(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (DetalleFactura d in Detalles)
            {
                total += d.CalcularSubtotal();
            }
            return total;
        }
    }
}
