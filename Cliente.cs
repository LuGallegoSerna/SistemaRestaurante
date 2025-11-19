namespace Dominio
{
    public class Cliente
    {
        private string cedula = string.Empty;
        private string nombreCompleto = string.Empty;
        private string celular = string.Empty;

        public string Cedula
        {
            get => cedula;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La cédula no puede estar vacía.");
                cedula = value;
            }
        }

        public string NombreCompleto
        {
            get => nombreCompleto;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombreCompleto = value;
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

        public Cliente(string cedula, string nombreCompleto, string celular)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
            Celular = celular;
        }

        public override string ToString()
        {
            return $"{Cedula} - {NombreCompleto} - {Celular}";
        }

        public void MostrarInfo()
        {
            Console.WriteLine("=== CLIENTE ===");
            Console.WriteLine($"Cédula: {Cedula}");
            Console.WriteLine($"Nombre: {NombreCompleto}");
            Console.WriteLine($"Celular: {Celular}");
            Console.WriteLine("==========================");
        }
    }
}
