using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Unidades disponibles: {Unidades}");
            Console.WriteLine($"Precio unitario: {PrecioUnitario:N2}$");
            Console.WriteLine($"Descripción: {Descripcion}");
        }
    }
}
