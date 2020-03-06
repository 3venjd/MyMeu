using MEU.web.Data.Entities;
using MEU.web.Models;
using System.Threading.Tasks;

namespace MEU.web.Helpers
{
    public interface IConverterHelper
    {
        Task<Vessel> ToVesselAsync(VesselViewModel mode,string path, bool isNew);

        VesselViewModel ToVesselViewModel(Vessel vessel);

        Task<Terminal> ToTerminalAsync(TerminalViewModel mode,string path, bool isNew);

        TerminalViewModel ToTerminalViewModel(Terminal terminal);

        Task<Voy> ToVoyAsync(VoysViewModel mode, bool isNew);

        VoysViewModel ToVoyViewModel(Voy voy);

        Task<Opinion> ToOpinionAsync(OpinionViewModel mode, bool isNew);

        OpinionViewModel ToOpinionViewModel(Opinion terminal);

        Task<Status> ToStatusAsync(StatusViewModel model, bool v);

        StatusViewModel ToStatusViewModel(Status statuses);

        Task<Hold> ToHoldAsync(HoldViewModel model, bool v);

        HoldViewModel ToHoldViewModel(Hold hold);

        Task<Alert> ToAlertAsync(AlertsViewModel model, bool v);

        AlertsViewModel ToAlertViewModel(Alert alert);
        
        Task<AlertImage> ToAlertImageAsync(AlertImageViewModel model,string path, bool v);

        AlertImageViewModel ToAlertImageViewModel(AlertImage alertimg);

        Task<Voyimage> ToVoyImageAsync(VoyImageViewModel model,string path, bool v);

        VoyImageViewModel ToVoyImageViewModel(Voyimage voyimg);

        Task<NewImage> ToNewImageAsync(NewsImageViewModel model, string path, bool v);

        NewsImageViewModel ToNewImageViewModel(NewImage newimg);

        Task<Port> ToPortAsync(PortViewModel model, string path, bool v);

        PortViewModel ToPortViewModel(Port port);

        Task<LineUp> ToLineUpAsync(LineUpViewModel model, bool v);

        LineUpViewModel ToLineUpViewModel(LineUp lineup);
    }
}
