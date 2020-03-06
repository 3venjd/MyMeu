using MEU.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MEU.Prims.ViewModels
{
    public class VoysPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ClientResponse _client;
        private ObservableCollection<VoysItemViewModel> _voys;

        public VoysPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
        public ObservableCollection<VoysItemViewModel> Voys
         {
             get => _voys;
             set => SetProperty(ref _voys, value);
         }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("client"))
            {
                _client = parameters.GetValue<ClientResponse>("client");
                Title = $"{_client.FullName}";
                Voys = new ObservableCollection<VoysItemViewModel>(_client.Company.Voys.Select(v => new VoysItemViewModel(_navigationService)
                {
                    Altitude = v.Altitude,
                    Account = v.Account,
                    Cargo = v.Cargo,
                    Cargo_Charterer = v.Cargo_Charterer,
                    Consignee = v.Consignee,
                    Contract = v.Contract,
                    Eta = v.Eta,
                    Etb = v.Etb,
                    Etc = v.Etc,
                    Etd = v.Etd,
                    Facility = v.Facility,
                    Id = v.Id,
                    LastKnowPosition = v.LastKnowPosition, 
                    Latitude = v.Latitude,
                    Laycan = v.Laycan,
                    Opinions = v.Opinions,
                    Owner_Charterer = v.Owner_Charterer,
                    Pod = v.Pod,
                    Pol = v.Pol,
                    Port = v.Port,
                    Sf = v.Sf,
                    Shipper = v.Shipper,
                    Statuses = v.Statuses,
                    Vessel = v.Vessel,
                    Voyimages = v.Voyimages,
                    Voy_number = v.Voy_number,
                    Employee = v.Employee
                    
                }).ToList());


            }
        }

        
    }
}
