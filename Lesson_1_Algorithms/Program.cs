/*
1. Константные (Constant): 0(1)
Once assigned a value, it remains constant for the duration of the program.
2. Логарифмические (Logarithmic): 0(log n)
Algorithms whose time complexity grows logarithmically with the size of the input. 
Examples include binary search.
3. Линейные (Linear): O(n), O(2*n)
Algorithms where the time taken increases linearly with the size of the input.
4. Линейно-логарифмические (Linearithmic): 0(n log n)
Algorithms with time complexity that is a combination of linear and logarithmic growth.
5. Квадратные (Quadratic): 0(n^2)
Algorithms whose time complexity grows quadratically with the size of the input. 
Examples include nested loops where each loop iterates over the size of the input.
6. Кубические (Cubic): 0(n^3)
Algorithms with time complexity that grows cubically with the size of the input. 
*/


// Напишите программу, которая считает сумму чисел от 1 до n.
// 1 и 3 тип алгоритма.

Console.Clear();
Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine()!), result = 0; // this one works faster
// ["345"] <- 345  Преобразовывается значение в ячейке памяти и записывается в ту же ячейку.
// By typing "!" we tell the complier that we are not going to hit enter,
// So the input won't be null. And the warning disappears.
// int n Convert.ToInt32(Console.ReadLine()); // this one works slower
// ["123"] -> 123 -> [123]  Преобразовывается значение и записывается в новую ячейку памяти.
for(int i = 1; i <= n; i++) // O(n)
    result += i;
Console.WriteLine($"Сумма чисел от 1 до {n} равна {result}");


// Console.Clear();
Console.Write("Enter a number: ");
int n2 = int.Parse(Console.ReadLine()!);
Console.WriteLine($"Сумма чисел от 1 до {n2} равна {(1 + n2) / 2 * n2}");