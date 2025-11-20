namespace Estructuras;

public class Cola<T>
{
    private Nodo<T>? inicio;
    private Nodo<T>? final;
    private int contador = 0;

    public int Longitud => contador;
    public bool EstaVacia() => inicio is null;

    public void Encolar(T valor)
    {
        var nuevo = new Nodo<T>(valor);

        if (EstaVacia())
        {
            inicio = final = nuevo;
        }
        else
        {
            final!.Siguiente = nuevo;
            final = nuevo;
        }

        contador++;
    }

    public T Desencolar()
    {
        if (EstaVacia())
            throw new InvalidOperationException("La cola está vacía.");

        var valor = inicio!.Valor;
        inicio = inicio.Siguiente;
        contador--;

        if (inicio is null)
            final = null;

        return valor;
    }

    public T Frente()
    {
        if (EstaVacia())
            throw new InvalidOperationException("La cola está vacía.");

        return inicio!.Valor;
    }

    public void Mostrar()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        var actual = inicio;
        while (actual != null)
        {
            Console.Write($"{actual.Valor} <- ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}
