//bridge
using System;

class Stack {
    private StackImpl impl;
    public Stack( String s ) {
        if      (s.Equals("array")) impl = new StackArray();
        else if (s.Equals("list"))  impl = new StackList();
        else Console.WriteLine( "Stack: unknown parameter" );
    }
    public Stack() :this( "array" )   { }
    public virtual void    push( int i ) { impl.push( i ); }
    public virtual int     pop()          { return impl.pop(); }
    public int     top()          { return impl.top(); }
    public bool isEmpty()      { return impl.isEmpty(); }
    public bool isFull()       { return impl.isFull(); }
}

class StackHanoi : Stack {
    private int totalRejected = 0;
    public StackHanoi():base( "array" ){ }
    public StackHanoi( String s ):base( s ){ }
    public int reportRejected()   { return totalRejected; }
    public override void push( int i ) {
        if ( ! isEmpty()  &&  i > top())
            totalRejected++;
        else base.push( i );
}   }

class StackFIFO : Stack {
    private StackImpl temp = new StackList();
    public StackFIFO():base( "array" ){ }
    public StackFIFO( String s ) : base( s ){ }
    public override int pop() {
        while ( ! isEmpty())
            temp.push( base.pop() );
        int ret =  temp.pop();
        while ( ! temp.isEmpty())
            push( temp.pop() );
        return ret;
}  }

interface StackImpl {
    void    push( int i );
    int     pop();
    int     top();
    bool isEmpty();
    bool isFull();
}

class StackArray : StackImpl {
    private int[] items = new int[12];
    private int   total = -1;
    public void push( int i ) { if ( ! isFull()) items[++total] = i; }
    public bool isEmpty()  { return total == -1; }
    public bool isFull()   { return total == 11; }
    public int top() {
        if (isEmpty()) return -1;
        return items[total];
    }
    public int pop() {
        if (isEmpty()) return -1;
        return items[total--];
}   }
class Node 
{
	public int  value;
	public Node prev, next;
	public Node( int i ) { value = i; }
}

class StackList : StackImpl {
    private Node last;
    public void push( int i ) {
        if (last == null)
            last = new Node( i );
        else {
            last.next = new Node( i );
            last.next.prev = last;
            last = last.next;
    }   }
    public bool isEmpty() { return last == null; }
    public bool isFull()  { return false; }
    public int top() {
        if (isEmpty()) return -1;
        return last.value;
    }
    public int pop() {
        if (isEmpty()) return -1;
        int ret = last.value;
        last = last.prev;
        return ret;
}   }

class BridgeDisc {
    public static void Main( String[] args ) {
        Stack[] stacks = { new Stack( "array" ), new Stack( "list" ),
            new StackFIFO(), new StackHanoi() };
        for (int i=1 ; i < 15; i++)
            for (int j=0; j < 3; j++) 
                stacks[j].push( i );
        Random rn = new Random();
        for (int i=1 ; i < 15; i++)
            stacks[3].push( rn.Next(20) );
        for (int i=0 ; i < stacks.Length; i++) {
            while ( ! stacks[i].isEmpty())
                Console.Write( stacks[i].pop() + "  " );
            Console.WriteLine();
        }
        Console.WriteLine( "total rejected is "
            + ((StackHanoi)stacks[3]).reportRejected() );
}   }

