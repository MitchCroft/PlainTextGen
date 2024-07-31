using PlainTextGenModels.Interfaces;

namespace PlainTextGenModels.Template
{
	/// <summary>
	/// Store information about a variable within a template that can be used to change the output dynamically
	/// </summary>
	/// <remarks>
	/// This corresponds to the representation in <see cref="Maker.MakerVariable"/>
	/// </remarks>
	public struct TemplateVariable : IUniqueElement
	{
		/// <summary>
		/// The unique identifier that will be used for the variable that is going to be used
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// The display name of the variable that is being used
		/// </summary>
		public string DisplayName;

		/// <summary>
		/// The type of variable that corresponds to this entry
		/// </summary>
		public VariableType Type;

		/// <summary>
		/// The default value that will be used for the variable if no override is defined
		/// </summary>
		/// <remarks>
		/// This is stored as a string but differs based on the variable type where:
		///		Bool => 0/1 value indicating the default enabled state
		///		Enum => 0...n value indicating the index of the <see cref="Options"/> element assigned
		///		Replacement => The default string literal that will be inserted into the output
		/// </remarks>
		public string DefaultValue;

		/// <summary>
		/// The different options that exist for the variable
		/// </summary>
		/// <remarks>
		/// These are used for the enumeration type as labels for the selection
		/// </remarks>
		public string[] Options;
	}

	/// <summary>
	/// The different types of variables that can be included in a template file
	/// </summary>
	public enum VariableType
	{
		/// <summary>
		/// Simple true/false evaluation that can be used for tests
		/// </summary>
		Bool,

		/// <summary>
		/// Multi-select variations of labels that can be selected between
		/// </summary>
		Enum,

		/// <summary>
		/// An entry that will be replaced with a string sequence in the generated output file
		/// </summary>
		Replacement
	}
}