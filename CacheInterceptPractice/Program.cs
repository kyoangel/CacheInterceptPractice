using Autofac;
using Autofac.Extras.DynamicProxy;
using System;

namespace CacheInterceptPractice
{
	internal class Program
	{
		private static IContainer _container;

		private static void Main(string[] args)
		{
			AutofacConfig();

			var longWork = _container.Resolve<LongWork>();
			var result = longWork.DoWork();
			Console.WriteLine(result);

			result = longWork.DoWork();
			Console.WriteLine(result);

			result = longWork.DoWork();
			Console.WriteLine(result);

			Console.ReadLine();
		}

		private static void AutofacConfig()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<CacheResultInterceptor>().SingleInstance();
			builder.RegisterType<LongWork>().EnableClassInterceptors();
			_container = builder.Build();
		}
	}
}