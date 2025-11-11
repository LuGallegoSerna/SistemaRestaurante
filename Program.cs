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


using System;
using Dominio;

class Program
{
    static void Main()
    {
        try
        {
            Restaurante rest = new Restaurante(
                nit: "900130748",
                nombre: "Donde Mamá",
                celular: "3108993117",
                direccion: "Cra 25 A # 4-02"
            );

            rest.MostrarInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}



