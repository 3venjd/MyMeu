using MEU.Common.Models;
using Prism.Navigation;
using System.Collections.Generic;

namespace MEU.Prims.ViewModels
{

    public class StatusPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        //private DelegateCommand _holds;

        private VoyResponse _voy;

        public StatusPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Data1 = new List<Hold>()
            {
                new Hold { Number = 8 , Quantity = 600000 },
                new Hold { Number = 7 , Quantity = 600000 },
                new Hold { Number = 6 , Quantity = 600000 },
                new Hold { Number = 5 , Quantity = 600000 },
                new Hold { Number = 4 , Quantity = 600000 },
                new Hold { Number = 3 , Quantity = 600000 },
                new Hold { Number = 2 , Quantity = 600000 },
                new Hold { Number = 1 , Quantity = 600000 },

            };

            Data2 = new List<Hold>()
            {
                new Hold { Number = 8 , Quantity = 220000 },
                new Hold { Number = 7 , Quantity = 120000 },
                new Hold { Number = 6 , Quantity = 320000 },
                new Hold { Number = 5 , Quantity = 200000 },
                new Hold { Number = 4 , Quantity = 140000 },
                new Hold { Number = 3 , Quantity = 90000 },
                new Hold { Number = 2 , Quantity = 310000 },
                new Hold { Number = 1 , Quantity = 70000 },

            };
            _navigationService = navigationService;
        }

        public List<Hold> Data1 { get; set; }

        public List<Hold> Data2 { get; set; }



        /*public DelegateCommand PHoldsCommand => _holds ?? (_holds = new DelegateCommand(poblateholds));


        private void  poblateholds()
        {
            Data = new List<Hold>()
            {
                new Hold { Number = 1 , Quantity = 350000 },
                new Hold { Number = 2 , Quantity = 450000 },
                new Hold { Number = 3 , Quantity = 500000 },
                new Hold { Number = 4 , Quantity = 250000 },

            };
        }*/

        public VoyResponse Voy
        {
            get => _voy;
            set => SetProperty(ref _voy, value);

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
    public class Hold
    {
        public int Number { get; set; }

        public double Quantity { get; set; }
    }


}
