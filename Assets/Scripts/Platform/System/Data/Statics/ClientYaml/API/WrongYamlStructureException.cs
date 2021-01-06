using System;

namespace Platform.System.Data.Statics.ClientYaml.API
{
	public class WrongYamlStructureException : Exception
	{
		public WrongYamlStructureException(string key, Type expected, Type actual)
		{
		}

	}
}
