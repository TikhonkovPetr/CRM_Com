using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CRM_Com.Pages
{
    public partial class Registration
    {
        [Inject]
        NavigationManager navMeneger { get; set; }
        [Inject]
        public IUserService userService { get; set; }
        [Inject]
        public ILocalStorageService localStoreg { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public bool Err = false;
        private async void NavToHome()
        {
            bool such = await userService.AuthCheck(login);
            if (!such)
            {
                await userService.Auntitification(login, password);
                Thread.Sleep(2000);
                await localStoreg.SetItemAsync("Id",await userService.Auth(login,password));
                navMeneger.NavigateTo("./Home");
            }
            else
            {
                Err = true;
                Console.WriteLine("Err in Reg");
            }
        }
        private void NavToLogin()
        {
            navMeneger.NavigateTo("./");
        }
    }
}
