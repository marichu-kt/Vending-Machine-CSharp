using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class MaquinaExpendedora
    {
        public List<Producto> Productos { get; private set; }
        public List<Producto> ProductosComprados { get; private set; } // Lista para almacenar los productos comprados

        public MaquinaExpendedora()
        {
            Productos = new List<Producto>();
            ProductosComprados = new List<Producto>(); // Inicializa la lista de productos comprados
        }

        public void MostrarProductos()
        {
            Console.WriteLine("Lista de Productos:");
            foreach (var producto in Productos)
            {
                Console.WriteLine("---------------------------------------------");

                Console.WriteLine($"Nombre: {producto.Nombre}");
                Console.WriteLine($"Unidades disponibles: {producto.Unidades}");
                Console.WriteLine($"Precio unitario: {producto.PrecioUnitario:N2}$");
                Console.WriteLine($"Descripción: {producto.Descripcion}");

                if (producto is MaterialPrecioso materialPrecioso)
                {
                    Console.WriteLine($"Tipo de material: {materialPrecioso.TipoMaterial}");
                    Console.WriteLine($"Peso: {materialPrecioso.Peso} gramos");
                }
                else if (producto is ProductoAlimenticio productoAlimenticio)
                {
                    Console.WriteLine($"Información nutricional: {productoAlimenticio.InformacionNutricional}");
                }
                else if (producto is ProductoElectronico productoElectronico)
                {
                    Console.WriteLine($"Materiales: {productoElectronico.Materiales}");
                    Console.WriteLine($"Tiene batería: {(productoElectronico.TieneBateria ? "Sí" : "No")}");
                    Console.WriteLine($"Precargado: {(productoElectronico.Precargado ? "Sí" : "No")}");
                }

                Console.WriteLine("---------------------------------------------");
            }
        }


        public void CargarProductosDesdeCSV(string rutaArchivo)
        {
            using (var reader = new StreamReader(rutaArchivo))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (values.Length < 5) // Verificar si la línea tiene al menos 5 valores
                    {
                        Console.WriteLine("Error: La línea del archivo CSV no tiene el formato correcto.");
                        continue; // Saltar esta línea y continuar con la siguiente
                    }

                    if (!int.TryParse(values[0], out int tipoProducto))
                    {
                        Console.WriteLine($"Error: Tipo de producto no válido en la línea '{line}'");
                        continue; // Saltar esta línea y continuar con la siguiente
                    }

                    string nombreProducto = values[1];
                    if (!int.TryParse(values[2], out int unidades))
                    {
                        Console.WriteLine($"Error: Cantidad de unidades no válida en la línea '{line}'");
                        continue; // Saltar esta línea y continuar con la siguiente
                    }

                    if (!double.TryParse(values[3], out double precioUnitario))
                    {
                        Console.WriteLine($"Error: Precio unitario no válido en la línea '{line}'");
                        continue; // Saltar esta línea y continuar con la siguiente
                    }

                    string descripcion = values[4];

                    switch (tipoProducto)
                    {
                        case 1: // Material Precioso
                            if (values.Length < 7) // Verificar si la línea tiene al menos 7 valores
                            {
                                Console.WriteLine("Error: La línea del archivo CSV no tiene el formato correcto para un material precioso.");
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            string tipoMaterial = values[5];
                            if (!double.TryParse(values[6], out double peso))
                            {
                                Console.WriteLine($"Error: Peso no válido en la línea '{line}'");
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            Productos.Add(new MaterialPrecioso
                            {
                                Nombre = nombreProducto,
                                Unidades = unidades,
                                PrecioUnitario = precioUnitario,
                                Descripcion = descripcion,
                                TipoMaterial = tipoMaterial,
                                Peso = peso
                            });
                            break;
                        case 2: // Producto Alimenticio
                            if (values.Length < 6) // Verificar si la línea tiene al menos 6 valores
                            {
                                Console.WriteLine("Error: La línea del archivo CSV no tiene el formato correcto para un producto alimenticio.");
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            string informacionNutricional = values[5];
                            Productos.Add(new ProductoAlimenticio
                            {
                                Nombre = nombreProducto,
                                Unidades = unidades,
                                PrecioUnitario = precioUnitario,
                                Descripcion = descripcion,
                                InformacionNutricional = informacionNutricional
                            });
                            break;
                        case 3: // Producto Electrónico
                            if (values.Length < 8) // Verificar si la línea tiene al menos 8 valores
                            {
                                Console.WriteLine("Error: La línea del archivo CSV no tiene el formato correcto para un producto electrónico.");
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            string materiales = values[5];
                            if (!bool.TryParse(values[6], out bool tieneBateria))
                            {
                                Console.WriteLine($"Error: Valor para 'tiene_bateria' no válido en la línea '{line}'");
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            if (!bool.TryParse(values[7], out bool precargado))
                            {
                                Console.WriteLine($"Error: Valor para 'precargado' no válido en la línea '{line}'");
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            Productos.Add(new ProductoElectronico
                            {
                                Nombre = nombreProducto,
                                Unidades = unidades,
                                PrecioUnitario = precioUnitario,
                                Descripcion = descripcion,
                                Materiales = materiales,
                                TieneBateria = tieneBateria,
                                Precargado = precargado
                            });
                            break;
                        default:
                            Console.WriteLine($"Error: Tipo de producto desconocido en la línea '{line}'");
                            break;
                    }
                }
            }
        }

        private void GuardarProductoEnCSV(Producto producto, string rutaArchivo)
        {
            using (var writer = new StreamWriter(rutaArchivo, true))
            {
                string tipoProducto = "";

                if (producto is MaterialPrecioso)
                {
                    tipoProducto = "1";
                    var materialPrecioso = (MaterialPrecioso)producto;
                    writer.WriteLine($"{tipoProducto};{materialPrecioso.Nombre};{materialPrecioso.Unidades};{materialPrecioso.PrecioUnitario};{materialPrecioso.Descripcion};{materialPrecioso.TipoMaterial};{materialPrecioso.Peso}");
                }
                else if (producto is ProductoAlimenticio)
                {
                    tipoProducto = "2";
                    var productoAlimenticio = (ProductoAlimenticio)producto;
                    writer.WriteLine($"{tipoProducto};{productoAlimenticio.Nombre};{productoAlimenticio.Unidades};{productoAlimenticio.PrecioUnitario};{productoAlimenticio.Descripcion};{productoAlimenticio.InformacionNutricional}");
                }
                else if (producto is ProductoElectronico)
                {
                    tipoProducto = "3";
                    var productoElectronico = (ProductoElectronico)producto;
                    string tieneBateria = productoElectronico.TieneBateria ? "true" : "false";
                    string precargado = productoElectronico.Precargado ? "true" : "false";
                    writer.WriteLine($"{tipoProducto};{productoElectronico.Nombre};{productoElectronico.Unidades};{productoElectronico.PrecioUnitario};{productoElectronico.Descripcion};{productoElectronico.Materiales};{tieneBateria};{precargado}");
                }
            }
        }

        public void EliminarProducto(string nombreProducto)
        {
            Producto productoAEliminar = Productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto));
            if (productoAEliminar != null)
            {
                Productos.Remove(productoAEliminar);
                Console.WriteLine($"Producto '{nombreProducto}' eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"El producto '{nombreProducto}' no existe en la máquina expendedora.");
            }
        }


        public Producto SolicitarDetalles()
        {
            if (Productos.Count >= 12) // La maquina expendedora tiene un limite de 12 productos
            {
                Console.WriteLine("La lista de productos está llena. No se pueden agregar más productos.");
                return null; // Retorna null para indicar que no se agregó ningún producto
            }

            Console.WriteLine(" Ingrese los detalles del nuevo producto:");

            Console.Write(" Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write(" Unidades disponibles: ");
            int unidades = int.Parse(Console.ReadLine());

            Console.Write(" Precio unitario: ");
            double precioUnitario = double.Parse(Console.ReadLine());

            Console.Write(" Descripción: ");
            string descripcion = Console.ReadLine();

            Console.WriteLine();
            Console.Write(" Seleccione el tipo de producto: ");
            Console.WriteLine();
            Console.WriteLine(" ###################################");
            Console.WriteLine(" ##   A D M I N I S T R A D O R   ##");
            Console.WriteLine(" ###################################");
            Console.WriteLine(" ## 1. Material Precioso          ##");
            Console.WriteLine(" ## 2. Producto Alimenticio       ##");
            Console.WriteLine(" ## 3. Producto Electrónico       ##");
            Console.WriteLine(" ###################################");


            Console.Write(" Ingrese el número correspondiente al tipo de producto: ");
            int tipoProducto = int.Parse(Console.ReadLine());

            switch (tipoProducto)
            {
                case 1:
                    Console.Write(" Tipo de material: ");
                    string tipoMaterial = Console.ReadLine();
                    Console.Write(" Peso (en gramos): ");
                    double peso = double.Parse(Console.ReadLine());

                    Producto materialPrecioso = new MaterialPrecioso
                    {
                        Nombre = nombre,
                        Unidades = unidades,
                        PrecioUnitario = precioUnitario,
                        Descripcion = descripcion,
                        TipoMaterial = tipoMaterial,
                        Peso = peso
                    };
                    Productos.Add(materialPrecioso);
                    GuardarProductoEnCSV(materialPrecioso, "productos.csv");
                    return materialPrecioso;

                case 2:
                    Console.Write(" Información nutricional: ");
                    string informacionNutricional = Console.ReadLine();

                    Producto productoAlimenticio = new ProductoAlimenticio
                    {
                        Nombre = nombre,
                        Unidades = unidades,
                        PrecioUnitario = precioUnitario,
                        Descripcion = descripcion,
                        InformacionNutricional = informacionNutricional
                    };
                    Productos.Add(productoAlimenticio);
                    GuardarProductoEnCSV(productoAlimenticio, "productos.csv");
                    return productoAlimenticio;

                case 3:
                    Console.Write(" Materiales: ");
                    string materiales = Console.ReadLine();
                    Console.Write("¿Tiene batería? (S/N): ");
                    bool tieneBateria = Console.ReadLine().ToUpper() == "S";
                    Console.Write("¿Está precargado? (S/N): ");
                    bool precargado = Console.ReadLine().ToUpper() == "S";

                    Producto productoElectronico = new ProductoElectronico
                    {
                        Nombre = nombre,
                        Unidades = unidades,
                        PrecioUnitario = precioUnitario,
                        Descripcion = descripcion,
                        Materiales = materiales,
                        TieneBateria = tieneBateria,
                        Precargado = precargado
                    };
                    Productos.Add(productoElectronico);
                    GuardarProductoEnCSV(productoElectronico, "productos.csv");
                    return productoElectronico;

                default:
                    Console.WriteLine("Opción no válida. Se creará un producto genérico.");
                    Producto productoGenerico = new Producto
                    {
                        Nombre = nombre,
                        Unidades = unidades,
                        PrecioUnitario = precioUnitario,
                        Descripcion = descripcion
                    };
                    Productos.Add(productoGenerico);
                    GuardarProductoEnCSV(productoGenerico, "productos.csv");
                    return productoGenerico;
            }
        }


        public void RealizarCompraConTarjeta(Producto producto)
        {
            if (producto.Unidades <= 0)
            {
                Console.WriteLine($"El producto {producto.Nombre} está agotado y no se puede comprar.");
                return;
            }
            Console.WriteLine($"Procesando compra de {producto.Nombre} con tarjeta...");

            // Solicitar los datos de la tarjeta al usuario
            Console.Write("Ingrese el número de tarjeta: ");
            string numeroTarjeta = Console.ReadLine();

            Console.Write("Ingrese la fecha de caducidad (MM/YY): ");
            string fechaCaducidad = Console.ReadLine();

            Console.Write("Ingrese el código de seguridad: ");
            string codigoSeguridad = Console.ReadLine();

            // Aquí agregarías la lógica para procesar la compra con tarjeta,
            // como conectar a un servicio de pago para realizar la transacción.

            // Por ejemplo, podrías imprimir los datos de la tarjeta para simular la transacción:
            Console.WriteLine($"Número de tarjeta: {numeroTarjeta}");
            Console.WriteLine($"Fecha de caducidad: {fechaCaducidad}");
            Console.WriteLine($"Código de seguridad: {codigoSeguridad}");

            // Después de confirmar la compra, se reduce el número de unidades disponibles en 1
            var productoEnLista = Productos.FirstOrDefault(p => p.Nombre == producto.Nombre);
            if (productoEnLista != null && productoEnLista.Unidades > 0)
            {
                productoEnLista.Unidades -= 1;
                // Guardar los cambios en el archivo CSV
                GuardarProductoEnCSV(productoEnLista, "productos.csv");
            }

            ProductosComprados.Add(producto);
            MostrarCesta();

            Console.WriteLine($"¡Compra de {producto.Nombre} realizada con tarjeta!");
        }

        public void RealizarCompraEnEfectivo(Producto producto)
        {
            if (producto.Unidades <= 0)
            {
                Console.WriteLine($"El producto {producto.Nombre} está agotado y no se puede comprar.");
                return;
            }
            // Lógica para procesar la compra con efectivo
            double total = producto.PrecioUnitario;
            double pagado = 0;

            Console.WriteLine($"El precio del producto es: {producto.PrecioUnitario:N2}$");

            // Solicitar monedas hasta que se alcance el precio o se supere
            while (pagado < total)
            {
                Console.Write("Ingrese el valor de una moneda: ");
                double moneda = double.Parse(Console.ReadLine());

                pagado += moneda;
                Console.WriteLine($"Total pagado hasta ahora: {pagado:N2}$");
            }

            if (pagado >= total)
            {
                Console.WriteLine($"¡Compra de {producto.Nombre} realizada en efectivo!");
                Console.WriteLine($"Su cambio es: {(pagado - total):N2}$");


                // Reducir las unidades disponibles del producto en 1
                var productoEnLista = Productos.FirstOrDefault(p => p.Nombre == producto.Nombre);
                if (productoEnLista != null && productoEnLista.Unidades > 0)
                {
                    productoEnLista.Unidades -= 1;
                    // Guardar los cambios en el archivo CSV
                    GuardarProductoEnCSV(productoEnLista, "productos.csv");
                }

                ProductosComprados.Add(producto);
                MostrarCesta();
            }
            else
            {
                Console.WriteLine("El monto ingresado no es suficiente para pagar el producto.");
            }
        }

        public void MostrarCesta()
        {
            Console.WriteLine(" Productos en la cesta:");
            foreach (var producto in ProductosComprados)
            {
                Console.WriteLine($"- {producto.Nombre} - {producto.PrecioUnitario:N2}");
            }
        }
    }
}
