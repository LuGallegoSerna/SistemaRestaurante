namespace Estructuras
{
    public class Pila<T>
    {
        private Nodo<T>? cima;
        private int contador = 0;

        public int Longitud => contador;

        public bool EstaVacia() => cima is null;

        public void Apilar(T valor)
        {
            Nodo<T> nuevo = new Nodo<T>(valor);
            nuevo.Siguiente = cima;
            cima = nuevo;
            contador++;
        }

        public T? Desapilar()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La pila está vacía.");

            T valor = cima!.Valor;
            cima = cima.Siguiente;
            contador--;
            return valor;
        }

        public T? Cima()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La pila está vacía.");

            return cima!.Valor;
        }

        public void Mostrar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La pila está vacía.");
                return;
            }

            Nodo<T>? actual = cima;
            while (actual != null)
            {
                Console.Write($"{actual.Valor} -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }
    }
}
