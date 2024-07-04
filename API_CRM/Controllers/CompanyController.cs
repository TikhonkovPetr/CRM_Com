using API_CRM.DataBase;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_CRM.Controllers
{
    public class CompanyController : Controller
    {
        DB dbcont = new DB();
        [HttpPost("Company")]
        public async void CreateCompany(string Name_Company)
        {
            Company company = new Company();
            company.Name = Name_Company;
            company.Id = Guid.NewGuid();
            dbcont.Companys.Add(company);
            dbcont.SaveChanges();
        }
        [HttpGet("Company")]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return dbcont.Companys;
        }
        [HttpGet("Company/{Id}")]
        public async Task<string> GetNameCompany(Guid Id)
        {
            List<Company> comp = dbcont.Companys.Where(com=>com.Id== Id).ToList();
            if(comp.Count == 0)
            {
                return null;
            }
            else
            {
                return comp.First().Name;
            }
        }
    }
}
