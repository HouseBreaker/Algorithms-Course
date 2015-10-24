using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _01.Distance_Between_Vertices
{
	class DistanceBetweenVertices
	{
		static int[] nodeNames = { 1, 2, 3, 4, 5, 6, 7, 8 };

		static List<int>[] childNodes = {
			new List<int> {3},
			new List<int> {3},
			new List<int> {3, 4},
			new List<int> {5},
			new List<int> {2, 6, 7},
			new List<int> {},
			new List<int> {7},
			new List<int> {},
		};

		static void Main()
		{
			PrintDistanceBetweenVertices(1, 6);
			PrintDistanceBetweenVertices(1, 5);
			PrintDistanceBetweenVertices(5, 6);
			PrintDistanceBetweenVertices(5, 8);
		}

		private static void PrintDistanceBetweenVertices(int startIndex, int endIndex)
		{
			Console.WriteLine("{{{0}, {1} -> {2}}}", startIndex, endIndex, BFS(startIndex, endIndex));
		}

		static int BFS(int node, int endNode)
		{
			Console.WriteLine("start nodes: " + node + " " + endNode);

			node = GetIndex(node);
			endNode = GetIndex(endNode);
			
			List<int> path = new List<int>();
			
			var nodes = new Queue<List<int>>();
			var visited = new bool[childNodes.Length];

			// Enqueue the start node to the queue
			visited[node] = true;
			path.Add(node);
			nodes.Enqueue(path);

			// Breadth-First Search (BFS)
			while (nodes.Count != 0)
			{
				List<int> currentPath = nodes.Dequeue();

				foreach (var childNode in childNodes[currentPath[0]])
				{
					if (childNode == endNode)
					{
						return currentPath.Count;
					}

					if (!visited[childNode])
					{
						var pathToEnqueue = new List<int>(currentPath);
						pathToEnqueue.Insert(0, childNode);

						nodes.Enqueue(pathToEnqueue);
						visited[childNode] = true;
					}
				}
			}
			return -1;
		}

		static int GetIndex(int node)
		{
			for (int i = 0; i < nodeNames.Length; i++)
			{
				if (nodeNames[i] == node)
				{
					return i;
				}
			}
			throw new FormatException("Couldn't find that element");
		}
	}
}