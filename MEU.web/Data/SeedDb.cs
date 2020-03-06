using System;
using System.Linq;
using System.Threading.Tasks;
using MEU.web.Data.Entities;
using MEU.web.Helpers;

namespace MEU.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();

            var client = await CheckUserAsync("1043244567","Samir", "Rincon", "administration@multiport.com.co", "3124348945","Client");
            var clientp = await CheckUserAsync("2045786524", "Roberto", "Calero", "director@multiport.com.co", "3124348945", "Client");
            var employee = await CheckUserAsync("9452094523", "Juan", "Pulgarin", "ops2@multiport.com.co", "3124348945", "Employee");
            var manager = await CheckUserAsync("7854934563", "Evelio", "Jimenez", "soporte.sistemas@multiport.com.co", "3124348945", "Manager");


            await CheckManagerAsync(manager);
            await CheckCompanyAsync();
            await CheckOffice();
            await CheckEmployeeAsync(employee);
            await CheckPortAsync();
            await CheckVesselTypeAsync();
            await CheckVesselAsync();
            await CheckVoyAsync();
            await CheckOpinionAsync();
            await CheckVoyImageAsync();
            await CheckStatusAsync();
            await CheckAlertAsync();
            await CheckAlerImagetAsync();
            await CheckNewAsync();
            await CheckNewImageAsync();
            await CheckTerminalAsync();
            await CheckHoldAsync();
            await CheckLineUpAsync();
            await CheckClient(client);
            await CheckClient(clientp);

        }

        private async Task CheckOpinionAsync()
        {
            var voy = _context.Voys.FirstOrDefault();
            if (!_context.Opinions.Any())
            {
                _context.Opinions.Add(new Opinion { Qualification = 4, Description = "Amazing service", Voy = voy });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }


        private async Task<User> CheckUserAsync(string document, string firstanme, string lastname, string email, string cellphone, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);

            if (user==null)
            {
                user = new User 
                {
                    FirstName = firstanme,
                    LastName = lastname,
                    UserName = email,
                    Email = email,
                    PhoneNumber = cellphone,
                    Document = document
                };
                await _userHelper.AddUserAsync(user,"123456");
                await _userHelper.AddUserToRoleAsync(user,role);
            }

            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Employee");
            await _userHelper.CheckRoleAsync("Client");
        }

        private async Task CheckAlertAsync()
        {
            var status = _context.Statuses.FirstOrDefault();
            if (!_context.Alerts.Any())
            {
                AddAlert(DateTime.Parse("12/04/2018"), "Photo about Alert in Operation", status);
                await _context.SaveChangesAsync();
            }
        }

        private void AddAlert(DateTime alert_date, string description, Status status)
        {
            _context.Alerts.Add(new Alert
            {
                Alert_Date = alert_date,
                Alert_Description = description,
                Status = status,
            }
            );
        }

        private async Task CheckAlerImagetAsync()
        {
            var alert = _context.Alerts.FirstOrDefault();

            if (!_context.Clients.Any())
            {
                AddAlertImage("Alert 1" , "https://www.mmaoffshore.com/sites/mmaoffshorecomau//" +
                    "assets/public/image/ProductListing/Thumbnails/14ad7e97-12e7-4bf4-a610-" +
                    "acbdde9ee220-mermaid-leeuwin.jpg",alert);

                await _context.SaveChangesAsync();
            }
        }

        private void AddAlertImage(string title, string URL, Alert alert)
        {
            _context.AlertImages.Add(new AlertImage
            {
                Title = title,
                ImageUrl = URL,
                Alert = alert,

            }

            );
        }

        private async Task CheckClient(User user)
        {
            var company = _context.Companies.FirstOrDefault();
            if (!_context.Clients.Any())
            {
                AddClient(user,company);
                await _context.SaveChangesAsync();
            }
        }

        private void AddClient(User client, Company company)
        {
            _context.Clients.Add(new Client
                {
                    User = client,
                    Company = company,
                     
                }    
                
            );
        }

        private async Task CheckCompanyAsync()
        {
            if (!_context.Companies.Any())
            {
                AddCompany("Hyundai", "China",true);
                await _context.SaveChangesAsync();
            }
        }

        private void AddCompany(string company_name, string country,bool pro)
        {
            _context.Companies.Add(new Company
            {
                Name = company_name,
                Country = country,
                Pro = pro,
            }
            );
        }

        private async Task CheckEmployeeAsync(User user)
        {
            var office = _context.Offices.FirstOrDefault();

            if (!_context.Employees.Any())
            {
                AddEmployees( "Operation Manager", "ops2meu",user, office);

                await _context.SaveChangesAsync();
            }
        }

        private void AddEmployees( string cargo, string skype,User user, Office office)
        {
            _context.Employees.Add(new Employee
            {
                Cargo = cargo,
                Skype = skype,
                Office = office,
                User = user
            }
            );
        }
        private async Task CheckHoldAsync()
        {
            var status = _context.Statuses.FirstOrDefault();

            if (!_context.Holds.Any())
            {
                AddHold(1, 3023, 2500, false, true, status);

                AddHold(2, 4566, 30000, false, true, status);

                AddHold(3, 2456, 20000, false, true, status);

                AddHold(4, 5678, 3500, false, true, status);



                await _context.SaveChangesAsync();
            }
        }

        private void AddHold(int hold_n, int actual_quantity, int max_quantity, bool full, bool empty, Status status)
        {
            _context.Holds.Add(new Hold
            {
                Hold_Number = hold_n,
                Actual_Quantity = actual_quantity,
                Max_Quantity = max_quantity,
                Is_Full = full,
                Is_Empty = empty,
                Status = status,
                
            }
           );
        }

        private async Task CheckLineUpAsync()
        {
            var terminal = _context.Terminals.FirstOrDefault();
            if (!_context.LineUps.Any())
            {

                AddLineUp("Sean Jhon", DateTime.Parse("06/06/2019"), DateTime.Parse("10/06/2019"),
                    DateTime.Parse("02/07/2019"), DateTime.Parse("02/07/2019"), "In Progress", "Steel", 
                    "450000", "02/06/2019 - 02/07/2019","Ravenna,Italy", "Cargil", "Allied Chemical Carriers",
                    "Multiport",terminal);


                await _context.SaveChangesAsync();
            }
        }

        private void AddLineUp(string vessel, DateTime eta, DateTime etb, DateTime etc, DateTime etd, string status, string cargo, string quantity, string laycan, string pol_pod, string shipperconsig, string cargo_char, string agency,Terminal terminal)
        {
            _context.LineUps.Add(new LineUp
            {
                Vessel = vessel,
                Eta = eta,
                Etb = etb,
                Etc = etc,
                Etd = etd,
                Status = status,
                Cargo = cargo,
                Quantity = quantity,
                Laycan = laycan,
                Pol_Pod = pol_pod,
                Shipper_Consignee = shipperconsig,
                Cargo_Charterer = cargo_char,
                Agency = agency,
                Terminal = terminal,
                
            }
            );
        }

        private async Task CheckNewAsync()
        {
            if (!_context.News.Any())
            {
                AddNew("Bigges Ship in Colombia", "Lorem Ipsum is simply dummy text of " +
                    "the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard " +
                    "dummy text ever since the 1500s, when an unknown " +
                    "printer took a galley of type and scrambled it to " +
                    "make a type specimen book. It has survived not only " +
                    "five centuries, but also the leap into electronic typesetting," +
                    " remaining essentially unchanged. It was popularised in the 1960s " +
                    "with the release of Letraset sheets containing Lorem Ipsum passages" +
                    "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                    DateTime.Parse("02/02/2019")
                    );

                await _context.SaveChangesAsync();
            }
        }

        private void AddNew(string title, string descripion, DateTime DatePlublication)
        {
            _context.News.Add(new New
            {
                Title = title,
                Description = descripion,
                DatePublication = DatePlublication,
            }
           );
        }

        private async Task CheckNewImageAsync()
        {
            var newn = _context.News.FirstOrDefault();

            if (!_context.Alerts.Any())
            {
                AddNewImage("https://www.mmaoffshore.com/sites/mmaoffshorecomau//assets/" +
                    "public/image/ProductListing/Thumbnails/bb5781bb-24c8-4a8b-b1e2-d6ef4a507c9e-mma" +
                    "-prestige.jpg", newn);
                await _context.SaveChangesAsync();
            }
        }

        private void AddNewImage(string URL, New newn)
        {
            _context.NewImages.Add
                (
                    new NewImage
                    {
                        ImageUrl = URL,
                        New = newn,
                    }
                );
        }

        private async Task CheckOffice()
        {
            if (!_context.Offices.Any())
            {
                AddFullStyle("Medellin","Calle 4 sur #43A-149", "050022", "+4 2688444", "340 8435674", "assistant.mgr@multiport.com.co");
                await _context.SaveChangesAsync();
            }
        }

        private void AddFullStyle(string name,string address, string postalc, string localphone, string usaphone, string mainmail)
        {
            _context.Offices.Add
                (
                    new Office
                    {
                        Name = name,
                        Adress = address,
                        Postal_Code = postalc,
                        Phone = localphone,
                        Usa_Phone = usaphone,
                        Email = mainmail
                    }
                );
        }

        private async Task CheckPortAsync()
        {

            if (!_context.Ports.Any())
            {
                AddPort("Barranquilla", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNNfRn7vJA30lD8uhLg7cSswDUqUBCQv0sWgyjL3WnCVQQOU27Wg");

                await _context.SaveChangesAsync();
            }
        }

        private void AddPort(string port_name, string URL)
        {
            _context.Ports.Add(new Port
            {
                Port_Name = port_name,
                ImageUrl = URL
            }
          );
        }

        private async Task CheckStatusAsync()
        {
            var voy = _context.Voys.FirstOrDefault();
            if (!_context.Statuses.Any())
            {
                AddStatus("In Progress",DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), voy);
                await _context.SaveChangesAsync();
            }
        }

        private void AddStatus(String name_status,DateTime arrival, DateTime anchored, DateTime pob, DateTime allfast, DateTime commenced, DateTime dateupdate, Voy voy)
        {
            _context.Statuses.Add(new Status
            {
                Name_status = name_status,
                Arrival = arrival,
                Anchored = anchored,
                Pob = pob,
                AllFast = allfast,
                Commenced = commenced,
                DateUpdate = dateupdate,
                Voy = voy,
            }
            ); 
        }

        private async Task CheckTerminalAsync()
        {
            var port = _context.Ports.FirstOrDefault();
            if (!_context.Terminals.Any())
            {

                AddTerminal("Santa Marta", "338 MTS", "62 MTS", "22 MTS", "360,000 TONS", "SW", "24 HRS Shinc", "Crude Oil", "https://www.seaboardmarine.com/wp-content/uploads/We-Bring-You-Closer-To-Your-Customersoptm-1024x269.jpg", port);

                await _context.SaveChangesAsync();
            }
        }

        private void AddTerminal(string terminal_Name, string max_Loa, string max_Beam, string max_Draft, string displacement, string water_Density, string working_hours, string type_Cargo, string URL,Port port)
        {
            _context.Terminals.Add(new Terminal
            {
                Terminal_Name = terminal_Name,
                Max_Loa = max_Loa,
                Max_Beam = max_Beam,
                Max_Draft = max_Draft,
                Displacement = displacement,
                Water_Density = water_Density,
                Working_hours = working_hours,
                Type_Cargo = type_Cargo,
                ImageUrl = URL,
                Port = port,
            }
            );
        }

        private async Task CheckVesselAsync()
        {
            var vesseltypes = _context.VesselTypes.FirstOrDefault();

            if (!_context.Vessels.Any())
            {
                AddVessel("Sean John",
                    "https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwj36IbivYrlAhUitlkKHUOSDAMQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.fleetmon." +
                    "com%2Fservices%2Fvessel-risk-rating%2F&psig=AOvVaw1aRZobSnPtiAbIzDdc1TT0&ust=1570549178192912", vesseltypes);
                await _context.SaveChangesAsync();
            }
        }

        private void AddVessel(string vessel_name, string URL, VesselType vesselType)
        {
            _context.Vessels.Add(new Vessel
            {
                Vessel_Name = vessel_name,
                ImageUrl = URL,
                VesselType = vesselType,
                
            }
            );

        }

        private async Task CheckVesselTypeAsync()
        {
            if (!_context.VesselTypes.Any())
            {
                _context.VesselTypes.Add(new VesselType { Type_Vessel = "Container" });
                _context.VesselTypes.Add(new VesselType { Type_Vessel = "General" });
                _context.VesselTypes.Add(new VesselType { Type_Vessel = "Crude Oil" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVoyAsync()
        {

            var vessel = _context.Vessels.FirstOrDefault();
            var company = _context.Companies.FirstOrDefault();
            var port = _context.Ports.FirstOrDefault();
            var employee = _context.Employees.FirstOrDefault();

            if (!_context.Voys.Any())
            {
                AddVoy(0000, "Aes Gener S.A", "16 Jun - 20 Jun", "70,000 mt +/- 10%", "Stream coal in bulk", "abt 43 cuft/mt",
                    "Santa Marta, Colombia", "Carbosan / spsm (pier7)", "Huasco,Chile", "Aes Gener S.A",
                    "Glencore Agriculture BV", "Colombia Natural Resources", "Aes Gener S.A",
                    "+57 3124356789", "234", "534", DateTime.Parse("12/04/2018"), DateTime.Parse("01/01/2018"),
                    DateTime.Parse("04/02/2018"), DateTime.Parse("05/02/2018"), DateTime.Parse("12/04/2018"),
                    vessel, company, port, employee
                    );

                await _context.SaveChangesAsync();
            }
        }

        private void AddVoy(int voy_number, string account, string laycan, string contract, string cargo,
                            string sf, string pol, string facility, string pod, string cargo_charterer,
                            string owner_charterer, string shipper, string consignee, string mob,
                            string latitude, string altitude, DateTime lastKnowPosition,
                            DateTime eta, DateTime etb, DateTime etc, DateTime etd, Vessel vessel, Company company, Port port, Employee employee)
        {
            _context.Voys.Add(new Voy
            {
                Voy_number = voy_number,
                Account = account,
                Laycan = laycan,
                Contract = contract,
                Cargo = cargo,
                Sf = sf,
                Pol = pol,
                Facility = facility,
                Pod = pod,
                Cargo_Charterer = cargo_charterer,
                Owner_Charterer = owner_charterer,
                Shipper = shipper,
                Consignee = consignee,
                Latitude = latitude,
                Altitude = altitude,
                LastKnowPosition = lastKnowPosition,
                Eta = eta,
                Etb = etb,
                Etc = etc,
                Etd = etd,
                Vessel = vessel,
                Company = company,
                Port = port,
                Employee = employee,
                 
            }
            );
        }
        private async Task CheckVoyImageAsync()
        {
            var voy = _context.Voys.FirstOrDefault();

            if (!_context.Alerts.Any())
            {
                AddVoyImage("Voy 123", "https://www.mmaoffshore.com/sites/mmaoffshorecomau//assets/" +
                    "public/image/ProductListing/Thumbnails/7c082b61-2ee0-4c35-99cb-338ce4e4f97f-" +
                    "Pride%2011.jpg", voy);
                await _context.SaveChangesAsync();
            }

        }

        private void AddVoyImage(string title, string URL, Voy voy)
        {
            _context.Voyimages.Add(new Voyimage 
                {
                    Title = title,
                    ImageUrl = URL,
                    Voy = voy,
                    
                }
            );
        }
    }
}
