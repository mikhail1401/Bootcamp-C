// Counting Sort O(n+k) - Сортировка подсчетом

/*
Initial array:
[0, 2, 3, 2, 1, 5, 9, 1, 1]

Lets count how many digits each index has, where index represents the digit itself:
[1, 3, 2, 1, 0, 1, 0, 0, 0, 1]

Final array:
[0, 1, 1, 1, 2, 2, 3, 5, 9]
*/

int[] array = { 0, 2, 3, 2, 1, 5, 9, 1, 1 };

void CountingSort(int[] inputArray)
{
    int[] counter = new int[10];  // массив повторений 

    for (int i = 0; i < inputArray.Length; i++)
    {
        counter[inputArray[i]]++;
    }

    int index = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            inputArray[index] = i;
            index++;
        }
    }
}

CountingSort(array);
Console.WriteLine(string.Join(", ", array));

int[] array2 = { 4, 5, 3, 2, 2, 0, 0, 0, 8, 7, 7, 3, 3, 9 };
CountingSort(array2);
Console.WriteLine(string.Join(", ", array2));


// Let's upgrade the algorithm for arrays containing numbers bigger than "9"

void CountingSortExtended(int[] inputArray)
{
    int[] counter = new int[21];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counter[inputArray[i]]++;
    }

    int index = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            inputArray[index] = i;
            index++;
        }
    }
}

int[] array3 = {20, 19, 18, 17, 6, 5, 4, 0};
CountingSortExtended(array3);
Console.WriteLine(string.Join(", ", array3));