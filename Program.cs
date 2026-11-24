using System;
using LAB06;

namespace LAB06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Проверка работы свойств и ToString");
            Range r1 = new Range(2, 5);
            Range r2 = new Range(4, 8);

            Console.WriteLine($"Отрезок 1: { r1}");
            Console.WriteLine($"Отрезок 2: { r2}");

            Console.WriteLine("2.Проверка оператора + (Объединение)");
            Range union = r1 + r2;
            Console.WriteLine($"Объединение(r1 + r2): { union}");

            Console.WriteLine("3.Проверка оператора - (Общая часть)");
            Range intersection = r1 - r2;
            Console.WriteLine($"Пересечение(r1 - r2): { intersection}");

            Console.WriteLine("4.Проверка валидации(Ошибки)");

            try
            {
                Range badRange = new Range(10, 5); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка конструктора: { ex.Message}");
            }

            try
            {
                Range r3 = new Range(10, 15);
                Range invalidUnion = r1 + r3;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка объединения: { ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
