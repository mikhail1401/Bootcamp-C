// Bubble sort - Пузырьковая сортировка

int n = 5;
int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    array[i] = Random.Shared.Next(10);
}

Console.WriteLine($"[{String.Join(", ", array)}]");

for (int k = 0; k < n - 1; k++) // Outer loop O(n-1)
    for (int i = 0; i < n - 1; i++) // Inner loop O(n-1)
    {
        if (array[i] > array[i+1])
        {
            int temp = array[i];
            array[i] = array[i+1];
            array[i+1] = temp;
        }
    }

// The total number of iterations is: (n-1) * (n-1) = (n-1)^2
// Thus, O((n-1)^2) = O(n^2 - 2n + 1)
// In Big-O notation, lower-order terms and constants are dropped
// Thus, O(n^2 - 2n + 1) -> O(n^2)

Console.WriteLine($"[{String.Join(", ", array)}]");


// We can refine the previos code

Console.WriteLine("Let's reverse it: ");
Array.Reverse(array);
Console.WriteLine($"[{String.Join(", ", array)}]");

for (int k = 0; k < n - 1; k++) // Outer loop O(n-1)
    for (int i = 0; i < n - 1 - k; i++) // Inner loop O(n-1-k)
    {
        if (array[i] > array[i+1])
        {
            int temp = array[i];
            array[i] = array[i+1];
            array[i+1] = temp;
        }
    }

//  O(n-1) * O(n-1-k)
// Need to calculate average value of k across all iterations of the outer loop
// The average value of k over (n-1) is (n-1)/2
// Thus O(n-1) * O((n-1)/2) -> O(n^2)

Console.WriteLine($"[{String.Join(", ", array)}]");