using Newtonsoft.Json;

using PlainTextGenModels.Maker;

namespace PlainTextGen
{

	internal class Program
	{
		static void Main(string[] args)
		{
			string json = new MakerBuilder()
				.AddTemplate(new MakerContainer
				{
					ID = Guid.NewGuid(),
					FileName = "TestTemplate",
					TargetDirectory = "Location/Root/"
				})
				.BuildJSON();

			Console.WriteLine(json);

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();

			MakerDescription description = new MakerBuilder()
				.ParseJSON(json)
				.Build();

			Console.WriteLine($"Version: {description.VersionCode}\nTemplates: {description.Data.Length}\n\n{string.Join('\n', description.Data.Select(x => $"{x.ID} -> {x.FileName} outputting to {x.TargetDirectory}"))}");
		}
	}
}
