using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Temporizador
{
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
            Console.WriteLine("1) Agregar proceso");
            Console.WriteLine("2) Mostrar procesos");
            Console.WriteLine("3) Ejecutar procesos");
            Console.WriteLine("4) Salir");

            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Duración en del proceso: ");
                if (int.TryParse(Console.ReadLine(), out int duracion) && duracion > 0)
                {
                    temporizadores.Add(new Temporizador { Duracion = duracion });
                    Console.WriteLine("Proceso agregado.");
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
                    Console.WriteLine($"{i + 1}) ({temporizadores[i].Duracion} segundos)");
                }

                Console.WriteLine("Presiona cualquier tecla para volver al menú principal");
                string seleccionStr = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(seleccionStr) || seleccionStr == "0")
                {
                    Console.WriteLine("Regresando al menú principal...");
                    continue;
                }
                else
                {
                    Console.WriteLine("Regresando al menú principal...");
                }
            }
            else if (opcion == "3")
            {
                if (temporizadores.Count == 0)
                {
                    Console.WriteLine("No hay procesos para ejecutar.");
                    continue;
                }

                Console.WriteLine("Ejecutando procesos...");
                for (int i = 0; i < temporizadores.Count; i++)
                {
                    Console.WriteLine($"\nProceso {i + 1} ({temporizadores[i].Duracion} segundos):");
                    await EjecutarCuentaRegresiva(temporizadores[i].Duracion);
                    Console.WriteLine("Proceso terminado.");
                }
            }
            else if (opcion == "4")
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
