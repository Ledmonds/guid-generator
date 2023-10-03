public class GuidFormatter
{
	public IEnumerable<string> FormatGuids(IEnumerable<Guid> guids, GuidPrintOptions options)
	{
		foreach (var guid in guids)
		{
			var guidString = guid.ToString();
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

			yield return guidString;
		}
	}
}