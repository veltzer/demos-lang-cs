using System;
using System.Collections;
using ConsoleApplication2;

class Test
{
	public static void f1(int a)
	{
		Console.WriteLine("a = " +a);
	}
	public static void f2(int a)
	{
		Console.WriteLine("a = " + a*2);
	}
    public static void Main()
    {
        Subject s = new Subject();
	
		s.del += new FunDel(f2);
		s.del += new FunDel(f1);

		s.del += new FunDel(f1);
		s.Invoke();
    }
}