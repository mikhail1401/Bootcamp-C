// Bubble sort - Пузырьковая сортировка

int n = 5;
int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    array[i] = Random.Shared.Next(10);
}

Console.WriteLine($"[{String.Join(', ', array)}]");
