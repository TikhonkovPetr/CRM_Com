using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class InfoWorkTask
    {
        [Inject]
        public IWorkTaskService workTaskService { get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public ILocalStorageService localStorageService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public Models.WorkTask workTask = null;
        public string nameSender = "";
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            Guid Id_Work = await localStorageService.GetItemAsync<Guid>("Id_WorkTask_Info");
            if (Id_Work != Guid.Empty)
            {
                workTask = await workTaskService.GetWorkTask_Id(await localStorageService.GetItemAsync<Guid>("Id_WorkTask_Info"));
                nameSender = await personService.GetPersonName(workTask.Id_Sender);
            }
        }
        protected async Task Back()
        {
            localStorageService.SetItemAsync("Id_WorkTask_Info",Guid.Empty);
            navigationManager.NavigateTo("./WorkTask");
        }
    }
}
