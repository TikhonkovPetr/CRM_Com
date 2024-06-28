using API_CRM.DataBase;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_CRM.Controllers
{
    public class TransactionController : Controller
    {
        DB dbcontext = new DB();
        [HttpGet("Transaction")]
        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return dbcontext.Transactions;
        }
        [HttpGet("Transaction_Id/{Id}")]
        public async Task<Transaction> GetTransaction_Id(Guid Id)
        {
            return dbcontext.Transactions.FirstOrDefault(tr=>tr.Id==Id);
        }
        [HttpGet("Transaction/{Id_Company}")]
        public async Task<IEnumerable<Transaction>> GetTransactions_IdCompany(Guid Id_Company)
        {
            return dbcontext.Transactions.Where(t=>t.Id_Company==Id_Company);
        }
        [HttpPost("Transaction_Post/{Id}/{Id_Company}/{Id_Client}/{Id_Product}/{colvo}/{cost}")]
        public async void PostTransaction(Guid Id,Guid Id_Company,Guid Id_Client,Guid Id_Product,int colvo,string cost)
        {
            dbcontext.Transactions.Add(new Transaction(){Id=Id,Id_Company=Id_Company,Id_Client=Id_Client,Id_Product=Id_Product,colvo=colvo,cost=cost });
            dbcontext.SaveChanges();
        }
        [HttpPatch("Transaction_Patch/{Id}/{Id_Company}/{Id_Client}/{Id_Product}/{colvo}/{cost}")]
        public async void PatchTransaction(Guid Id, Guid Id_Company, Guid Id_Client, Guid Id_Product, int colvo, string cost)
        {
            dbcontext.Transactions.Update(new Transaction() { Id = Id, Id_Company = Id_Company, Id_Client = Id_Client, Id_Product = Id_Product, colvo = colvo, cost = cost });
            dbcontext.SaveChanges();
        }
        [HttpDelete("Transaction_Del/{Id}")]
        public async void DelTransaction(Guid Id)
        {
            Transaction transaction = new Transaction() { Id=Id};
            dbcontext.Transactions.Attach(transaction);
            dbcontext.Transactions.Remove(transaction);
            dbcontext.SaveChanges();
        }
    }
}
