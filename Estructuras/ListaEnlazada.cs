namespace Estructuras;

public class ListasEnlazada<T>
{
    private Nodo<T>? cabeza;
    private int contador = 0;

    public int longitud => contador;
    public bool EstaVacia() => cabeza is null;

    public void InsertarInicio(T valor)
    {
        var nuevo = new Nodo<T>(valor);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
        contador++;
    }

    public void InsertarFinal(T valor)
    {
        var nuevo = new Nodo<T>(valor);

        if (cabeza is null)
        {
            cabeza = nuevo;
        }
        else
        {
            var actual = cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;

            actual.Siguiente = nuevo;
        }
        contador++;
    }

    public bool Eliminar(Predicate<T> coincide)
    {
        if (cabeza is null) return false;

        if (coincide(cabeza.Valor))
        {
            cabeza = cabeza.Siguiente;
            contador--;
            return true;
        }

        var anterior = cabeza;
        var actual = cabeza.Siguiente;

        while (actual != null)
        {
            if (coincide(actual.Valor))
            {
                anterior.Siguiente = actual.Siguiente;
                contador--;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }

        return false;
    }
    public T? Buscar(Predicate<T> coincide)
    {
        var actual = cabeza;
        while (actual != null)
        {
            if (coincide(actual.Valor))
                return actual.Valor;

            actual = actual.Siguiente;
        }
        return default;
    }
    public void ForEach(Action<T> accion)
    {
        var actual = cabeza;
        while (actual != null)
        {
            accion(actual.Valor);
            actual = actual.Siguiente;
        }

    }

        public void Mostrar()
{
    if (cabeza == null)
    {
        Console.WriteLine("La lista está vacía.");
        return;
    }

    Nodo<T>? actual = cabeza;
    while (actual != null)
    {
        Console.Write($"{actual.Valor} -> ");
        actual = actual.Siguiente;
    }
    Console.WriteLine("null");
}

    }