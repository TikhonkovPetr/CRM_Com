using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Redact_Pages
{
    public partial class Redact_Transaction
    {
        [Inject]
        public ILocalStorageService storageService { get; set; }
        [Inject]
        public NavigationManager navigat { get; set; }
        [Inject]
        public ITransactionService transactionService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public IClientService clientService { get; set; }
        [Inject]
        public IHistoryService historyService { get; set; }
        public Client client = new Client() { Name = "Не выбран" };
        public int colvo = 0;
        public Product product = new Product() { Name = "Не выбран", cost = "0$" };
        public Transaction transaction = new Transaction() {Id_Client=Guid.Empty,Id_Product=Guid.Empty };
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if (await storageService.GetItemAsync<Guid>("Id_Transaction") != null)
            {
                transaction = await transactionService.GetTransaction_Id(await storageService.GetItemAsync<Guid>("Id_Transaction"));
                if (await storageService.GetItemAsync<Product>("Product_Transaction") == null)
                    product = await productService.GetProduct_Id(transaction.Id_Product);
                else
                    product = await storageService.GetItemAsync<Product>("Product_Transaction");
                if (await storageService.GetItemAsync<Client>("Client_Transaction") == null)
                    client = await clientService.GetClient_Id(transaction.Id_Client);
                else
                    client = await storageService.GetItemAsync<Client>("Client_Transaction");
                colvo = transaction.colvo;
            }
        }
        private double GetCostProduct(string cost)
        {
            string itogC = "";
            for (int i = 0; i < cost.Length - 1; i++)
            {
                itogC += cost[i];
            }
            return Convert.ToDouble(itogC);
        }
        protected async void Back()
        {
            await storageService.SetItemAsync<Client>("Client_Transaction", null);
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
            await transactionService.PatchTransaction(transaction.Id, transaction.Id_Company,
                client.Id, product.Id,
                colvo, (colvo * GetCostProduct(product.cost)).ToString() + product.cost[product.cost.Length - 1]);
            await historyService.PostHistory(Guid.NewGuid(),client.Id,client.Id_Company,transaction.Id, "Обновил покупку", DateTime.Now);
            Back();
        }
    }
}
