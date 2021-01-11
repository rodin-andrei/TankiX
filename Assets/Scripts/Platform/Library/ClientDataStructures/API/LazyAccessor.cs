using System;

namespace Platform.Library.ClientDataStructures.API
{
	public class LazyAccessor<T>
	{
		private T value;

		private readonly Func<T> initializer;

		public T Value
		{
			get
			{
				if (value == null)
				{
					value = initializer();
				}
				return value;
			}
		}

		public LazyAccessor(Func<T> initializer)
		{
			this.initializer = initializer;
		}

		public LazyAccessor(T value)
		{
			this.value = value;
		}
	}
}
