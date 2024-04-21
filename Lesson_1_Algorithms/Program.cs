/*
1. Константные (Constant): O(1), O(2)
Once assigned a value, it remains constant for the duration of the program.
2. Логарифмические (Logarithmic): O(log n)  - Бинарный поиск
Algorithms whose time complexity grows logarithmically with the size of the input. 
Examples include binary search.
3. Линейные (Linear): O(n), O(2*n)
Algorithms where the time taken increases linearly with the size of the input.
4. Линейно-логарифмические (Linearithmic): O(n log n)   - Быстра сортировка 
Algorithms with time complexity that is a combination of linear and logarithmic growth.
5. Квадратные (Quadratic): O(n^2)   - пузырьковая сортировка, сортировка выбором, сортировка вставками
Algorithms whose time complexity grows quadratically with the size of the input. 
Examples include nested loops where each loop iterates over the size of the input.
6. Кубические (Cubic): O(n^3)
Algorithms with time complexity that grows cubically with the size of the input. 
*/


// Напишите программу, которая считает сумму чисел от 1 до n.
// 1 и 3 тип алгоритма. Константный O(1) и Линейный O(n), O(2*n)

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
Console.WriteLine($"Sum of numbers from 1 to {n} equals {result}");


Console.Clear();
Console.Write("Enter a number: ");
double n2 = int.Parse(Console.ReadLine()!); // 0(1)
Console.WriteLine($"Sum of numbers from 1 to {n2} equals {(1 + n2) / 2 * n2}");
// Or i could declare n2 as int, and divide it by "2.0" instead of "2". The result will also be double in this case.


// 2-ой тип алгоритма, Логарифмический O(log n)
// Бинарный поиск (двоичный поиск)
// Загаданное число равно 67
// Загадать чисчло от 1 до 100
// Число больше 50? - Да -> новый диапозон от 50 до 100
// Число больше 75? - Нет -> новый диапозон т 50 до 75
// Число больше 62? - Да -> новые диапозон от 62 до 75
// Число больше 68? - Нет -> новые диапозон от 62 до 68
// Число больше 65? - Да -> новые диапозон от 65 до 68
// Число больше 66? - Да -> новые диапозон от 66 до 68
// Число больше 67? - Нет -> Ответ - 67
// 7 попыток
// Сложность алгоритма бинарного поискеа равен O(log2(n))
// В алгоритме с числом от 1 до 1000 сложность будет:
// log2(1024) = 10 попыток


// 4-ой тип алгоритма, Линейно-логарифмический
// [34, 1, 2, -10, 56, 314, 13, 1, 2, 4, 90, -123, 32, 54, 652], n - кол-во элементов массива
// O(n * log2(n)) + O(log2(n))

// Быстрая сортировка 0(n * log2(n))   (Рекурисивный подход)
// [34, -10, 23, 5, 2, 1]
// 1. Выбирается опорный эелемент (в основном берется первый эелемент массива)
// 2. Создается 2 массива. 1-ый массив содержит эелементы меньше опорного,
// 2-ой массив содержит элементы больше или равные опорному.