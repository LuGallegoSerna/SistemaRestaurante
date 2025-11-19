// using System;
// using Estructuras;

// class Program
// {
//     static void Main()
//     {
//         // Crear una lista enlazada de números
//         ListasEnlazada<int> lista = new ListasEnlazada<int>();

//         // Insertar algunos valores
//         lista.InsertarInicio(10);
//         lista.InsertarInicio(20);
//         lista.InsertarInicio(30);

//         Console.WriteLine("Lista inicial:");
//         lista.Mostrar(); // si tienes un método Mostrar() que recorra e imprima

//         // Eliminar un valor específico usando Predicate
//         bool eliminado = lista.Eliminar(x => x == 20);

//         if (eliminado)
//             Console.WriteLine("\nSe eliminó el valor 20 correctamente.");
//         else
//             Console.WriteLine("\nEl valor 20 no se encontró en la lista.");
//     }
// }

// using System;
// using Estructuras;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== PRUEBA DE COLA ===");
//         Cola<string> cola = new Cola<string>();
//         cola.Encolar("Pedido 1");
//         cola.Encolar("Pedido 2");
//         cola.Encolar("Pedido 3");
//         cola.Mostrar();

//         Console.WriteLine($"Desencolando: {cola.Desencolar()}");
//         cola.Mostrar();

//         Console.WriteLine("\n=== PRUEBA DE PILA ===");
//         Pila<string> pila = new Pila<string>();
//         pila.Apilar("Plato 1");
//         pila.Apilar("Plato 2");
//         pila.Apilar("Plato 3");
//         pila.Mostrar();

//         Console.WriteLine($"Desapilando: {pila.Desapilar()}");
//         pila.Mostrar();
//     }
// }


// using System;
// using Dominio;

// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             Restaurante rest = new Restaurante(
//                 nit: "900130748",
//                 nombre: "Donde Mamá",
//                 celular: "3108993117",
//                 direccion: "Cra 25 A # 4-02"
//             );

//             rest.MostrarInfo();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//     }
// }

// using Dominio;

// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             Cliente cliente = new Cliente(
//                 cedula: "1001234567",
//                 nombreCompleto: "Lu Gallego",
//                 celular: "3004567890",
//                 email: "prueba@mail.com"
//             );

//             cliente.MostrarInfo();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//     }
// }

// using Dominio;

// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             Plato plato = new Plato(
//                 codigo: "P001",
//                 nombre: "Bandeja paisa",
//                 descripcion: "Arroz, fríjoles, carne molida, chicharrón, huevo y aguacate.",
//                 precio: 25000m
//             );

//             plato.MostrarInfo();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//     }
// }


// using Dominio;
// using Estructuras;

// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             Plato bandeja = new Plato(
//                 codigo: "P001",
//                 nombre: "Bandeja paisa",
//                 descripcion: "Arroz, fríjoles, carne molida, chicharrón, huevo y aguacate.",
//                 precio: 25000m
//             );

//             Plato jugo = new Plato(
//                 codigo: "P002",
//                 nombre: "Jugo natural",
//                 descripcion: "Jugo de naranja.",
//                 precio: 6000m
//             );

//             Pedido pedido = new Pedido(cedulaCliente: "1001234567");

//             pedido.AgregarPlato(bandeja, 1);
//             pedido.AgregarPlato(jugo, 2);

//             pedido.MostrarInfo();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//     }
// }

using Dominio;

class Program
{
    static void Main()
    {
        try
        {
            Restaurante rest = new Restaurante(
                nit: "900123456",
                nombre: "Restaurante El Buen Sabor",
                celular: "3004567890",
                direccion: "Calle 10 #15-20"
            );

            Cliente c1 = new Cliente(
                cedula: "1001234567",
                nombreCompleto: "Lu Gallego",
                celular: "3004567890"
            );

            Cliente c2 = new Cliente(
                cedula: "1009876543",
                nombreCompleto: "Manguito Feliz",
                celular: "3012345678"
            );

            Plato p1 = new Plato(
                codigo: "P001",
                nombre: "Bandeja paisa",
                descripcion: "Arroz, fríjoles, carne molida, chicharrón, huevo y aguacate.",
                precio: 25000m
            );

            Plato p2 = new Plato(
                codigo: "P002",
                nombre: "Jugo natural",
                descripcion: "Jugo de naranja.",
                precio: 6000m
            );

            rest.AgregarCliente(c1);
            rest.AgregarCliente(c2);

            rest.AgregarPlato(p1);
            rest.AgregarPlato(p2);

            rest.MostrarInfo();
            Console.WriteLine();

            rest.ListarClientes();
            Console.WriteLine();

            rest.ListarPlatos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}