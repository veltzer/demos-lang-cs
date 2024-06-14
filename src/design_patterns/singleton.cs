//singleton

using System;
using System.Collections;
using System.Threading;


class LoadBalancer
{
	private static LoadBalancer balancer;
	private ArrayList servers = new ArrayList();
	private Random random = new Random();

	protected LoadBalancer() 
	{
		servers.Add( "ServerI" );
		servers.Add( "ServerII" );
		servers.Add( "ServerIII" );
		servers.Add( "ServerIV" );
		servers.Add( "ServerV" );
	}

	public static LoadBalancer GetLoadBalancer()
	{
		if( balancer == null )
		{
			Mutex mutex = new Mutex();
			mutex.WaitOne();

			if( balancer == null )
				balancer = new LoadBalancer();

			mutex.Close();
		}
    
		return balancer;
	}

	public string Server
	{
		get
		{
			int r = random.Next( servers.Count );
			return servers[ r ].ToString();
		}
	}
}

public class SingletonApp
{
	public static void Main( string[] args )
	{
		LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
		LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
		LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
		LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

		if( (b1 == b2) && (b2 == b3) && (b3 == b4) )
			Console.WriteLine( "Same instance" );

		Console.WriteLine( b1.Server );
		Console.WriteLine( b2.Server );
		Console.WriteLine( b3.Server );
		Console.WriteLine( b4.Server );

		Console.Read();
	}
}
