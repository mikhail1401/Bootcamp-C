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

// Creating a locker to avoid race condition
object lock_object = new object();   // object is the base type. Its a universal type, capable of holding any kind of data.

// Creating a random array with random numbers
Random rand = new Random();
int[] array = new int[N].Select(r => rand.Next(0, 5)).ToArray();

int[] resultSerial = new int[N];
int[] resultParallel = new int[N];

Array.Copy(array, resultSerial, N);
Array.Copy(array, resultParallel, N);


void PrepareParallelCountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counter = new int[max + offset + 1];

    int eachThreadRange = N / THREADS_NUMBER;
    var threadsParallel = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadRange;
        int endPos = (i + 1) * eachThreadRange;
        if (i == THREADS_NUMBER - 1) endPos = N; // for the remainder

        // Syntax for a thread performing cerain fucntion
        threadsParallel.Add(new Thread(() => ParallelCountingSort(inputArray, counter, offset, startPos, endPos)));
        // Starting the thread
        threadsParallel[i].Start();
    }

    // To ensure that all threads comlete their work before the next step in the program is executed
    foreach(var thread in threadsParallel)
    {
        thread.Join();
    }

    // Forming a sorted array. It won't be paralleled
    int index = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}


void ParallelCountingSort(int[] inputArray, int[] counter, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (lock_object)   // Until Thread 1 is finished, Thread 2 will wait
        {
          counter[inputArray[i] + offset]++;
        }
    }
}


bool EqualityMatrix(int[] firstMatrix, int[] secondMatrix)
{
    bool result = true;

    for (int i = 0; i < N; i++)
    {
        result = result && (firstMatrix[i] == secondMatrix[i]);
    }

    return result;
}


// Regular serial Counting Sort function
void CountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counter = new int[offset + max + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counter[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counter.Length; i++)
    {
        for (int j = 0; j < counter[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}


CountingSort(resultSerial);
PrepareParallelCountingSort(resultParallel);
Console.WriteLine(EqualityMatrix(resultSerial, resultParallel));

