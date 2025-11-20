using Estructuras;

namespace Dominio
{
    public class Restaurante
    {
        private string nit = string.Empty;
        private string nombre = string.Empty;
        private string celular = string.Empty;
        private string direccion = string.Empty;

        private readonly ListasEnlazada<Cliente> clientes = new ListasEnlazada<Cliente>();
        private readonly ListasEnlazada<Plato> platos = new ListasEnlazada<Plato>();

        private readonly Cola<Pedido> pedidosPendientes = new Cola<Pedido>();
        private readonly Pila<Pedido> historialPedidos = new Pila<Pedido>();

        private decimal gananciasHoy = 0;
        public decimal GananciasHoy => gananciasHoy;

        public string Nit
        {
            get => nit;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El NIT no puede estar vacío.");
                nit = value;
            }
        }

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string Celular
        {
            get => celular;
            set
            {
                if (value.Length != 10 || !value.All(char.IsDigit))
                    throw new ArgumentException("El celular debe tener exactamente 10 dígitos numéricos.");
                celular = value;
            }
        }

        public string Direccion
        {
            get => direccion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La dirección no puede estar vacía.");
                direccion = value;
            }
        }

        public Restaurante(string nit, string nombre, string celular, string direccion)
        {
            Nit = nit;
            Nombre = nombre;
            Celular = celular;
            Direccion = direccion;
        }

        public void MostrarInfo()
        {
            Console.WriteLine("=== RESTAURANTE ===");
            Console.WriteLine($"NIT: {Nit}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Celular: {Celular}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("===================");
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            clientes.InsertarInicio(cliente);
        }

        public void ListarClientes()
        {
            Console.WriteLine("=== CLIENTES DEL RESTAURANTE ===");
            clientes.Mostrar();
        }

        public void AgregarPlato(Plato plato)
        {
            if (plato is null)
                throw new ArgumentNullException(nameof(plato));

            platos.InsertarInicio(plato);
        }

        public void ListarPlatos()
        {
            Console.WriteLine("=== MENÚ DEL RESTAURANTE ===");
            platos.Mostrar();
        }

       public Plato? BuscarPlato(string codigo)
        {
            return platos.Buscar(p => p.Codigo == codigo);
        }


        public void TomarPedido(Pedido pedido)
        {
            if (pedido is null)
                throw new ArgumentNullException(nameof(pedido));

            pedidosPendientes.Encolar(pedido);
        }

        public void ListarPedidosPendientes()
        {
            Console.WriteLine("=== PEDIDOS PENDIENTES ===");
            pedidosPendientes.Mostrar();
        }

        public void DespacharPedido()
        {
            if (pedidosPendientes.EstaVacia())
            {
                Console.WriteLine("No hay pedidos pendientes.");
                return;
            }

            Pedido pedido = pedidosPendientes.Desencolar();
            pedido.MarcarDespachado();

            gananciasHoy += pedido.Total;

            historialPedidos.Apilar(pedido);

            Console.WriteLine($"Pedido {pedido.IdPedido} despachado correctamente.");
        }

        public void MostrarHistorialPedidos()
        {
            Console.WriteLine("=== HISTORIAL DE PEDIDOS DESPACHADOS ===");
            historialPedidos.Mostrar();
        }
    }
}





