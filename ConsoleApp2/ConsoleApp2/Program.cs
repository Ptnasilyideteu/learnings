using System;
using System.Reflection;
{


    {



        Console.WriteLine("Введите количество строк треугольника:");

        int rows = Convert.ToInt32(Console.ReadLine()); // количество строк треугольника, введенное пользователем
        int i = 1; // переменная для отслеживания текущей строки

        while (i <= rows)
        {
            string stars = new string('*', i); // строка с символами "*"

            Console.WriteLine(stars); // вывод строки с символами "*"

            i++;
        }

        Console.ReadLine(); // чтобы консоль не закрывалась сразу
    }

}
