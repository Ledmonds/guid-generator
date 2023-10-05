namespace guid_spammer.Generators
{
	public record struct UnformattedGuid
	{
		public static UnformattedGuid NewId() => new(Guid.NewGuid());

		private UnformattedGuid(Guid guid)
		{
			Value = guid;
		}

		public Guid Value { get; }

		public FormattedGuid FormatGuid(GuidFormatterOptions options)
		{
			var guidString = Value.ToString();
			if (options.Uppercase)
			{
				guidString = guidString.ToUpper();
			}
			if (options.Brace)
			{
				guidString = $"{{{guidString}}}";
			}
			if (!options.Hypenise)
			{
				guidString = guidString.Replace("-", "");
			}

			return new FormattedGuid(guidString);
		}
	}
}