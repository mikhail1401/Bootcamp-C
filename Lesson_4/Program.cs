using System.Diagnostics;

// Bubble sort - Пузырьковая сортировка

// Creating a Unit test that will verify whethe an array is sorted
bool Check(int[] array)
{
    int size = array.Length;

    for (int i = 0; i < size - 1; i++)
    {
        if (array[i] > array[i + 1]) return false;
    }
    return true;
}

// Creating and filling an array
int n = 10000;  // Modify this number when testing the algorithms' speed
int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    array[i] = Random.Shared.Next(10);
}

// Making a few copies of the array
int[] array1 = new int [n];
int[] array2 = new int[n];

Array.Copy(array, array1, n);
Array.Copy(array, array2, n);

Console.Write("Our initial array: ");
Console.WriteLine($"[{String.Join(", ", array)}]");

// Creating a boolean to show sorted lists, so we can disble it when the lists a big
bool show = !true;

// Creating a timer
Stopwatch sw = new Stopwatch();


// I. Sorting the array - O((n-1)^2)
sw.Start();

for (int k = 0; k < n - 1; k++) // Outer loop O(n-1)
    for (int i = 0; i < n - 1; i++) // Inner loop O(n-1)
    {
        if (array1[i] > array1[i+1])
        {
            int temp = array1[i];
            array1[i] = array1[i+1];
            array1[i+1] = temp;
        }
    }

sw.Stop();
// The total number of iterations is: (n-1) * (n-1) = (n-1)^2
// Thus, O((n-1)^2) = O(n^2 - 2n + 1)
// In Big-O notation, lower-order terms and constants are dropped
// Thus, O(n^2 - 2n + 1) -> O(n^2)

Console.WriteLine($"Algorithm I - {Check(array1)} {sw.ElapsedMilliseconds}ms");
if (show) Console.WriteLine($"[{String.Join(", ", array1)}]");


// II. Refined algorithm. O((n-1)^2 / 2)
sw.Reset();
sw.Start();

for (int k = 0; k < n - 1; k++) // Outer loop O(n-1)
    for (int i = 0; i < n - 1 - k; i++) // Inner loop O(n-1-k)
    {
        if (array2[i] > array2[i+1])
        {
            int temp = array2[i];
            array2[i] = array2[i+1];
            array2[i+1] = temp;
        }
    }

sw.Stop();
//  O(n-1) * O(n-1-k)
// Need to calculate average value of k across all iterations of the outer loop
// The average value of k over (n-1) is (n-1)/2
// Thus O(n-1) * O((n-1)/2) -> O((n-1)^2 / 2) -> O(n^2)

Console.WriteLine($"Algorithm II - {Check(array2)} {sw.ElapsedMilliseconds}ms");
if (show) Console.WriteLine($"[{String.Join(", ", array2)}]");

