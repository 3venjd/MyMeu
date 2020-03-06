using System;
using System.Collections.Generic;
using System.Text;
using MEU.Common.Models;
using Prism.Commands;
using Prism.Navigation;

namespace MEU.Prims.ViewModels
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;
        private ClientResponse _client;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));

        private async void SelectMenu()
        {

            if (PageName.Equals("Login"))
            {
                await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                return;
            }
            await _navigationService.NavigateAsync($"/MEUMasterDetailPage/NavigationPage/{PageName}");
        }

    }
}
