using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NTLayerArch.DTO;
using NTLayerArch.Entity;

namespace NTLayerArch
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetUserAdd(UserToAddDto dto);

        [OperationContract]
        string UpdateUser(UserToUpdateDto dto);

        [OperationContract]
        string DeleteUser(UserToDeleteDto dto);

        [OperationContract]
        List<User> GetUsersList();
    }
}
