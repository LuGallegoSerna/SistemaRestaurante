using System;
using Dominio;

class Program
{
    static void Main()
    {
        Restaurante restaurante = new Restaurante(
            nit: "900123456",
            nombre: "Restaurante El Buen Sabor",
            celular: "3004567890",
            direccion: "Calle 10 #15-20"
        );

        int opcion = -1;

        while (opcion != 0)
        {
            Console.WriteLine("=== SISTEMA RESTAURANTE ===");
            Console.WriteLine("1. Crear cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Crear plato");
            Console.WriteLine("4. Listar platos");
            Console.WriteLine("5. Crear pedido");
            Console.WriteLine("6. Listar pedidos pendientes");
            Console.WriteLine("7. Despachar pedido");
            Console.WriteLine("8. Ver historial de pedidos");
            Console.WriteLine("9. Ver ganancias del día");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione opción: ");

            string? entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("Opción inválida.");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            try
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine() ?? string.Empty;

                        Console.Write("Nombre completo: ");
                        string nombreCliente = Console.ReadLine() ?? string.Empty;

                        Console.Write("Celular: ");
                        string celular = Console.ReadLine() ?? string.Empty;

                        Cliente cliente = new Cliente(cedula, nombreCliente, celular);
                        restaurante.AgregarCliente(cliente);

                        Console.WriteLine("Cliente creado.");
                        break;

                    case 2:
                        restaurante.ListarClientes();
                        break;

                    case 3:
                        Console.Write("Código del plato: ");
                        string codigoPlato = Console.ReadLine() ?? string.Empty;

                        Console.Write("Nombre del plato: ");
                        string nombrePlato = Console.ReadLine() ?? string.Empty;

                        Console.Write("Descripción: ");
                        string descripcion = Console.ReadLine() ?? string.Empty;

                        Console.Write("Precio: ");
                        string? textoPrecio = Console.ReadLine();
                        if (!decimal.TryParse(textoPrecio, out decimal precio) || precio <= 0)
                        {
                            Console.WriteLine("Precio inválido.");
                            break;
                        }

                        Plato plato = new Plato(codigoPlato, nombrePlato, descripcion, precio);
                        restaurante.AgregarPlato(plato);

                        Console.WriteLine("Plato creado.");
                        break;

                    case 4:
                        restaurante.ListarPlatos();
                        break;

                    case 5:
                        Console.Write("Cédula del cliente: ");
                        string cedulaPedido = Console.ReadLine() ?? string.Empty;

                        Pedido pedido = new Pedido(cedulaPedido);

                        int continuar = 1;
                        while (continuar == 1)
                        {
                            Console.Write("Código del plato: ");
                            string cod = Console.ReadLine() ?? string.Empty;

                            Console.Write("Cantidad: ");
                            string? textoCant = Console.ReadLine();
                            if (!int.TryParse(textoCant, out int cantidad) || cantidad <= 0)
                            {
                                Console.WriteLine("Cantidad inválida.");
                                continue;
                            }

                            Plato? platoEncontrado = restaurante.BuscarPlato(cod);
                            if (platoEncontrado != null)
                            {
                                pedido.AgregarPlato(platoEncontrado, cantidad);
                                Console.WriteLine("Plato agregado al pedido.");
                            }
                            else
                            {
                                Console.WriteLine("El plato no existe en el menú.");
                            }

                            Console.Write("¿Agregar otro plato? (1 = sí, 0 = no): ");
                            string? textoContinuar = Console.ReadLine();
                            int.TryParse(textoContinuar, out continuar);
                        }

                        restaurante.TomarPedido(pedido);
                        Console.WriteLine("Pedido encolado como PENDIENTE.");
                        break;

                    case 6:
                        restaurante.ListarPedidosPendientes();
                        break;

                    case 7:
                        restaurante.DespacharPedido();
                        break;

                    case 8:
                        restaurante.MostrarHistorialPedidos();
                        break;

                    case 9:
                        Console.WriteLine($"Ganancias del día: {restaurante.GananciasHoy:C}");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}

