using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
   public class EmployeeRepo : IEmployeeRepo
    {
        private TechOneSanjSecondEntities _techOneSanjSecondEntities;
        public EmployeeRepo(TechOneSanjSecondEntities dbContext)
        {
            _techOneSanjSecondEntities = dbContext;
        }

        public bool CreateUser(UserInformation userInformation)
        {
            _techOneSanjSecondEntities.UserInformations.Add(userInformation);
            return Save();
        }

        public bool DeleteUser(int UserId)
        {
            var deleteUser = _techOneSanjSecondEntities.UserInformations.Where(a => a.Id == UserId).SingleOrDefault();

            deleteUser.Active = false;
           
            return Save();

        }

        public UserInformation GetUserInformation(int GetUserId)
        {
            var query = (from user in _techOneSanjSecondEntities.UserInformations
                         where user.Active == true && user.Id == GetUserId
                         select user).SingleOrDefault();
            return query;
        }

        public ICollection<UserInformation> GetUserInformations()
        {
            var query = (from user in _techOneSanjSecondEntities.UserInformations
                         where user.Active == true
                         select user).ToList();
            return query;
        }

        public bool Save()
        {
            var save = _techOneSanjSecondEntities.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdateUser(UserInformation userInformation)
        {
            _techOneSanjSecondEntities.Entry(userInformation).State = EntityState.Modified;
            return Save();
        }

        
    }
}
