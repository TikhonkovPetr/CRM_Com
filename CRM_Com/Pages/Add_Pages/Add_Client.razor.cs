using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Add_Pages
{
    public partial class Add_Client
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public IClientService ClientService { get; set; }
        [Inject]
        public IPersonService PersonService { get; set; }
        [Inject]
        public IHistoryService HistoryService { get; set; }
        [Inject]
        public NavigationManager navigate {  get; set; }
        public string number;
        public string name;
        public string status;
        public string description;
        public Person person;
        public List<string> values = new List<string>() { "Активный покупатель", "Новый клиен", "Низкая актвиность" };
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await PersonService.GetPersonId(await LocalStorage.GetItemAsync<Guid>("Id_Person"));
        }
        protected async void CreateClient()
        {
            if(person!=null && name!="" && number!="" && status!="" && description != "")
            {
                Guid idObj = Guid.NewGuid();
                await ClientService.PostClient(idObj,person.Id_Company,name,number,status,description);
                await HistoryService.PostHistory(Guid.NewGuid(),person.Id,person.Id_Company, idObj, "Добавил клиента",DateTime.Now.ToUniversalTime());
                navigate.NavigateTo("./ListClient");
            } 
        }
        protected async void Back()
        {
            await LocalStorage.SetItemAsync("Id_Client",Guid.Empty);
            navigate.NavigateTo("./ListClient");
        }
    }
}
