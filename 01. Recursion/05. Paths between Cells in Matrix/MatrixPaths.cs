

using System;
using System.Collections.Generic;
using System.Linq;

class AllPathsInLabyrinth
{
	static int solutions = 0;
	static List<char> path = new List<char>();
	static readonly char[,] lab =
	{
		{' ', ' ', ' ', ' ', ' ', ' '},
		{' ', '*', '*', ' ', '*', ' '},
		{' ', '*', '*', ' ', '*', ' '},
		{' ', '*', 'e', ' ', ' ', ' '},
		{' ', ' ', ' ', '*', ' ', ' '},
	};

	static void Main()
	{
		FindPathToExit(0, 0, ' ');
		Console.WriteLine("Total paths found: " + solutions);
	}

	static void FindPathToExit(int row, int col, char direction)
	{
		if (!InRange(row, col))
		{
			// We are out of the labyrinth -> can't find a path
			return;
		}

		// Append the current direction to the path
		path.Add(direction);

		// Check if we have found the exit
		if (lab[row, col] == 'e')
		{
			Console.WriteLine(string.Join("", path.Skip(1))); //print path
			solutions++;
		}

		if (lab[row, col] == ' ')
		{
			// Temporary mark the current cell as visited
			lab[row, col] = 's';

			// Recursively explore all possible directions
			FindPathToExit(row, col - 1, 'L'); // left
			FindPathToExit(row, col + 1, 'R'); // right
			FindPathToExit(row - 1, col, 'U'); // up
			FindPathToExit(row + 1, col, 'D'); // down

			// Mark back the current cell as free
			lab[row, col] = ' ';
		}

		// Remove the last direction from the path
		path.RemoveAt(path.Count - 1);
	}

	static bool InRange(int row, int col)
	{
		bool rowInRange = row >= 0 && row < lab.GetLength(0);
		bool colInRange = col >= 0 && col < lab.GetLength(1);
		return rowInRange && colInRange;
	}
}
