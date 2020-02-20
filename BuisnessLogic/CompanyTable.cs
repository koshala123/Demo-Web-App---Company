using BuisnessLogic.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class CompanyTable : ICompanyTable
    {
        private TechOneSanjSecondEntities _techOneSanjSecondEntities;

        public CompanyTable(TechOneSanjSecondEntities dbContext)
        {
            _techOneSanjSecondEntities = dbContext;
        }
        public bool CreateCompany(CompanyTabel companyTabel)
        {
            companyTabel.CreatedDate = DateTime.Now;
           // companyTabel.DateTime = DateTime.Now;
            companyTabel.CreatedBy = companyTabel.RequestName;

            _techOneSanjSecondEntities.CompanyTabels.Add(companyTabel);
            return Save();
        }

        public bool DeleteCompany(int companyId)
        {
            var deleteUser = _techOneSanjSecondEntities.CompanyTabels.Where(a => a.Id == companyId).SingleOrDefault();
            deleteUser.Active = false;
            return Save();
        }

        public CompanyTableDTO GetCompanyTabel(int CompanyId)
        {
            var result = _techOneSanjSecondEntities.CompanyTabels.Where(a => a.Id == CompanyId).FirstOrDefault();
            CompanyTableDTO company = new CompanyTableDTO();
            company.id = result.Id;
            company.CompanyName = result.CompanyName;
            company.SystemName = result.SystemName;
            company.IssueType = result.IssueType;
            company.ClassName = result.className;
            company.MethodName = result.MethodName;
            company.DateTime = result.DateTime;
            company.RequestNumber = result.RequestNumber;
            company.RequestName = result.UserInformation.DisplayName;
            company.Status = result.Status1.Name;
            company.Comment = result.Comment;
            company.Error = result.error;
            company.Active = result.Active;
            company.DueDate = (result.DateTime - DateTime.Now).Days;

            return company;
        }

        public List<CompanyTableDTO> GetCompanyTables()
        {   
            
            var results = _techOneSanjSecondEntities.CompanyTabels.Where(a => a.Active == true).OrderBy(a => a.Id);
            
            List<CompanyTableDTO> comapnydto = new List<CompanyTableDTO>();

            foreach (var item in results)
            {
                CompanyTableDTO company = new CompanyTableDTO();
                company.id = item.Id;
                company.CompanyName = item.CompanyName;
                company.SystemName = item.SystemName;
                company.IssueType = item.IssueType;
                company.ClassName = item.className;
                company.MethodName = item.MethodName;
                company.DateTime = item.DateTime;
                company.RequestNumber = item.RequestNumber;
                company.RequestName = item.UserInformation.DisplayName;
                company.Status = item.Status1.Name;
                company.Comment = item.Comment;
                company.Error = item.error;
                company.Active = item.Active;
                company.DueDate = (item.DateTime - DateTime.Now).Days;

                comapnydto.Add(company);
            }

            return comapnydto;
        }

        public bool Save()
        {
            var save = _techOneSanjSecondEntities.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdateCompany(CompanyTabel companyTabel)
        {
            _techOneSanjSecondEntities.Entry(companyTabel).State = EntityState.Modified;
            return Save();
        }
    }
}
