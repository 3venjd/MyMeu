using MEU.Common.Models;
using MEU.Common.Services;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace MEU.Prims.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        private ClientResponse _client;
       

        public NewsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "News:";
        }

       

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("client"))
            {
                _client = parameters.GetValue<ClientResponse>("client");
                Title = $"{_client.FullName}";
            }
        }
    }
}
