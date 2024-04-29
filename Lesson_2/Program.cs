int n = 5;
int[] array = new int[n];
// Its not neccessary to use Console.Write() before Console.Read()
for (int i = 0; i < n; i++)
    array[i] = Convert.ToInt32(Console.ReadLine());
// Syntax: string result = string.Join(separator, collection);
Console.WriteLine("[" + string.Join(" ", array) + "]");

// [x1, x2, x3, x4, x5] - our array
// [4, 5, 3, 2, 1]

Console.WriteLine("Finding a velue by index - O(1):");
// I want to find the value with the index [3]
Console.WriteLine(array[3]);
// Algorithm complexity O(1) - amount of actions needed to find the final result

Console.WriteLine("Finding the sum of the array - O(n):");
// I want to find the sum of the array
int sum = 0;
for (int i = 0; i<array.Length; i++)
    sum+= array[i];
Console.WriteLine($"The sum of the array is {sum}");
// Algorithm complexity O(n)

Console.WriteLine("Sorting an array - O(n * log(2)n):");
// I want to sort it
// [4, 5, 3, 1, 2]
int[] arraySorted = array;
Array.Sort(arraySorted);
Console.WriteLine(string.Join(" ", arraySorted));
// [1, 2, 3, 4, 5]
// Algorith complexity O(n * log2(n))

Console.WriteLine("Finding an array's sum by sorting it first - " +52
"O(n * log2(n)) + O(1)");
// I can find the sum by sorting it first, and then applying
// the math formula
// [4, 5, 3, 1, 2] -> [1, 2, 3, 4, 5]   O(n * log2(n))
// (1 + 5) / 2  O(1)
// Result: O(n * log2(n)) + O(1)