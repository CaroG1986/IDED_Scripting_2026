namespace SOLUCION_TALLER_REPASO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solución ejercicios\n");

            Ejercicio1();
            Console.WriteLine("\nPresione enter para el siguiente ejercicio");
            Console.ReadLine();
            Console.Clear();

            Ejercicio2();
            Console.WriteLine("\nPresione enter para el siguiente ejercicio");
            Console.ReadLine();
            Console.Clear();

            Ejercicio3();
            Console.WriteLine("\nPresione enter para el siguiente ejercicio");
            Console.ReadLine();
            Console.Clear();

            Ejercicio4();
            Console.WriteLine("\nPresione enter para terminar");
            Console.ReadLine();
        }
        // Ejercio 1

        static void Ejercicio1()
        {
            Console.WriteLine("Ejercicio 1\n");
            Console.Write("Ingrese el número de términos: ");
            int n = int.Parse(Console.ReadLine());


            Console.WriteLine("\nNúmeros primos en la serie de Fibonacci:");

            for (int i = 1; i <= n; i++)
            {
                long fib = Fibonacci(i);

                if (EsPrimo(fib))
                {
                    Console.Write(fib + " ");
                }
            }

        }
        static long Fibonacci(int n)
        {
            if (n == 1)
                return 0;
            if (n == 2)
                return 1;

            long a = 0;
            long b = 1;
            long resultado = 0;

            for (int i = 3; i <= n; i++)
            {
                resultado = a + b;
                a = b;
                b = resultado;
            }

            return resultado;
        }

        static bool EsPrimo(long numero)
        {
            if (numero < 2)
                return false;

            for (long i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }
        //Ejercicio 2

        static void Ejercicio2()
        {
            Console.WriteLine("Ingrese los segundos");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RegresarFormato(n));
        }

        static string RegresarFormato(int n)
        {
            int hora;
            int minuto;
            int segundo;

            if (n < 0)
            {
                return "no es posible calcualr la hora";
            }
            else
            {
                hora = n / 3600;
                minuto = (n % 3600)/60;
                segundo = (n % 3600)%60;

                return $"{hora:D2}:{minuto:D2}:{segundo:D2}";
            }
        }

        //Ejercicio 3
        static void Ejercicio3()
        {
            string numeroJugador = LeerNumero4Cifras("Ingrese su número (4 cifras): ");
            string numeroGanador = LeerNumero4Cifras("Ingrese el número ganador (4 cifras): ");
            int apuesta = LeerApuesta("Ingrese la apuesta: ");

            int premio = CalcularPremio(numeroJugador, numeroGanador, apuesta);

            if (premio > 0)
                Console.WriteLine("Ganó $" + premio);
            else
                Console.WriteLine("No ganó premio");
        }

        // Lee y valida un número de 4 cifras
        static string LeerNumero4Cifras(string mensaje)
        {
            string numero;
            do
            {
                Console.Write(mensaje);
                numero = Console.ReadLine();
            }
            while (numero.Length != 4 || !numero.All(char.IsDigit));

            return numero;
        }

        // Lee y valida la apuesta
        static int LeerApuesta(string mensaje)
        {
            int apuesta;
            do
            {
                Console.Write(mensaje);
            }
            while (!int.TryParse(Console.ReadLine(), out apuesta) || apuesta <= 0);

            return apuesta;
        }

        // Determina si el jugador ganó algo
        static bool GanoSorteo(string jugador, string ganador)
        {
            return CalcularPremio(jugador, ganador, 1) > 0;
        }

        // Calcula el premio según las reglas
        static int CalcularPremio(string jugador, string ganador, int apuesta)
        {
            // 4 cifras exactas en orden
            if (jugador == ganador)
                return apuesta * 4500;

            // 4 cifras en desorden
            if (CuatroCifrasDesorden(jugador, ganador))
                return apuesta * 200;

            // Últimas 3 cifras en orden
            if (jugador[1] == ganador[1] &&
                jugador[2] == ganador[2] &&
                jugador[3] == ganador[3])
                return apuesta * 400;

            // Últimas 2 cifras en orden
            if (jugador[2] == ganador[2] &&
                jugador[3] == ganador[3])
                return apuesta * 50;

            // Última cifra
            if (jugador[3] == ganador[3])
                return apuesta * 5;

            return 0;
        }

        // Verifica si las 4 cifras están en desorden
        static bool CuatroCifrasDesorden(string a, string b)
        {
            int contador = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i] == b[j])
                    {
                        contador++;
                        break;
                    }
                }
            }

            return contador == 4;
        }

        //Ejercicio 4

        static void Ejercicio4()
        {
            MessageManager manager = new MessageManager();
            manager.Ejecutar();
            Console.ReadKey();
        }
        // Clase abstracta
        abstract class AbstractSample
        {
            // Atributo privado
            private string message;

            public AbstractSample(string message)
            {
                this.message = message;
            }

            protected string GetMessage()
            {
                return message;
            }

            // Método abstracto
            public abstract void PrintMessage(string text);

            // Método virtual que invierte el mensaje
            public virtual string InvertMessage(string text)
            {
                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                return new string(chars);
            }
        }

        // Clase que imprime el mensaje normal
        class NormalMessage : AbstractSample
        {
            public NormalMessage(string message) : base(message) { }

            public override void PrintMessage(string text)
            {
                Console.WriteLine(text);
            }
        }

        // Clase que invierte mayúsculas y minúsculas
        class CaseInvertedMessage : AbstractSample
        {
            public CaseInvertedMessage(string message) : base(message) { }

            public override void PrintMessage(string text)
            {
                Console.WriteLine(InvertCase(text));
            }

            // Ahora SOLO invierte el texto (no cambia mayúsculas)
            public override string InvertMessage(string text)
            {
                return base.InvertMessage(text);
            }

            private string InvertCase(string text)
            {
                char[] result = new char[text.Length];

                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]))
                        result[i] = char.ToLower(text[i]);
                    else if (char.IsLower(text[i]))
                        result[i] = char.ToUpper(text[i]);
                    else
                        result[i] = text[i];
                }

                return new string(result);
            }
        }

        // Clase gestora
        class MessageManager
        {
            public void Ejecutar()
            {
                string mensaje = "Hola Mundo";

                AbstractSample normal = new NormalMessage(mensaje);
                AbstractSample invertidoCase = new CaseInvertedMessage(mensaje);

                Console.WriteLine("Mensaje normal:");
                normal.PrintMessage(mensaje);

                Console.WriteLine("\nMensaje normal con mayúsculas/minúsculas invertidas:");
                invertidoCase.PrintMessage(mensaje);

                Console.WriteLine("\nMensaje invertido:");
                normal.PrintMessage(normal.InvertMessage(mensaje));

                Console.WriteLine("\nMensaje invertido + mayúsculas/minúsculas invertidas:");
                invertidoCase.PrintMessage(invertidoCase.InvertMessage(mensaje));
            }
        }

    }

}
