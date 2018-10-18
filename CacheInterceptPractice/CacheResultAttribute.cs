using System;

namespace CacheInterceptPractice
{
	public class CacheResultAttribute : Attribute
	{
		public int Duration { get; set; }
	}
}