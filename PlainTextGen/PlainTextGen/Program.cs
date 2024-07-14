using Newtonsoft.Json;

using PlainTextGenModels.Maker;

namespace PlainTextGen
{

	internal class Program
	{
		static void Main(string[] args)
		{
			string json = new MakerBuilder()
				.AddTemplate(new MakerTemplate
				{
					TemplateID = "TestTemplateID",
					FileName = "TestTemplate",
					OutputDirectory = "Location/Root/"
				})
				.BuildJSON();

			Console.WriteLine(json);

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();

			MakerDescription description = new MakerBuilder()
				.ParseJSON(json)
				.Build();

			Console.WriteLine($"Version: {description.VersionCode}\nTemplates: {description.Templates.Length}\n\n{string.Join('\n', description.Templates.Select(x => $"{x.TemplateID} -> {x.FileName} outputting to {x.OutputDirectory}"))}");
		}
	}
}
