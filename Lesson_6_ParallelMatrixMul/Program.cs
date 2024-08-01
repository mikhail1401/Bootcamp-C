const int N = 11; // matrix size; const because this parameter will never change
const int THREADS_NUMBER = 4; // задаем кол-во потоков
// const variables are written in CAPITAL letters (e.g. const int PI)

int[,] serialMulRes = new int[N, N]; // результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N]; // результат параллельного умножения матриц

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMultiplication(firstMatrix, secondMatrix);
PrepareParallelMatrixMultiplication(firstMatrix, secondMatrix);
Console.WriteLine(EquilityMatrix(serialMulRes, threadMulRes));

int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    if (matrix1.GetLength(1) != matrix2.GetLength(0)) throw new Exception("Matrices multiplication is impossible");

    // 2 matrices can be multipled via 3 loops:
    for (int row = 0; row < matrix1.GetLength(0); row++)
    {
        for (int column = 0; column < matrix2.GetLength(1); column++)
        {
            for (int column1OrRow2 = 0; column1OrRow2 < matrix2.GetLength(0); column1OrRow2++)
            {
                serialMulRes[row, column] += matrix1[row, column1OrRow2] * matrix2[column1OrRow2, column];
            }
        }
    }
}

void PrepareParallelMatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    if (matrix1.GetLength(1) != matrix2.GetLength(0)) throw new Exception("Matrices multiplication is impossible");

    int eachThreadNumber = N / THREADS_NUMBER; // сколько вычислений будет приходиться на каждый поток
    var threadsList = new List<Thread>(); // this is a dynamic version of an array
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadNumber;
        int endPos = (i + 1) * eachThreadNumber;
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsList.Add(new Thread(() => ParallelMatrixMultiplication(matrix1, matrix2, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
}

void ParallelMatrixMultiplication(int[,] matrix1, int[,] matrix2, int startPos, int endPos)
{
    for (int row = startPos; row < endPos; row++)
    {
        for (int column = 0; column < matrix2.GetLength(1); column++)
        {
            for (int column1OrRow2 = 0; column1OrRow2 < matrix2.GetLength(0); column1OrRow2++)
            {
                threadMulRes[row, column] += matrix1[row, column1OrRow2] * matrix2[column1OrRow2, column];
            }
        }
    }
}

bool EquilityMatrix(int[,] matrix1, int[,] matrix2)
{
    bool result = true;

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            result = result && (matrix1[i, j] == matrix2[i, j]);
        }
    }

    return result;
}
