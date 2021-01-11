namespace Platform.Library.ClientDataStructures.API
{
	public struct Optional<T> where T : class
	{
		public static readonly Optional<T> EMPTY = default(Optional<T>);

		private readonly T value;

		public Optional(T value)
		{
			this.value = value;
		}

		public T Get()
		{
			return value;
		}

		public bool IsPresent()
		{
			return value != null;
		}

		public override string ToString()
		{
			return string.Concat("Optional[", value, "]");
		}

		public static Optional<T> nullableOf(T value)
		{
			if (value == null)
			{
				return empty();
			}
			return of(value);
		}

		public static Optional<T> empty()
		{
			return EMPTY;
		}

		public static Optional<T> of(T value)
		{
			return new Optional<T>(value);
		}
	}
}
