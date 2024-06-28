using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Redact_Pages
{
    public partial class Redact_Product
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IPersonService PersonService { get; set; }
        [Inject]
        public IHistoryService HistoryService { get; set; }
        [Inject]
        public NavigationManager navigate { get; set; }
        Guid id = Guid.Empty;
        public Person person;
        public Product product = new Product();
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await PersonService.GetPersonId(await LocalStorage.GetItemAsync<Guid>("Id_Person"));
            id = await LocalStorage.GetItemAsync<Guid>("Id_Product");
            if (id != Guid.Empty) product = await ProductService.GetProduct_Id(await LocalStorage.GetItemAsync<Guid>("Id_Product"));
        }
        protected async void UpdateClient()
        {
            if (person != null && product.Name != "" && product.cost != "")
            {
                await ProductService.UpdateProduct(product.Id, person.Id_Company, product.Name, product.cost);
                await HistoryService.PostHistory(Guid.NewGuid(),person.Id,person.Id_Company,product.Id, "Обновил продукт", DateTime.Now);
                navigate.NavigateTo("./ListProduct");
            }
        }
        protected async void Back()
        {
            await LocalStorage.SetItemAsync<Guid>("Id_Product", Guid.Empty);
            navigate.NavigateTo("./ListProduct");
        }
        protected async void DelClient()
        {
            if (await LocalStorage.GetItemAsync<Guid>("Id_Product") != Guid.Empty)
            {
                ProductService.DeleteProduct(await LocalStorage.GetItemAsync<Guid>("Id_Product"));
                Back();
            }
        }
    }
}
