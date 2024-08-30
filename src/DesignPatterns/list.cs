using System;

namespace ConsoleApplication8
{
	public interface Comp
	{
		 int compareTo(Comp other);
	}
	public class Item
	{
		public Comp data;
		public Item next;
		public Item(Comp d){data=d;next=null;}
	}
	public class Mylist
	{
		private Item head;
		public Mylist(){ head=null;}
		public void add(Comp ob)
		{
			Item temp=new Item(ob);
			Item p=head;
			Item prev=head;
			if (head==null)
			{
				head=temp; 
				return;
			}
		
			if (head.data.compareTo(ob)==1)
			{
				head=temp;
				temp.next=p;
				return;
			}
			while (p!=null)
			{
				if(p.data.compareTo(ob)==1)
				{
					temp.next=p;
					prev.next=temp;
					return;
				}
				prev=p;
				p=p.next;
			}
			prev.next=temp;	
		}
		public void print()
		{
			Item p=head;
			while(p!=null)
			{
				Console.WriteLine(p.data.ToString());
				p=p.next;
			}
		}
	}
	public class Numb : Comp
	  {
	    private int x;
		public Numb(int t)
		{
			x=t;
		}
		public int getNum()
		{
			return x;
		}
		public override String ToString(){return x.ToString(); }
		public int compareTo(Comp other)
		{
			if (((Numb)other).getNum()<x)
				return 1;
			else
				if (((Numb)other).getNum()>x)
				return -1;
			else
				return 0;
		}
	}
	public class UseList
	{
		public static void Main(String []arg)
		{
			int i=0;
			Mylist ls=new Mylist();
			for(i=8;i>0;i-=2)
			{
				Numb ob=new Numb(i);
				ls.add(ob);
			}
			for(i=1;i<12;i+=2)
			{
				Numb ob=new Numb(i);
				ls.add(ob);
			}
			ls.print();
		}
	}
}
