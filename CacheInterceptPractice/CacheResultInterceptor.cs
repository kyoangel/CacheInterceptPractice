using Castle.DynamicProxy;
using System;
using System.Linq;

namespace CacheInterceptPractice
{
	public class CacheResultInterceptor : IInterceptor
	{
		private MemoryCacheProvider _memoryCacheProvider;

		public void Intercept(IInvocation invocation)
		{
			var attribute = Attribute.GetCustomAttribute(invocation.MethodInvocationTarget, typeof(CacheResultAttribute)) as CacheResultAttribute;

			if (attribute == null)
			{
				invocation.Proceed();
				return;
			}

			var key = $"{invocation.TargetType.FullName}-{invocation.Method.Name}-{invocation.Arguments.Select(a => a ?? "")}";

			_memoryCacheProvider = new MemoryCacheProvider();
			if (_memoryCacheProvider.Contains(key))
			{
				invocation.ReturnValue = _memoryCacheProvider.Get(key);
				return;
			}

			invocation.Proceed();
			var result = invocation.ReturnValue;
			if (result != null)
			{
				_memoryCacheProvider.Put(key, result, attribute.Duration);
			}
		}
	}
}