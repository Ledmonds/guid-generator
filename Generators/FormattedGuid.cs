namespace guid_spammer.Generators;

public record struct FormattedGuid(string Value)
{
	public override string ToString() => Value;
}