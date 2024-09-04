// Race Condition in Parallel computing

/* Let's review a possible race condition while performing a counting sort
{0, 1, 2, 5, | 1, 1, 3, 6}
 1st Thread    2nd Thread

The same counters array will be used by both threads.
counters = [0] [1] [2] [3] [4] [4] [6]
1st loop    1   1
2nd loop       1+1 (from both Threads at the same time. This is a Race Condition)

In order to avoid a Race Condition, in .NET platform we can use 
a SYNCHRONIZATION PRIMITIVE called 'lock'.
With the 'lock', the 2nd thread will wait for the 1 thread to finish updating the counters array,
and only after that will it proceed to make its own update. */

// We are going to use the Counting Sort algorithm as an example


const int THREADS_NUMBER = 4;   // число потоков
const int N = 100000;   // размер массива

// Creating a random array with random numbers
Random rand = new Random();
int[] arr = new int[N].Select(r => rand.Next(0, 5)).ToArray();


int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};

int[] CountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int[] sortedArray = new int[inputArray.Length];

    int offset = 0 - min; // 10
    int[] counter = new int[offset + max + 1]; // 16

    for (int i = 0; i < inputArray.Length; i++)
    {
        counter[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            sortedArray[index] = i - offset;
            index++;
        }
    }

    return sortedArray;
}

// Continue from 19:00


