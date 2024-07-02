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


// [7, 4, 1, 3, 5, 2, 6] - [1, 2, 3, 4, 5, 6, 7]
// pivot = 7 - берется опорный элемент
// массив с элементами меньше опорного + опорный элемент + массив с элементаи больше или равными опорному
// [4, 1, 3, 5, 2, 6] + [7] + []
// Дальше работаем с этими двумя массивами (слева и справа от опрного элемента)
// pivot = 4
// [1, 3, 2] + [4] + [5, 6]
// pivot = 1
// [] + [1] + [3, 2]
// pivot = 5
// [] + [5] + [6]
// pivot = 3
// [2] + [3] + []


int[] inputArray(int[] array)
{
    for (int i = 0; i < array.GetLength; i++)
        array[i] = new Random().Next(-20; 21);
    return array;
}

Console.Write("Enter number of elements in the array: ");
int n = int.Parse(Console.ReadLine()!);
int[] array = new int[n];

// From 24:30
