using API_CRM.DataBase;
using Microsoft.AspNetCore.Mvc;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_CRM.Controllers
{
    public class ClientController : Controller
    {
        DB dbcontext = new DB();
        [HttpGet("Client")]
        public async Task<IEnumerable<Client>> GetClient()
        {
            return dbcontext.Clients;
        }
        [HttpPost("Client")]
        public async void PostClient([FromBody]Client client)
        {
            client.Id = Guid.NewGuid();
            dbcontext.Clients.Add(client);
            dbcontext.SaveChanges();
        }
        [HttpGet("Client_IdComp/{Id_company}")]
        public async Task<IEnumerable<Client>> GetClient_IdCompany(Guid Id_company)
        {
            return dbcontext.Clients.Where(cl=>cl.Id_Company==Id_company);
        }
        [HttpPost("Client/{Id}/{Id_Company}/{Name}/{Number}/{Status}/{Description}")]
        public async void PostClientAll(Guid Id,Guid Id_Company,string Name,string Number,string Status,string Description)
        {
            dbcontext.Clients.Add(new Client() { Id=Id, Id_Company=Id_Company,Name=Name,Number=Number,Status=Status,Description=Description});
            dbcontext.SaveChanges();
        }
        [HttpGet("Client_Name/{Id}")]
        public async Task<string> GetClientname(Guid Id)
        {
            return dbcontext.Clients.FirstOrDefault(cl=>cl.Id==Id).Name;
        }
        [HttpGet("Client/{Id}")]
        public async Task<Client> GetClient(Guid Id)
        {
            return dbcontext.Clients.FirstOrDefault(cl=>cl.Id==Id);
        }
        [HttpPatch("Client_Patch/{Id}/{Id_Company}/{Name}/{Number}/{Status}/{Description}")]
        public async void UpdateClient(Guid Id, Guid Id_Company, string Name, string Number, string Status, string Description)
        {
            dbcontext.Clients.Update(new Client(){ Id = Id, Id_Company = Id_Company, Name = Name, Number = Number, Status = Status, Description = Description });
            dbcontext.SaveChanges();
        }
        [HttpDelete("Client_Del/{Id}")]
        public async void DelClient(Guid Id)
        {
            Client client = new Client() { Id = Id };
            dbcontext.Clients.Attach(client);
            dbcontext.Clients.Remove(client);
            dbcontext.SaveChanges();
        }
    }
}
