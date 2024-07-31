namespace PlainTextGenModels.Template
{
	/// <summary>
	/// Define the common display elements of a template that can be customised
	/// </summary>
	/// <remarks>
	/// This corresponds to the identifier used in <see cref="Maker.MakerDescription"/>
	/// </remarks>
	public struct TemplateDescription
	{
		/// <summary>
		/// The latest version code that we are up to when it comes to describing template files to be read
		/// </summary>
		public const ushort LATEST_VERSION_CODE = 1;

		/// <summary>
		/// The version of the maker description schema that is contained for processing
		/// </summary>
		public ushort VersionCode { get; internal set; }

		/// <summary>
		/// The information about the template that will be used to generate the output
		/// </summary>
		public TemplateData Data;
	}
}
