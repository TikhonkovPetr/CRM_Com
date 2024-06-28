using API_CRM.DataBase;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_CRM.Controllers
{
    public class HistoryController : Controller
    {
        DB dbcontext = new DB();
        //[HttpPost("History_Post/{Id}/{Id_Changeling}/{Id_Company}/{Id_Object}/{Action}/{Ddate}")]
        //public async void PostHistory(Guid Id, Guid Id_Changeling, Guid Id_Company, Guid Id_Object, string Action, string Ddate)
        //{
        //    dbcontext.Histories.Add(new History() { Id = Id, Id_Changeling = Id_Changeling, Id_Company = Id_Company, Id_Object = Id_Object, Action = Action, Ddate = Ddate });
        //    dbcontext.SaveChanges();
        //}
        
        [HttpGet("History_IdCompany/{Id_Company}")]
        public async Task<IEnumerable<History>> GetHistory_IdCompany(Guid Id_Company)
        {
            return dbcontext.Histories.Where(hi=>hi.Id_Company==Id_Company);
        }
        [HttpGet("History_Id/{Id}")]
        public async Task<History> GetHistory_Id(Guid Id)
        {
            return dbcontext.Histories.FirstOrDefault(hi => hi.Id == Id);
        }
        [HttpGet("History")]
        public async Task<IEnumerable<History>> GetHistories()
        {
            return dbcontext.Histories;
        }
        [HttpPost("History_Post/{Id}/{Id_Chang}/{Id_Company}/{Id_Obj}/{Actionn}/{Ddate}")]
        public async void PostHistory(Guid Id,Guid Id_Chang,Guid Id_Company,Guid Id_Obj, string Actionn, string Ddate)
        {
            dbcontext.Histories.Add(new History() { Id = Id, Id_Changeling = Id_Chang, Id_Company = Id_Company, Id_Object = Id_Obj, Action = Actionn, Ddate = Ddate });
            dbcontext.SaveChanges();
        }
        [HttpDelete("History_Del/{Id}")]
        public async void DelHistory(Guid Id)
        {
            History history = new History() { Id = Id };
            dbcontext.Histories.Attach(history);
            dbcontext.Histories.Remove(history);
            dbcontext.SaveChanges();
        }
    }
}
