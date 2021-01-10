namespace YamlDotNet.Serialization
{
	public enum SerializationOptions
	{
		None = 0,
		Roundtrip = 1,
		DisableAliases = 2,
		EmitDefaults = 4,
		JsonCompatible = 8,
		DefaultToStaticType = 16,
	}
}
