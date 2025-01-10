using System;

class Program
{
    // Definición del struct para almacenar información de un contacto
    struct Contacto
    {
        public string Nombre;
        public string Telefono;
    }

    static void Main(string[] args)
    {
        // Vector para almacenar los contactos
        Contacto[] agenda = new Contacto[100]; // Capacidad de 100 contactos
        int cantidadContactos = 0; // Número actual de contactos en la agenda

        while (true)
        {
            Console.WriteLine("\n=== Agenda Telefónica de Jorge Dìaz y Fernando Corrales===");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Consultar contacto por nombre");
            Console.WriteLine("3. Listar todos los contactos");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;
            switch (opcion)
            {
                case "1":
                    AgregarContacto(ref agenda, ref cantidadContactos);
                    break;
                case "2":
                    ConsultarContacto(agenda, cantidadContactos);
                    break;
                case "3":
                    ListarContactos(agenda, cantidadContactos);
                    break;
                case "4":
                    Console.WriteLine("Saliendo de la agenda...");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }

    static void AgregarContacto(ref Contacto[] agenda, ref int cantidadContactos)
    {
        if (cantidadContactos >= agenda.Length)
        {
            Console.WriteLine("La agenda está llena. No se pueden agregar más contactos.");
            return;
        }

        Contacto nuevoContacto;

        Console.Write("Ingrese el nombre: ");
        nuevoContacto.Nombre = Console.ReadLine() ?? string.Empty;
        Console.Write("Ingrese el teléfono: ");
        nuevoContacto.Telefono = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(nuevoContacto.Nombre) || string.IsNullOrWhiteSpace(nuevoContacto.Telefono))
        {
            Console.WriteLine("El nombre y el teléfono no pueden estar vacíos.");
            return;
        }

        agenda[cantidadContactos] = nuevoContacto;
        cantidadContactos++;

        Console.WriteLine("Contacto agregado exitosamente.");
    }

    static void ConsultarContacto(Contacto[] agenda, int cantidadContactos)
    {
        Console.Write("Ingrese el nombre del contacto a buscar: ");
        string nombreBuscado = Console.ReadLine() ?? string.Empty;

        bool encontrado = false;
        for (int i = 0; i < cantidadContactos; i++)
        {
            if (agenda[i].Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nContacto encontrado:");
                Console.WriteLine($"Nombre: {agenda[i].Nombre}");
                Console.WriteLine($"Teléfono: {agenda[i].Telefono}");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    static void ListarContactos(Contacto[] agenda, int cantidadContactos)
    {
        if (cantidadContactos == 0)
        {
            Console.WriteLine("La agenda está vacía.");
            return;
        }

        Console.WriteLine("\nListado de contactos:");
        for (int i = 0; i < cantidadContactos; i++)
        {
            Console.WriteLine($"\nContacto {i + 1}:");
            Console.WriteLine($"Nombre: {agenda[i].Nombre}");
            Console.WriteLine($"Teléfono: {agenda[i].Telefono}");
        }
    }
}
