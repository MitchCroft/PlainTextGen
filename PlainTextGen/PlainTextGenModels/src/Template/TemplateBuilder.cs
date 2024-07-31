using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PlainTextGenModels.Interfaces;

namespace PlainTextGenModels.Template
{
	/// <summary>
	/// Builder class that is used to parse and construct a <see cref="TemplateDescription"/> object description
	/// </summary>
	public sealed partial class TemplateBuilder
	{
		/*----------Variables----------*/
		//PRIVATE

		/// <summary>
		/// The collection of template files that will be created from this template being created
		/// </summary>
		private readonly List<TemplateFile> _files = new List<TemplateFile>();

		/// <summary>
		/// The collection of variables that will be used for handling the generation process
		/// </summary>
		private readonly List<TemplateVariable> _variables = new List<TemplateVariable>();

		/*----------Properties----------*/
		//PUBLIC

		/// <summary>
		/// The unique ID of the template that can identify it within the system
		/// </summary>
		public Guid TemplateID { get; private set; }

		/// <summary>
		/// The name given to this element that allows it to be displayed within the UI
		/// </summary>
		public string DisplayName { get; private set; }

		/// <summary>
		/// The collection of template files that are stored in the builder for processing
		/// </summary>
		public IReadOnlyList<TemplateFile> Files => _files;

		/// <summary>
		/// The collection of variables that are stored in the builder for processing
		/// </summary>
		public IReadOnlyList<TemplateVariable> Variables => _variables;

		/*----------Functions----------*/
		//PUBLIC

		/// <summary>
		/// Default constructor, base set of values
		/// </summary>
		public TemplateBuilder() 
		{
			TemplateID = Guid.Empty;
			DisplayName = string.Empty;
		}

		/// <summary>
		/// Construct this builder based on an existing template
		/// </summary>
		/// <param name="template">The template that is to be loaded into the builder for processing</param>
		public TemplateBuilder(TemplateData template) : this()
		{
			LoadFromTemplate(template);
		}

		/// <summary>
		/// Construct this builder based on an existing template
		/// </summary>
		/// <param name="container">The template that is to be loaded into the builder for processing</param>
		public TemplateBuilder(TemplateDescription container) : this() 
		{
			LoadFromTemplate(container.Data);
		}

		/// <summary>
		/// Assign an ID to contained template structure
		/// </summary>
		/// <param name="templateId">The specific ID that is to be assigned to the template</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		public TemplateBuilder WithId(Guid templateId)
		{
			TemplateID = templateId;
			return this;
		}

		/// <summary>
		/// Assign a random, unique ID to the template structure
		/// </summary>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		public TemplateBuilder WithNewId()
		{
			TemplateID = Guid.NewGuid();
			return this;
		}

		/// <summary>
		/// Assign a display name to the template structure
		/// </summary>
		/// <param name="displayName">The name that is to be assigned to the template</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		public TemplateBuilder WithName(string displayName)
		{
			DisplayName = displayName;
			return this;
		}

		/// <summary>
		/// Add a template file to the structure for use
		/// </summary>
		/// <param name="file">The file description that is to be included in the structure</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		/// <exception cref="ArgumentException">Thrown if there is an existing file with the same relative output path</exception>
		/// <remarks>
		/// Duplication of a template file is based on the <see cref="TemplateFile.DefaultRelativePath"/>, there can't be two with the same path contained
		/// </remarks>
		public TemplateBuilder WithFile(TemplateFile file)
		{
			if (_files.IndexOfElement(file.ID) != -1)
			{
				throw new ArgumentException($"[{nameof(TemplateBuilder)}] Can't add file, there is already a definition with the same Default Relative Path");
			}
			_files.Add(file);
			return this;
		}

		/// <summary>
		/// Remove a template file from the structure for use
		/// </summary>
		/// <param name="file">The file description that is to be removed from the structure</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		public TemplateBuilder WithoutFile(TemplateFile file)
		{
			int index = _files.IndexOfElement(file.ID);
			if (index != -1)
			{
				_files.RemoveAt(index);
			}
			return this;
		}

		/// <summary>
		/// Remove a template file from the structure for use
		/// </summary>
		/// <param name="index">The index of the Template File to be removed</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if the supplied index doesn't correspond to an existing Template File</exception>
		public TemplateBuilder WithoutFile(int index)
		{
			if (index < 0 || index >= _files.Count)
			{
				throw new ArgumentOutOfRangeException($"[{nameof(TemplateBuilder)}] Template File index to be removed is out of range");
			}
			_files.RemoveAt(index);
			return this;
		}

		/// <summary>
		/// Add a variable to the structure for use
		/// </summary>
		/// <param name="variable">The variable that is to be included in the structure</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		/// <exception cref="ArgumentException">Thrown if there is an existing file with the same relative output path</exception>
		public TemplateBuilder WithVariable(TemplateVariable variable)
		{
			if (_variables.IndexOfElement(variable.ID) != -1)
			{
				throw new ArgumentException($"[{nameof(TemplateBuilder)}] Can't add variable, there is already a definition with the same ID");
			}
			_variables.Add(variable);
			return this;
		}

		/// <summary>
		/// Remove a variable from the structure for use
		/// </summary>
		/// <param name="variable">The variable description that is to be added to the structure</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		public TemplateBuilder WithoutVariable(TemplateVariable variable)
		{
			int index = _variables.IndexOfElement(variable.ID);
			if (index != -1)
			{
				_variables.RemoveAt(index);
			}
			return this;
		}

		/// <summary>
		/// Remove a variable from the structure for use
		/// </summary>
		/// <param name="index">The index of the variable to be removed</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if the supplied index doesn't correspond to an existing Template File</exception>
		public TemplateBuilder WithoutVariable(int index)
		{
			if (index < 0 || index >= _variables.Count)
			{
				throw new ArgumentOutOfRangeException($"[{nameof(TemplateBuilder)}] Variable index to be removed is out of range");
			}
			_variables.RemoveAt(index);
			return this;
		}

		/// <summary>
		/// Load the values in the builder based on an existing template structure
		/// </summary>
		/// <param name="template">The template data object that is to be read in</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		public TemplateBuilder LoadFromTemplate(TemplateData template)
		{
			TemplateID = template.ID;
			DisplayName = template.DisplayName;
			_files.Clear();
			foreach (var file in template.Files)
			{
				WithFile(file);
			}
			_variables.Clear();
			foreach (var variable in template.Variables)
			{
				WithVariable(variable);
			}
			return this;
		}

		/// <summary>
		/// Recreate the collection of template files that need to be processed
		/// </summary>
		/// <param name="json">The JSON description of the data that is to be handled</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		/// /// <exception cref="JsonReaderException">The supplied JSON string was invalid and couldn't be processed</exception>
		/// <exception cref="FormatException">The supplied JSON string was missing an expected property</exception>
		/// <exception cref="ArgumentException">The supplied JSON is using an unsupported version code that can't be read</exception>
		public TemplateBuilder ParseJSON(string json)
		{
			// Get the version of the object that is to be processed
			JObject template = JObject.Parse(json);
			ushort code = template[nameof(TemplateDescription.VersionCode)]?.Value<ushort>() ??
				throw new FormatException($"[{nameof(TemplateBuilder)}] Received JSON is missing the {nameof(TemplateDescription.VersionCode)} property");

			// Determine how the data will be parsed
			switch (code)
			{
				// The latest version can always be a simple JSON parse
				case TemplateDescription.LATEST_VERSION_CODE:
					return ParseLatestVersion(template);

				// TODO: Any older versions that are being made compatible

				// Anything else is a problem we can't handle
				default: throw new ArgumentException($"[{nameof(TemplateBuilder)}] Unable to handle the parsing of a template with the version code '{code}'");
			}
		}

		/// <summary>
		/// Build the final template object that contains the values to be used
		/// </summary>
		/// <returns>Returns the compiled template object that will be used for processing</returns>
		public TemplateDescription Build()
		{
			return new TemplateDescription
			{
				VersionCode		= TemplateDescription.LATEST_VERSION_CODE,
				Data			= new TemplateData
				{
					ID			= TemplateID,
					DisplayName = DisplayName,
					Files		= _files.ToArray(),
					Variables	= _variables.ToArray(),
				}
			};
		}

		/// <summary>
		/// Build the final template object as a JSON description that can be written to disk
		/// </summary>
		/// <returns>Returns the template description as a JSON string</returns>
		public string BuildJSON()
		{
			return JsonConvert.SerializeObject(Build(), Formatting.None);
		}

		//PRIVATE

		/// <summary>
		/// Parse the supplied JSON object into the base format that can be loaded
		/// </summary>
		/// <param name="template">The template JSON object that can be read</param>
		/// <returns>Returns a reference to itself for chaining operations</returns>
		private TemplateBuilder ParseLatestVersion(JObject template)
		{
			var parsed = template.ToObject<TemplateDescription>();
			return LoadFromTemplate(parsed.Data);
		}
	}
}
