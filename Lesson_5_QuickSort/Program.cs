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


// [7, 4, 1, 3, 5, 2, 6] -> [1, 2, 3, 4, 5, 6, 7]
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


void inputArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
        array[i] = new Random().Next(-20, 21);
}

int[] quickSort(int[] array, int leftIndex, int rightIndex)
{
    int i = leftIndex, j = rightIndex, pivot = array[leftIndex];
    while (i <= j)
    {
        while (array[i] < pivot)
        {
            i++;
        }
        while (array[j] > pivot)
        {
            j--;
        }
        if (i <= j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
            i++;
            j--;
        }
    }
    if (leftIndex < j)
        quickSort(array, leftIndex, j);

    if (i < rightIndex)
        quickSort(array, i, rightIndex);

    return array;
}

Console.Write("Enter number of elements in the array: ");
int n = int.Parse(Console.ReadLine()!);
int[] array = new int[n];

inputArray(array);
Console.WriteLine($"Initial array: [{string.Join(", ", array)}]");
Console.WriteLine($"Final array: [{string.Join(", ", quickSort(array, 0, array.Length - 1))}]");

/*
Exlanation of the quickSort() method.
array = [-8, 19, 6, 12, 15]

1: 
i = leftIndex = 0, j = rightIndex = 4, pivot = array[leftIndex] = -8
while i <= j
    while array[i] < pivot 
          array[0] < pivot
          -8  < -8  - incorrect, the loop stops here, i = 0
    while array[j] > pivot
          array[4] > pviot
          15 > -8  - correct =>  j--, j=4-1=3
          array[3] > pivot
          12 > -8  - corret => j--, j=3-1=2
          array[2] > pivot
          6 > -8  - correct => j--, j=2-1=2
          array[1] > pivot
          19 > -8  - correct => j--, j=1-1 = 0
          array[0] < pivot
          -8 < -8  - the loop stops here, j = 0
    if (i <= j)
    if (0 <= 0) - yes =>
        => array[0] swaps with array[0]
        i++, i = 0 + 1 = 1
        j--, j = 0 - 1 = -1
=> while(i<=j)
i <= j
1 <= -1  - incorret, thus the outer loop stops here

if (leftIndex < j)
if (0 < -1)  - incorrect, nothing happens

if (i < rightIndex)
    1 < 4  - correct, =>
    => quickSort(array, i, rightIndex), quickSort([-8, 19, 6, 12, 15], 1, 4)

2:
i = leftIndex = 1, j = rightIndex = 4, pivot = array[leftIndex] = 19
while i <= j
    while array[i] < pivot
          array[1] < 19
          19 < 19  - incorrect, the loop stops here, i = 1
    while array[j] > pivot
          15 > 19  - incorrect, the loop stops here, j = 4
    if (i<=j)
        1 <= 4  - correct =>
        => array[1] swaps with array[4]
        array[1] = 15, array[4] = 19
        [-8, 15, 6, 12, 19]
        i++, i = 1 + 1 = 2
        j--, j = 4 - 1 = 3
=> while i <= j
    2 <= 3  - correct, another iteration of the outer loop will happen

while i <= j
2 <= 3
    while array[i] < pivot
          array[2] < 19
          6 < 19 - correct => i++, i = 2 + 1 = 3
          array[3] < 19
          12 < 19 - correct => i++, i = 3 + 1 = 4
          array[4] < 19
          19 < 19 - incorrect, the loop stops here, i = 4
    while array[j] > pivot
          array[3] > 19
          12 > 19 - incorrect, the loop stops here, j = 3
    if (i <= j)
        4 <= 3 - incorrect, nothing happens
=> while i <= j
    4 <= 3 - incorrect, the outer loop stops here

if (leftIndex < j)
    1 < 3 - correct => 
    => quickSort(array, leftIndex, j), quickSort([-8, 15, 6, 12, 19], 1, 3)

3:
i = leftIndex = 1, j = rightIndex = 3, pivot = array[leftIndex] = 15

while i <= j
      1 <= 3 - correct
      while array[i] < pivot
            array[1] < 15
            15 < 15 - incorrect, the loop stops here
      while array[j] > pivot
            array[3] > 15
            12 > 15 - incorrect, the loop stops here
      if (i <= j)
          1 <= 3 - correct =>
          => array[1] swaps with array[3]
          array[1] = 12
          array[3] = 15
          [-8, 12, 6, 15, 19]
          i++, i = 1 + 1 = 2
          j--, j = 3 - 1 = 2
=> while i <= j
    2 <= 2 - correct, the outer loop continues

while i <= j
      2 <= 2 - correct
      while array[i] < pivot
            array[2] < pivot
            6 < 15 - correct =>
            => i++, i = 2 + 1 = 3
            array[3] < pivot
            15 < 15 - incorrect, the loop stops here
      while array[j] > pivot
            array[2] > 15
            6 > 15 - incorrect, the loop stops here
      if i <= j
         3 <= 2 - incorrect, the loop stops here
=> while i <= j
    3 <= 2 - incorrect, the outer loop stops here

if (leftIndex < j)
    1 < 2 - correct => 
    => quickSort(array, leftIndex, j), quickSort([-8, 12, 6, 15, 19], 1, 2)

4:
i = leftIndex = 1, j = rightIndex = 2, pivot = array[leftIndex] = 12

while i <= j
      1 <= 2 - correct
      while array[i] < pivot
            array[1] < 12
            12 < 12 - incorrect, the loop stops here
      while arra[j] > pivot
            array[2] > 12
            6 > 12 - incorrect, the loop stops here
      if (i <= j)
         1 <= 2 - correct =>
         => array[1] swaps with array[2]
         array[1] = 6
         array[2] = 12
         [-8, 6, 12, 15, 19]
         i++, i = 1 + 1 = 2
         j--, j = 2 - 1 = 1
=> while i <= j
    2 <= 1 - incorrect, the outer loop fails here

if (leftIndex < j)
    1 < 1 - incorrect, nothing happens

if (i < rightIndex)
    2 < 2 - incorrect, nothing happens

All the conditions have failed => return array
return [-8, 6, 12, 15, 19]   
*/
