using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Data.Entities;

namespace PhoneBookApp.Data.Configuration
{
    // Context - klasa konfiguracyjna EF Core
    public class PhoneBookAppContext : DbContext
    {
        // Kolekcje, które są bezpośrednim dostępem do tabel bazodanowych
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<PersonalData> PersonalDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PhoneBookApp;Integrated Security=True;Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.CreationDate);
                entity.Property(u => u.Login);
                entity.Property(u => u.Password);
                entity.Property(u => u.IsPremium);
                entity.Property(u => u.PersonalDataId);

                entity.HasOne(u => u.PersonalData).WithMany().HasForeignKey(u => u.PersonalDataId);
                entity.HasMany(u => u.PhoneBooks).WithOne().HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<User>().Navigation(u => u.PersonalData).AutoInclude();
            modelBuilder.Entity<User>().Navigation(u => u.PhoneBooks).AutoInclude();

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contacts");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.CreationDate);
                entity.Property(c => c.Name);
                entity.Property(c => c.PhoneNumber);
                entity.Property(c => c.Description);
                entity.Property(c => c.PhoneBookId);
            });

            modelBuilder.Entity<PhoneBook>(entity =>
            {
                entity.ToTable("PhoneBooks");
                entity.HasKey(pb => pb.Id);
                entity.Property(pb => pb.CreationDate);
                entity.Property(pb => pb.Name);
                entity.Property(pb => pb.MaxSize);
                entity.Property(pb => pb.UserId);

                entity.HasMany(pb => pb.Contacts).WithOne().HasForeignKey(c => c.PhoneBookId);
            });

            modelBuilder.Entity<PhoneBook>().Navigation(pb => pb.Contacts).AutoInclude();

            modelBuilder.Entity<PersonalData>(entity =>
            {
                entity.ToTable("PersonalDatas");
                entity.HasKey(pd => pd.Id);
                entity.Property(pd => pd.CreationDate);
                entity.Property(pd => pd.Name);
                entity.Property(pd => pd.Surname);
                entity.Property(pd => pd.Age);
                entity.Property(pd => pd.EmailAddress);
            });
        }
    }
}
