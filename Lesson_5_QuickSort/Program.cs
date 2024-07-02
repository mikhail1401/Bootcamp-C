// Quick Sort O(n * log2(n)) - Быстрая сортировка O(n * log2(n))

// Напишите программу, которая сложит 2 числа a и b, без прямого сложения
Console.Write("Enter two numbers: ");
int[] numbers = Console.ReadLine()!.Split().Select(x => int.Parse(x)).ToArray();
int sumNumbers(int x, int y)
{
    if (x==0)
        return y;
    return sumNumbers(x-1, y+1);
}
Console.WriteLine($"Result is {numbers[0]} + {numbers[1]} = {sumNumbers(numbers[0], numbers[1])}");
