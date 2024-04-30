using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class ProductoAlimenticio : Producto
    {
        public string InformacionNutricional { get; set; }


        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Información nutricional: {InformacionNutricional}");
        }
    }
}
