public class GuidFactory
{
	public IReadOnlyCollection<Guid> GenerateGuids(int number, bool unique)
	{
		return unique ? GenerateUniqueGuids(number) : GenerateNonUniqueGuids(number);
	}

	private IReadOnlyCollection<Guid> GenerateUniqueGuids(int number)
	{
		var uniqueGuids = new HashSet<Guid>();

		for (int i = 0; i < number; i++)
		{
			var guid = Guid.NewGuid();
			while (uniqueGuids.Contains(guid))
			{
				guid = Guid.NewGuid();
			}
			uniqueGuids.Add(guid);
		}

		return uniqueGuids;
	}

	private IReadOnlyCollection<Guid> GenerateNonUniqueGuids(int number)
	{
		return Enumerable.Range(0, number).Select(_ => Guid.NewGuid()).ToArray();
	}
}