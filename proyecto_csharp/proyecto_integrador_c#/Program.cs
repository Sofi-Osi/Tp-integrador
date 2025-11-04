using System;
using System.Collections.Generic;

class ProgramaInscripcion
{
    static void Main()
    {
        Console.WriteLine("Ingresá tu nombre: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingresá tu apellido: ");
        string apellido = Console.ReadLine();

        Console.WriteLine("Ingresá tu edad: ");
        string edad = Console.ReadLine();

        Console.WriteLine("Ingresá tu correo electrónico: ");
        string correo = Console.ReadLine();

        Console.WriteLine("\n<<<<< Datos del alumno >>>>>");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Apellido: {apellido}");
        Console.WriteLine($"Edad: {edad}");
        Console.WriteLine($"Email: {correo}");
        Console.WriteLine($"¿Los datos son correctos? - 'S' para confirmar, 'N' para cancelar ");

        string confirmacion = Console.ReadLine()?.ToUpper();

        if (confirmacion == "S")
        {
            Console.WriteLine("\n<<< Selecciona el código de la carrera elegida: >>>");
            Console.WriteLine("1. Programación .NET");
            Console.WriteLine("2. Programación Java");
            Console.WriteLine("3. Programación PHP");

            string codigoCarrera = Console.ReadLine();
            string carrera = "";
            string[] cursosDisponibles;

            switch (codigoCarrera)
            {
               case "1":
                  carrera = "Programación .NET";
                    cursosDisponibles = new string[]
                    {
                      "HTML5: Fundamentos Web",
                      "C# .NET para no programadores",
                      "Introducción a Bases de Datos y SQL",
                      "JavaScript desde cero",
                      "Introducción al Paradigma de Objetos"
                    };
                  break;
               case "2":
                  carrera = "Programación Java";
                    cursosDisponibles = new string[]
                    {
                      "Java para principiantes",
                      "Java avanzado",
                      "Java nivel senior"
                    };
                  break;
               case "3":
                  carrera = "Programación PHP";
                    cursosDisponibles = new string[]
                    {
                      "HTML5: Fundamentos Web",
                      "Introducción a Bases de Datos y SQL",
                      "JavaScript desde cero"
                    };
                   break;
            default:
                Console.WriteLine("\nCurso inexistente");
                Console.WriteLine("Datos incorrectos. Ejecutar nuevamente la aplicación.");
                return;
            }

            List<string> cursosInscritos = new List<string>();
            string seguir = "S";

            while (seguir.ToUpper() == "S")
            {
                Console.WriteLine("\n<< Cursos diponibles >>");
                for (int i = 0; i < cursosDisponibles.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {cursosDisponibles[i]}");
                }

                Console.WriteLine("Ingrese el código del curso al que desea inscribirse:");
                if (int.TryParse(Console.ReadLine(), out int codigoCurso) &&
                    codigoCurso >= 1 && codigoCurso <= cursosDisponibles.Length)
                {
                    cursosInscritos.Add(cursosDisponibles[codigoCurso - 1]);
                }
                else
                {
                    Console.WriteLine("Carrera/Curso inexistente");
                    Console.WriteLine("\nDatos incorrectos. Ejecutar nuevamente la aplicación.");
                    return;
                }

                Console.WriteLine("¿Desea seguir cargando cursos? - 'S' para confirmar, 'N' para terminar.");
                seguir = Console.ReadLine();
            }

            Console.WriteLine("\n<<< Constancia de inscripción >>>");
            Console.WriteLine($"Alumno: {nombre} {apellido}.");
            Console.WriteLine($"Correo electrónico: {correo}");
            Console.WriteLine($"Carrera: {carrera}");
            Console.WriteLine("Cursos:");
            for (int i = 0; i < cursosInscritos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cursosInscritos[i]}");
            }

            Console.WriteLine("\nPresione una tecla para finalizar...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nDatos incorrectos. Ejecutar nuevamente la aplicación.");
        }
    }
}
