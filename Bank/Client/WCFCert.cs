﻿using Contracts;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	public class WCFCert : ChannelFactory<ICert>, ICert, IDisposable
	{
		ICert factory;

		public WCFCert(NetTcpBinding binding, EndpointAddress address)
			: base(binding, address)
		{

			factory = this.CreateChannel();
		}

		public void TestCommunication()
		{
			try
			{
				factory.TestCommunication();
			}
			catch (Exception e)
			{
				Console.WriteLine("[TestCommunication] ERROR = {0}", e.Message);
			}
		}

		public void Dispose()
		{
			if (factory != null)
			{
				factory = null;
			}

			this.Close();
		}
	}
}