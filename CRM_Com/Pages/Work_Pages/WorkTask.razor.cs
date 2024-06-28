using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class WorkTask
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
        [Inject]
        public IHistoryService historyService { get; set; }
        public Person person = null;
        public List<Models.WorkTask> workTasks = new List<Models.WorkTask>();
        public List<Models.WorkTask> workTasksComplit = new List<Models.WorkTask>();
        public List<Models.WorkTask> workTasksUnComplit = new List<Models.WorkTask>();
        public List<string> sendersComplitName= new List<string>();
        public List<string> sendersUnComplitName = new List<string>();
        public string NameCompanty = "";
        public int pagee1 = 0;
        public int pagee2 = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localstoreg.GetItemAsync<Guid>("Id_Person"));
            NameCompanty = await companyService.GetNameCompany(person.Id_Company);
            workTasks = (await workTaskService.GetWorkTasks_IdPerson(person.Id)).ToList();
            foreach (var workTask in workTasks)
            {
                if (workTask.IsCompleted)
                {
                    workTasksComplit.Add(workTask);
                    sendersComplitName.Add(await personService.GetPersonName(workTask.Id_Sender));
                }
                else
                {
                    workTasksUnComplit.Add(workTask);
                    sendersUnComplitName.Add(await personService.GetPersonName(workTask.Id_Sender));
                }
                
            }
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
        protected string GetMes(string mes)
        {
            if (mes.Count() > 47)
            {
                string s = "";
                for (int i = 0; i < 45; i++)
                {
                    s += mes[i];
                }
                s += "...";
                return s;
            }
            return mes;
        }
        protected void muvPage1(int i)
        {
            pagee1 += i;
        }
        protected void muvPage2(int i)
        {
            pagee2 += i;
        }
        protected async Task GoToProfil()
        {
            navigate.NavigateTo("./Profil");
        }
        protected async Task GoToWorkTask()
        {
            navigate.NavigateTo("./WorkTask");
        }
        protected async Task EndWorkTask(Models.WorkTask work)
        {
            workTasksUnComplit.Remove(work);
            await workTaskService.PatchWorkTask(work.Id,work.Id_Company,work.Id_Person,work.Id_Sender,work.message,true);
            await historyService.PostHistory(Guid.NewGuid(),person.Id,person.Id_Company,person.Id,"Завершил задачу",DateTime.Now);
        }
    }
}
