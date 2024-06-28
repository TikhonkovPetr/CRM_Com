using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Redact_Pages
{
    public partial class Redact_Client
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
        public NavigationManager navigate { get; set; }
        Guid id = Guid.Empty;
        public Person person;
        public Client client = new Client();
        public List<string> values = new List<string>() { "Активный покупатель", "Новый клиен", "Низкая актвиность" };
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await PersonService.GetPersonId(await LocalStorage.GetItemAsync<Guid>("Id_Person"));
            id = await LocalStorage.GetItemAsync<Guid>("Id_Client");
            if (id!=Guid.Empty) client = await ClientService.GetClient_Id(await LocalStorage.GetItemAsync<Guid>("Id_Client"));
        }
        protected async void UpdateClient()
        {
            if (person != null && client.Name != "" && client.Number != "" && client.Status != "" && client.Description != "")
            {
                await ClientService.UpdateClient(client.Id, person.Id_Company, client.Name, client.Number, client.Status, client.Description);
                await HistoryService.PostHistory(Guid.NewGuid(),person.Id,person.Id_Company,client.Id, "Обновил клиента",DateTime.Now);
                navigate.NavigateTo("./ListClient");
            }
        }
        protected async void Back()
        {
            await LocalStorage.SetItemAsync<Guid>("Id_Client", Guid.Empty);
            navigate.NavigateTo("./ListClient");
        }
        protected async void DelClient()
        {
            if (await LocalStorage.GetItemAsync<Guid>("Id_Client") != Guid.Empty)
            {
                ClientService.DeleteClient(await LocalStorage.GetItemAsync<Guid>("Id_Client"));
                Back();
            }
        }
    }
}
