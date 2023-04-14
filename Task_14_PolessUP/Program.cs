int[,] matrix = { { 8, -7 }, { -10, 9 }, {1, -10 } };
Console.WriteLine("Ввод:");
GroupPrint(matrix);
Console.WriteLine("Вывод сумма:");
Console.WriteLine(MaxSumMatrix(matrix));


int MaxSumMatrix(int[,] matrix)
{
    FindCountMinusElementsInGroup(matrix, out int countminus);
    
    if (countminus % 2 == 0)
        return SumMatrix(matrix, true);

    FindIndexMinElementInGroup(matrix, out int[] indexmin);
    matrix[indexmin[0], indexmin[1]] *= -1;
    return SumMatrix(matrix);
}

void GroupPrint(int[,] group)
{
	for (int row = 0; row < group.GetLength(0); row++)
	{
		for (int column = 0; column < group.GetLength(1); column++)
		{
			Console.Write(group[row, column] + "\t");
        }
        Console.WriteLine();
    }
}

int SumMatrix(int[,] matrix, bool check = false)
{
    int sum = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            if (check && matrix[row, column] < 0)
            {
                matrix[row, column] *= -1;
            }
            sum = sum + matrix[row, column];
        }
    }
    return sum;
}

void FindCountMinusElementsInGroup(int[,] matrix, out int countminus)
{
    countminus = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            if (matrix[row, column] < 0)
            {
                countminus++;
            }
        }
    }
}

void FindIndexMinElementInGroup(int[,] matrix, out int[] indexmin)
{
    indexmin = new int[]{0,0};
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            if (matrix[row, column] < 0)
            {
                matrix[row, column] *= -1;
            }
            if (matrix[row, column] < matrix[indexmin[0], indexmin[1]])
            {
                indexmin[0] = row;
                indexmin[1] = column;
            }
        }
    }
}
