using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class Airline_OARSContext : DbContext
    {
        public Airline_OARSContext()
        {
        }

        public Airline_OARSContext(DbContextOptions<Airline_OARSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightStatus> FlightStatuses { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; }
        public virtual DbSet<Usercredential> Usercredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN80025165\\SQLEXPRESS; Database=Airline_OARS; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.AadharNo)
                    .HasName("PK__Customer__91785592F57CEB43");

                entity.ToTable("Customer");

                entity.Property(e => e.AadharNo)
                    .ValueGeneratedNever()
                    .HasColumnName("Aadhar_No");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Contact_No");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightNo)
                    .HasName("PK__Flight__CAC37268EFDD7E8F");

                entity.ToTable("Flight");

                entity.Property(e => e.FlightNo)
                    .ValueGeneratedNever()
                    .HasColumnName("Flight_No");

                entity.Property(e => e.Arrival).HasColumnType("date");

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Arrival_Time");

                entity.Property(e => e.Depature).HasColumnType("date");

                entity.Property(e => e.DepatureTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Depature_Time");

                entity.Property(e => e.Destination)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfSeats).HasColumnName("No_of_seats");

                entity.Property(e => e.Origin)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightStatus>(entity =>
            {
                entity.HasKey(e => e.FlightNo)
                    .HasName("PK__Flight_S__CAC372687880081D");

                entity.ToTable("Flight_Status");

                entity.Property(e => e.FlightNo)
                    .ValueGeneratedNever()
                    .HasColumnName("Flight_No");

                entity.Property(e => e.Destination)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Start)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TerminalNo).HasColumnName("Terminal_No");

                entity.Property(e => e.Via)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__Reservat__ED7260B9FBEB5E36");

                entity.ToTable("Reservation");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_Id");

                entity.Property(e => e.AadharNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Aadhar_No");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.FlightNo).HasColumnName("Flight_No");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfTicket).HasColumnName("No_of_ticket");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");

                entity.Property(e => e.TicketStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ticket_Status");

                entity.Property(e => e.TotalFare).HasColumnName("Total_Fare");

                entity.HasOne(d => d.FlightNoNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FlightNo)
                    .HasConstraintName("FK__Reservati__Fligh__625A9A57");
            });

            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__Ticket_S__ED7260B921B56BE3");

                entity.ToTable("Ticket_Status");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ticket_Id");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usercredential>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__usercred__536C85E50700CAFA");

                entity.ToTable("usercredential");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Last_name");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_No");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
