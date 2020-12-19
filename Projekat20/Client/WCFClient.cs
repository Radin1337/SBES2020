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

        public void ModifyValue(long id, double newValue)
        {

            try
            {
                factory.ModifyValue(id, newValue);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void ModifyID(long oldId, long newId)
        {

            try
            {
                factory.ModifyID(oldId, newId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void AddEntity(long Id, double value,string name)
        {
            try
            {
                factory.AddEntity(Id, value,name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DeleteEntity(long Id)
        {
            try
            {
                factory.DeleteEntity(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DeleteDatabase()
        {
            try
            {
                factory.DeleteDatabase();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
