using System;
using System.Collections;
namespace Visitor
{
	public abstract class Animal 
	{
		private string name_;
		public Animal(string name) 
		{
			name_ = name;
		}
		public override String ToString() 
		{
			return name_;
		}
		public abstract void Accept(Visitor v);
	}
	public class Horse : Animal 
	{
	  public Horse(string name):base(name){}
      public override void Accept(Visitor v) 
	  {
			v.Visit_Horse(this);
	  }
	}
	public class Cat: Animal {
		public Cat(string name):base(name)  {}
		public override void Accept(Visitor v) 
		{
			v.Visit_Cat(this);
		}
	}
	public interface Visitor 
	{
		void Visit_Horse(Horse h);
		void Visit_Cat(Cat c);
	}
    /// <summary>
    /// 
    /// </summary>
	public class DentistVisitor : Visitor 
	{
		public void Visit_Horse(Horse h){
			Console.WriteLine("Dentist is treating the horse " + h);
		}

		public void Visit_Cat(Cat c){
			Console.WriteLine("Dentist is treating the cat " + c);
		}
	}
	public class TestMain 
	{
		private void treatAnimal(Animal a,Visitor v) {    a.Accept(v);   }
		private void treatAnimals(ArrayList c,Visitor v){
			foreach(Animal a in c) {
				treatAnimal(a ,v);
			}
		}

		public TestMain(){
			ArrayList s = new ArrayList();
			s.Add(new Horse("sivka")); s.Add(new Cat("vaska")); 
			s.Add(new Horse("burka"));s.Add(new Cat("barsik"));
		    treatAnimals(s,new DentistVisitor());
		}
		[STAThread]
		static void Main(string[] args)	{
			TestMain main1 = new TestMain();
		}
	}
}