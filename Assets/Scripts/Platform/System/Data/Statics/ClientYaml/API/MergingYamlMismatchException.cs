using System;

namespace Platform.System.Data.Statics.ClientYaml.API
{
	public class MergingYamlMismatchException : Exception
	{
		public MergingYamlMismatchException(string key, Type destinationType, Type sourceType)
		{
		}

	}
}
