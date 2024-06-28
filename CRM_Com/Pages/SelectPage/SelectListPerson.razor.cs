using Blazored.LocalStorage;
using CRM_Com.Services;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.SelectPage
{
    public partial class SelectListPerson
    {
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        public List<Person> person = new List<Person>();
        public int pagee = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = (await personService.GetPerson_IdCompany(await localStorage.GetItemAsync<Guid>("Id_Company"))).ToList();
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
        protected async void Select(Person person)
        {
            await localStorage.SetItemAsync<Person>("Person_Work", person);
            if (await localStorage.GetItemAsync<Guid>("Id_Work") == Guid.Empty)
            {
                navigation.NavigateTo("./AddWorkTask");
            }
            else
            {
                navigation.NavigateTo("./RedactWorkTask");
            }
        }
        protected async void Back()
        {
            if (await localStorage.GetItemAsync<Guid>("Id_Work") == Guid.Empty)
            {
                await localStorage.SetItemAsync<Person>("Person_Work", null);
                navigation.NavigateTo("./AddWorkTask");
            }
            else
            {
                navigation.NavigateTo("./RedactWorkTask");
            }
        }
    }
}
