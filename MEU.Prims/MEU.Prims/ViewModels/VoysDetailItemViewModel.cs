using MEU.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEU.Prims.ViewModels
{
    public class VoysDetailItemViewModel : VoyResponse
    {

        private readonly INavigationService _navigationService;
        private DelegateCommand _tostatuscommand;

        public VoysDetailItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand VoysDetailtoStatusCommand => _tostatuscommand ?? (_tostatuscommand = new DelegateCommand(Status));


        public async void Status()
        {
            var parameters = new NavigationParameters
            {
                { "voy", this }
            };
            await _navigationService.NavigateAsync("StatusPage", parameters);
        }

        
    }
}
