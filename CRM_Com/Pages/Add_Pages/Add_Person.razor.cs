using Blazored.LocalStorage;
using CRM_Com.Services;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Add_Pages
{
    public partial class Add_Person
    {
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public ILocalStorageService localStorageService { get; set; }
        [Inject]
        public IHistoryService historyService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public Guid Id_User_Person= Guid.Empty;
        public string Name = "";
        public string Dostup = "";
        public Person person = new Person();
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localStorageService.GetItemAsync<Guid>("Id_Person"));
        }
        public async Task CreatePerson()
        {
            if(Id_User_Person!=Guid.Empty && Name!="" && Dostup != "")
            {
                Guid obj=Guid.NewGuid();
                await personService.CreatePerson(obj,Id_User_Person,person.Id_Company,Name,Dostup);
                await historyService.PostHistory(Guid.NewGuid(),person.Id,person.Id_Company,obj, "Добавил работника",DateTime.Now);
            }
            navigationManager.NavigateTo("./Profil");
        }
        public async Task Back()
        {
            navigationManager.NavigateTo("./Profil");
        }

    }
}
