using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> filaEspera = new Queue<string>();
        List<string> asientosOcupados = new List<string>();
        int totalAsientos = 30;

        Console.WriteLine("Simulación de asignación de asientos en una atracción.");

        while (asientosOcupados.Count < totalAsientos)
        {
            Console.WriteLine("\nJorge Diaz - Fernando Corrales - Nataly Anchundia");
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Agregar persona a la fila de espera");
            Console.WriteLine("2. Asignar asiento");
            Console.WriteLine("3. Ver estado de asientos");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine(); // Permitir valores nulos con '?'

            switch (opcion)
            {
                case "1":
                    if (asientosOcupados.Count + filaEspera.Count < totalAsientos)
                    {
                        Console.Write("Ingrese el nombre de la persona: ");
                        string? nombre = Console.ReadLine(); // Permitir valores nulos

                        if (!string.IsNullOrWhiteSpace(nombre)) // Validación de nulo o vacío
                        {
                            filaEspera.Enqueue(nombre);
                            Console.WriteLine($"{nombre} ha sido agregado a la fila de espera.");
                        }
                        else
                        {
                            Console.WriteLine("Error: No se puede agregar un nombre vacío.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Todos los asientos están ocupados. No se puede agregar más personas.");
                    }
                    break;

                case "2":
                    if (filaEspera.Count > 0 && asientosOcupados.Count < totalAsientos)
                    {
                        string persona = filaEspera.Dequeue();
                        asientosOcupados.Add(persona);
                        Console.WriteLine($"Asiento asignado a {persona}. Asientos ocupados: {asientosOcupados.Count}/{totalAsientos}");
                    }
                    else
                    {
                        Console.WriteLine("No hay personas en la fila de espera o ya no quedan asientos.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Estado de asientos ---");
                    if (asientosOcupados.Count == 0)
                    {
                        Console.WriteLine("No hay asientos ocupados aún.");
                    }
                    else
                    {
                        for (int i = 0; i < asientosOcupados.Count; i++)
                        {
                            Console.WriteLine($"Asiento {i + 1}: {asientosOcupados[i]}");
                        }
                    }
                    Console.WriteLine($"Asientos disponibles: {totalAsientos - asientosOcupados.Count}");
                    break;

                case "4":
                    Console.WriteLine("Saliendo del sistema...");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

        Console.WriteLine("\nTodos los asientos han sido ocupados. Fin de la simulación.");
    }
}
