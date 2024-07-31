namespace PlainTextGenModels.Maker
{
	/// <summary>
	/// Contain the elements about the template file that is to be created 
	/// </summary>
	/// <remarks>
	/// This corresponds to the data stored in <see cref="Template.TemplateData"/>
	/// with additional settings that dictate how the generated data should be processed
	/// </remarks>
	public struct MakerContainer
	{
		/// <summary>
		/// The ID of the template file that is to be generated with these settings
		/// </summary>
		public Guid ID;

		/// <summary>
		/// The name that has been given to the file generation process that is to be handled
		/// </summary>
		public string FileName;

		/// <summary>
		/// The root directory where the generated template files can be output relative to their requirements
		/// </summary>
		public string TargetDirectory;

		/// <summary>
		/// The collection of variables that will be overridden with new values for processing the generation
		/// </summary>
		public MakerVariable[] GlobalVariables;

		/// <summary>
		/// The collection of overrides that are to be applied to the template files contained within the template
		/// </summary>
		public MakerTemplateFile[] TemplateFileOverrides;
	}
}
