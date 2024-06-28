using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using CRM_Com.Services;
using Models;


namespace CRM_Com.Pages
{
    public partial class Index
    {
        
        [Inject]
        NavigationManager navMeneger {  get; set; }
        [Inject]
        public IUserService userService { get; set; }
        [Inject]
        public ILocalStorageService localStoreg {  get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public bool Err = false;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if(await localStoreg.GetItemAsync<Guid>("Id") != Guid.Empty)
            {
                navMeneger.NavigateTo("./Home");
            }
        }
        private async void NavToHome()
        {
            Guid Id = await userService.Auth(login,password);
            if (Id!=Guid.Empty)
            {
                await localStoreg.SetItemAsync("Id",Id);
                navMeneger.NavigateTo("./Home");
            }
            else
            {
                Err = true;
                Console.WriteLine("Err in Log");
            }
        }
        private void NavToReg()
        {
            navMeneger.NavigateTo("./Reg");
        }
    }
}
