using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class ListClient
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
        public IClientService clientService { get; set; }
        public Person person = null;
        public List<Client> clients = new List<Client>();
        public string NameCompanty = "";
        public int pagee = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localstoreg.GetItemAsync<Guid>("Id_Person"));
            NameCompanty = await companyService.GetNameCompany(person.Id_Company);
            clients = (await clientService.GetClient_Id_Company(person.Id_Company)).ToList();
        }
        protected async Task GoToAddClient()
        {
            navigate.NavigateTo("./AddClient");
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
        protected async Task GoToRedact(Guid Id_Client)
        {
            Console.WriteLine(Id_Client);
            await localstoreg.SetItemAsync("Id_Client", Id_Client);
            navigate.NavigateTo("./RedactClient");
        }
        protected async Task GoToProfil()
        {
            navigate.NavigateTo("./Profil");
        }
        protected async Task GoToWorkTask()
        {
            navigate.NavigateTo("./WorkTask");
        }
        protected string GetOpis(string desc)
        {
            if (desc.Count() > 65)
            {
                string s= "";
            for (int i = 0; i < 62; i++)
            {
                s += desc[i];
            }
            s += "...";
            return s;
            }
            return desc;
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
    }
}
