using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Temporizador
{
    public string Nombre { get; set; }
    public int Duracion { get; set; }
}

class Program
{
    static List<Temporizador> temporizadores = new List<Temporizador>();

    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1) Agregar temporizador");
            Console.WriteLine("2) Mostrar y ejecutar temporizador");
            Console.WriteLine("3) Salir");

            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Nombre del temporizador: ");
                string nombre = Console.ReadLine();

                Console.Write("Duración en segundos: ");
                if (int.TryParse(Console.ReadLine(), out int duracion) && duracion > 0)
                {
                    temporizadores.Add(new Temporizador { Nombre = nombre, Duracion = duracion });
                    Console.WriteLine("Temporizador agregado.");
                }
                else
                {
                    Console.WriteLine("Duración inválida.");
                }
            }
            else if (opcion == "2")
            {
                if (temporizadores.Count == 0)
                {
                    Console.WriteLine("No hay temporizadores disponibles.");
                    continue;
                }

                Console.WriteLine("Temporizadores:");
                for (int i = 0; i < temporizadores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {temporizadores[i].Nombre} ({temporizadores[i].Duracion} segundos)");
                }

                Console.WriteLine("0) Volver al menú principal");
                Console.Write("Selecciona un temporizador (número): ");
                string seleccionStr = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(seleccionStr) || seleccionStr == "0")
                {
                    Console.WriteLine("Regresando al menú principal...");
                    continue;
                }

                if (int.TryParse(seleccionStr, out int seleccion) &&
                    seleccion >= 1 && seleccion <= temporizadores.Count)
                {
                    var temporizador = temporizadores[seleccion - 1];
                    Console.WriteLine($"\nIniciando temporizador: {temporizador.Nombre}");

                    await EjecutarCuentaRegresiva(temporizador.Duracion);

                    Console.WriteLine("Temporizador finalizado.\n");
                }
                else
                {
                    Console.WriteLine("Selección no válida. Regresando al menú principal...");
                }
            }
            else if (opcion == "3")
            {
                Console.WriteLine("Programa finalizado");
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }

    static async Task EjecutarCuentaRegresiva(int duracion)
    {
        for (int i = duracion; i > 0; i--)
        {
            Console.WriteLine($"{i} segundos...");
            await Task.Delay(1000);
        }
    }
}
