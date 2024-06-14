//abstract factory

using System;

abstract class Shape 
{
	public	Shape() { id_ = total_++; }
	public abstract void draw();
	
	protected int id_;
	protected static int  total_=0;
}
class Circle : Shape 
{
	public override void draw() 
	{
		Console.WriteLine("circle " + id_ + ": draw" );
	}
}


class Square : Shape 
{
	public override void draw() 
	{
		Console.WriteLine("Square " + id_ + ": draw" ); 
	}
}
class Ellipse : Shape 
{
	public override void draw() 
	{
		Console.WriteLine("Ellipse " + id_ + ": draw" ); 
	}
}class Rectangle : Shape 
 {
	 public override void draw() 
	 {
		 Console.WriteLine("Rectangle " + id_ + ": draw" ); 
	 }
 }
abstract class Factory 
{
	
	public abstract Shape createCurvedInstance();
	public abstract Shape createStraightInstance();
}
class SimpleShapeFactory : Factory 
{
	public override Shape createCurvedInstance()   { return new Circle(); }
	public override Shape createStraightInstance() { return new Square(); }
}
class RobustShapeFactory :  Factory 
{
	public override Shape createCurvedInstance()   { return new Ellipse(); }
	public override Shape createStraightInstance() { return new Rectangle(); }
}




class Class1
{
	static void Main(string[] args)
	{
		//Factory  factory = new RobustShapeFactory();
		Factory  factory = new SimpleShapeFactory();
		Shape   []shapes=new Shape[3];

		shapes[0] = factory.createCurvedInstance();   
		shapes[1] = factory.createStraightInstance(); 
		shapes[2] = factory.createCurvedInstance();   

		for (int i=0; i < 3; i++)
			shapes[i].draw();
	}
}
