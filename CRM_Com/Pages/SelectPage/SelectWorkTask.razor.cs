using Blazored.LocalStorage;
using CRM_Com.Pages.Work_Pages;
using CRM_Com.Services;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;
using System;

namespace CRM_Com.Pages.SelectPage
{
    public partial class SelectWorkTask
    {
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public IWorkTaskService workTaskService { get; set; }
        public List<Models.WorkTask> workTasks = new List<Models.WorkTask>();
        public List<string> SenderStr= new List<string>();
        public List<string> PersonStr= new List<string>();
        public int pagee = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            workTasks = (await workTaskService.GetWorkTasks_IdCompany(await localStorage.GetItemAsync<Guid>("Id_Company"))).ToList();
            foreach(var work in workTasks)
            {
                SenderStr.Add(await personService.GetPersonName(work.Id_Sender));
                PersonStr.Add(await personService.GetPersonName(work.Id_Person));
            }
            await localStorage.SetItemAsync<Guid>("Id_Work", Guid.Empty);
            await localStorage.SetItemAsync<Person>("WorkTask_Select", new Person());
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
        protected async void Select(Models.WorkTask workTask)
        {
            await localStorage.SetItemAsync<Models.WorkTask>("WorkTask_Select", workTask);
            await localStorage.SetItemAsync<Guid>("Id_Work", workTask.Id);
            await localStorage.SetItemAsync<Person>("Person_Work", await personService.GetPersonId(workTask.Id_Person));
            navigation.NavigateTo("./RedactWorkTask");
        }
        protected async void Back()
        {
            navigation.NavigateTo("./Profil");
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
    }
}
