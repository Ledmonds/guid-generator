using Fclp;

public static class FluentCommandLineParserExtensions
{
	public static void SetupArguments(this FluentCommandLineParser<ApplicationArguments> parser)
	{
		parser.SetupHelp("?", "help").Callback(text => Console.WriteLine(text));

		parser
			.Setup(arg => arg.Count)
			.As('c', "count")
			.SetDefault(1)
			.WithDescription("Count of guids to generate");

		parser
			.Setup(arg => arg.Unique)
			.As('d', "distinct")
			.SetDefault(false)
			.WithDescription("Should guids be distinct");

		parser
			.Setup(arg => arg.Uppercase)
			.As('u', "uppercase")
			.SetDefault(false)
			.WithDescription("Should guids be uppercase");

		parser
			.Setup(arg => arg.Brace)
			.As('b', "brace")
			.SetDefault(false)
			.WithDescription("Should guids be wrapped in curly braces");

		parser
			.Setup(arg => arg.Hypenise)
			.As('h', "hypenise")
			.SetDefault(true)
			.WithDescription("Should guid segments be hypen-delimited");
	}
}