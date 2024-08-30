using System;

namespace ConsoleApplication2
{
	/// <summary>
	/// Summary description for Sybject.
	/// </summary>
	/// 
	public delegate void FunDel(int a);
	public class Subject
	{
		public event FunDel del;
		public void Invoke()
		{
			del(10);
		}
		
	}
}
