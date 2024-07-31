namespace PlainTextGenModels.Interfaces
{
	/// <summary>
	/// Provide a means of identifying a unique element within the collection 
	/// of asset definitions
	/// </summary>
	public interface IUniqueElement
	{
		/// <summary>
		/// The Unique Identifier for the asset that is being referenced
		/// </summary>
		public Guid ID { get; set; }
	}

	/// <summary>
	/// Provide additional functionality to the elements that have unique identifiers
	/// </summary>
	public static class UniqueElementUtility
	{
		/// <summary>
		/// Assign a new, random ID to the supplied element for use
		/// </summary>
		/// <typeparam name="T">The type of element that is to have the new ID value assigned</typeparam>
		/// <param name="element">The element that is to be modified</param>
		/// <returns>Returns the same instance with the new ID assigned</returns>
		public static T WithRandomID<T>(this T element) where T : IUniqueElement
		{
			element.ID = Guid.NewGuid();
			return element;
		}

		/// <summary>
		/// Find the index of an element in a collection with the specified ID
		/// </summary>
		/// <typeparam name="T">The type of unique elements to be searched</typeparam>
		/// <param name="elements">The collection of unique elements to look for the matching ID</param>
		/// <param name="id">The ID of the element that is being looked for in the collection</param>
		/// <returns>Returns the index of the element with the matching ID or -1 if not found</returns>
		public static int IndexOfElement<T>(this IList<T> elements, Guid id) where T : IUniqueElement
		{
			for (int i = 0; i < elements.Count; ++i)
			{
				if (elements[i].ID == id)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
