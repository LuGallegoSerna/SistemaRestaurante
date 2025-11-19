namespace Dominio
{
    public class Plato
    {
        private string codigo = string.Empty;
        private string nombre = string.Empty;
        private string descripcion = string.Empty;
        private decimal precio = 0;

        public string Codigo
        {
            get => codigo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El código no puede estar vacío.");
                codigo = value;
            }
        }

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del plato no puede estar vacío.");
                nombre = value;
            }
        }

        public string Descripcion
        {
            get => descripcion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La descripción no puede estar vacía.");
                descripcion = value;
            }
        }

        public decimal Precio
        {
            get => precio;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio debe ser mayor que cero.");
                precio = value;
            }
        }

        public Plato(string codigo, string nombre, string descripcion, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }

        public void MostrarInfo()
        {
            Console.WriteLine("=== PLATO ===");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Precio: {Precio:C}");
            Console.WriteLine("==========================");
        }
    }
}

