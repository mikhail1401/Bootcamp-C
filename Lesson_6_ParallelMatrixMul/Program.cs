const int N = 1000; // matrix size; const because this parameter will never change
// const variables are written in CAPITAL letters (e.g. const int PI)

int[,] serialMulRes = new int[N, N]; // результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N]; // результат параллельного умножения матриц

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

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
    if (matrix1.GetLength(1) != matrix2.GetLength(0)) throw Exception("Matrices multiplication is impossible");

    else
    {
        // 2 matrices can be multipled via 3 loops:
        for (int row = 0; row < matrix1.GetLength(0); row++)
        {
            for (int column = 0; column < matrix2.GetLength(1); column++)
            {
                for (int column1OrRow2 = 0; column1OrRow2 < matrix1.GetLength(1); column1OrRow2++)
                {
                    serialMulRes[row, column] += matrix1[row, column1OrRow2] * matrix2[column1OrRow2, column];
                }
            }
        }
    }
}

// Continue from 17:50