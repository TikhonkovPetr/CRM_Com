using Blazored.LocalStorage;
using CRM_Com.Services;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class ListHistory
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
        public IHistoryService historyService { get; set; }
        [Inject]
        public IClientService clientService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        public Person person = null;
        public List<History> histories{get; set;}
        public string NameCompanty = "";
        public int pagee = 0;
        public List<string> objStr= new List<string>();
        public List<string> chenStr= new List<string>();
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            person = await personService.GetPersonId(await localstoreg.GetItemAsync<Guid>("Id_Person"));
            NameCompanty = await companyService.GetNameCompany(person.Id_Company);
            histories = (await historyService.GetHistoryIdCompany(person.Id_Company)).ToList();
            await localstoreg.SetItemAsync<Guid>("Id_History", Guid.Empty);
            foreach (var item in histories)
            {
                if (item.Action == "Добавил покупку")
                {
                    objStr.Add((await productService.GetProduct_Id(item.Id_Object)).Name);
                    chenStr.Add(await clientService.GetClientname(item.Id_Changeling));
                }
                else if (item.Action == "Обновил покупку")
                {
                    objStr.Add((await productService.GetProduct_Id(item.Id_Object)).Name);
                    chenStr.Add(await clientService.GetClientname(item.Id_Changeling));
                }
                else if (item.Action == "Обновил продукт")
                {
                    objStr.Add((await productService.GetProduct_Id(item.Id_Object)).Name);
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
                else if (item.Action == "Добавил продукт")
                {
                    objStr.Add((await productService.GetProduct_Id(item.Id_Object)).Name);
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
                else if (item.Action == "Добавил клиента")
                {
                    objStr.Add(await clientService.GetClientname(item.Id_Object));
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
                else if (item.Action == "Обновил клиента")
                {
                    objStr.Add(await clientService.GetClientname(item.Id_Object));
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
                else if (item.Action == "Добавил задачу" || item.Action == "Обновил задачу" || item.Action == "Завершил задачу")
                {
                    objStr.Add((await personService.GetPersonId(item.Id_Object)).Name);
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
                else if(item.Action == "Добавил работника")
                {
                    objStr.Add((await personService.GetPersonId(item.Id_Object)).Name);
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
                else
                {
                    objStr.Add(await clientService.GetClientname(item.Id_Object));
                    chenStr.Add((await personService.GetPersonId(item.Id_Changeling)).Name);
                }
            }
        }
        protected async Task GoToAddTransaction()
        {
            navigate.NavigateTo("./AddTransaction");
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
        protected async Task GoToInfo(Guid Id_History)
        {
            await localstoreg.SetItemAsync("Id_History", Id_History);
            navigate.NavigateTo("./InfoHistory");
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
