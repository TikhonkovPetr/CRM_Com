using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;
using System;
using System.Formats.Tar;

namespace CRM_Com.Pages.SelectPage
{
    public partial class SelectClient
    {
        [Inject]
        public ILocalStorageService localStorage {  get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public IClientService clientService { get; set; }
        public List<Client> clients =new List<Client>();
        public int pagee=0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            clients = (await clientService.GetClient_Id_Company(await localStorage.GetItemAsync<Guid>("Id_Person"))).ToList();
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
        protected async void Select(Client client)
        {
            await localStorage.SetItemAsync<Client>("Client_Transaction", client);
            if (await localStorage.GetItemAsync<Guid>("Id_Transaction") == Guid.Empty)
            {
                navigation.NavigateTo("./AddTransaction");
            }
            else
            {
                navigation.NavigateTo("./RedactTransaction");
            }
        }
        protected async void Back()
        {
            if (await localStorage.GetItemAsync<Guid>("Id_Transaction") == Guid.Empty)
            {
                navigation.NavigateTo("./AddTransaction");
                await localStorage.SetItemAsync<Client>("Client_Transaction", null);
            }
            else
            {
                navigation.NavigateTo("./RedactTransaction");
            }
            
        }
    }
}
