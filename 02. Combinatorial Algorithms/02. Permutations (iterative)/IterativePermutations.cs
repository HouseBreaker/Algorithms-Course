using System;
using System.Linq;

namespace _02.Permutations__iterative_
{
	class IterativePermutations
	{
		static int countOfPermutations = 1;
		static int[] arr, manipulatedArr;

		static void Main()
		{
			Console.Write("n = ");
			int n = int.Parse(Console.ReadLine());

			arr = Enumerable.Range(1, n).ToArray();
			manipulatedArr = Enumerable.Range(0, n + 1).ToArray();

			Console.WriteLine(string.Join(" ", arr));

			int i = 1, j;

			while (i < n)
			{
				manipulatedArr[i]--;
				
				j = i%2 == 1 ? manipulatedArr[i] : 0;
				Swap(ref arr[j], ref arr[i]);
				i = 1;

				while (manipulatedArr[i] == 0)
				{

					manipulatedArr[i] = i;
					i++;
				}

				Console.WriteLine(string.Join(" ", arr));
				countOfPermutations++;
			}

			Console.WriteLine($"Total permutations: {countOfPermutations}");
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
