using BuisnessLogic.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public interface ICompanyTable
    {
        List<CompanyTableDTO> GetCompanyTables();
        CompanyTableDTO GetCompanyTabel(int CompanyId);
        bool CreateCompany(CompanyTabel companyTabel);
        bool UpdateCompany(CompanyTabel companyTabel);
        bool DeleteCompany(int companyId);
        bool Save();

    }
}
