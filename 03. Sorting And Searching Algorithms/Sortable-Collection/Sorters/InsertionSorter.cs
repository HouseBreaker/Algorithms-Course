namespace Sortable_Collection.Sorters
{
	using System;
	using System.Collections.Generic;

	using Sortable_Collection.Contracts;

	public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
	{
		public void Sort(List<T> collection)
		{
			int currentValue, previousValue;

			for (currentValue = 1; currentValue < collection.Count; currentValue++)
			{
				T value = collection[currentValue];
				previousValue = currentValue - 1;

				while ((previousValue >= 0) && (collection[previousValue].CompareTo(value) > 0))
				{
					collection[previousValue+1] = collection[previousValue];
					previousValue--;
				}

				collection[previousValue + 1] = value;
			}
		}
	}
}
