using Fclp;
using guid_spammer.Generators;

internal class Program
{
	private static void Main(string[] args)
	{
		var parser = new FluentCommandLineParser<ApplicationArguments>();
		parser.SetupArguments();
		parser.Parse(args);

		var guidFactory = new GuidFactory();

		var unformattedGuids = guidFactory.GenerateGuids(parser.Object.Count, parser.Object.Unique);
		var formattingOptions = new GuidFormatterOptions(
			parser.Object.Uppercase,
			parser.Object.Brace,
			parser.Object.Hypenise
		);

		foreach (var guid in unformattedGuids)
		{
			var formattedGuid = guid.FormatGuid(formattingOptions);
			Console.WriteLine(formattedGuid);
		}
	}
}