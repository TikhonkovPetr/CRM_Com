using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_CRM.DataBase;
using Models;

namespace API_CRM.Controllers
{
    public class PersonController : Controller
    {
        DB dbcont = new DB();
        [HttpPost("Person/{Id}/{Id_User}/{Id_Company}/{Name}/{Dostup}")]
        public async void CreatePerson(Guid Id,Guid Id_User,Guid Id_Company,string Name,string Dostup)
        {
            Person person = new Person() {Id=Id,Id_User=Id_User,Id_Company=Id_Company,Name=Name,Dostup=Dostup};
            dbcont.Persons.Add(person);
            dbcont.SaveChanges();
        }
        [HttpGet("Person")]
        public async Task<IEnumerable<Person>> GetPerson()
        {
            return dbcont.Persons;
        }
        [HttpGet("Person_IdCompany{Id_Company}")]
        public async Task<IEnumerable<Person>> GetPerson_IdCompany(Guid Id_Company)
        {
            return dbcont.Persons.Where(p=>p.Id_Company==Id_Company);
        }
        [HttpGet("PersonName/{Id}")]
        public async Task<string> GetPersonName(Guid Id)
        {
            return dbcont.Persons.FirstOrDefault(p=>p.Id==Id).Name;
        }
        [HttpGet("Person/{Id_User}")]
        public async Task<IEnumerable<Person>> GetPersonId_User(Guid Id_User)
        {
            return dbcont.Persons.Where(p=>p.Id_User==Id_User);
        }
        [HttpGet("Person_Id/{Id}")]
        public async Task<Person> GetPersonId(Guid Id)
        {
            return dbcont.Persons.FirstOrDefault(p => p.Id == Id);
        }
    }
}
