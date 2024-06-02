using System.Diagnostics;

// Bubble sort - Пузырьковая сортировка

// Creating a Unit test that will verify whether an array is sorted
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
int[] array2 = new int [n];
int[] array3 = new int [n];

Array.Copy(array, array1, n);
Array.Copy(array, array2, n);
Array.Copy(array, array3, n);

Console.Write("Our initial array: ");
Console.WriteLine($"[{String.Join(", ", array)}]");

// Creating a boolean to show sorted lists, 
// so we can disable it when the lists are too long
bool show = !true;

// Creating a timer
Stopwatch sw = new Stopwatch();


// I. Sorting the array - O((n-1)^2)
sw.Start();

for (int k = 0; k < n - 1; k++) // Outer loop O(n-1)   - represents number of passes
    for (int i = 0; i < n - 1; i++) // Inner loop O(n-1) - iterates over the array
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


// III. Refined algorithm. O((n-1)^2 / 2), but terminates early (once sorted)
sw.Reset();
sw.Start();

for (int k = 0; k < n - 1; k++) // each outer loop iteration represents one pass
{
    bool check = true;
    for (int i = 0; i < n - 1 - k; i++) // iterates over unsorted portion of array
    {
        if (array3[i] > array3[i+1])
        {
            check = false;
            int temp = array3[i];
            array3[i] = array3[i+1];
            array3[i+1] = temp;
        }
    }
    if (check) break; // after each pass of inner iteration the 'check' variable
    // is checked. If it's still 'true', it means that no swaps were made
    // during the pass, indicating that the array is already sorted.
    // In this case the outer loop is terminated using the 'break' statement.
}

sw.Stop();

Console.WriteLine($"Algorithm III - {Check(array3)} {sw.ElapsedMilliseconds}ms");
if (show) Console.WriteLine($"[{String.Join(", ", array3)}]");