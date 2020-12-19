using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class WCFClient: ChannelFactory<ISpecialUsers>, ISpecialUsers
    {
        ISpecialUsers factory;
        public WCFClient(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public void AddEntity(long Id, double value)
        {
            try
            {
                factory.AddEntity(Id, value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
