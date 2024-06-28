using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class ListTransaction
    {
        [Inject]
        public NavigationManager navigate { get; set; }
        [Inject]
        public ILocalStorageService localstoreg { get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public ICompanyService companyService { get; set; }
        [Inject]
        public ITransactionService transactionService { get; set; }
        [Inject]
        public IClientService clientService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        public Person person = null;
        public List<Transaction> transactions = new List<Transaction>();
        public string NameCompanty = "";
        public List<string> strcli = new List<string>();
        public List<string> strpro = new List<string>();
        public int pagee = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localstoreg.GetItemAsync<Guid>("Id_Person"));
            NameCompanty = await companyService.GetNameCompany(person.Id_Company);
            transactions = (await transactionService.GetTransactions_IdCompany(person.Id_Company)).ToList();
            await localstoreg.SetItemAsync<Client>("Client_Transaction", null);
            await localstoreg.SetItemAsync<Product>("Product_Transaction", null);
            await localstoreg.SetItemAsync<Guid>("Id_Transaction",Guid.Empty);
            foreach(var trans in transactions)
            {
                strcli.Add(await clientService.GetClientname(trans.Id_Client));
                strpro.Add(await productService.GetProductName(trans.Id_Product));
            }
        }
        protected async Task GoToAddTransaction()
        {
            navigate.NavigateTo("./AddTransaction");
        }
        protected async Task GoToMenu()
        {
            navigate.NavigateTo("./Main_Menu");
        }
        protected async Task GoToProducts()
        {
            navigate.NavigateTo("./ListProduct");
        }
        protected async Task GoToClient()
        {
            navigate.NavigateTo("./ListClient");
        }
        protected async Task GoToOperation()
        {
            navigate.NavigateTo("./Operation");
        }
        protected async Task GoToRedact(Guid Id_Transaction)
        {
            await localstoreg.SetItemAsync("Id_Transaction", Id_Transaction);
            navigate.NavigateTo("./RedactTransaction");
        }
        protected async Task GoToProfil()
        {
            navigate.NavigateTo("./Profil");
        }
        protected async Task GoToWorkTask()
        {
            navigate.NavigateTo("./WorkTask");
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
    }
    public class ObjClient
    {
        public Guid Id { get; set; }
        public string client { get; set; }
    }
}
