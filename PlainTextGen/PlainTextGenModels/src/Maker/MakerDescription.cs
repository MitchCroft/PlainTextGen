namespace PlainTextGenModels.Maker
{
    /// <summary>
    /// Defines the collection of settings that will be used to describe how the generation process should be handled
    /// </summary>
	/// <remarks>
	/// This corresponds to the data in <see cref="Template.TemplateDescription"/>
	/// </remarks>
    public struct MakerDescription
    {
		/// <summary>
		/// The latest version code that we are up to when it comes to describing the maker file
		/// </summary>
		public const ushort LATEST_VERSION_CODE = 1;

        /// <summary>
        /// The version of the maker description schema that is contained for processing
        /// </summary>
        public ushort VersionCode { get; internal set; }

		/// <summary>
		/// The collection of templates that are to be created during the build process
		/// </summary>
		public MakerContainer[] Data { get; internal set; }
    }
}
