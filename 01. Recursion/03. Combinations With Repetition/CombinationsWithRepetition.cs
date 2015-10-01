using System;

namespace _03.Combinations_With_Repetition
{
	class CombinationsWithRepetition
	{
		static int[] loops;

		static void Main()
		{
			Console.Write("N = ");
			int n = int.Parse(Console.ReadLine());

			Console.Write("K = ");
			int k = int.Parse(Console.ReadLine());

			loops = new int[k];
			CombinationWithRepetition(0, 1, n);
		}

		static void CombinationWithRepetition(int index, int startNum, int endNum)
		{
			if (index >= loops.Length)
			{
				Console.WriteLine("(" + string.Join(" ", loops) + ")");
			}
			else
			{
				for (int i = startNum; i <= endNum; i++)
				{
					loops[index] = i;
					CombinationWithRepetition(index + 1, i, endNum);
				}
			}
		}
	}
}