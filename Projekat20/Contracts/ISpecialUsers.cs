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
        void ModifyValue(string id, string newValue); // only for operators

        [OperationContract]
        void ModifyID(string oldId, string newId);    // only for operators

        [OperationContract]
        void AddEntity(string Id, string value, string name);    // only for administrators

        [OperationContract]
        void DeleteEntity(string Id);    // only for administrators

        [OperationContract]
        void DeleteDatabase();    // only for super administrators

        [OperationContract]
        void GetElectricityConsumption(string imeprezime, string uid);
    }
}
