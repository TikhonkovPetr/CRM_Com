using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.SelectPage
{
    public partial class SelectListProduct
    {
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        public List<Product> products=new List<Product>();
        public int pagee = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            products = (await productService.GetProduct_Id_Company(await localStorage.GetItemAsync<Guid>("Id_Company"))).ToList();
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
        protected async void Select(Product product)
        {
            await localStorage.SetItemAsync<Product>("Product_Transaction", product);
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
                await localStorage.SetItemAsync<Product>("Product_Transaction", null);
                navigation.NavigateTo("./AddTransaction");
            }
            else
            {
                navigation.NavigateTo("./RedactTransaction");
            }
        }
    }
}
