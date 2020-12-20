using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface ISpecialUsers
    {
        [OperationContract]
        void ModifyValue(long id, double newValue); // only for operators

        [OperationContract]
        void ModifyID(long oldId, long newId);    // only for operators

        [OperationContract]
        void AddEntity(long Id, double value, string name);    // only for administrators

        [OperationContract]
        void DeleteEntity(long Id);    // only for administrators

        [OperationContract]
        void DeleteDatabase();    // only for super administrators

        [OperationContract]
        void GetElectricityConsumption(string imeprezime, int uid);
    }
}
