using System;
using System.Reflection;
{


    {



        Console.WriteLine("Введите количество строк треугольника:");

        int rows = Convert.ToInt32(Console.ReadLine()); 
        int i = 1; 

        while (i <= rows)
        {
            string stars = new string('*', i); 

            Console.WriteLine(stars); 

            i++;
        }

        Console.ReadLine(); 
    }

}
