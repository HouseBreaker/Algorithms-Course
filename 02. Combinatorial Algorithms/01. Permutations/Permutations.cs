using System;
using System.Linq;

namespace _02.Combinatorial_Algorithms
{
	class Permutations
	{

		static int countOfPermutations;
		static int[] arr;
		static void Main()
		{
			Console.Write("n = ");
			int n = int.Parse(Console.ReadLine());

			arr = Enumerable.Range(1, n).ToArray();
			Permute(0);

			Console.WriteLine($"Total permutations: {countOfPermutations}");
		}

		static void Permute(int index)
		{
			if (index >= arr.Length - 1)
			{
				Console.WriteLine(string.Join(" ", arr));
				countOfPermutations++;
			}
			else
			{
				for (int i = index; i < arr.Length; i++)
				{
					Swap(ref arr[index], ref arr[i]);
					Permute(index + 1);
					Swap(ref arr[index], ref arr[i]);
				}
			}
		}

		static void Swap(ref int i, ref int j)
		{
			if (i == j)
			{
				return;
			}

			i ^= j;
			j ^= i;
			i ^= j;
		}
	}
}
