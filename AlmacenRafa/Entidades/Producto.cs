using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenRafa.Entidades
{
    internal class Producto
    {
        public int Id_articulo { get; set; }
        public string Nombre_a { get; set; }
        public double Precio_unitario { get; set; }


        public Producto()
        {
            Id_articulo = 0;
            Nombre_a = string.Empty;
            Precio_unitario = 0;
        }
        public Producto(int id_articulo,string nombre_a,double precio_unitario)
        {
            Id_articulo=id_articulo;
            Nombre_a = nombre_a;
            Precio_unitario=precio_unitario;
        }

        public override string ToString()
        {
            return Nombre_a;
        }
    }
}
