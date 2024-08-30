//prototype 

using System;

interface Prototype 
{ 
	Object clone();   
	String getName(); 
} 
interface PrototypeCommand   
{ 
	void   execute(); 
}                    

class PrototypesModule 
{                 
	private static Prototype[] prototypes = new Prototype[9];
	private static int         total      = 0;
	static PrototypesModule()
	{
		PrototypesModule.addPrototype( new This() );
		PrototypesModule.addPrototype( new That() );
		PrototypesModule.addPrototype( new TheOther() );

	}
	public static void addPrototype( Prototype obj ) 
	{
		prototypes[total++] = obj;
	}
	public static Object? findAndClone( String name ) 
	{  
		for (int i=0; i < total; i++)
			if (prototypes[i].getName().Equals( name ))
				return prototypes[i].clone();
		Console.WriteLine( name + " not found" );
		return null;
	}  
}
                                                  
class This : Prototype, PrototypeCommand 
{         
	public Object clone()   { return new This(); } 
	public String getName() { return "This"; }     
	public void   execute() { Console.WriteLine( "This: execute" ); }
}
class That : Prototype, PrototypeCommand 
{
	public Object clone()   { return new That(); }
	public String getName() { return "That"; }
	public void   execute() { Console.WriteLine( "That: execute" ); }
}
class TheOther : Prototype, PrototypeCommand 
{
	public Object clone()   { return new TheOther(); }
	public String getName() { return "TheOther"; }
	public void   execute() { Console.WriteLine( "TheOther: execute" ); }
}

public class PrototypeDemo 
{
	public static void Main( String[] args ) 
	{
		string []arr=new string[5]{"Garbage", "This", "That", "Nothing", "TheOther"};

		Object?[] objects = new Object[9];
		int      total   = 0;
		for (int i=0; i < arr.Length; i++) 
		{     
			objects[total] = PrototypesModule.findAndClone( arr[i] );
			if (objects[total] != null) 
				total++; 
		}
		for (int i=0; i < total; i++) {
			PrototypeCommand? pc = objects[i] as PrototypeCommand;
			if(pc!=null)
				pc.execute();
		}
	}  
}