/*
1. Константные (Constant): 0(1)
Algorithms that take the same amount of time regardless of the size of the input.
2. Логарифмические (Logarithmic): Algorithms whose time complexity grows logarithmically with the size of the input. Examples include binary search. Denoted as O(log n).
3. Линейные (Linear): O(n), O(2*n)
Algorithms where the time taken increases linearly with the size of the input.
4. Линейно-логарифмические (Linearithmic): Algorithms with time complexity that is a combination of linear and logarithmic growth. Denoted as O(n log n).
5. Квадратные (Quadratic): Algorithms whose time complexity grows quadratically with the size of the input. Examples include nested loops where each loop iterates over the size of the input. Denoted as O(n^2).
6. Кубические (Cubic): Algorithms with time complexity that grows cubically with the size of the input. Denoted as O(n^3).
*/


// Напишите программу, которая считает сумму чисел от 1 до n.
// 1 и 3 тип алгоритма.

Console.Clear();
Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine()!), result = 0; // this one works faster
// ["345"] <- 345  Преобразовывается значение в ячейке памяти и записывается в ту же ячейку.
// By typing "!" we tell the complier that we are not going to hit enter,
// So the input will be null. And the warning disappears.
// int n Convert.ToInt32(Console.ReadLine()); // this one works slower
// ["123"] -> 123 -> [123]  Преобразовывается значение и записывается в новую ячейку памяти.
for(int i = 1; i <= n; i++) // O(n)
    result += i;
Console.WriteLine($"Сумма чисел от 1 до {n} равна {result}");


// Continue from 30:00...
Console.Clear();
Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine()!), result = 0;