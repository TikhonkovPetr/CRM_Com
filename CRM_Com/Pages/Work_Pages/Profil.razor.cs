using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class Profil
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
        public IWorkTaskService workTaskService { get; set; }
        public int complit=0;
        public int uncomplit=0;
        public Person person = null;
        public string NameCompanty = "";
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localstoreg.GetItemAsync<Guid>("Id_Person"));
            NameCompanty = await companyService.GetNameCompany(person.Id_Company);
            complit = await workTaskService.GetNumberWorkTask_IsComplit(person.Id,true);
            uncomplit = await workTaskService.GetNumberWorkTask_IsComplit(person.Id,false);
        }
        protected async Task GoToAddProduct()
        {
            navigate.NavigateTo("./AddProduct");
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
        protected async Task GoToTransaction()
        {
            navigate.NavigateTo("./ListTransaction");
        }
        protected async Task GoToHistory()
        {
            navigate.NavigateTo("./ListHistory");
        }
        protected async Task GoToProfil()
        {
            navigate.NavigateTo("./Profil");
        }
        protected async Task GoToWorkTask()
        {
            navigate.NavigateTo("./WorkTask");
        }
        protected async Task AddWorkTask()
        {
            navigate.NavigateTo("./AddWorkTask");
        }
        protected async Task RedactWorkTask()
        {
            navigate.NavigateTo("./SelectListWorkTask");
        }
        protected async Task AddPerson()
        {
            navigate.NavigateTo("./AddPerson");
        }
        protected async Task ExitAccount()
        {
            Guid UserId = await localstoreg.GetItemAsync<Guid>("Id");
            await localstoreg.ClearAsync();
            await localstoreg.SetItemAsync<Guid>("Id",UserId);
            navigate.NavigateTo("./Home");
        }
    }
}
