using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class WCFClient: ChannelFactory<ISpecialUsers>, ISpecialUsers
    {
        ISpecialUsers factory;
        NetTcpBinding binding2 = new NetTcpBinding();
        



        public WCFClient(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
            
        }

       

        public void GetElectricityConsumption(string imeprezime, int uid)
        {
            try
            {
                factory.GetElectricityConsumption(imeprezime, uid);
            }
            catch(SecurityAccessDeniedException es){
                Console.WriteLine("There was a error completing action: 'GetElectricityConsumption'. Message: " + es.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void ModifyValue(long id, double newValue)
        {

            try
            {
                factory.ModifyValue(id, newValue);
            }
            catch (SecurityAccessDeniedException es)
            {
                Console.WriteLine("There was a error completing action: 'ModifyValue'. Message: " + es.Message);
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
            catch (SecurityAccessDeniedException es)
            {
                Console.WriteLine("There was a error completing action: 'ModifyID'. Message: " + es.Message);
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
            catch (SecurityAccessDeniedException es)
            {
                Console.WriteLine("There was a error completing action: 'AddEntity'. Message: " + es.Message);
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
            catch (SecurityAccessDeniedException es)
            {
                Console.WriteLine("There was a error completing action: 'DeleteEntity'. Message: " + es.Message);
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
            catch (SecurityAccessDeniedException es)
            {
                Console.WriteLine("There was a error completing action: 'DeleteDatabase'. Message: " + es.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
