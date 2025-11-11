namespace Dominio
{
    public class Restaurante
    {
        private string nit;
        private string nombre;
        private string celular;
        private string direccion;

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
            Console.WriteLine("=== INFORMACIÓN DEL RESTAURANTE ===");
            Console.WriteLine($"NIT: {Nit}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Celular: {Celular}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("===================================");
        }
    }
}
