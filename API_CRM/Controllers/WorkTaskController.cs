using API_CRM.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_CRM.Controllers
{
    public class WorkTaskController : Controller
    {
        DB dbcontext = new DB();
        [HttpGet("WorkTask_Id/{Id}")]
        public async Task<WorkTask> GetWorkTaskId(Guid Id)
        {
            return dbcontext.WorkTasks.FirstOrDefault(w=>w.Id==Id);
        }
        [HttpGet("WorkTask_IdCompany/{Id_Company}")]
        public async Task<IEnumerable<WorkTask>> GetWorkTasks_IdCompany(Guid Id_Company)
        {
            return dbcontext.WorkTasks.Where(w=>w.Id_Company==Id_Company);
        }
        [HttpGet("WorkTask_IdPersom/{Id_Person}")]
        public async Task<IEnumerable<WorkTask>> GetWorkTasks_IdPerson(Guid Id_Person)
        {
            return dbcontext.WorkTasks.Where(w => w.Id_Person == Id_Person);
        }
        [HttpGet("WorkTask_IdPerson_IsComplit/{Id_Person}/{IsComplit}")]
        public async Task<int> GetNumberWorkTask_IsComplit(Guid Id_Person,bool IsComplit)
        {
            return dbcontext.WorkTasks.Where(w=>w.Id_Person==Id_Person && w.IsCompleted==IsComplit).Count();
        }
        [HttpPost("WorkTaskPost/{Id}/{Id_Company}/{Id_Person}/{Id_Sender}/{message}")]
        public async Task PostWorkTask(Guid Id, Guid Id_Company,Guid Id_Person, Guid Id_Sender, string message)
        {
            dbcontext.WorkTasks.Add(new WorkTask() {Id=Id, Id_Company=Id_Company,Id_Person=Id_Person,Id_Sender=Id_Sender, message=message,IsCompleted=false});
            dbcontext.SaveChanges();
        }
        [HttpPatch("WorkTaskPatch/{Id}/{Id_Company}/{Id_Person}/{Id_Sender}/{message}/{IsCompleted}")]
        public async Task PostWorkTask(Guid Id, Guid Id_Company, Guid Id_Person, Guid Id_Sender, string message,bool IsCompleted)
        {
            dbcontext.WorkTasks.Update(new WorkTask() { Id = Id, Id_Company = Id_Company, Id_Person = Id_Person, Id_Sender = Id_Sender, message = message, IsCompleted = IsCompleted});
            dbcontext.SaveChanges();
        }
        [HttpDelete("WorkTaskDelete/{Id}")]
        public async Task DelWorkTask(Guid Id)
        {
            WorkTask workTask = new WorkTask() {Id=Id };
            dbcontext.WorkTasks.Attach(workTask);
            dbcontext.WorkTasks.Remove(workTask);
            dbcontext.SaveChanges();
        }
    }
}
