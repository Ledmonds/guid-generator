using Fclp;

internal class Program
{
	private static void Main(string[] args)
	{
		var parser = new FluentCommandLineParser<ApplicationArguments>();
		parser.SetupArguments();
		parser.Parse(args);

		var guidFactory = new GuidFactory();
		var guidFormatter = new GuidFormatter();

		var guids = guidFactory.GenerateGuids(parser.Object.Count, parser.Object.Unique);
		var formattedGuids = guidFormatter.FormatGuids(
			guids,
			new(parser.Object.Uppercase, parser.Object.Brace, parser.Object.Hypenise)
		);

		foreach (var formattedGuid in formattedGuids)
		{
			Console.WriteLine(formattedGuid);
		}
	}
}