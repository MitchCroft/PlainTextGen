namespace PlainTextGenModels.Maker
{
	/// <summary>
	/// A description of the different variable selection values that should be used for a template
	/// </summary>
	/// <remarks>
	/// This corresponds to the data in <see cref="Template.TemplateVariable"/>
	/// </remarks>
	public struct MakerVariable
	{
		/// <summary>
		/// The ID of the variable that these values will be applied to
		/// </summary>
		public Guid ID;

		/// <summary>
		/// The override value that will be used for determining the output 
		/// </summary>
		public string OverrideValue;
	}
}
