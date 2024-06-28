using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages
{
    public partial class Home :ComponentBase
    {
        [Inject]
        NavigationManager navMeneger { get; set; }
        [Inject]
        public ILocalStorageService localStoreg {  get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public ICompanyService companyService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public IClientService clientService { get; set; }
        [Inject]
        public IWorkTaskService workTaskService { get; set; }
        [Inject]
        public ITransactionService transactionService { get; set; }
        public Guid hId = Guid.Empty;
        public IEnumerable<Company> companies = new List<Company>();
        public IEnumerable<Person> Persons = new List<Person>();

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            hId = await localStoreg.GetItemAsync<Guid>("Id");
            Persons = await personService.GetPersonId_User(hId);
            companies = await companyService.GetCompany();
            if(await localStoreg.GetItemAsync<Guid>("Id_Person") != Guid.Empty)
            {
                GotoMenu(await personService.GetPersonId(await localStoreg.GetItemAsync<Guid>("Id_Person")));
            }
        }
        protected string GetComp(Guid Id)
        {
            return companies.FirstOrDefault(com => com.Id == Id).Name;
        }
        protected async void GotoMenu(Person person)
        {
            await localStoreg.SetItemAsync<Guid>("Id_Person", person.Id);
            await localStoreg.SetItemAsync<Guid>("Id_Company", person.Id_Company);
            navMeneger.NavigateTo("./Main_Menu");
        }
        protected async Task ExitAccaunt()
        {
            await localStoreg.ClearAsync();
            navMeneger.NavigateTo("./");
        }
    }
}
