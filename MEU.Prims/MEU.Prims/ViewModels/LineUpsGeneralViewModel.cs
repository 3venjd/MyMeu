using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MEU.Prims.ViewModels
{
    public class LineUpsGeneralViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _GentoDetacommand;

        public LineUpsGeneralViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand GenDetommand => _GentoDetacommand ?? (_GentoDetacommand = new DelegateCommand(GentoDet));

        public async void GentoDet()
        {
            await _navigationService.NavigateAsync("LineUpsDetailPage");
        }

    }
}
