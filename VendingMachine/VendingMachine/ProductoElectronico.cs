using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class ProductoElectronico : Producto
    {
        public string Materiales { get; set; }
        public bool TieneBateria { get; set; }
        public bool Precargado { get; set; }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Materiales: {Materiales}");
            Console.WriteLine($"Tiene batería: {(TieneBateria ? "Sí" : "No")}");
            Console.WriteLine($"Precargado: {(Precargado ? "Sí" : "No")}");
        }
    }
}
