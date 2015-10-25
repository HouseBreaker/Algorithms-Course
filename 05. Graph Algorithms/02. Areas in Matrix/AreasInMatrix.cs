using System;
using System.Collections.Generic;

namespace _02.Areas_in_Matrix
{
	class AreasInMatrix
	{
		static Stack<int> branchingCellCol = new Stack<int>();
		static Stack<int> branchingCellRow = new Stack<int>();

		static int currentAreaSize;
		static int maxAreaSize;

		static readonly char[,] matrix = {
			{'a', 'a', 'c', 'c', 'c', 'a', 'a', 'c'},
			{'b', 'a', 'a', 'a', 'a', 'c', 'c', 'c'},
			{'b', 'a', 'a', 'b', 'a', 'c', 'c', 'c'},
			{'b', 'b', 'd', 'a', 'a', 'c', 'c', 'c'},
			{'c', 'c', 'd', 'c', 'c', 'c', 'c', 'c'},
			{'c', 'c', 'd', 'c', 'c', 'c', 'c', 'c'}
		};

		static readonly int rows = matrix.GetLength(0);
		static readonly int cols = matrix.GetLength(1);

		static bool[,] visited;

		static readonly char[] chars = {'a', 'b', 'c', 'd'};

		static void Main()
		{
            visited = new bool[rows, cols];
			PrintGraphMatrix(matrix);

			//CheckMatrix(matrix, cols, rows);

			int currentArea = FindAreas(chars[0]);

			Console.WriteLine(currentArea);
		}

		static int FindAreas(char c)
		{
			int areasCount = 0;

			// todo: check if there's the same element in any direction
			// todo: if there is, traverse right down left up
			// todo: count area until every recursion goes to bottom
			// todo: add to list

			return areasCount;
		}

		private static bool HasNeighbors(int row, int col)
		{
			int currentValue = matrix[row, col];
			
			if (col + 1 < cols && matrix[row, col + 1] == currentValue &&
			    IsVisited(row, col + 1) == false) //right
			{
				return true;
			}

			if (row + 1 < rows && matrix[row + 1, col] == currentValue &&
			    IsVisited(row + 1, col) == false) //down
			{
				return true;
			}

			if (row - 1 >= 0 && matrix[row - 1, col] == currentValue &&
				IsVisited(row - 1, col) == false) //up
			{
				return true;
			}

			if (col - 1 >= 0 && matrix[row, col - 1] == currentValue &&
				IsVisited(row, col - 1) == false) //left
			{
				return true;
			}

			return false;
		}

		static bool IsVisited(int row, int col)
		{
			return visited[row, col];
		}

		public static int CheckMatrix(char[,] table, int cols, int rows)
		{
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					if (!visited[row, col] && HasNeighbors(row, col))
					{
						branchingCellCol.Push(col);
						branchingCellRow.Push(row);
						Explore(col, row);
					}
				}
			}

			return maxAreaSize;
		}


		private static void Explore(int col, int row)
		{
			int currentValue = matrix[row, col];

			while (branchingCellCol.Count > 0 && branchingCellRow.Count > 0)
			{
				col = branchingCellCol.Pop();
				row = branchingCellRow.Pop();


				int colTemp = col;
				int rowTemp = row;
				while (colTemp - 1 >= 0 && matrix[rowTemp, colTemp - 1] == currentValue &&
					IsVisited(rowTemp, colTemp - 1) == false) //left
				{
					colTemp = colTemp - 1;
					//rowTemp = rowTemp;
					branchingCellCol.Push(colTemp);
					branchingCellRow.Push(rowTemp);
					visited[rowTemp, colTemp] = true;
					currentAreaSize++;
				}

				colTemp = col;
				rowTemp = row;
				while (colTemp + 1 < cols && matrix[rowTemp, colTemp + 1] == currentValue &&
					IsVisited(rowTemp, colTemp + 1) == false)//right
				{
					colTemp = colTemp + 1;
					//rowTemp = rowTemp;
					branchingCellCol.Push(colTemp);
					branchingCellRow.Push(rowTemp);
					visited[rowTemp, colTemp] = true;
					currentAreaSize++;
				}

				colTemp = col;
				rowTemp = row;
				while (rowTemp - 1 >= 0 && matrix[rowTemp - 1, colTemp] == currentValue &&
				   IsVisited(rowTemp - 1, colTemp) == false)//up
				{
					//colTemp = colTemp;
					rowTemp = rowTemp - 1;
					branchingCellCol.Push(colTemp);
					branchingCellRow.Push(rowTemp);
					visited[rowTemp, colTemp] = true;
					currentAreaSize++;
				}

				colTemp = col;
				rowTemp = row;
				while (rowTemp + 1 < rows && matrix[rowTemp + 1, colTemp] == currentValue &&
					IsVisited(rowTemp + 1, colTemp) == false)//down
				{
					//colTemp = colTemp;
					rowTemp = rowTemp + 1;
					branchingCellCol.Push(colTemp);
					branchingCellRow.Push(rowTemp);
					visited[rowTemp, colTemp] = true;
					currentAreaSize++;
				}
			}

			if (currentAreaSize > maxAreaSize)
			{
				maxAreaSize = currentAreaSize;
			}
			currentAreaSize = 0;
		}

		static void PrintGraphMatrix(char[,] graph)
		{
			for (int row = 0; row < graph.GetLength(0); row++)
			{
				for (int col = 0; col < graph.GetLength(1); col++)
				{
					Console.Write(graph[row, col] + " ");
				}

				Console.WriteLine();
			}
		}
	}
}