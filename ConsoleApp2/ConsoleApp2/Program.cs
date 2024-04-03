using System;
using System.Reflection;
{


    {

        

        int i = 1;
       Console.WriteLine("введите параметр треугольника");
        int rows = Convert.ToInt32(Console.ReadLine());

        while (i <= rows)
        {
            
            int j = 1;

            
            while (j <= rows - i)
            {
                Console.Write("");
                j++;
            }

            j = 1;

            
            while (j <= 2 * i - 1)
            {
                Console.Write("*");
                j++;
            }

            Console.WriteLine(); 

            i++;
        }

        Console.ReadLine(); 
    }
}
