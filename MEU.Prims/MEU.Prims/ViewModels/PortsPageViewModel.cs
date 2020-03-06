using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MEU.Prims.ViewModels
{
    public class PortsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _portToTerminals;
        private DelegateCommand _portToLineups;

        public PortsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand PortToTerminalCommand => _portToTerminals ?? (_portToTerminals = new DelegateCommand(Terminals));
        public DelegateCommand PorToLineUp => _portToLineups ?? (_portToLineups = new DelegateCommand(LineUps));

        private async void Terminals()
        {
            await _navigationService.NavigateAsync("TerminalsPage");
        }

        private async void LineUps()
        {
            await _navigationService.NavigateAsync("LineUpsGeneral");
        }
    }
}
