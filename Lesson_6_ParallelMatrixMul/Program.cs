const int N = 1000; // matrix size; const because this parameter will never change
// const variables are written in CAPITAL letters (e.g. const int PI)

int[,] serialMulRes = new int[N, N]; // результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N]; // результат параллельного умножения матриц


