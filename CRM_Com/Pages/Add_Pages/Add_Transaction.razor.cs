
using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;
using System.Dynamic;

namespace CRM_Com.Pages.Add_Pages
{
    public partial class Add_Transaction
    {
        [Inject]
        public ILocalStorageService storageService { get; set; }
        [Inject]
        public IHistoryService historyService { get; set; }
        [Inject]
        public NavigationManager navigat { get; set; }
        [Inject]
        public ITransactionService transactionService { get; set; }
        public Client client = new Client() {Name="Не выбран" };
        public int colvo = 0;
        public Product product = new Product() {Name="Не выбран", cost="0$"};
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if(await storageService.GetItemAsync<Client>("Client_Transaction") != null)
            {
                client = await storageService.GetItemAsync<Client>("Client_Transaction");
            }
            if(await storageService.GetItemAsync<Client>("Product_Transaction") != null)
            {
                product = await storageService.GetItemAsync<Product>("Product_Transaction");
            }
        }
        private double GetCostProduct(string cost)
        {
            string itogC = "";
            for (int i = 0; i < cost.Length-1; i++) 
            {
                itogC+= cost[i];
            }
            return Convert.ToDouble(itogC);
        }
        protected async void Back()
        {
            await storageService.SetItemAsync<Client>("Client_Transaction",null);
            await storageService.SetItemAsync<Product>("Product_Transaction", null);
            navigat.NavigateTo("./ListTransaction");
        }
        protected async void SelectProduct()
        {
            await storageService.SetItemAsync<Product>("Product_Transaction", null);
            navigat.NavigateTo("./SelectListProduct");
        }
        protected async void SelectClient()
        {
            await storageService.SetItemAsync<Client>("Client_Transaction", null);
            navigat.NavigateTo("./SelectListClient");
        }
        protected async void CreateTransaction()
        {
            Guid IdObj= Guid.NewGuid();
            await transactionService.PostTransaction(IdObj,await storageService.GetItemAsync<Guid>("Id_Company"),
                (await storageService.GetItemAsync<Client>("Client_Transaction")).Id, (await storageService.GetItemAsync<Product>("Product_Transaction")).Id,
                colvo, (colvo * GetCostProduct(product.cost)).ToString() + product.cost[product.cost.Length - 1]);
            await historyService.PostHistory(Guid.NewGuid(),client.Id,client.Id_Company,IdObj, "Добавил покупку", DateTime.Now);
            Back();
        }
    }
}
