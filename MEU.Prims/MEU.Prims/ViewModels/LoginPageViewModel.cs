using MEU.Common.Models;
using MEU.Common.Services;
using Prism.Commands;
using Prism.Navigation;

namespace MEU.Prims.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isenable;
        private bool _isrunning;
        private DelegateCommand _logincommand;


        public LoginPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            IsEnable = true;
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsEnable
        {
            get => _isenable;
            set => SetProperty(ref _isenable, value);
        }

        public bool IsRunning
        {
            get => _isrunning;
            set => SetProperty(ref _isrunning, value);
        }

        public DelegateCommand LoginCommand => _logincommand ?? (_logincommand = new DelegateCommand(Login));

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "you must enter an email", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "you must enter an Password", "Accept");
                return;
            }



            IsRunning = true;
            IsEnable = false;

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnectionAsync(url);

            if (!connection)
            {
                IsEnable = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection", "Accept");
                return;

            }

            var request = new TokenRequest
            {
                Password = Password,
                UserName = Email
            };

           
            var response = await _apiService.GetTokenAsync(url,"/Account","/CreateToken",request);

            IsRunning = false;
            IsEnable = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error","User or password incorrect","Acept");
                Password = string.Empty;
                return;
            }

            var token = response.Result;
            var response2 = await _apiService.GetClientByEmailAsync(
                    url,
                    "api",
                    "/Clients/GetClientByEmail",
                    "bearer",
                    token.Token,
                    Email
                );

            

            if (!response2.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert("Error","Problem with user data,please contact the administration","Accept");
                return;
                
            }

            var client = response2.Result;
            var parameters = new NavigationParameters
            {
                { "client", client }
            };

            await App.Current.MainPage.DisplayAlert("Welcome", "Your Vessels is arriving", "Accept");
            await _navigationService.NavigateAsync("/MEUMasterDetailPage/NavigationPage/VoysPage", parameters);
        }
    }
}
