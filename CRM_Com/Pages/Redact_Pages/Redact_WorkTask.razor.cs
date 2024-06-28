using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;
using System;

namespace CRM_Com.Pages.Redact_Pages
{
    public partial class Redact_WorkTask
    {
        [Inject]
        public ILocalStorageService storageService { get; set; }
        [Inject]
        public IHistoryService historyService { get; set; }
        [Inject]
        public NavigationManager navigat { get; set; }
        [Inject]
        public IWorkTaskService workTaskService { get; set; }
        public WorkTask workTask = new WorkTask();
        public string message = "";
        public Person person = new Person() {Name="" };
        public bool isCompleted = false;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if (await storageService.GetItemAsync<Guid>("Id_Work") != null)
            {
                workTask = await workTaskService.GetWorkTask_Id(await storageService.GetItemAsync<Guid>("Id_Work"));
                person = await storageService.GetItemAsync<Person>("Person_Work");
                message = workTask.message;
            }
        }
        protected async void Back()
        {
            await storageService.SetItemAsync<Person>("Person_Work", null);
            await storageService.SetItemAsync<Guid>("Id_Work", Guid.Empty);
            navigat.NavigateTo("./Profil");
        }
        protected async void SelectWorkTask()
        {
            navigat.NavigateTo("./SelectListPerson");
        }
        protected async void RedactWorkTask()
        {
            await workTaskService.PatchWorkTask(workTask.Id, person.Id_Company, person.Id, await storageService.GetItemAsync<Guid>("Id_Person"), message, isCompleted);
            await historyService.PostHistory(Guid.NewGuid(), await storageService.GetItemAsync<Guid>("Id_Person"), person.Id_Company, person.Id, "Обновил задачу", DateTime.Now);
            if(isCompleted)await historyService.PostHistory(Guid.NewGuid(), await storageService.GetItemAsync<Guid>("Id_Person"), person.Id_Company, person.Id, "Завершил задачу", DateTime.Now);
            Back();
        }
    }
}
