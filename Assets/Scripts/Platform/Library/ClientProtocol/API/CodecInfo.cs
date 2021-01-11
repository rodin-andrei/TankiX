using System;

namespace Platform.Library.ClientProtocol.API
{
	public struct CodecInfo
	{
		private const string TO_STRING_FORMAT = "Type = {0}, Optional = {1}, Varied = {2}";

		public readonly Type type;

		public readonly bool optional;

		public readonly bool varied;

		public CodecInfo(Type type, bool optional, bool varied)
		{
			this.type = type;
			this.optional = optional;
			this.varied = varied;
		}

		public bool Equals(CodecInfo other)
		{
			return object.Equals(type, other.type) && optional == other.optional && varied == other.varied;
		}

		public override int GetHashCode()
		{
			int num = 0;
			num = (num * 397) ^ ((type != null) ? type.GetHashCode() : 0);
			int num2 = num * 397;
			bool flag = optional;
			num = num2 ^ flag.GetHashCode();
			int num3 = num * 397;
			bool flag2 = varied;
			return num3 ^ flag2.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("Type = {0}, Optional = {1}, Varied = {2}", type, optional, varied);
		}
	}
}
