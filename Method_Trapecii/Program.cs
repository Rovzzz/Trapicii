using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Trapecii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Начальные данные
            Console.WriteLine("Метод трапеций");
            Console.WriteLine();
            double a = 2;
            Console.WriteLine($"Нижняя граница интергирования: {a}");
            double b = 3.2;
            Console.WriteLine($"Верхняя граница интегрирования: {b}");
            int n = 10;
            Console.WriteLine($"Количество частей для разбиения отрезка: {n}");
            int r = n;
            double x0 = a;
            double h = (b-a)/n;
            Console.WriteLine($"Шаг интегрирования: {h}");
            double f;
            double y2;
            // Число, которое изменяет индекс массива "d и d2".
            int k = 0;
            //массив для нахождения функции на заданном отрезке 
            double [] d = new double [(int)n+4];
            Console.WriteLine();
            //Нахождение функции
            for (int i = 0; i <= n+3; i++)
            {
                f = (1/Math.Pow(x0,2)*Math.Log(x0+1));                                 
                d[k] = f; 
                k++; 
                Console.WriteLine("| "+ i + "\t|" + x0 + "\t|" + f + "\t|");
                x0 += h; 
            }
            //Формула трапеции
            Console.WriteLine();
            Console.WriteLine("Формула трапеции");
            double t = (b - a) / (2 * r) * (d[0] + d[10] + 2 * (d[1]+d[2]+d[3]+d[4]+d[5]+d[6]+d[7]+d[8]+d[9]));
            Console.WriteLine("Ответ: " + t);
            Console.WriteLine();
            // массив для нахождения второй производной y"
            double[] d2 = new double[(int)n+2];
            k = 0;
            //Нахождение y''
            for (int i = 0; i <= n; i++)
            {                
                y2 = Math.Abs((1 / Math.Pow(h, 2)) * (2 * d[k] - 5 * d[k+1] + 4 * d[k+2] - d[k+3]));
                d2[k] = y2;
                k++;
                Console.WriteLine("| " + y2 + "\t|");
            }
            Console.WriteLine();
            //Максимальное значение y''
            Console.WriteLine("Максимальное значение y'': " + d2.Max());
            Console.WriteLine();
            //Погрешность
            double R = (Math.Pow((b - a), 3) / (12 * Math.Pow(n, 2))) * d2.Max();
            Console.WriteLine("Погрешность: " + R);
            Console.ReadKey();
        }
    }
}
