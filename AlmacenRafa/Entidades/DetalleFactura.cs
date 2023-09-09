using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlmacenRafa.Entidades
{
    internal class DetalleFactura
    {
        public Producto Id_articulo { get; set; }
        public int Cantidad { get; set; }
        

        public DetalleFactura(Producto id_articulo,int cantidad)
        {

            Id_articulo = id_articulo;
            Cantidad = cantidad;
        }
        public double CalcularSubtotal()
        {
            double subtotal = 0;
            subtotal = Cantidad * Id_articulo.Precio_unitario;
            return subtotal;
        }

    }
}
