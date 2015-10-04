using System;
using System.Linq;

namespace _04.Generate_Subsets_of_String_Array
{
	class StringSubset
	{


		static int[] loops;
		static string[] input = {"test", "rock", "fun"};

		static void Main()
		{
			Console.WriteLine($"String array: {{{string.Join(", ", input)}}}");

			Console.Write("k = ");
			int k = int.Parse(Console.ReadLine());

			loops = new int[k];

			CombinationWithRepetition(0, 1, input.Length);
		}

		static void CombinationWithRepetition(int index, int startNum, int endNum)
		{
			if (index >= loops.Length)
			{
				Console.WriteLine("(" + string.Join(" ", loops.Select(n => input[n-1])) + ")");
			}
			else
			{
				for (int i = startNum; i <= endNum; i++)
				{
					loops[index] = i;
					CombinationWithRepetition(index + 1, i + 1, endNum);
				}
			}
		}
	}
}