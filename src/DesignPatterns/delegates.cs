using System;

namespace Creating_A_Simple_Chat_Server
{
	class DChatServer 
	{
		public delegate void OnMsgArrived(string message);
		private static OnMsgArrived onMsgArrived;

		private DChatServer() {}

		public static void ClientConnect(OnMsgArrived onMsgArrived) 
		{
			DChatServer.onMsgArrived += onMsgArrived;
		}

		public static void ClientDisconnect(OnMsgArrived onMsgArrived) 
		{
			DChatServer.onMsgArrived -= onMsgArrived;
		}

		public static void SendMsg(string msg) 
		{
			SendMsg(msg, null);
		}

		public static void SendMsg(string msg, object excludeClient) 
		{
			if (excludeClient == null) 
			{
				onMsgArrived(msg);
			} 
			else 
			{
				Delegate[] DelegateList = onMsgArrived.GetInvocationList();
				for (int i = 0; i < DelegateList.Length; i++) 
				{
					if (DelegateList[i].Target != excludeClient) 
					{
						((OnMsgArrived) DelegateList[i])(msg);
					}
				}            
			}        
		}    
	}


	///////////////////////////////////////////////////////////////////////////////


	class DChatClient 
	{
		private void onMsgArrived(string msg) 
		{
			Console.WriteLine("Msg arrived (Client {0}): {1}", clientName, msg);
		}

		private string clientName;

		public DChatClient(string clientName) 
		{
			this.clientName = clientName;
			//DChatServer.onMsgArrived += new DChatServer.OnMsgArrived(onMsgArrived);
			DChatServer.ClientConnect(new DChatServer.OnMsgArrived(onMsgArrived));
		}

	}



	///////////////////////////////////////////////////////////////////////////////


	class Application 
	{
		public static void DelegatesMain() 
		{
			DChatClient cc1 = new DChatClient("1");
			DChatClient cc2 = new DChatClient("2");
			DChatClient cc3 = new DChatClient("3");

			DChatServer.SendMsg("Hi to all clients", null); 
			DChatServer.SendMsg("Hi to all clients except client 2", cc2);
		}
	}
}
