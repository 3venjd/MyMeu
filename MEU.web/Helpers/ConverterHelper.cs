using MEU.web.Data;
using MEU.web.Data.Entities;
using MEU.web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEU.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext,ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }
        public async Task<Vessel> ToVesselAsync(VesselViewModel model,string path, bool isNew)
        {
            return new Vessel
            {
                Vessel_Name = model.Vessel_Name,
                ImageUrl = path,
                Voys = isNew ? new List<Voy>() : model.Voys,
                Id = isNew ? 0 : model.Id,
                VesselType = await _dataContext.VesselTypes.FindAsync(model.VesselTypeId),

            };
        }

        public VesselViewModel ToVesselViewModel(Vessel vessel)
        {
            return new VesselViewModel
            {
                Vessel_Name = vessel.Vessel_Name,
                ImageUrl = vessel.ImageUrl,
                Voys = vessel.Voys,
                Id = vessel.Id,
                VesselType = vessel.VesselType,
                VesselTypes = _combosHelper.GetComboVesselType(),
            };
        }

        public async Task<Terminal> ToTerminalAsync(TerminalViewModel model,string path, bool isNew)
        {
            return new Terminal
            {
                Id = isNew ? 0 : model.Id,
                ImageUrl = path,
                Displacement = model.Displacement,
                Max_Beam = model.Max_Beam,
                Max_Draft = model.Max_Draft,
                Max_Loa = model.Max_Loa,
                Terminal_Name = model.Terminal_Name,
                Type_Cargo = model.Type_Cargo,
                Water_Density = model.Water_Density,
                Working_hours = model.Working_hours,
                Port = await _dataContext.Ports.FindAsync(model.Port_id),
                LineUps = isNew? new List<LineUp>() : model.LineUps,

            };
        }

        public TerminalViewModel ToTerminalViewModel(Terminal terminal)
        {
            return new TerminalViewModel
            {
                ImageUrl = terminal.ImageUrl,
                Displacement = terminal.Displacement,
                Max_Beam = terminal.Max_Beam,
                Max_Draft = terminal.Max_Draft,
                Max_Loa = terminal.Max_Loa,
                Terminal_Name = terminal.Terminal_Name,
                Type_Cargo = terminal.Type_Cargo,
                Water_Density = terminal.Water_Density,
                Working_hours = terminal.Working_hours,
                Port = terminal.Port,
                LineUps = terminal.LineUps,
                Port_id = terminal.Port.Id,
            };
        }

        public async Task<Voy> ToVoyAsync(VoysViewModel model, bool isNew)
        {
            return new Voy
            {

                Account = model.Account,
                Altitude = model.Altitude,
                Cargo = model.Cargo,
                Cargo_Charterer = model.Cargo_Charterer,
                Company = await _dataContext.Companies.FindAsync(model.Company_id),
                Consignee = model.Consignee,
                Contract = model.Contract,
                Employee = await _dataContext.Employees.FindAsync(model.Employ_id),
                Id = isNew ? 0 : model.Id,
                Eta = isNew ? DateTime.Today : model.Eta.ToUniversalTime(),
                Etb = isNew ? DateTime.Today : model.Etb.ToUniversalTime(),
                Etc = isNew ? DateTime.Today : model.Etc.ToUniversalTime(),
                Etd = isNew ? DateTime.Today : model.Etd.ToUniversalTime(),
                Facility = model.Facility,
                LastKnowPosition = isNew ? DateTime.Today : model.LastKnowPosition,
                Latitude = model.Latitude,
                Laycan = model.Laycan,
                Opinions = isNew ? new List<Opinion>() : model.Opinions,
                Owner_Charterer = model.Owner_Charterer,
                Pod = model.Pod,
                Pol = model.Pol,
                Port = await _dataContext.Ports.FindAsync(model.Port_id),
                Sf = model.Sf,
                Shipper = model.Shipper,
                Statuses = isNew ? new List<Status>() : model.Statuses,
                Vessel = await _dataContext.Vessels.FindAsync(model.Vessel_id),
                Voyimages = isNew ? new List<Voyimage>() : model.Voyimages,
                Voy_number = model.Voy_number,
            };
        }

        public VoysViewModel ToVoyViewModel(Voy voy)
        {
            return new VoysViewModel
            {
                Account = voy.Account,
                Altitude = voy.Altitude,
                Cargo = voy.Cargo,
                Cargo_Charterer = voy.Cargo_Charterer,
                Company_id = voy.Company.Id,
                Consignee = voy.Consignee,
                Contract = voy.Contract,
                Employ_id = voy.Employee.Id,
                Employee_list = _combosHelper.GetComboEmployees(),
                Id = voy.Id,
                Eta = voy.EtaLocal,
                Etb = voy.EtbLocal,
                Etc = voy.EtcLocal,
                Etd = voy.EtdLocal,
                Facility = voy.Facility,
                LastKnowPosition = voy.LastKnowPosition,
                Latitude = voy.Latitude,
                Laycan = voy.Laycan,
                Opinions = voy.Opinions,
                Owner_Charterer = voy.Owner_Charterer,
                Pod = voy.Pod,
                Pol = voy.Pol,
                Port_id = voy.Port.Id,
                Port_list = _combosHelper.GetComboPorts(),
                Sf = voy.Sf,
                Shipper = voy.Shipper,
                Statuses = voy.Statuses,
                Vessel_id = voy.Vessel.Id,
                Vessel_list = _combosHelper.GetComboVessels(),
                Voyimages = voy.Voyimages,
                Voy_number = voy.Voy_number,
            };
        }

        public async Task<Opinion> ToOpinionAsync(OpinionViewModel model, bool isNew)
        {
            return new Opinion
            {
                Id = isNew ? 0 : model.Id,
                Qualification = model.Qualification,
                Description = model.Description,
                Voy = await _dataContext.Voys.FindAsync(model.Voy_id)

            };
        }

        public OpinionViewModel ToOpinionViewModel(Opinion opinion)
        {
            return new OpinionViewModel
            {
                Id = opinion.Id,
                Qualification = opinion.Qualification,
                Description = opinion.Description,
                Voy = opinion.Voy,
                Voy_id = opinion.Voy.Id
            };
        }

        public async Task<Status> ToStatusAsync(StatusViewModel model, bool isNew)
        {
            return new Status
            {
                Id = isNew ? 0 : model.Id,
                Alerts = isNew ? new List<Alert>() : model.Alerts,
                AllFast = model.AllFast,
                Anchored = model.Anchored,
                Arrival = model.Arrival,
                Commenced = model.Commenced.ToUniversalTime(),
                DateUpdate = model.DateUpdate.ToUniversalTime(),
                Holds = isNew ? new List<Hold>() : model.Holds,
                Name_status = model.Name_status,
                Pob = model.Pob,
                Voy = await _dataContext.Voys.FindAsync(model.Voy_id)

            };
        }

        public StatusViewModel ToStatusViewModel(Status statuses)
        {
            return new StatusViewModel
            {
                Id = statuses.Id,
                Alerts = statuses.Alerts,
                AllFast = statuses.AllFast,
                Anchored = statuses.Anchored,
                Arrival = statuses.Arrival,
                Commenced = statuses.CommencedLocal,
                DateUpdate = statuses.DateUpdateLocal,
                Holds = statuses.Holds,
                Name_status = statuses.Name_status,
                Pob = statuses.Pob,
                Voy = statuses.Voy,
                Voy_id = statuses.Voy.Id
                 

            };
        }

        public async Task<Hold> ToHoldAsync(HoldViewModel model, bool IsNew)
        {
            return new Hold
            {
                Id = IsNew ? 0 : model.Id,
                Actual_Quantity = model.Actual_Quantity,
                First_Charge = model.First_Charge,
                Hold_Number = model.Hold_Number,
                Is_Empty = IsNew ? true : false,
                Is_Full = IsNew ? false : true,
                Last_Charge = model.Last_Charge,
                Max_Quantity = model.Max_Quantity,
                Status = await _dataContext.Statuses.FindAsync(model.Status_id)
            };
        }

        public HoldViewModel ToHoldViewModel(Hold hold)
        {
            return new HoldViewModel
            {
                Id = hold.Id,
                Actual_Quantity = hold.Actual_Quantity,
                First_Charge = hold.First_Charge,
                Hold_Number = hold.Hold_Number,
                Is_Empty = hold.Is_Empty,
                Is_Full = hold.Is_Full,
                Last_Charge = hold.Last_Charge,
                Max_Quantity = hold.Max_Quantity,
                Status = hold.Status,
                Status_id = hold.Status.Id

            };
        }

        public AlertsViewModel ToAlertViewModel(Alert alert)
        {
            return new AlertsViewModel
            {
                Id = alert.Id,
                Alert_Date = alert.Alert_Date,
                Alert_Description = alert.Alert_Description,
                AlertImages = alert.AlertImages,
                Status = alert.Status,
                Status_id = alert.Status.Id

            };
        }

        public async Task<Alert> ToAlertAsync(AlertsViewModel model, bool IsNew)
        {
            return new Alert
            {
                Id = IsNew ? 0 : model.Id,
                Alert_Description = model.Alert_Description,
                Alert_Date = model.Alert_Date,
                AlertImages = IsNew ? new List<AlertImage>() : model.AlertImages,
                Status = await _dataContext.Statuses.FindAsync(model.Status_id)
            };
        }

        public async Task<AlertImage> ToAlertImageAsync(AlertImageViewModel model,string path, bool IsNew)
        {
            return new AlertImage
            {
                Id = IsNew ? 0 : model.Id,
                Title = model.Title,
                ImageUrl = path,
                Alert = await _dataContext.Alerts.FindAsync(model.Alert_id)
            };
        }

        public AlertImageViewModel ToAlertImageViewModel(AlertImage alertimg)
        {
            return new AlertImageViewModel
            {
                Id = alertimg.Id,
                Alert_id = alertimg.Alert.Id,
                Alert = alertimg.Alert,
                ImageUrl = alertimg.ImageUrl,
                Title = alertimg.Title
            };
        }

        public async Task<Voyimage> ToVoyImageAsync(VoyImageViewModel model,string path, bool IsNew)
        {
            return new Voyimage
            {
                Id = IsNew ? 0 : model.Id,
                Title = model.Title,
                ImageUrl = path,
                Voy = await _dataContext.Voys.FindAsync(model.Voy_id),
               
            };
        }

        public VoyImageViewModel ToVoyImageViewModel(Voyimage voyimg)
        {
            return new VoyImageViewModel
            {
                Id = voyimg.Id,
                Voy_id = voyimg.Voy.Id,
                Voy = voyimg.Voy,
                ImageUrl = voyimg.ImageUrl,
                Title = voyimg.Title
            };
        }

        public async Task<NewImage> ToNewImageAsync(NewsImageViewModel model,string path, bool IsNew)
        {
            return new NewImage
            {
                Id = IsNew ? 0 : model.Id,
                ImageUrl = path,
                New = await _dataContext.News.FindAsync(model.New_id)
            };
        }

        public NewsImageViewModel ToNewImageViewModel(NewImage newimg)
        {
            return new NewsImageViewModel
            {
                Id = newimg.Id,
                New_id = newimg.New.Id,
                New = newimg.New,
                ImageUrl = newimg.ImageUrl,

            };
        }

        public async Task<Port> ToPortAsync(PortViewModel model, string path, bool IsNew)
        {
            return new Port
            {
                Id = IsNew ? 0 : model.Id,
                Port_Name = model.Port_Name,
                ImageUrl = path,
                Voys = IsNew ? new List<Voy>() : model.Voys,
                Terminals = IsNew ? new List<Terminal>() : model.Terminals,
                
            };
        }

        public PortViewModel ToPortViewModel(Port port)
        {
            return new PortViewModel
            {
                Id = port.Id,
                Port_Name = port.Port_Name,
                ImageUrl = port.ImageUrl,
                Voys = port.Voys,
                Terminals = port.Terminals,

            };
        }

        public async Task<LineUp> ToLineUpAsync(LineUpViewModel model, bool IsNew)
        {
            return new LineUp
            {
                Id = IsNew ? 0 : model.Id,
                Vessel = model.Vessel,
                Agency = model.Agency,
                Cargo = model.Cargo,
                Cargo_Charterer = model.Cargo_Charterer,
                Eta = model.Eta.ToUniversalTime(),
                Etb = model.Etb.ToUniversalTime(),
                Etc = model.Etb.ToUniversalTime(),
                Etd = model.Etd.ToUniversalTime(),
                Laycan = model.Laycan,
                Pol_Pod = model.Pol_Pod,
                Quantity = model.Quantity,
                Shipper_Consignee = model.Shipper_Consignee,
                Status = model.Status,
                Terminal = await _dataContext.Terminals.FindAsync(model.Terminal_id)
            };
        }

        public LineUpViewModel ToLineUpViewModel(LineUp lineup)
        {
            return new LineUpViewModel
            {
                Id = lineup.Id,
                Vessel = lineup.Vessel,
                Agency = lineup.Agency,
                Cargo = lineup.Cargo,
                Cargo_Charterer = lineup.Cargo_Charterer,
                Eta = lineup.Eta,
                Etb = lineup.Etb,
                Etc = lineup.Etb,
                Etd = lineup.Etd,
                Laycan = lineup.Laycan,
                Pol_Pod = lineup.Pol_Pod,
                Quantity = lineup.Quantity,
                Shipper_Consignee = lineup.Shipper_Consignee,
                Status = lineup.Status,
                Terminal = lineup.Terminal,
                Terminal_id = lineup.Terminal.Id,
            };
        }
    }
}
