using Autofac.Extras.DynamicProxy;
using System;
using System.Threading;

namespace CacheInterceptPractice
{
	[Intercept(typeof(CacheResultInterceptor))]
	public class LongWork
	{
		[CacheResult(Duration = 2100)]
		public virtual string DoWork()
		{
			Console.WriteLine("Sleep 1.5 sec");
			Console.WriteLine();
			Thread.Sleep(1500);
			return Guid.NewGuid().ToString();
		}
	}
}