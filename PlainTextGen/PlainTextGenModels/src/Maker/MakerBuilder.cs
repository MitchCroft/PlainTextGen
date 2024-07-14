using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlainTextGenModels.Maker
{
	/// <summary>
	/// Builder class that is used to compile the list of templates that are to be created
	/// </summary>
	public sealed class MakerBuilder
	{
		/*----------Variables----------*/
		//PRIVATE

		/// <summary>
		/// Store the collection of templates that are being requested to be constructed
		/// </summary>
		private readonly List<MakerTemplate> _templates = new List<MakerTemplate>();

		/*----------Functions----------*/
		//PUBLIC

		/// <summary>
		/// Add a defined template description to the collection of elements that are to be built
		/// </summary>
		/// <param name="template">The template asset that is to be created</param>
		/// <returns>Returns a reference to itself so that instructions can be chained</returns>
		public MakerBuilder AddTemplate(MakerTemplate template)
		{
			_templates.Add(template);
			return this;
		}

		/// <summary>
		/// Recreate the collection of template description objects that need to be processed
		/// </summary>
		/// <param name="json">The JSON description of the data that is to be handled</param>
		/// <returns>Returns a reference to itself so that instructions can be chained</returns>
		/// <exception cref="JsonReaderException">The supplied JSON string was invalid and couldn't be processed</exception>
		/// <exception cref="FormatException">The supplied JSON string was missing an expected property</exception>
		/// <exception cref="ArgumentException">The supplied JSON is using an Unsupported version code that can't be read</exception>
		public MakerBuilder ParseJSON(string json)
		{
			// Get the type of object that is to be processed
			JObject description = JObject.Parse(json);
			ushort code = description[nameof(MakerDescription.VersionCode)]?.Value<ushort>() ??
				throw new FormatException($"Received JSON is missing the {nameof(MakerDescription.VersionCode)} property");

			// Determine how the data will be parsed
			switch (code)
			{
				// The latest version can always be a simple JSON parse
				case MakerDescription.LATEST_VERSION_CODE:
					return ParseLatestVersion(description);

				// TODO: Any older versions that are being made compatible

				// Anything else is a problem we can't handle
				default: throw new ArgumentException($"Unable to handle the parsing of a description with the version code '{code}'");
			}
		}

		/// <summary>
		/// Build the final description object that contains the values to be processed
		/// </summary>
		/// <returns>Returns the compiled description that will be used for processing</returns>
		public MakerDescription Build()
		{
			return new MakerDescription
			{
				VersionCode = MakerDescription.LATEST_VERSION_CODE,
				Templates	= _templates.ToArray()
			};
		}

		/// <summary>
		/// Build the final description object as a JSON description that can be written to disk
		/// </summary>
		/// <returns>Returns the build description as a JSON string</returns>
		public string BuildJSON()
		{
			return JsonConvert.SerializeObject(Build(), Formatting.None);
		}

		//PRIVATE

		/// <summary>
		/// Parse the latest version of the 
		/// </summary>
		/// <param name="description">The parsed JSON object that is to be deserialised into a format that can be used</param>
		/// <returns>Returns a reference to itself so that instructions can be chained</returns>
		/// <exception cref="JsonReaderException">The supplied JSON string was invalid and couldn't be processed</exception>
		/// <exception cref="FormatException">The supplied JSON string was missing an expected property</exception>
		private MakerBuilder ParseLatestVersion(JObject description)
		{
			// We need the template descriptions from the object
			JToken templatesObj = description[nameof(MakerDescription.Templates)] ??
				throw new FormatException($"Received JSON is missing the {nameof(MakerDescription.Templates)} property");

			// Parse the data that we need
			MakerTemplate[]? templates = templatesObj.ToObject<MakerTemplate[]>();
			if (templates is not null)
			{
				_templates.AddRange(templates);
			}
			return this;
		}
	}
}
