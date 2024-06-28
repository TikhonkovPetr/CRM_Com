using Blazored.LocalStorage;
using CRM_Com.Services;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Models;

namespace CRM_Com.Pages.Work_Pages
{
    public partial class InfoHistory
    {
        [Inject]
        public ILocalStorageService localStorage {  get; set; }
        [Inject]
        public NavigationManager navigate {  get; set; }
        [Inject]
        public IHistoryService historyService { get; set; }
        [Inject]
        public IClientService clientService { get; set; }
        [Inject]
        public IPersonService personService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        public string nameObj = "";
        public string objChang = "";
        public History history = null;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            history = await historyService.GetHistory_Id(await localStorage.GetItemAsync<Guid>("Id_History"));
            if (history != null)
            {
                if (history.Action == "Добавил покупку")
                {
                    nameObj = (await productService.GetProduct_Id(history.Id_Object)).Name;
                    objChang = await clientService.GetClientname(history.Id_Changeling);
                }
                else if (history.Action == "Обновил покупку")
                {
                    nameObj = (await productService.GetProduct_Id(history.Id_Object)).Name;
                    objChang = await clientService.GetClientname(history.Id_Changeling);
                }
                else if (history.Action == "Обновил продукт")
                {
                    nameObj = (await productService.GetProduct_Id(history.Id_Object)).Name;
                    objChang = (await personService.GetPersonId(history.Id_Changeling)).Name;
                }
                else if (history.Action == "Добавил продукт")
                {
                    nameObj = (await productService.GetProduct_Id(history.Id_Object)).Name;
                    objChang = (await personService.GetPersonId(history.Id_Changeling)).Name;
                }
                else if (history.Action == "Добавил клиента")
                {
                    nameObj = await clientService.GetClientname(history.Id_Object);
                    objChang = (await personService.GetPersonId(history.Id_Changeling)).Name;
                }
                else if (history.Action == "Обновил клиента")
                {
                    nameObj = await clientService.GetClientname(history.Id_Object);
                    objChang = (await personService.GetPersonId(history.Id_Changeling)).Name;
                }
                else if (history.Action == "Добавил задачу" || history.Action== "Обновил задачу" || history.Action == "Завершил задачу")
                {
                    nameObj = (await personService.GetPersonId(history.Id_Object)).Name;
                    objChang = (await personService.GetPersonId(history.Id_Changeling)).Name;
                }
                else if (history.Action == "Добавил работника")
                {
                    nameObj=(await personService.GetPersonId(history.Id_Object)).Name;
                    objChang=(await personService.GetPersonId(history.Id_Changeling)).Name;
                }
                else
                {
                    nameObj = await clientService.GetClientname(history.Id_Object);
                    objChang = (await personService.GetPersonId(history.Id_Changeling)).Name;
                }
            }
            else
            {
                nameObj = "Не найдено";
                objChang = "Не найдено";
            }
        }
        protected async void Back()
        {
            await localStorage.SetItemAsync("Id_History", Guid.Empty);
            navigate.NavigateTo("./ListHistory");
        }
    }
}
