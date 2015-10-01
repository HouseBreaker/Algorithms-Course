using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tower_of_Hanoi
{
	class TowerOfHanoi
	{
		static int numberOfDisks = 5;
		static int stepsTaken = 0;

		static Stack<int> sourceRod = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
		static Stack<int> destinationRod = new Stack<int>();
		static Stack<int> spareRod = new Stack<int>();

		static void Main()
		{
			//Console.Write("N = ");
			//numberOfDisks = int.Parse(Console.ReadLine());

			sourceRod = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
			PrintRods();

			MoveDisks(numberOfDisks, sourceRod, destinationRod, spareRod);
		}

		static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
		{
			if (bottomDisk == 1)
			{
				stepsTaken++;
				destination.Push(source.Pop());
				Console.WriteLine($"Step {stepsTaken}: moved disk {destination.Peek()}");
				PrintRods();
			}
			else
			{
				MoveDisks(bottomDisk - 1, source, spare, destination);

				// only way i found that works
				stepsTaken++;
				destination.Push(source.Pop());
				Console.WriteLine($"Step {stepsTaken}: moved disk {destination.Peek()}");
				PrintRods();

				MoveDisks(bottomDisk - 1, spare, destination, source);
			}
		}

		static void PrintRods()
		{
			Console.WriteLine("Source: {0}", string.Join(", ", sourceRod.Reverse()));
			Console.WriteLine("Destination: {0}", string.Join(", ", destinationRod.Reverse()));
			Console.WriteLine("Spare: {0}", string.Join(", ", spareRod.Reverse()));
			Console.WriteLine();
		}
	}
}