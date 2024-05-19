// Selection sort O(n^2) - Сортировка выбором O(n^2)

/*
Let's create an array first.
[45, 23, -10, 5, 3, 9, 1]
1. We need to find the min element.
min = -10
2. We need to swap the positions of the 1st and min elements.
[-10, 23, 45, 5, 3, 9, 1]
3. Now we're looking for the min element in the unsorted part of the array.
And then we swap with the first element of the unsorted array.
min = 1
[-10, 1, 45, 5, 3, 9, 23]
4. Repeat
min = 3
[-10, 1, 3, 5, 45, 9, 23]
5. Repeat
min = 5
Since min = 5 is the 1st element, we don't do anything.
6. Repeat
min = 9
[-10, 1, 3, 5, 9, 45, 23]
7. Repeat
min = 23
[-10, 1, 3, 5, 9, 23, 45]
8. No reason to validate the last element, because it will be the max.
*/

// Realizing it in practice using a function
int[] sortSelection(int[] array)
{
    // Standard names for loop counters are i, j, k, m, n
    for (int i = 0; i < array.Length; i++)
    {
        int indexMin = i;
        for (int j = i; j < array.Length; j++)
        {
            if (array[j] < array[indexMin])
                indexMin = j;
        }
        if (array[indexMin] == array[i])
            continue; // means go to the next iteration of the loop

        int temp = array[indexMin];
        array[indexMin] = array[i];
        array[i] = temp;
    }
    return array;
}

int[] array1 = {-10, 1, 3, 5, 9, 45, 23};
int[] array2 = sortSelection(array1);
string result = string.Join(" ", array2);
Console.WriteLine(result);
