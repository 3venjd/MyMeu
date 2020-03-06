using MEU.Common.Models;
using MEU.web.Data;
using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ClientsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetClientByEmail")]
        public async Task<IActionResult> GetClientByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var client = await _dataContext.Clients
                .Include(u => u.User)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .ThenInclude(h => h.Holds)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .ThenInclude(a => a.Alerts)
                .ThenInclude(ga => ga.AlertImages)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(v => v.Vessel)
                .ThenInclude(vt => vt.VesselType)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(gv => gv.Voyimages)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(o => o.Opinions)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(o => o.Port)
                .ThenInclude(t => t.Terminals)
                .ThenInclude(lu => lu.LineUps)
                .Include(c => c.Company)
                .ThenInclude(v => v.Voys)
                .ThenInclude(e => e.Employee)
                .ThenInclude(o => o.Office)
                .ThenInclude(u => u.Employees)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(u => u.User.Email.ToLower() == request.Email.ToLower());
                

            if (client == null)
            {
                return NotFound();
            }

            var response = new ClientResponse
            {
                Id = client.Id,
                FirstName = client.User.FirstName,
                LastName = client.User.LastName,
                Document = client.User.Document,
                Email = client.User.Email,
                PhoneNumber = client.User.PhoneNumber,
                Company = ToCompanyResponse(client.Company)
            };

            return Ok(response);
        }

        private CompanyResponse ToCompanyResponse(Company company)
        {
            return new CompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                Country = company.Country,
                Pro = company.Pro,
                Voys = company.Voys?.Select(v => new VoyResponse
                {
                    Id = v.Id,
                    Account = v.Account,
                    Altitude = v.Altitude,
                    Cargo = v.Cargo,
                    Cargo_Charterer = v.Cargo_Charterer,
                    Consignee = v.Consignee,
                    Contract = v.Contract,
                    Eta = v.Eta,
                    Etb = v.Etb,
                    Etc = v.Etc,
                    Etd = v.Etd,
                    Facility = v.Facility,
                    LastKnowPosition = v.LastKnowPosition,
                    Latitude = v.Latitude,
                    Laycan = v.Laycan,
                    Owner_Charterer = v.Owner_Charterer,
                    Pod = v.Pod,
                    Pol = v.Pol,
                    Sf = v.Sf,
                    Shipper = v.Shipper,
                    Voy_number = v.Voy_number,
                    Opinions = v.Opinions?.Select(o => new OpinionResponse
                    {
                        Id = o.Id,
                        Description = o.Description,
                        Qualification = o.Qualification
                    }).ToList(),
                    Statuses = v.Statuses?.Select(s => new StatusResponse
                    {
                        Id = s.Id,
                        AllFast = s.AllFast,
                        Anchored = s.Anchored,
                        Arrival = s.Arrival,
                        Commenced = s.Commenced,
                        DateUpdate = s.DateUpdate,
                        Name_status = s.Name_status,
                        Pob = s.Pob,
                        Alerts = s.Alerts?.Select(a => new AlertResponse
                        {
                            Id = a.Id,
                            Alert_Description = a.Alert_Description,
                            Alert_Date = a.Alert_Date,
                            AlertImages = a.AlertImages?.Select(ai => new AlertImageResponse
                            {
                                Id = ai.Id,
                                Title = ai.Title,
                                ImageUrl = ai.ImageUrl
                            }).ToList(),
                        }).ToList(),
                        Holds = s.Holds?.Select(h => new HoldResponse
                        {
                            Id = h.Id,
                            Actual_Quantity = h.Actual_Quantity,
                            First_Charge = h.First_Charge,
                            Hold_Number = h.Hold_Number,
                            Is_Empty = h.Is_Empty,
                            Is_Full = h.Is_Full,
                            Last_Charge = h.Last_Charge,
                            Max_Quantity = h.Max_Quantity
                        }).ToList(),
                    }).OrderByDescending(st => st.DateUpdateLocal).Take(1).ToList(),
                    Voyimages = v.Voyimages?.Select(vi => new VoyImageResponse
                    {
                        Id = vi.Id,
                        Title = vi.Title,
                        ImageUrl = vi.ImageUrl
                    }).ToList(),
                    Port = ToPortResponse(v.Port),
                    Vessel = ToVesselResponse(v.Vessel),
                    Employee = ToEmployeeResponse(v.Employee)
                }).ToList(),

            };
        }

        private EmployeeResponse ToEmployeeResponse(Employee employee)
        {
            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.User.FirstName,
                LastName = employee.User.LastName,
                Email = employee.User.Email,
                Phone_number = employee.User.PhoneNumber,
                Skype = employee.Skype,
                Cargo = employee.Cargo,
                Office = ToOfficeResponse(employee.Office)
            };
        }

        private OfficeResponse ToOfficeResponse(Office office)
        {
            return new OfficeResponse
            {
                Id = office.Id,
                Name = office.Name,
                Phone = office.Phone,
                Adress = office.Adress,
                Email = office.Email,            
            };
        }

        private VesselResponse ToVesselResponse(Vessel vessel)
        {
            return new VesselResponse
            {
                Id = vessel.Id,
                Vessel_Name = vessel.Vessel_Name,
                ImageUrl = vessel.ImageUrl,
                VesselType = vessel.VesselType.Type_Vessel
            };
        }

        private PortResponse ToPortResponse(Port port)
        {
            return new PortResponse
            {
                Id = port.Id,
                Port_Name = port.Port_Name,
                ImageUrl = port.ImageUrl,
                Terminals = port.Terminals?.Select(t => new TerminalResponse
                {
                    Id = t.Id,
                    Displacement = t.Displacement,
                    ImageUrl = t.ImageUrl,
                    Max_Beam = t.Max_Beam,
                    Max_Draft = t.Max_Draft,
                    Max_Loa = t.Max_Loa,
                    Terminal_Name = t.Terminal_Name,
                    Type_Cargo = t.Type_Cargo,
                    Water_Density = t.Type_Cargo,
                    Working_hours = t.Working_hours,
                    LineUps = t.LineUps?.Select(lu => new LineUpResponse
                    {
                        Id = lu.Id,
                        Agency = lu.Agency,
                        Cargo = lu.Cargo,
                        Cargo_Charterer = lu.Cargo_Charterer,
                        Eta = lu.Eta,
                        Etb = lu.Etb,
                        Etc = lu.Etc,
                        Etd = lu.Etd,
                        Laycan = lu.Laycan,
                        Pol_Pod = lu.Pol_Pod,
                        Quantity = lu.Quantity,
                        Shipper_Consignee = lu.Shipper_Consignee,
                        Status = lu.Status,
                        Vessel = lu.Vessel,
                    }).ToList(),
                }).ToList(),
            };
        }
    }
}
