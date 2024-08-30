using System;
namespace DecoratorLab
{
	interface IA 
	{
		 void doIt();
	}
	class A : IA
	{
		public virtual void doIt() { Console.Write("A"); }
	}
	abstract class Deco : IA
	{
		private IA inner;
		public Deco(IA ia) { inner = ia;}
		public virtual void doIt() { inner.doIt();  }
	}
	class X : Deco 
	{
		public X(IA ia):base(ia){}
		public override void doIt() 
		{
			base.doIt();
			Console.Write("X");
		}  
	}
	class Y : Deco 
	{
		public Y(IA ia):base(ia){}
		public override void doIt() 
		{
			base.doIt();
			Console.Write("Y");
		}
    }
	class Z : Deco 
	{
		public Z(IA ia):base(ia){}
		public override void doIt() 
		{
			base.doIt();
			Console.Write("Z");
		}
	}
	class DecoLab
	{
		[STAThread]
		static void Main(string[] args)
		{
			IA anX = new X(new A()); //AwithX    anX;
			IA anXY = new Y(new X(new A()));//AwithXY   anXY;
			IA anXYZ=new Z(new Y(new X(new A())));//AwithXYZ  anXYZ;			
			anX.doIt();  Console.Write('\n');   
			anXY.doIt();   Console.Write('\n');  
			anXYZ.doIt();  Console.Write('\n');  
		}
	}
}
