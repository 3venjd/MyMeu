using MEU.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Linq;

namespace MEU.Prims.ViewModels
{
    public class VoysDetailsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _tostatuscommand;
        private VoyResponse _voy;

        public VoysDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
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
        public VoyResponse Voy 
        {
            get => _voy;
            set => SetProperty(ref _voy,value);

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("voy"))
            {
                Voy = parameters.GetValue<VoyResponse>("voy");
                Title = $"{Voy.Vessel.Vessel_Name}";
            }
        }
    }
}
