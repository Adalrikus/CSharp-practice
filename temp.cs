using System;
using System.Collections.Generic;

namespace temp
{
	class Compare<T>
	{
		public void compare(T a, T b)
		{
			if(a.compareTo(b))
			{
				Console.WriteLine("Equal");
			}
			else
			{
				Console.WriteLine("Not Equal");
			}
		}
	}
	class Program
	{
		static void Main()
		{
			int a;
			int b;
			
			Console.WriteLine("Enter a variable: ");
			a = int.Parse(Console.Read());
			Console.WriteLine("Enter a variable: ");
			b = int.Parse(Console.Read());
			Program<int> obj;
			obj.compare(a, b);
		}
	}
}
