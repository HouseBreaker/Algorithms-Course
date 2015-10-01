using System;

namespace _02.Nested_Loops_To_Recursion
{
	class NestedLoopsToRecursion
	{
		static int n;
		static int[] loops;

		static void Main()
		{
			Console.Write("N = ");
			n = int.Parse(Console.ReadLine());

			loops = new int[n];
			NestedLoops(0);
		}

		static void NestedLoops(int current)
		{
			if (current == n)
			{
				Console.WriteLine(string.Join(" ", loops)); //print loops
				return;
			}

			for (int i = 1; i <= n; i++)
			{
				loops[current] = i;
				NestedLoops(current+1);
			}
		}
	}
}