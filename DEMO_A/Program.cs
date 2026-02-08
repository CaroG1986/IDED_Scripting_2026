using System;

class Program
{
    static void Main()
    {
        // Crear el arreglo de tamaño 4
        int[] numeros = new int[4];

        // Asignar valores
        numeros[0] = 10;
        numeros[1] = 20;
        numeros[2] = 30;
        numeros[3] = 40;

        // Acceder a la última posición (posición n)
        int ultimo = numeros[4];

        Console.WriteLine("El último elemento del arreglo es: " + ultimo);
    }
}
