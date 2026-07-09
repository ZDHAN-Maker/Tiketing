using Microsoft.EntityFrameworkCore;
using Ticketing.API.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace Ticketing.API.Data
{
    public class TicketingDbContext : DbContext
    {
        public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerStaff> OrganizerStaffs { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketStock> TicketStocks { get; set; }
        public DbSet<SeatMap> SeatMaps { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<EventPublishLog> EventPublishLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Data Seeding untuk Kategori
            modelBuilder.Entity<EventCategory>().HasData(
                new EventCategory
                {
                    Id = 1,
                    Name = "Konser Musik",
                    Slug = "konser-musik",
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Data Seeding untuk Venue
            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    Id = 1,
                    Name = "Stadion Utama",
                    Address = "Jl. Sudirman No 1",
                    City = "Jakarta",
                    Capacity = 50000,
                    CreatedAt = DateTime.UtcNow
                }
            );
            // =========================================================================
            // KONFIGURASI RELASI (JOIN TABLE)
            // =========================================================================
            // Mengatur Composite Primary Key untuk tabel perantara UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });


            // =========================================================================
            // DATA SEEDING (MASTER DATA & DEFAULT ADMIN)
            // =========================================================================

            // 1. Seed Master Data Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "SuperAdmin" },
                new Role { Id = 2, Name = "EventOrganizer" },
                new Role { Id = 3, Name = "Customer" }
            );

            // 2. Seed Akun Super Admin Default
            // Menggunakan salt statis sepanjang 22 karakter agar nilai hash deterministik
            var staticSalt = "$2a$11$abcdefghijklmnopqrstuu";
            var hashedAdminPassword = BCrypt.Net.BCrypt.HashPassword("AdminBesar123!", staticSalt);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Super Admin Utama",
                    Email = "superadmin@ticket.com",
                    Password = hashedAdminPassword,
                    Phone = "081111111111",
                    IsActive = true
                }
            );

            // 3. Pasangkan User Admin Utama (Id 1) dengan Role SuperAdmin (Id 1)
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 }
            );
            // ==========================================
            // 1. AUTHENTICATION & RBAC CONFIGURATION
            // ==========================================
            modelBuilder.Entity<Role>().ToTable("roles");

            modelBuilder.Entity<Permission>().ToTable("permissions");
            modelBuilder.Entity<Permission>().HasIndex(p => p.Name).IsUnique();

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<UserRole>().ToTable("user_roles").HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolePermission>().ToTable("role_permissions").HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermission>().HasOne(rp => rp.Role).WithMany().HasForeignKey(rp => rp.RoleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RolePermission>().HasOne(rp => rp.Permission).WithMany().HasForeignKey(rp => rp.PermissionId).OnDelete(DeleteBehavior.Cascade);

            // ==========================================
            // 2. MANAJEMEN ORGANIZER
            // ==========================================
            modelBuilder.Entity<Organizer>().ToTable("organizers");
            modelBuilder.Entity<Organizer>().HasOne(o => o.Owner).WithMany().HasForeignKey(o => o.OwnerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrganizerStaff>().ToTable("organizer_staff");
            modelBuilder.Entity<OrganizerStaff>().HasOne(os => os.Organizer).WithMany(o => o.Staffs).HasForeignKey(os => os.OrganizerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrganizerStaff>().HasOne(os => os.User).WithMany().HasForeignKey(os => os.UserId).OnDelete(DeleteBehavior.Cascade);

            // ==========================================
            // 3. MANAJEMEN EVENT
            // ==========================================
            modelBuilder.Entity<EventCategory>().ToTable("event_categories");
            modelBuilder.Entity<EventCategory>().HasIndex(ec => ec.Name).IsUnique();
            modelBuilder.Entity<EventCategory>().HasIndex(ec => ec.Slug).IsUnique();

            modelBuilder.Entity<Venue>().ToTable("venues");

            modelBuilder.Entity<Event>().ToTable("events");
            modelBuilder.Entity<Event>().HasIndex(e => e.Slug).IsUnique();
            modelBuilder.Entity<Event>().HasIndex(e => new { e.Status, e.StartTime }).HasDatabaseName("idx_events_status_time"); // Sesuai Indeks SQL Anda
            modelBuilder.Entity<Event>().HasIndex(e => e.Title).HasDatabaseName("idx_events_title");
            modelBuilder.Entity<Event>().HasOne(e => e.Organizer).WithMany(o => o.Events).HasForeignKey(e => e.OrganizerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Event>().HasOne(e => e.Category).WithMany(c => c.Events).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Event>().HasOne(e => e.Venue).WithMany(v => v.Events).HasForeignKey(e => e.VenueId).OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // 4. MANAJEMEN TIKET & SEATING
            // ==========================================
            modelBuilder.Entity<TicketType>().ToTable("ticket_types");
            modelBuilder.Entity<TicketType>().Property(tt => tt.Price).HasPrecision(15, 2);
            modelBuilder.Entity<TicketType>().HasOne(tt => tt.Event).WithMany(e => e.TicketTypes).HasForeignKey(tt => tt.EventId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketStock>().ToTable("ticket_stock");
            modelBuilder.Entity<TicketStock>().HasOne(ts => ts.TicketType).WithMany().HasForeignKey(ts => ts.TicketTypeId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeatMap>().ToTable("seat_maps");
            modelBuilder.Entity<SeatMap>().HasOne(sm => sm.Event).WithMany().HasForeignKey(sm => sm.EventId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Seat>().ToTable("seats");
            modelBuilder.Entity<Seat>().HasIndex(s => new { s.SeatMapId, s.SeatNumber }).IsUnique(); // Mencegah duplikasi kursi di denah yg sama
            modelBuilder.Entity<Seat>().HasOne(s => s.SeatMap).WithMany(sm => sm.Seats).HasForeignKey(s => s.SeatMapId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Seat>().HasOne(s => s.TicketType).WithMany().HasForeignKey(s => s.TicketTypeId).OnDelete(DeleteBehavior.Cascade);

            // ==========================================
            // 5. PUBLIKASI LOG & REVIEWS
            // ==========================================
            modelBuilder.Entity<EventPublishLog>().ToTable("event_publish_logs");
            modelBuilder.Entity<EventPublishLog>().HasOne(l => l.Event).WithMany().HasForeignKey(l => l.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EventPublishLog>().HasOne(l => l.Publisher).WithMany().HasForeignKey(l => l.PublishedBy).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Review>().HasOne(r => r.Event).WithMany().HasForeignKey(r => r.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>().HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // 6. TRANSAKSI (ORDERS & PAYMENTS)
            // ==========================================
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique().HasDatabaseName("idx_orders_number");
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(15, 2);
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>().ToTable("order_items");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasPrecision(15, 2);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Subtotal).HasPrecision(15, 2);
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(o => o.OrderItems).HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.TicketType).WithMany().HasForeignKey(oi => oi.TicketTypeId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentMethod>().ToTable("payment_methods");

            modelBuilder.Entity<Payment>().ToTable("payments");
            modelBuilder.Entity<Payment>().HasIndex(p => p.TransactionId).IsUnique();
            modelBuilder.Entity<Payment>().Property(p => p.Amount).HasPrecision(15, 2);
            modelBuilder.Entity<Payment>().HasOne(p => p.Order).WithMany(o => o.Payments).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Payment>().HasOne(p => p.PaymentMethod).WithMany(pm => pm.Payments).HasForeignKey(p => p.PaymentMethodId).OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // 7. TICKETS, QR CODES, & CHECK-INS
            // ==========================================
            modelBuilder.Entity<Ticket>().ToTable("tickets");
            modelBuilder.Entity<Ticket>().HasIndex(t => t.TicketCode).IsUnique().HasDatabaseName("idx_tickets_code");
            modelBuilder.Entity<Ticket>().HasOne(t => t.Order).WithMany(o => o.Tickets).HasForeignKey(t => t.OrderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ticket>().HasOne(t => t.OrderItem).WithMany(oi => oi.Tickets).HasForeignKey(t => t.OrderItemId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ticket>().HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ticket>().HasOne(t => t.Seat).WithMany(s => s.Tickets).HasForeignKey(t => t.SeatId).OnDelete(DeleteBehavior.SetNull); // Sesuai SQL ON DELETE SET NULL

            modelBuilder.Entity<QrCode>().ToTable("qr_codes");
            modelBuilder.Entity<QrCode>().HasIndex(q => q.QrHash).IsUnique();
            modelBuilder.Entity<QrCode>().HasOne(q => q.Ticket).WithMany(t => t.QrCodes).HasForeignKey(q => q.TicketId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CheckIn>().ToTable("checkins");
            modelBuilder.Entity<CheckIn>().HasOne(c => c.Ticket).WithMany(t => t.CheckIns).HasForeignKey(c => c.TicketId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CheckIn>().HasOne(c => c.GateOfficer).WithMany().HasForeignKey(c => c.GateOfficerId).OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // 8. REFUNDS
            // ==========================================
            modelBuilder.Entity<Refund>().ToTable("refunds");
            modelBuilder.Entity<Refund>().Property(r => r.Amount).HasPrecision(15, 2);
            modelBuilder.Entity<Refund>().HasOne(r => r.Order).WithMany(o => o.Refunds).HasForeignKey(r => r.OrderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Refund>().HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Refund>().HasOne(r => r.Processor).WithMany().HasForeignKey(r => r.ProcessedBy).OnDelete(DeleteBehavior.SetNull);
        }
    }

    // Class tambahan pendukung Junction Table RolePermission
    public class RolePermission
    {
        public long RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public long PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}