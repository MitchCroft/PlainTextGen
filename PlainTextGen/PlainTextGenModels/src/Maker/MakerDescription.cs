namespace PlainTextGenModels.Maker
{
    /// <summary>
    /// Defines the collection of settings that will be used to describe how the generation process should be handled
    /// </summary>
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
		public MakerTemplate[] Templates { get; internal set; }
    }

    /// <summary>
    /// A description of the different templates that are to be created as a part of the generation operation
    /// </summary>
    public struct MakerTemplate
    {
        /// <summary>
        /// The ID of the template file that is to be generated with these settings
        /// </summary>
        public string TemplateID;

        /// <summary>
        /// The name that has been given to the file generation process that is to be handled
        /// </summary>
        public string FileName;

		/// <summary>
		/// The directory where the generated template file should be output to
		/// </summary>
		public string OutputDirectory;

		// TODO: Input variables
    }
}
