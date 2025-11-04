using System;
using Estructuras;

class Program
{
    static void Main()
    {
        // Crear una lista enlazada de números
        ListasEnlazada<int> lista = new ListasEnlazada<int>();

        // Insertar algunos valores
        lista.InsertarInicio(10);
        lista.InsertarInicio(20);
        lista.InsertarInicio(30);

        Console.WriteLine("Lista inicial:");
        lista.Mostrar(); // si tienes un método Mostrar() que recorra e imprima

        // Eliminar un valor específico usando Predicate
        bool eliminado = lista.Eliminar(x => x == 20);

        if (eliminado)
            Console.WriteLine("\nSe eliminó el valor 20 correctamente.");
        else
            Console.WriteLine("\nEl valor 20 no se encontró en la lista.");
    }
}


