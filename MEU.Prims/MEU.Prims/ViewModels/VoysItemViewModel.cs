using MEU.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Prims.ViewModels
{
    public class VoysItemViewModel : VoyResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _detailcommand;

        public VoysItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand VoytoDetailCommand => _detailcommand ?? (_detailcommand = new DelegateCommand(VoysDetails));

        public async void VoysDetails()
        {
            var parameters = new NavigationParameters
            {
                { "voy", this }
            };
            await _navigationService.NavigateAsync("VoysDetailsPage",parameters);
        }

    }
}
