using Blazored.LocalStorage;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class ListProduct
    {
        [Inject]
        public NavigationManager navigate { get; set; }
        [Inject]
        public ILocalStorageService localstoreg { get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public ICompanyService companyService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        public Person person = null;
        public List<Product> products = new List<Product>();
        public string NameCompanty = "";
        public int pagee = 0;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localstoreg.GetItemAsync<Guid>("Id_Person"));
            NameCompanty = await companyService.GetNameCompany(person.Id_Company);
            products = (await productService.GetProduct_Id_Company(person.Id_Company)).ToList();
        }
        protected async Task GoToAddProduct()
        {
            navigate.NavigateTo("./AddProduct");
        }
        protected async Task GoToMenu()
        {
            navigate.NavigateTo("./Main_Menu");
        }
        protected async Task GoToProducts()
        {
            navigate.NavigateTo("./ListProduct");
        }
        protected async Task GoToClient()
        {
            navigate.NavigateTo("./ListClient");
        }
        protected async Task GoToOperation()
        {
            navigate.NavigateTo("./Operation");
        }
        protected async Task GoToRedact(Guid Id_Product)
        {
            Console.WriteLine(Id_Product);
            await localstoreg.SetItemAsync("Id_Product", Id_Product);
            navigate.NavigateTo("./RedactProduct");
        }
        protected async Task GoToProfil()
        {
            navigate.NavigateTo("./Profil");
        }
        protected async Task GoToWorkTask()
        {
            navigate.NavigateTo("./WorkTask");
        }
        protected void muvPage(int i)
        {
            pagee += i;
        }
    }
}
