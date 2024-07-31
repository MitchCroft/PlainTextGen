namespace PlainTextGenModels.Maker
{
    /// <summary>
    /// A description of the different templates that are to be created as a part of the generation operation
    /// </summary>
	/// <remarks>
	/// This corresponds to the data in <see cref="Template.TemplateFile"/>
	/// </remarks>
    public struct MakerTemplateFile
    {
		/// <summary>
		/// The ID of the template file that these override settings will apply to
		/// </summary>
		public Guid ID;

		/// <summary>
		/// Flags if this file should be included in the generation process at all
		/// </summary>
		public bool Included;

		/// <summary>
		/// The override relative path that should be used for the file output when generated
		/// </summary>
		public string RelativePath;

		/// <summary>
		/// The override collection of variables that will be used for the specified file only
		/// </summary>
		public MakerVariable[] Variables;

		// TODO: Sections
    }
}
