using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaquinaExpendedora maquina = new MaquinaExpendedora();
            maquina.CargarProductosDesdeCSV("productos.csv");


            int opcion = 0;

            Console.WriteLine();
            Console.WriteLine("███████████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("█▄─▀█▀─▄██─▄─██─▄▄▄─█▄─██─▄█▄─▄█▄─▀█▄─▄██─▄─████▄─▄▄─█▄─▀─▄█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄█▄─▄▄▀█▄─▄▄─█▄─▄▄▀█─▄▄─█▄─▄▄▀██─▄─██");
            Console.WriteLine("██─█▄█─███─▀─██─██▀▄██─██─███─███─█▄▀─███─▀─█████─▄█▀██▀─▀███─▄▄▄██─▄█▀██─█▄▀─███─██─██─▄█▀██─██─█─██─██─▄─▄██─▀─██");
            Console.WriteLine("█▄▄▄█▄▄▄█▄▄█▄▄█▄▄▄█▄██▄▄▄▄██▄▄▄█▄▄▄██▄▄█▄▄█▄▄███▄▄▄▄▄█▄▄█▄▄█▄▄▄███▄▄▄▄▄█▄▄▄██▄▄█▄▄▄▄██▄▄▄▄▄█▄▄▄▄██▄▄▄▄█▄▄█▄▄█▄▄█▄▄█");
            Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.WriteLine();

            do
            {
                Console.WriteLine(" ###################################");
                Console.WriteLine(" ##          C L I E N T E        ##");
                Console.WriteLine(" ###################################");
                Console.WriteLine(" ##  1.Comprar Productos          ##");
                Console.WriteLine(" ##  2.Información de Productos   ##");
                Console.WriteLine(" ##  3.Salir                      ##");
                Console.WriteLine(" ##  4.Opciones Admin             ##");
                Console.WriteLine(" ###################################");
                Console.WriteLine();
                Console.Write(" Elige una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Mostrar los productos disponibles
                        maquina.MostrarProductos();

                        // Pedir al usuario que elija un producto
                        Console.Write("Elige el número del producto que deseas comprar (0 para volver al menú principal): ");
                        int indiceProducto = int.Parse(Console.ReadLine());

                        // Verificar si el índice seleccionado está dentro del rango de productos válidos
                        if (indiceProducto >= 0 && indiceProducto <= maquina.Productos.Count)
                        {
                            if (indiceProducto == 0)
                            {
                                Console.WriteLine("Volviendo al menú principal...");
                                break; // Salir del case 1 y volver al menú principal
                            }

                            // El índice seleccionado por el usuario debe ser el índice real menos uno
                            int indiceReal = indiceProducto - 1;

                            Producto productoSeleccionado = maquina.Productos[indiceReal];

                            // Mostrar información del producto seleccionado
                            Console.WriteLine("Has seleccionado el siguiente producto:");
                            productoSeleccionado.MostrarInformacion();

                            // Agregar el producto comprado a la lista de productos comprados
                            maquina.ProductosComprados.Add(productoSeleccionado);


                            // Pedir al usuario que elija el método de pago
                            Console.WriteLine("Selecciona el método de pago:");
                            Console.WriteLine("1. Tarjeta");
                            Console.WriteLine("2. Efectivo");
                            Console.Write("Elige una opción: ");
                            int opcionPago = int.Parse(Console.ReadLine());

                            switch (opcionPago)
                            {
                                case 1:
                                    Console.WriteLine("Has elegido pagar con tarjeta.");
                                    // Lógica para procesar la compra con tarjeta
                                    maquina.RealizarCompraConTarjeta(productoSeleccionado);
                                    break;

                                case 2:
                                    Console.WriteLine("Has elegido pagar con efectivo.");
                                    // Lógica para procesar la compra con efectivo
                                    maquina.RealizarCompraEnEfectivo(productoSeleccionado);
                                    break;

                                default:
                                    Console.WriteLine("Opción de pago no válida.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("¡La opción seleccionada no es válida!");
                        }
                        break;



                    case 2:
                        maquina.MostrarProductos();
                        break;

                    case 3:
                        Console.WriteLine("Saliendo ...");
                        break;

                    case 4:
                        MostrarMenuAdmin(maquina);
                        break;
                }
            } while (opcion != 3);

        }

        static void MostrarMenuAdmin(MaquinaExpendedora maquina)
        {
            // Definir la contraseña
            string contraseña = "key";

            // Solicitar la contraseña al usuario sin mostrarla en la consola
            Console.WriteLine();
            Console.Write(" Ingrese la contraseña de administrador: ");
            StringBuilder contraseñaIngresada = new StringBuilder();
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey(true); // Lee la tecla sin mostrarla en la consola
                if (tecla.Key != ConsoleKey.Enter)
                {
                    if (tecla.Key == ConsoleKey.Backspace && contraseñaIngresada.Length > 0)
                    {
                        Console.Write("\b \b"); // Borra el último carácter mostrado
                        contraseñaIngresada.Remove(contraseñaIngresada.Length - 1, 1); // Elimina el último carácter de la contraseña ingresada
                    }
                    else
                    {
                        contraseñaIngresada.Append(tecla.KeyChar);
                        Console.Write("*"); // Muestra un asterisco en lugar del carácter real
                    }
                }
            } while (tecla.Key != ConsoleKey.Enter);
            Console.WriteLine(); // Imprimir una nueva línea después de presionar Enter

            // Verificar si la contraseña es correcta
            if (contraseñaIngresada.ToString() == contraseña)
            {
                // Mostrar el menú de administrador solo si la contraseña es correcta
                int opcionAdmin;
                do
                {

                    Console.WriteLine();
                    Console.WriteLine(" ###################################");
                    Console.WriteLine(" ##   A D M I N I S T R A D O R   ##");
                    Console.WriteLine(" ###################################");
                    Console.WriteLine(" ##  1.Cargar Producto            ##");
                    Console.WriteLine(" ##  2.Eliminar Producto          ##");
                    Console.WriteLine(" ##  3.Cargar lista de Productos  ##");
                    Console.WriteLine(" ##  4.Volver al Menú Principal   ##");
                    Console.WriteLine(" ###################################");
                    Console.WriteLine();
                    Console.Write(" Elige una opción: ");

                    opcionAdmin = int.Parse(Console.ReadLine());

                    switch (opcionAdmin)
                    {
                        case 1:
                            Producto nuevoProducto = maquina.SolicitarDetalles();
                            break;

                        case 2:
                            Console.Write("Ingrese el nombre del producto a eliminar: ");
                            string nombreProductoEliminar = Console.ReadLine();
                            maquina.EliminarProducto(nombreProductoEliminar);
                            break;

                        case 3:
                            Console.Write("Ingrese la ruta del archivo CSV: ");
                            string rutaArchivo = Console.ReadLine();
                            maquina.CargarProductosDesdeCSV(rutaArchivo);
                            Console.WriteLine("Lista de productos cargada desde el archivo CSV.");
                            break;
                    }
                } while (opcionAdmin != 4);
            }
            else
            {
                // Mostrar un mensaje de error si la contraseña es incorrecta
                Console.WriteLine("Contraseña incorrecta. Acceso denegado.");
            }
        }
    }
}
