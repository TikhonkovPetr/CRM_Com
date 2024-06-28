using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Add_Pages
{
    public partial class Add_Product
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
        public string cost;
        public string name;
        public Person person;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await PersonService.GetPersonId(await LocalStorage.GetItemAsync<Guid>("Id_Person"));
        }
        protected async void CreateProduct()
        {
            if (person != null && name != "" && cost != "")
            {
                if(cost[cost.Length - 1] != '₽' || cost[cost.Length - 1] != '$' || cost[cost.Length - 1] != '€')
                {
                    cost += "₽";
                }
                Guid IdObj=Guid.NewGuid();
                await ProductService.PostProduct(IdObj, person.Id_Company, name, cost);
                await HistoryService.PostHistory(Guid.NewGuid(),person.Id,person.Id_Company,IdObj, "Добавил продукт", DateTime.Now);
                navigate.NavigateTo("./ListProduct");
            }
        }
        protected async void Back()
        {
            await LocalStorage.SetItemAsync("Id_Product", Guid.Empty);
            navigate.NavigateTo("./ListProduct");
        }
    }
}
