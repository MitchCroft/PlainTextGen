using PlainTextGenModels.Interfaces;

namespace PlainTextGenModels.Template
{
	/// <summary>
	/// Store the information related to a single file output within a template that will be shown
	/// </summary>
	/// <remarks>
	/// This corresponds to the representation in <see cref="Maker.MakerTemplateFile"/>
	/// </remarks>
	public struct TemplateFile : IUniqueElement
	{
		/// <summary>
		/// The unique ID of the template file within the template umbrella for processing
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Flags if this template file will be included in the output by default
		/// </summary>
		/// <remarks>
		/// This path can be overriden as a part of the generation settings
		/// </remarks>
		public bool DefaultIncluded;

		/// <summary>
		/// The default, relative path to the export location where the file should be generated
		/// </summary>
		/// <remarks>
		/// This path will be able to be overriden as a part of the generation settings
		/// This path will have the name substitute process run over it
		/// </remarks>
		public string DefaultRelativePath;

		// TODO: Sections
	}
}