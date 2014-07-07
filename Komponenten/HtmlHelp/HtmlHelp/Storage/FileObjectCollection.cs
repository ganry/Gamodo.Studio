using System;
using System.Collections;

namespace HtmlHelp.Storage
{
	/// <summary>
	/// The class <c>FileObjectCollection</c> implements a colletion class for enumerated storage files
	/// </summary>
	public class FileObjectCollection : CollectionBase
	{
		/// <summary>
		/// Adds a new file object to the collection
		/// </summary>
		/// <param name="fo">file object instance to add</param>
		public void Add(FileObject fo)
		{
			base.List.Add(fo);
		}

		/// <summary>
		/// Removes a file object from the collection
		/// </summary>
		/// <param name="index">index of file object to remove</param>
		public void Remove(int index)
		{
			if (index < base.Count - 1 && index > 0)
			{
				base.List.RemoveAt(index);
			}
		}

		/// <summary>
		/// Gets the file object at a given index from the collection
		/// </summary>
		/// <param name="index">index of file object to retreive</param>
		/// <returns>Returns the file object at the given index, or null if not found.</returns>
		public FileObject Item(int index)
		{
			return (FileObject)base.List[index];
		}
	}
}
