using System;
using System.Linq;

namespace _02.Combinatorial_Algorithms
{
	class Permutations
	{
		static int count;
		static int[] arr;
		static void Main()
		{
			int n = 4;
			arr = Enumerable.Range(1, n).ToArray();

			GeneratePermutations(n);
		}

		static void GeneratePermutations(int n)
		{
			if (n == 1)
			{
				Print(arr);
			}
			else
			{
				for (int i = 0; i < n-1; i++)
				{
					GeneratePermutations(n-1);

					if (n%2 == 0) //if even, swap values of arr[n-1] and arr[i]
					{
						Swap(arr[i], arr[n-1]);
					}
					else		  //if odd, swap values of the first element of arr and n-1
					{
						Swap(arr[0], arr[n - 1]);
					}
				}
				GeneratePermutations(n - 1);
            }
		}

		private static void Swap(int i1, int i2)
		{
			arr[i1] ^= arr[i2];
			arr[i2] ^= arr[i1];
			arr[i1] ^= arr[i2];
		}

		static void Print(int[] arr)
		{
			Console.WriteLine(string.Join(" ", arr));
		}
	}
}
