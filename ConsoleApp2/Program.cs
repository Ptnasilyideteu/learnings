using System;
for (int i = 1; i < 10; i++)
{
    Console.WriteLine(i);
    
}

int u = 9;

while (u > 0)
{
    Console.WriteLine(u);
    u--;
}
Console.WriteLine("Enter the number * to ээ pyramid: ");

int p = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < p; i++)
{
    Console.WriteLine();

    for (int j = 0; j <= i; j++)
    {
        Console.Write("*");
    }
}

