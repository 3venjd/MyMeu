using MEU.web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MEU.web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Alert> Alerts { get; set; }

        public DbSet<AlertImage> AlertImages { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Hold> Holds { get; set; }

        public DbSet<LineUp> LineUps { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<New> News { get; set; }

        public DbSet<NewImage> NewImages { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Terminal> Terminals { get; set; }

        public DbSet<Vessel> Vessels { get; set; }

        public DbSet<VesselType> VesselTypes { get; set; }

        public DbSet<Voy> Voys { get; set; }

        public DbSet<Voyimage> Voyimages { get; set; }


    }
}
