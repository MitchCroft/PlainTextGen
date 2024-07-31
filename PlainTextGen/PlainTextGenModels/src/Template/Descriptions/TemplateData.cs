using PlainTextGenModels.Interfaces;

namespace PlainTextGenModels.Template
{
	/// <summary>
	/// Defines the operational information for a template that can be generated
	/// </summary>
	/// <remarks>
	/// This corresponds to the data overrides defined in <see cref="Maker.MakerContainer"/>
	/// </remarks>
	public struct TemplateData : IUniqueElement
	{
		/// <summary>
		/// The unique ID of the template that can identify it within the system
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// The name given to this element that allows it to be displayed within the UI
		/// </summary>
		public string DisplayName;

		/// <summary>
		/// The collection of variables that have been defined for the template that can be used for the generation process
		/// </summary>
		public TemplateVariable[] Variables;

		/// <summary>
		/// The collection of template files that will be created from this template being created
		/// </summary>
		public TemplateFile[] Files;
	}
}