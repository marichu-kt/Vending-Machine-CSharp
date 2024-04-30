using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class MaterialPrecioso : Producto
    {
        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo de material: {TipoMaterial}");
            Console.WriteLine($"Peso: {Peso} gramos");
        }
    }
}
