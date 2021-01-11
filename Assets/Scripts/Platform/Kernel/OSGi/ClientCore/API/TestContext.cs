using System.Collections;
using System.Collections.Specialized;

namespace Platform.Kernel.OSGi.ClientCore.API
{
	public class TestContext
	{
		private ThreadLocal<IDictionary> data = new ThreadLocal<IDictionary>();

		private static ThreadLocal<TestContext> context = new ThreadLocal<TestContext>();

		public bool SpyEntity
		{
			get;
			set;
		}

		public static bool IsTestMode
		{
			get
			{
				return context.Exists();
			}
		}

		public static TestContext Current
		{
			get
			{
				return context.Get();
			}
		}

		private TestContext()
		{
			data.Set(new ListDictionary());
			SpyEntity = false;
		}

		public static void EnterTestMode()
		{
			context.Set(new TestContext());
		}

		public void PutData(object key, object value)
		{
			data.Get().Add(key, value);
		}

		public object GetData(object key)
		{
			return data.Get()[key];
		}

		public bool IsDataExists(object key)
		{
			return data.Get().Contains(key);
		}
	}
}
