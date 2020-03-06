using MEU.Common.Models;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MEU.Prims.ViewModels
{
    public class MEUMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MEUMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_Vessel.png",
                    PageName = "VoysPage",
                    Title = "YOUR VOYS",
                },
                new Menu
                {
                    Icon = "ic_Lineups.png",
                    PageName = "PortsPage",
                    Title = "PORTS",
                },
                new Menu
                {
                    Icon = "ic_News.png",
                    PageName = "NewsPage",
                    Title = "News",
                },
                new Menu
                {
                    Icon = "ic_FullStyle.png",
                    PageName = "OfficesPage",
                    Title = "OUR OFFICES",
                },
                new Menu
                {
                    Icon = "ic_FullStyle.png",
                    PageName = "RatePage",
                    Title = "OUR OFFICES",
                },
                new Menu
                {
                    Icon = "ic_Exit.png",
                    PageName = "LoginPage",
                    Title = "LOGOUT",
                },
            };

            Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel(_navigationService)
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
                 
            }).ToList());
        }

    }
}
