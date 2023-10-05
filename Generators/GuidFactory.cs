using guid_spammer.Generators;

public class GuidFactory
{
	public IReadOnlyCollection<UnformattedGuid> GenerateGuids(int number, bool unique)
	{
		return unique ? GenerateUniqueGuids(number) : GenerateNonUniqueGuids(number);
	}

	private IReadOnlyCollection<UnformattedGuid> GenerateUniqueGuids(int number)
	{
		var uniqueGuids = new HashSet<UnformattedGuid>();

		for (int i = 0; i < number; i++)
		{
			var guid = UnformattedGuid.NewId();
			while (uniqueGuids.Contains(guid))
			{
				guid = UnformattedGuid.NewId();
			}
			uniqueGuids.Add(guid);
		}

		return uniqueGuids;
	}

	private IReadOnlyCollection<UnformattedGuid> GenerateNonUniqueGuids(int number)
	{
		return Enumerable.Range(0, number).Select(_ => UnformattedGuid.NewId()).ToArray();
	}
}