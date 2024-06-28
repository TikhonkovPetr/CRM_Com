using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Add_Pages
{
    public partial class AddWorkTask
    {
        [Inject]
        public ILocalStorageService storageService { get; set; }
        [Inject]
        public IHistoryService historyService { get; set; }
        [Inject]
        public NavigationManager navigat { get; set; }
        [Inject]
        public IWorkTaskService workTaskService { get; set; }
        public Person person = new Person();
        public string message = "";
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if (await storageService.GetItemAsync<Person>("Person_Work") != null)
            {
                person = await storageService.GetItemAsync<Person>("Person_Work");
            }
        }
        protected async void Back()
        {
            await storageService.SetItemAsync<Person>("Person_Work", null);
            navigat.NavigateTo("./Profil");
        }
        protected async void SelectWorkTask()
        {
            await storageService.SetItemAsync<Person>("Person_Work", null);
            navigat.NavigateTo("./SelectListPerson");
        }
        protected async void CreateWorkTask()
        {
            Guid IdObj = Guid.NewGuid();
            await workTaskService.PostWorkTask(IdObj, person.Id_Company,person.Id , await storageService.GetItemAsync<Guid>("Id_Person"), message);
            await historyService.PostHistory(Guid.NewGuid(), await storageService.GetItemAsync<Guid>("Id_Person"), person.Id_Company, person.Id, "Добавил задачу", DateTime.Now);
            Back();
        }
    }
}
