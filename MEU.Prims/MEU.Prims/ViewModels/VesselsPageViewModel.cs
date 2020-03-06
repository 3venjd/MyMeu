using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MEU.Prims.ViewModels
{
    public class VesselsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _Voyscommand;

        public VesselsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand VoysCommand => _Voyscommand ?? (_Voyscommand = new DelegateCommand(Voys));

        public async void Voys()
        {
            await _navigationService.NavigateAsync("VoysPage");
        }
    }
}
