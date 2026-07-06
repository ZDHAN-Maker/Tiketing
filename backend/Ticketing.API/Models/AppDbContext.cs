using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ticketing.API.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityTimelines202607> ActivityTimelines202607s { get; set; }

    public virtual DbSet<ActivityTimelinesDefault> ActivityTimelinesDefaults { get; set; }

    public virtual DbSet<AuditLogs202607> AuditLogs202607s { get; set; }

    public virtual DbSet<AuditLogs202608> AuditLogs202608s { get; set; }

    public virtual DbSet<AuditLogsDefault> AuditLogsDefaults { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingItem> BookingItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DiscountVoucher> DiscountVouchers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventSession> EventSessions { get; set; }

    public virtual DbSet<EventTicketTier> EventTicketTiers { get; set; }

    public virtual DbSet<ExternalLogin> ExternalLogins { get; set; }

    public virtual DbSet<InternalNote> InternalNotes { get; set; }

    public virtual DbSet<KnowledgeBasis> KnowledgeBases { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<OrganizationMember> OrganizationMembers { get; set; }

    public virtual DbSet<OrganizationSettlement> OrganizationSettlements { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentWebhookLog> PaymentWebhookLogs { get; set; }

    public virtual DbSet<PayoutRequest> PayoutRequests { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<RefundRequest> RefundRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ScheduledJobRun> ScheduledJobRuns { get; set; }

    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketHold> TicketHolds { get; set; }

    public virtual DbSet<TicketScan> TicketScans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPlatformRole> UserPlatformRoles { get; set; }

    public virtual DbSet<VTicketTierAvailability> VTicketTierAvailabilities { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    public virtual DbSet<VenueSeat> VenueSeats { get; set; }

    public virtual DbSet<VenueSection> VenueSections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Tiketing;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<RoleScope>("iam", "role_scope");
        modelBuilder.HasPostgresEnum<UserStatus>("iam", "user_status");
        modelBuilder.HasPostgresEnum<BookingStatus>("ticketing", "booking_status");
        modelBuilder.HasPostgresEnum<PaymentStatus>("ticketing", "payment_status");
        modelBuilder
            .HasPostgresEnum("booking_status", new[] { "AwaitingPayment", "Paid", "Cancelled", "Expired", "Refunded", "PartiallyRefunded" })
            .HasPostgresEnum("discount_type", new[] { "Percentage", "FixedAmount" })
            .HasPostgresEnum("event_approval_status", new[] { "Draft", "PendingReview", "Approved", "Rejected", "Cancelled" })
            .HasPostgresEnum("event_type", new[] { "GeneralAdmission", "ReservedSeating", "Hybrid" })
            .HasPostgresEnum("hold_status", new[] { "Active", "Released", "Converted" })
            .HasPostgresEnum("job_run_status", new[] { "Running", "Success", "Failed" })
            .HasPostgresEnum("notification_channel", new[] { "Email", "SMS", "Push", "InApp" })
            .HasPostgresEnum("notification_status", new[] { "Queued", "Sent", "Failed" })
            .HasPostgresEnum("org_member_status", new[] { "Invited", "Active", "Removed" })
            .HasPostgresEnum("org_verification_status", new[] { "Pending", "Verified", "Rejected", "Suspended" })
            .HasPostgresEnum("payment_status", new[] { "Pending", "Success", "Failed", "Expired", "Refunded" })
            .HasPostgresEnum("payout_status", new[] { "Requested", "Processing", "Paid", "Rejected" })
            .HasPostgresEnum("refund_status", new[] { "Requested", "Approved", "Rejected", "Processed" })
            .HasPostgresEnum("role_scope", new[] { "Platform", "Organization" })
            .HasPostgresEnum("scan_result", new[] { "Success", "DuplicateScan", "InvalidTicket", "WrongEvent" })
            .HasPostgresEnum("ticket_status", new[] { "Issued", "Scanned", "Refunded", "Void" })
            .HasPostgresEnum("tier_type", new[] { "GeneralAdmission", "Seated" })
            .HasPostgresEnum("user_status", new[] { "Active", "Suspended", "Banned", "PendingVerification" })
            .HasPostgresEnum("venue_section_type", new[] { "Seated", "Standing" })
            .HasPostgresExtension("citext")
            .HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<ActivityTimelines202607>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Timestamp }).HasName("activity_timelines_2026_07_pkey");

            entity.ToTable("activity_timelines_2026_07", "ops");

            entity.HasIndex(e => new { e.ReferenceId, e.ReferenceType }, "activity_timelines_2026_07_reference_id_reference_type_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, 0L, 0L, 0L, null, 0L)
                .HasColumnName("id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("timestamp");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(50)
                .HasColumnName("reference_type");

            entity.HasOne(d => d.Actor).WithMany(p => p.ActivityTimelines202607s)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("activity_timelines_actor_id_fkey");
        });

        modelBuilder.Entity<ActivityTimelinesDefault>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Timestamp }).HasName("activity_timelines_default_pkey");

            entity.ToTable("activity_timelines_default", "ops");

            entity.HasIndex(e => new { e.ReferenceId, e.ReferenceType }, "activity_timelines_default_reference_id_reference_type_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, 0L, 0L, 0L, null, 0L)
                .HasColumnName("id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("timestamp");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(50)
                .HasColumnName("reference_type");

            entity.HasOne(d => d.Actor).WithMany(p => p.ActivityTimelinesDefaults)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("activity_timelines_actor_id_fkey");
        });

        modelBuilder.Entity<AuditLogs202607>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Timestamp }).HasName("audit_logs_2026_07_pkey");

            entity.ToTable("audit_logs_2026_07", "ops");

            entity.HasIndex(e => e.NewValues, "audit_logs_2026_07_new_values_idx").HasMethod("gin");

            entity.HasIndex(e => e.OldValues, "audit_logs_2026_07_old_values_idx").HasMethod("gin");

            entity.HasIndex(e => e.RecordId, "audit_logs_2026_07_record_id_idx");

            entity.HasIndex(e => e.TableName, "audit_logs_2026_07_table_name_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, 0L, 0L, 0L, null, 0L)
                .HasColumnName("id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("timestamp");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.NewValues)
                .HasColumnType("jsonb")
                .HasColumnName("new_values");
            entity.Property(e => e.OldValues)
                .HasColumnType("jsonb")
                .HasColumnName("old_values");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AuditLogs202608>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Timestamp }).HasName("audit_logs_2026_08_pkey");

            entity.ToTable("audit_logs_2026_08", "ops");

            entity.HasIndex(e => e.NewValues, "audit_logs_2026_08_new_values_idx").HasMethod("gin");

            entity.HasIndex(e => e.OldValues, "audit_logs_2026_08_old_values_idx").HasMethod("gin");

            entity.HasIndex(e => e.RecordId, "audit_logs_2026_08_record_id_idx");

            entity.HasIndex(e => e.TableName, "audit_logs_2026_08_table_name_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, 0L, 0L, 0L, null, 0L)
                .HasColumnName("id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("timestamp");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.NewValues)
                .HasColumnType("jsonb")
                .HasColumnName("new_values");
            entity.Property(e => e.OldValues)
                .HasColumnType("jsonb")
                .HasColumnName("old_values");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AuditLogsDefault>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Timestamp }).HasName("audit_logs_default_pkey");

            entity.ToTable("audit_logs_default", "ops");

            entity.HasIndex(e => e.NewValues, "audit_logs_default_new_values_idx").HasMethod("gin");

            entity.HasIndex(e => e.OldValues, "audit_logs_default_old_values_idx").HasMethod("gin");

            entity.HasIndex(e => e.RecordId, "audit_logs_default_record_id_idx");

            entity.HasIndex(e => e.TableName, "audit_logs_default_table_name_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, 0L, 0L, 0L, null, 0L)
                .HasColumnName("id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("timestamp");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.NewValues)
                .HasColumnType("jsonb")
                .HasColumnName("new_values");
            entity.Property(e => e.OldValues)
                .HasColumnType("jsonb")
                .HasColumnName("old_values");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookings_pkey");

            entity.ToTable("bookings", "ticketing");

            entity.HasIndex(e => e.BookingNumber, "bookings_booking_number_key").IsUnique();

            entity.HasIndex(e => e.PublicId, "bookings_public_id_key").IsUnique();

            entity.HasIndex(e => e.CustomerId, "idx_bookings_customer");

            entity.HasIndex(e => e.EventId, "idx_bookings_event");

            entity.HasIndex(e => e.SlaPaymentDueDate, "idx_bookings_sla_expiry").HasFilter("(status = 'AwaitingPayment'::booking_status)");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.BookingNumber)
                .HasMaxLength(50)
                .HasColumnName("booking_number");
            entity.Property(e => e.CancellationReason).HasColumnName("cancellation_reason");
            entity.Property(e => e.CancelledAt).HasColumnName("cancelled_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DiscountAmount)
                .HasPrecision(18, 2)
                .HasColumnName("discount_amount");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.PaidAt).HasColumnName("paid_at");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("public_id");
            entity.Property(e => e.ServiceFeeAmount)
                .HasPrecision(18, 2)
                .HasColumnName("service_fee_amount");
            entity.Property(e => e.SlaPaymentDueDate).HasColumnName("sla_payment_due_date");
            entity.Property(e => e.SubtotalAmount)
                .HasPrecision(18, 2)
                .HasColumnName("subtotal_amount");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(18, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookings_customer_id_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookings_event_id_fkey");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("bookings_voucher_id_fkey");
        });

        modelBuilder.Entity<BookingItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("booking_items_pkey");

            entity.ToTable("booking_items", "ticketing");

            entity.HasIndex(e => e.BookingId, "idx_booking_items_booking");

            entity.HasIndex(e => e.TierId, "idx_booking_items_tier");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasPrecision(18, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.TierId).HasColumnName("tier_id");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(18, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingItems)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("booking_items_booking_id_fkey");

            entity.HasOne(d => d.Tier).WithMany(p => p.BookingItems)
                .HasForeignKey(d => d.TierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_items_tier_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories", "catalog");

            entity.HasIndex(e => e.Slug, "categories_slug_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.IconUrl).HasColumnName("icon_url");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(120)
                .HasColumnName("slug");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("categories_parent_category_id_fkey");
        });

        modelBuilder.Entity<DiscountVoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discount_vouchers_pkey");

            entity.ToTable("discount_vouchers", "catalog");

            entity.HasIndex(e => new { e.OrganizationId, e.Code }, "discount_vouchers_organization_id_code_key").IsUnique();

            entity.HasIndex(e => new { e.OrganizationId, e.Code }, "idx_vouchers_org_code").HasFilter("(is_deleted = false)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.DiscountValue)
                .HasPrecision(18, 2)
                .HasColumnName("discount_value");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MaxUsage).HasColumnName("max_usage");
            entity.Property(e => e.MinTransactionAmount)
                .HasPrecision(18, 2)
                .HasDefaultValue(0m)
                .HasColumnName("min_transaction_amount");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.UsedCount).HasColumnName("used_count");
            entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
            entity.Property(e => e.ValidUntil).HasColumnName("valid_until");

            entity.HasOne(d => d.Event).WithMany(p => p.DiscountVouchers)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("discount_vouchers_event_id_fkey");

            entity.HasOne(d => d.Organization).WithMany(p => p.DiscountVouchers)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("discount_vouchers_organization_id_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events", "catalog");

            entity.HasIndex(e => e.Slug, "events_slug_key").IsUnique();

            entity.HasIndex(e => e.CategoryId, "idx_events_category");

            entity.HasIndex(e => e.OrganizationId, "idx_events_org");

            entity.HasIndex(e => e.StartDate, "idx_events_published_upcoming").HasFilter("((is_published = true) AND (is_deleted = false))");

            entity.HasIndex(e => e.VenueId, "idx_events_venue");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ApprovedAt).HasColumnName("approved_at");
            entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");
            entity.Property(e => e.BannerUrl).HasColumnName("banner_url");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.EventTimezone)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Asia/Jakarta'::character varying")
                .HasColumnName("event_timezone");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsPublished).HasColumnName("is_published");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.Slug)
                .HasMaxLength(280)
                .HasColumnName("slug");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.EventApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("events_approved_by_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("events_category_id_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("events_created_by_fkey");

            entity.HasOne(d => d.Organization).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_organization_id_fkey");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("events_venue_id_fkey");
        });

        modelBuilder.Entity<EventSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_sessions_pkey");

            entity.ToTable("event_sessions", "catalog");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.SessionEnd).HasColumnName("session_end");
            entity.Property(e => e.SessionName)
                .HasMaxLength(100)
                .HasColumnName("session_name");
            entity.Property(e => e.SessionStart).HasColumnName("session_start");

            entity.HasOne(d => d.Event).WithMany(p => p.EventSessions)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("event_sessions_event_id_fkey");
        });

        modelBuilder.Entity<EventTicketTier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_ticket_tiers_pkey");

            entity.ToTable("event_ticket_tiers", "catalog");

            entity.HasIndex(e => e.EventId, "idx_tiers_event").HasFilter("(is_deleted = false)");

            entity.HasIndex(e => e.SessionId, "idx_tiers_session");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'IDR'::bpchar")
                .IsFixedLength()
                .HasColumnName("currency");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.HeldCount).HasColumnName("held_count");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MaxPurchasePerTxn)
                .HasDefaultValue(10)
                .HasColumnName("max_purchase_per_txn");
            entity.Property(e => e.MinPurchasePerTxn)
                .HasDefaultValue(1)
                .HasColumnName("min_purchase_per_txn");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");
            entity.Property(e => e.Quota).HasColumnName("quota");
            entity.Property(e => e.SalesEndAt).HasColumnName("sales_end_at");
            entity.Property(e => e.SalesStartAt).HasColumnName("sales_start_at");
            entity.Property(e => e.SectionId).HasColumnName("section_id");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.SoldCount).HasColumnName("sold_count");
            entity.Property(e => e.TierName)
                .HasMaxLength(50)
                .HasColumnName("tier_name");
            entity.Property(e => e.Version)
                .HasDefaultValue(1)
                .HasColumnName("version");

            entity.HasOne(d => d.Event).WithMany(p => p.EventTicketTiers)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("event_ticket_tiers_event_id_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.EventTicketTiers)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("event_ticket_tiers_section_id_fkey");

            entity.HasOne(d => d.Session).WithMany(p => p.EventTicketTiers)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("event_ticket_tiers_session_id_fkey");
        });

        modelBuilder.Entity<ExternalLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("external_logins_pkey");

            entity.ToTable("external_logins", "iam");

            entity.HasIndex(e => new { e.Provider, e.ProviderKey }, "external_logins_provider_provider_key_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Provider)
                .HasMaxLength(30)
                .HasColumnName("provider");
            entity.Property(e => e.ProviderKey)
                .HasMaxLength(255)
                .HasColumnName("provider_key");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ExternalLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("external_logins_user_id_fkey");
        });

        modelBuilder.Entity<InternalNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("internal_notes_pkey");

            entity.ToTable("internal_notes", "ops");

            entity.HasIndex(e => e.ReferenceId, "idx_internal_notes_ref");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(50)
                .HasColumnName("reference_type");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.Staff).WithMany(p => p.InternalNotes)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("internal_notes_staff_id_fkey");
        });

        modelBuilder.Entity<KnowledgeBasis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("knowledge_bases_pkey");

            entity.ToTable("knowledge_bases", "ops");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AnswerOrContent).HasColumnName("answer_or_content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("'id-ID'::character varying")
                .HasColumnName("language_code");
            entity.Property(e => e.QuestionOrTitle).HasColumnName("question_or_title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notifications_pkey");

            entity.ToTable("notifications", "ops");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Payload)
                .HasColumnType("jsonb")
                .HasColumnName("payload");
            entity.Property(e => e.SentAt).HasColumnName("sent_at");
            entity.Property(e => e.TemplateCode)
                .HasMaxLength(100)
                .HasColumnName("template_code");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notifications_user_id_fkey");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organizations_pkey");

            entity.ToTable("organizations", "tenancy");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.BankAccountHolder)
                .HasMaxLength(150)
                .HasColumnName("bank_account_holder");
            entity.Property(e => e.BankAccountNumber)
                .HasMaxLength(50)
                .HasColumnName("bank_account_number");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            entity.Property(e => e.BusinessType)
                .HasMaxLength(50)
                .HasColumnName("business_type");
            entity.Property(e => e.CommissionRatePercent)
                .HasPrecision(5, 2)
                .HasDefaultValue(5.00m)
                .HasColumnName("commission_rate_percent");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LegalName)
                .HasMaxLength(255)
                .HasColumnName("legal_name");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OwnerUserId).HasColumnName("owner_user_id");
            entity.Property(e => e.TaxId)
                .HasMaxLength(50)
                .HasColumnName("tax_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.OwnerUser).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.OwnerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizations_owner_user_id_fkey");
        });

        modelBuilder.Entity<OrganizationMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_members_pkey");

            entity.ToTable("organization_members", "tenancy");

            entity.HasIndex(e => e.OrganizationId, "idx_org_members_org");

            entity.HasIndex(e => e.UserId, "idx_org_members_user");

            entity.HasIndex(e => new { e.OrganizationId, e.UserId }, "organization_members_organization_id_user_id_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.InvitedBy).HasColumnName("invited_by");
            entity.Property(e => e.JoinedAt).HasColumnName("joined_at");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.InvitedByNavigation).WithMany(p => p.OrganizationMemberInvitedByNavigations)
                .HasForeignKey(d => d.InvitedBy)
                .HasConstraintName("organization_members_invited_by_fkey");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationMembers)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("organization_members_organization_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.OrganizationMembers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organization_members_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.OrganizationMemberUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("organization_members_user_id_fkey");
        });

        modelBuilder.Entity<OrganizationSettlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_settlements_pkey");

            entity.ToTable("organization_settlements", "tenancy");

            entity.HasIndex(e => new { e.OrganizationId, e.EventId }, "idx_settlement_org_event");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CommissionAmount)
                .HasPrecision(18, 2)
                .HasColumnName("commission_amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.GrossAmount)
                .HasPrecision(18, 2)
                .HasColumnName("gross_amount");
            entity.Property(e => e.NetAmount)
                .HasPrecision(18, 2)
                .HasColumnName("net_amount");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PeriodEnd).HasColumnName("period_end");
            entity.Property(e => e.PeriodStart).HasColumnName("period_start");

            entity.HasOne(d => d.Event).WithMany(p => p.OrganizationSettlements)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("fk_settlement_event");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationSettlements)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organization_settlements_organization_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payments_pkey");

            entity.ToTable("payments", "ticketing");

            entity.HasIndex(e => e.BookingId, "idx_payments_booking");

            entity.HasIndex(e => e.IdempotencyKey, "payments_idempotency_key_key").IsUnique();

            entity.HasIndex(e => e.PublicId, "payments_public_id_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'IDR'::bpchar")
                .IsFixedLength()
                .HasColumnName("currency");
            entity.Property(e => e.IdempotencyKey)
                .HasMaxLength(255)
                .HasColumnName("idempotency_key");
            entity.Property(e => e.PaymentGateway)
                .HasMaxLength(50)
                .HasColumnName("payment_gateway");
            entity.Property(e => e.PaymentGatewayRef)
                .HasMaxLength(255)
                .HasColumnName("payment_gateway_ref");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentTime).HasColumnName("payment_time");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("public_id");
            entity.Property(e => e.RawGatewayResponse)
                .HasColumnType("jsonb")
                .HasColumnName("raw_gateway_response");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("payments_booking_id_fkey");
        });

        modelBuilder.Entity<PaymentWebhookLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_webhook_logs_pkey");

            entity.ToTable("payment_webhook_logs", "ticketing");

            entity.HasIndex(e => e.Processed, "idx_webhook_logs_processed").HasFilter("(processed = false)");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.EventType)
                .HasMaxLength(100)
                .HasColumnName("event_type");
            entity.Property(e => e.Payload)
                .HasColumnType("jsonb")
                .HasColumnName("payload");
            entity.Property(e => e.PaymentGateway)
                .HasMaxLength(50)
                .HasColumnName("payment_gateway");
            entity.Property(e => e.Processed).HasColumnName("processed");
            entity.Property(e => e.ReceivedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("received_at");
            entity.Property(e => e.SignatureVerified).HasColumnName("signature_verified");
        });

        modelBuilder.Entity<PayoutRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payout_requests_pkey");

            entity.ToTable("payout_requests", "tenancy");

            entity.HasIndex(e => e.PublicId, "payout_requests_public_id_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.BankReference)
                .HasMaxLength(255)
                .HasColumnName("bank_reference");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.ProcessedAt).HasColumnName("processed_at");
            entity.Property(e => e.ProcessedBy).HasColumnName("processed_by");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("public_id");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("requested_at");

            entity.HasOne(d => d.Organization).WithMany(p => p.PayoutRequests)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payout_requests_organization_id_fkey");

            entity.HasOne(d => d.ProcessedByNavigation).WithMany(p => p.PayoutRequests)
                .HasForeignKey(d => d.ProcessedBy)
                .HasConstraintName("payout_requests_processed_by_fkey");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permissions_pkey");

            entity.ToTable("permissions", "iam");

            entity.HasIndex(e => e.PermissionCode, "permissions_permission_code_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Module)
                .HasMaxLength(50)
                .HasColumnName("module");
            entity.Property(e => e.PermissionCode)
                .HasMaxLength(100)
                .HasColumnName("permission_code");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refresh_tokens_pkey");

            entity.ToTable("refresh_tokens", "iam");

            entity.HasIndex(e => e.UserId, "idx_refresh_tokens_user").HasFilter("(revoked_at IS NULL)");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceInfo)
                .HasMaxLength(255)
                .HasColumnName("device_info");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.RevokedAt).HasColumnName("revoked_at");
            entity.Property(e => e.TokenHash)
                .HasMaxLength(255)
                .HasColumnName("token_hash");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("refresh_tokens_user_id_fkey");
        });

        modelBuilder.Entity<RefundRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refund_requests_pkey");

            entity.ToTable("refund_requests", "ticketing");

            entity.HasIndex(e => e.BookingId, "idx_refunds_booking");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.ProcessedAt).HasColumnName("processed_at");
            entity.Property(e => e.ProcessedBy).HasColumnName("processed_by");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.RequestedBy).HasColumnName("requested_by");

            entity.HasOne(d => d.Booking).WithMany(p => p.RefundRequests)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("refund_requests_booking_id_fkey");

            entity.HasOne(d => d.Payment).WithMany(p => p.RefundRequests)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("refund_requests_payment_id_fkey");

            entity.HasOne(d => d.ProcessedByNavigation).WithMany(p => p.RefundRequestProcessedByNavigations)
                .HasForeignKey(d => d.ProcessedBy)
                .HasConstraintName("refund_requests_processed_by_fkey");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.RefundRequestRequestedByNavigations)
                .HasForeignKey(d => d.RequestedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("refund_requests_requested_by_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles", "iam");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasMany(d => d.Permissions).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePermission",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionId")
                        .HasConstraintName("role_permissions_permission_id_fkey"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("role_permissions_role_id_fkey"),
                    j =>
                    {
                        j.HasKey("RoleId", "PermissionId").HasName("role_permissions_pkey");
                        j.ToTable("role_permissions", "iam");
                        j.HasIndex(new[] { "RoleId", "PermissionId" }, "idx_role_perms_composite");
                        j.IndexerProperty<Guid>("RoleId").HasColumnName("role_id");
                        j.IndexerProperty<Guid>("PermissionId").HasColumnName("permission_id");
                    });
        });

        modelBuilder.Entity<ScheduledJobRun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scheduled_job_runs_pkey");

            entity.ToTable("scheduled_job_runs", "ops");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ErrorMessage).HasColumnName("error_message");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.JobName)
                .HasMaxLength(100)
                .HasColumnName("job_name");
            entity.Property(e => e.RowsAffected).HasColumnName("rows_affected");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<SystemSetting>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("system_settings_pkey");

            entity.ToTable("system_settings", "ops");

            entity.Property(e => e.Key)
                .HasMaxLength(100)
                .HasColumnName("key");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Value)
                .HasColumnType("jsonb")
                .HasColumnName("value");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SystemSettings)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("system_settings_updated_by_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tickets_pkey");

            entity.ToTable("tickets", "ticketing");

            entity.HasIndex(e => e.BookingItemId, "idx_tickets_booking_item");

            entity.HasIndex(e => e.SeatId, "idx_tickets_seat");

            entity.HasIndex(e => e.TierId, "idx_tickets_tier");

            entity.HasIndex(e => e.PublicId, "tickets_public_id_key").IsUnique();

            entity.HasIndex(e => e.TicketNumber, "tickets_ticket_number_key").IsUnique();

            entity.HasIndex(e => new { e.TierId, e.SeatId }, "uq_active_seat_ticket")
                .IsUnique()
                .HasFilter("((seat_id IS NOT NULL) AND (is_deleted = false))");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.BookingItemId).HasColumnName("booking_item_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IssuedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("issued_at");
            entity.Property(e => e.PdfAttachmentUrl).HasColumnName("pdf_attachment_url");
            entity.Property(e => e.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("public_id");
            entity.Property(e => e.QrCodePayload).HasColumnName("qr_code_payload");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.TicketNumber)
                .HasMaxLength(50)
                .HasColumnName("ticket_number");
            entity.Property(e => e.TierId).HasColumnName("tier_id");

            entity.HasOne(d => d.BookingItem).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.BookingItemId)
                .HasConstraintName("tickets_booking_item_id_fkey");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("tickets_seat_id_fkey");

            entity.HasOne(d => d.Tier).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_tier_id_fkey");
        });

        modelBuilder.Entity<TicketHold>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_holds_pkey");

            entity.ToTable("ticket_holds", "ticketing");

            entity.HasIndex(e => e.BookingId, "idx_holds_booking");

            entity.HasIndex(e => e.ExpiresAt, "idx_holds_expiry").HasFilter("(status = 'Active'::hold_status)");

            entity.HasIndex(e => e.TierId, "idx_holds_tier_active").HasFilter("(status = 'Active'::hold_status)");

            entity.HasIndex(e => new { e.TierId, e.SeatId }, "uq_active_seat_hold")
                .IsUnique()
                .HasFilter("((seat_id IS NOT NULL) AND (status = 'Active'::hold_status))");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.HeldAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("held_at");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.TierId).HasColumnName("tier_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.TicketHolds)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ticket_holds_booking_id_fkey");

            entity.HasOne(d => d.Seat).WithMany(p => p.TicketHolds)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("ticket_holds_seat_id_fkey");

            entity.HasOne(d => d.Tier).WithMany(p => p.TicketHolds)
                .HasForeignKey(d => d.TierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_holds_tier_id_fkey");
        });

        modelBuilder.Entity<TicketScan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_scans_pkey");

            entity.ToTable("ticket_scans", "ticketing");

            entity.HasIndex(e => e.ScannedBy, "idx_ticket_scans_staff");

            entity.HasIndex(e => e.TicketId, "idx_ticket_scans_ticket");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DeviceInfo)
                .HasMaxLength(255)
                .HasColumnName("device_info");
            entity.Property(e => e.LocationScanned)
                .HasMaxLength(255)
                .HasColumnName("location_scanned");
            entity.Property(e => e.ScanTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("scan_time");
            entity.Property(e => e.ScannedBy).HasColumnName("scanned_by");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");

            entity.HasOne(d => d.ScannedByNavigation).WithMany(p => p.TicketScans)
                .HasForeignKey(d => d.ScannedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_scans_scanned_by_fkey");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketScans)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("ticket_scans_ticket_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users", "iam");

            entity.HasIndex(e => e.Id, "idx_users_active").HasFilter("(is_deleted = false)");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasColumnType("citext")
                .HasColumnName("email");
            entity.Property(e => e.EmailVerifiedAt).HasColumnName("email_verified_at");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LanguagePreference)
                .HasMaxLength(10)
                .HasDefaultValueSql("'id-ID'::character varying")
                .HasColumnName("language_preference");
            entity.Property(e => e.LastLoginAt).HasColumnName("last_login_at");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.PhoneVerifiedAt).HasColumnName("phone_verified_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<UserPlatformRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("user_platform_roles_pkey");

            entity.ToTable("user_platform_roles", "iam");

            entity.HasIndex(e => e.UserId, "idx_user_platform_roles_user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("assigned_at");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.UserPlatformRoleAssignedByNavigations)
                .HasForeignKey(d => d.AssignedBy)
                .HasConstraintName("user_platform_roles_assigned_by_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.UserPlatformRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_platform_roles_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserPlatformRoleUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_platform_roles_user_id_fkey");
        });

        modelBuilder.Entity<VTicketTierAvailability>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_ticket_tier_availability", "catalog");

            entity.Property(e => e.AvailableQuota).HasColumnName("available_quota");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.HeldCount).HasColumnName("held_count");
            entity.Property(e => e.Quota).HasColumnName("quota");
            entity.Property(e => e.SoldCount).HasColumnName("sold_count");
            entity.Property(e => e.TierId).HasColumnName("tier_id");
            entity.Property(e => e.TierName)
                .HasMaxLength(50)
                .HasColumnName("tier_name");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venues_pkey");

            entity.ToTable("venues", "catalog");

            entity.HasIndex(e => e.Id, "idx_venues_active").HasFilter("(is_deleted = false)");

            entity.HasIndex(e => e.OrganizationId, "idx_venues_org");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Indonesia'::character varying")
                .HasColumnName("country");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Latitude)
                .HasPrecision(9, 6)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(9, 6)
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .HasColumnName("province");

            entity.HasOne(d => d.Organization).WithMany(p => p.Venues)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("venues_organization_id_fkey");
        });

        modelBuilder.Entity<VenueSeat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venue_seats_pkey");

            entity.ToTable("venue_seats", "catalog");

            entity.HasIndex(e => e.SectionId, "idx_venue_seats_section");

            entity.HasIndex(e => new { e.SectionId, e.SeatRow, e.SeatNumber }, "venue_seats_section_id_seat_row_seat_number_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(10)
                .HasColumnName("seat_number");
            entity.Property(e => e.SeatRow)
                .HasMaxLength(10)
                .HasColumnName("seat_row");
            entity.Property(e => e.SectionId).HasColumnName("section_id");

            entity.HasOne(d => d.Section).WithMany(p => p.VenueSeats)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("venue_seats_section_id_fkey");
        });

        modelBuilder.Entity<VenueSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venue_sections_pkey");

            entity.ToTable("venue_sections", "catalog");

            entity.HasIndex(e => e.VenueId, "idx_venue_sections_venue");

            entity.HasIndex(e => new { e.VenueId, e.SectionName }, "venue_sections_venue_id_section_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.SectionName)
                .HasMaxLength(100)
                .HasColumnName("section_name");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueSections)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("venue_sections_venue_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
