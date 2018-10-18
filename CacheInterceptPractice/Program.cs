using Autofac.Extras.DynamicProxy;
using System;
using Autofac;
using Autofac.Core;

namespace CacheInterceptPractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CacheResultInterceptor>().SingleInstance();
            builder.RegisterType<LongWork>().EnableClassInterceptors();
            var container = builder.Build();

            var longWork = container.Resolve<LongWork>();
            var result = longWork.DoWork();
            Console.WriteLine(result);

            result = longWork.DoWork();
            Console.WriteLine(result);

            result = longWork.DoWork();
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}