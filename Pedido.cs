using Estructuras;

namespace Dominio
{
    public class PlatoPedido
    {
        private string codigoPlato = string.Empty;
        private int cantidad;
        private decimal precioUnitario;

        public string CodigoPlato
        {
            get => codigoPlato;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El código del plato no puede estar vacío.");
                codigoPlato = value;
            }
        }

        public int Cantidad
        {
            get => cantidad;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor que cero.");
                cantidad = value;
            }
        }

        public decimal PrecioUnitario
        {
            get => precioUnitario;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio unitario debe ser mayor que cero.");
                precioUnitario = value;
            }
        }

        public decimal Subtotal => Cantidad * PrecioUnitario;

        public PlatoPedido(string codigoPlato, int cantidad, decimal precioUnitario)
        {
            CodigoPlato = codigoPlato;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public override string ToString()
        {
            return $"{Cantidad} x {CodigoPlato} (unitario {PrecioUnitario:C}) = {Subtotal:C}";
        }
    }

    public class Pedido
    {
        private static int ultimoId = 0;

        private int idPedido;
        private string cedulaCliente = string.Empty;
        private readonly ListasEnlazada<PlatoPedido> platos = new ListasEnlazada<PlatoPedido>();
        private decimal total = 0;
        private DateTime fechaHora;
        private string estado = "PENDIENTE";

        public int IdPedido => idPedido;

        public string CedulaCliente
        {
            get => cedulaCliente;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La cédula del cliente no puede estar vacía.");
                cedulaCliente = value;
            }
        }

        public ListasEnlazada<PlatoPedido> Platos => platos;

        public decimal Total => total;

        public DateTime FechaHora => fechaHora;

        public string Estado
        {
            get => estado;
            set
            {
                if (value != "PENDIENTE" && value != "DESPACHADO")
                    throw new ArgumentException("El estado debe ser 'PENDIENTE' o 'DESPACHADO'.");
                estado = value;
            }
        }

        public Pedido(string cedulaCliente)
        {
            idPedido = ++ultimoId;
            CedulaCliente = cedulaCliente;
            fechaHora = DateTime.Now;
            estado = "PENDIENTE";
        }

        public void AgregarPlato(Plato plato, int cantidad)
        {
            if (plato is null)
                throw new ArgumentNullException(nameof(plato));

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            var item = new PlatoPedido(plato.Codigo, cantidad, plato.Precio);
            platos.InsertarInicio(item);

            total += item.Subtotal;
        }

        public void MarcarDespachado()
        {
            Estado = "DESPACHADO";
        }

        public void MostrarInfo()
        {
            Console.WriteLine("=== PEDIDO ===");
            Console.WriteLine($"Id: {IdPedido}");
            Console.WriteLine($"Cédula cliente: {CedulaCliente}");
            Console.WriteLine($"Fecha/hora: {FechaHora}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine("Platos del pedido:");
            platos.Mostrar();
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine("==========================");
        }
    }
}
