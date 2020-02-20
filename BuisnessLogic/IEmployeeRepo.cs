using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public interface IEmployeeRepo
    {
        ICollection<UserInformation> GetUserInformations();
        UserInformation GetUserInformation(int GetUserId);
       
        bool CreateUser(UserInformation userInformation);
        bool UpdateUser(UserInformation userInformation);
        bool DeleteUser(int UserId);
        bool Save();
    }
}
