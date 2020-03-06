using Prism.Commands;
using Prism.Navigation;

namespace MEU.Prims.ViewModels
{
    public class OfficesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _officetodetails;

        public OfficesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand FullStyleToOfficeCommand => _officetodetails ?? (_officetodetails = new DelegateCommand(OfficeDetails));

        private async void OfficeDetails()
        {
            await _navigationService.NavigateAsync("OfficeDetailsPage");
        }
    }
}
