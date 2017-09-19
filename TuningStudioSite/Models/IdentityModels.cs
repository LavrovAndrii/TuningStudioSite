using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TuningStudioSite.Models.DbEntities;
using Task = TuningStudioSite.Models.DbEntities.Task;

namespace TuningStudioSite.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<DetailTask> DetailTasks { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Master>()
               .HasMany(e => e.Tasks)
               .WithRequired(e => e.Master)
               .HasForeignKey(e => e.IdMaster);

            modelBuilder.Entity<Client>()
               .HasMany(e => e.Tasks)
               .WithRequired(e => e.Client)
               .HasForeignKey(e => e.IdClient);

            modelBuilder.Entity<Supplier>()
               .HasMany(e => e.Details)
               .WithRequired(e => e.Supplier)
               .HasForeignKey(e => e.IdSupplier);


            modelBuilder.Entity<Detail>()
               .HasMany(e => e.DetailTasks)
               .WithRequired(e => e.Detail)
               .HasForeignKey(e => e.IdDetail);

            modelBuilder.Entity<Task>()
               .HasMany(e => e.DetailTasks)
               .WithRequired(e => e.Task)
               .HasForeignKey(e => e.IdTask);
        }
    }
}