using System;
using System.Net;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ops");

            migrationBuilder.EnsureSchema(
                name: "ticketing");

            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.EnsureSchema(
                name: "iam");

            migrationBuilder.EnsureSchema(
                name: "tenancy");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:booking_status", "AwaitingPayment,Paid,Cancelled,Expired,Refunded,PartiallyRefunded")
                .Annotation("Npgsql:Enum:discount_type", "Percentage,FixedAmount")
                .Annotation("Npgsql:Enum:event_approval_status", "Draft,PendingReview,Approved,Rejected,Cancelled")
                .Annotation("Npgsql:Enum:event_type", "GeneralAdmission,ReservedSeating,Hybrid")
                .Annotation("Npgsql:Enum:hold_status", "Active,Released,Converted")
                .Annotation("Npgsql:Enum:iam.role_scope", "platform,organization")
                .Annotation("Npgsql:Enum:iam.user_status", "active,suspended,banned,pending_verification")
                .Annotation("Npgsql:Enum:job_run_status", "Running,Success,Failed")
                .Annotation("Npgsql:Enum:notification_channel", "Email,SMS,Push,InApp")
                .Annotation("Npgsql:Enum:notification_status", "Queued,Sent,Failed")
                .Annotation("Npgsql:Enum:org_member_status", "Invited,Active,Removed")
                .Annotation("Npgsql:Enum:org_verification_status", "Pending,Verified,Rejected,Suspended")
                .Annotation("Npgsql:Enum:payment_status", "Pending,Success,Failed,Expired,Refunded")
                .Annotation("Npgsql:Enum:payout_status", "Requested,Processing,Paid,Rejected")
                .Annotation("Npgsql:Enum:refund_status", "Requested,Approved,Rejected,Processed")
                .Annotation("Npgsql:Enum:role_scope", "Platform,Organization")
                .Annotation("Npgsql:Enum:scan_result", "Success,DuplicateScan,InvalidTicket,WrongEvent")
                .Annotation("Npgsql:Enum:ticket_status", "Issued,Scanned,Refunded,Void")
                .Annotation("Npgsql:Enum:ticketing.booking_status", "awaiting_payment,paid,cancelled,expired,refunded,partially_refunded")
                .Annotation("Npgsql:Enum:ticketing.payment_status", "pending,success,failed,expired,refunded")
                .Annotation("Npgsql:Enum:tier_type", "GeneralAdmission,Seated")
                .Annotation("Npgsql:Enum:user_status", "Active,Suspended,Banned,PendingVerification")
                .Annotation("Npgsql:Enum:venue_section_type", "Seated,Standing")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.CreateTable(
                name: "audit_logs_2026_07",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '0', '0', '0', 'False', '0'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    table_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    record_id = table.Column<Guid>(type: "uuid", nullable: true),
                    old_values = table.Column<string>(type: "jsonb", nullable: true),
                    new_values = table.Column<string>(type: "jsonb", nullable: true),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("audit_logs_2026_07_pkey", x => new { x.id, x.timestamp });
                });

            migrationBuilder.CreateTable(
                name: "audit_logs_2026_08",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '0', '0', '0', 'False', '0'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    table_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    record_id = table.Column<Guid>(type: "uuid", nullable: true),
                    old_values = table.Column<string>(type: "jsonb", nullable: true),
                    new_values = table.Column<string>(type: "jsonb", nullable: true),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("audit_logs_2026_08_pkey", x => new { x.id, x.timestamp });
                });

            migrationBuilder.CreateTable(
                name: "audit_logs_default",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '0', '0', '0', 'False', '0'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    table_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    record_id = table.Column<Guid>(type: "uuid", nullable: true),
                    old_values = table.Column<string>(type: "jsonb", nullable: true),
                    new_values = table.Column<string>(type: "jsonb", nullable: true),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("audit_logs_default_pkey", x => new { x.id, x.timestamp });
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    parent_category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    slug = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    icon_url = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pkey", x => x.id);
                    table.ForeignKey(
                        name: "categories_parent_category_id_fkey",
                        column: x => x.parent_category_id,
                        principalSchema: "catalog",
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "knowledge_bases",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    question_or_title = table.Column<string>(type: "text", nullable: false),
                    answer_or_content = table.Column<string>(type: "text", nullable: false),
                    language_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, defaultValueSql: "'id-ID'::character varying"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("knowledge_bases_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_webhook_logs",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    payment_gateway = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    event_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    payload = table.Column<string>(type: "jsonb", nullable: false),
                    signature_verified = table.Column<bool>(type: "boolean", nullable: false),
                    processed = table.Column<bool>(type: "boolean", nullable: false),
                    received_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("payment_webhook_logs_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    permission_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    module = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("permissions_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    role_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    Scope = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scheduled_job_runs",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    job_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    finished_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rows_affected = table.Column<int>(type: "integer", nullable: true),
                    error_message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("scheduled_job_runs_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "citext", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    email_verified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    phone_verified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    language_preference = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, defaultValueSql: "'id-ID'::character varying"),
                    last_login_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "iam",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_permissions_pkey", x => new { x.role_id, x.permission_id });
                    table.ForeignKey(
                        name: "role_permissions_permission_id_fkey",
                        column: x => x.permission_id,
                        principalSchema: "iam",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "role_permissions_role_id_fkey",
                        column: x => x.role_id,
                        principalSchema: "iam",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activity_timelines_2026_07",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '0', '0', '0', 'False', '0'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    reference_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    actor_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("activity_timelines_2026_07_pkey", x => new { x.id, x.timestamp });
                    table.ForeignKey(
                        name: "activity_timelines_actor_id_fkey",
                        column: x => x.actor_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "activity_timelines_default",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '0', '0', '0', 'False', '0'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    reference_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    actor_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("activity_timelines_default_pkey", x => new { x.id, x.timestamp });
                    table.ForeignKey(
                        name: "activity_timelines_actor_id_fkey",
                        column: x => x.actor_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "external_logins",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    provider = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    provider_key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("external_logins_pkey", x => x.id);
                    table.ForeignKey(
                        name: "external_logins_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "internal_notes",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    reference_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    staff_id = table.Column<Guid>(type: "uuid", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("internal_notes_pkey", x => x.id);
                    table.ForeignKey(
                        name: "internal_notes_staff_id_fkey",
                        column: x => x.staff_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                schema: "ops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    payload = table.Column<string>(type: "jsonb", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("notifications_pkey", x => x.id);
                    table.ForeignKey(
                        name: "notifications_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                schema: "tenancy",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    owner_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    legal_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    tax_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    business_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commission_rate_percent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 5.00m),
                    bank_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    bank_account_holder = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    bank_account_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("organizations_pkey", x => x.id);
                    table.ForeignKey(
                        name: "organizations_owner_user_id_fkey",
                        column: x => x.owner_user_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    device_info = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    revoked_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("refresh_tokens_pkey", x => x.id);
                    table.ForeignKey(
                        name: "refresh_tokens_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "system_settings",
                schema: "ops",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    value = table.Column<string>(type: "jsonb", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("system_settings_pkey", x => x.key);
                    table.ForeignKey(
                        name: "system_settings_updated_by_fkey",
                        column: x => x.updated_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_platform_roles",
                schema: "iam",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    assigned_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_platform_roles_pkey", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "user_platform_roles_assigned_by_fkey",
                        column: x => x.assigned_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_platform_roles_role_id_fkey",
                        column: x => x.role_id,
                        principalSchema: "iam",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_platform_roles_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_members",
                schema: "tenancy",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    invited_by = table.Column<Guid>(type: "uuid", nullable: true),
                    joined_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("organization_members_pkey", x => x.id);
                    table.ForeignKey(
                        name: "organization_members_invited_by_fkey",
                        column: x => x.invited_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "organization_members_organization_id_fkey",
                        column: x => x.organization_id,
                        principalSchema: "tenancy",
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "organization_members_role_id_fkey",
                        column: x => x.role_id,
                        principalSchema: "iam",
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "organization_members_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payout_requests",
                schema: "tenancy",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    public_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    requested_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    processed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    processed_by = table.Column<Guid>(type: "uuid", nullable: true),
                    bank_reference = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("payout_requests_pkey", x => x.id);
                    table.ForeignKey(
                        name: "payout_requests_organization_id_fkey",
                        column: x => x.organization_id,
                        principalSchema: "tenancy",
                        principalTable: "organizations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "payout_requests_processed_by_fkey",
                        column: x => x.processed_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "venues",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    province = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValueSql: "'Indonesia'::character varying"),
                    postal_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: true),
                    longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: true),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("venues_pkey", x => x.id);
                    table.ForeignKey(
                        name: "venues_organization_id_fkey",
                        column: x => x.organization_id,
                        principalSchema: "tenancy",
                        principalTable: "organizations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "events",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    slug = table.Column<string>(type: "character varying(280)", maxLength: 280, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    banner_url = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    event_timezone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValueSql: "'Asia/Jakarta'::character varying"),
                    approved_by = table.Column<Guid>(type: "uuid", nullable: true),
                    approved_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rejection_reason = table.Column<string>(type: "text", nullable: true),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_pkey", x => x.id);
                    table.ForeignKey(
                        name: "events_approved_by_fkey",
                        column: x => x.approved_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "events_category_id_fkey",
                        column: x => x.category_id,
                        principalSchema: "catalog",
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "events_created_by_fkey",
                        column: x => x.created_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "events_organization_id_fkey",
                        column: x => x.organization_id,
                        principalSchema: "tenancy",
                        principalTable: "organizations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "events_venue_id_fkey",
                        column: x => x.venue_id,
                        principalSchema: "catalog",
                        principalTable: "venues",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "venue_sections",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    section_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("venue_sections_pkey", x => x.id);
                    table.ForeignKey(
                        name: "venue_sections_venue_id_fkey",
                        column: x => x.venue_id,
                        principalSchema: "catalog",
                        principalTable: "venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_vouchers",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    discount_value = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    max_usage = table.Column<int>(type: "integer", nullable: false),
                    used_count = table.Column<int>(type: "integer", nullable: false),
                    min_transaction_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true, defaultValue: 0m),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    valid_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valid_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("discount_vouchers_pkey", x => x.id);
                    table.ForeignKey(
                        name: "discount_vouchers_event_id_fkey",
                        column: x => x.event_id,
                        principalSchema: "catalog",
                        principalTable: "events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "discount_vouchers_organization_id_fkey",
                        column: x => x.organization_id,
                        principalSchema: "tenancy",
                        principalTable: "organizations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "event_sessions",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    session_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    session_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("event_sessions_pkey", x => x.id);
                    table.ForeignKey(
                        name: "event_sessions_event_id_fkey",
                        column: x => x.event_id,
                        principalSchema: "catalog",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_settlements",
                schema: "tenancy",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    gross_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    commission_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    net_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    period_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    period_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("organization_settlements_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_settlement_event",
                        column: x => x.event_id,
                        principalSchema: "catalog",
                        principalTable: "events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "organization_settlements_organization_id_fkey",
                        column: x => x.organization_id,
                        principalSchema: "tenancy",
                        principalTable: "organizations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "venue_seats",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_row = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    seat_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("venue_seats_pkey", x => x.id);
                    table.ForeignKey(
                        name: "venue_seats_section_id_fkey",
                        column: x => x.section_id,
                        principalSchema: "catalog",
                        principalTable: "venue_sections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    public_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    booking_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    voucher_id = table.Column<Guid>(type: "uuid", nullable: true),
                    subtotal_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    discount_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    service_fee_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    sla_payment_due_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    paid_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cancelled_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cancellation_reason = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bookings_pkey", x => x.id);
                    table.ForeignKey(
                        name: "bookings_customer_id_fkey",
                        column: x => x.customer_id,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "bookings_event_id_fkey",
                        column: x => x.event_id,
                        principalSchema: "catalog",
                        principalTable: "events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "bookings_voucher_id_fkey",
                        column: x => x.voucher_id,
                        principalSchema: "catalog",
                        principalTable: "discount_vouchers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "event_ticket_tiers",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_id = table.Column<Guid>(type: "uuid", nullable: true),
                    section_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tier_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false, defaultValueSql: "'IDR'::bpchar"),
                    quota = table.Column<int>(type: "integer", nullable: false),
                    held_count = table.Column<int>(type: "integer", nullable: false),
                    sold_count = table.Column<int>(type: "integer", nullable: false),
                    min_purchase_per_txn = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    max_purchase_per_txn = table.Column<int>(type: "integer", nullable: false, defaultValue: 10),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    sales_start_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sales_end_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("event_ticket_tiers_pkey", x => x.id);
                    table.ForeignKey(
                        name: "event_ticket_tiers_event_id_fkey",
                        column: x => x.event_id,
                        principalSchema: "catalog",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "event_ticket_tiers_section_id_fkey",
                        column: x => x.section_id,
                        principalSchema: "catalog",
                        principalTable: "venue_sections",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "event_ticket_tiers_session_id_fkey",
                        column: x => x.session_id,
                        principalSchema: "catalog",
                        principalTable: "event_sessions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    public_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    booking_id = table.Column<long>(type: "bigint", nullable: false),
                    payment_method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    payment_gateway = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    payment_gateway_ref = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    idempotency_key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false, defaultValueSql: "'IDR'::bpchar"),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    payment_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    raw_gateway_response = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("payments_pkey", x => x.id);
                    table.ForeignKey(
                        name: "payments_booking_id_fkey",
                        column: x => x.booking_id,
                        principalSchema: "ticketing",
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_items",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    booking_id = table.Column<long>(type: "bigint", nullable: false),
                    tier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("booking_items_pkey", x => x.id);
                    table.ForeignKey(
                        name: "booking_items_booking_id_fkey",
                        column: x => x.booking_id,
                        principalSchema: "ticketing",
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "booking_items_tier_id_fkey",
                        column: x => x.tier_id,
                        principalSchema: "catalog",
                        principalTable: "event_ticket_tiers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ticket_holds",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    tier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    booking_id = table.Column<long>(type: "bigint", nullable: true),
                    seat_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    held_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ticket_holds_pkey", x => x.id);
                    table.ForeignKey(
                        name: "ticket_holds_booking_id_fkey",
                        column: x => x.booking_id,
                        principalSchema: "ticketing",
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ticket_holds_seat_id_fkey",
                        column: x => x.seat_id,
                        principalSchema: "catalog",
                        principalTable: "venue_seats",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "ticket_holds_tier_id_fkey",
                        column: x => x.tier_id,
                        principalSchema: "catalog",
                        principalTable: "event_ticket_tiers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "refund_requests",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    booking_id = table.Column<long>(type: "bigint", nullable: false),
                    payment_id = table.Column<long>(type: "bigint", nullable: true),
                    requested_by = table.Column<Guid>(type: "uuid", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    processed_by = table.Column<Guid>(type: "uuid", nullable: true),
                    processed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("refund_requests_pkey", x => x.id);
                    table.ForeignKey(
                        name: "refund_requests_booking_id_fkey",
                        column: x => x.booking_id,
                        principalSchema: "ticketing",
                        principalTable: "bookings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "refund_requests_payment_id_fkey",
                        column: x => x.payment_id,
                        principalSchema: "ticketing",
                        principalTable: "payments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "refund_requests_processed_by_fkey",
                        column: x => x.processed_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "refund_requests_requested_by_fkey",
                        column: x => x.requested_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    public_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    booking_item_id = table.Column<long>(type: "bigint", nullable: false),
                    tier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_id = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ticket_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    qr_code_payload = table.Column<string>(type: "text", nullable: false),
                    pdf_attachment_url = table.Column<string>(type: "text", nullable: true),
                    issued_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tickets_pkey", x => x.id);
                    table.ForeignKey(
                        name: "tickets_booking_item_id_fkey",
                        column: x => x.booking_item_id,
                        principalSchema: "ticketing",
                        principalTable: "booking_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tickets_seat_id_fkey",
                        column: x => x.seat_id,
                        principalSchema: "catalog",
                        principalTable: "venue_seats",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "tickets_tier_id_fkey",
                        column: x => x.tier_id,
                        principalSchema: "catalog",
                        principalTable: "event_ticket_tiers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ticket_scans",
                schema: "ticketing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ticket_id = table.Column<long>(type: "bigint", nullable: false),
                    scanned_by = table.Column<Guid>(type: "uuid", nullable: false),
                    scan_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    location_scanned = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    device_info = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ticket_scans_pkey", x => x.id);
                    table.ForeignKey(
                        name: "ticket_scans_scanned_by_fkey",
                        column: x => x.scanned_by,
                        principalSchema: "iam",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "ticket_scans_ticket_id_fkey",
                        column: x => x.ticket_id,
                        principalSchema: "ticketing",
                        principalTable: "tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "activity_timelines_2026_07_reference_id_reference_type_idx",
                schema: "ops",
                table: "activity_timelines_2026_07",
                columns: new[] { "reference_id", "reference_type" });

            migrationBuilder.CreateIndex(
                name: "IX_activity_timelines_2026_07_actor_id",
                schema: "ops",
                table: "activity_timelines_2026_07",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "activity_timelines_default_reference_id_reference_type_idx",
                schema: "ops",
                table: "activity_timelines_default",
                columns: new[] { "reference_id", "reference_type" });

            migrationBuilder.CreateIndex(
                name: "IX_activity_timelines_default_actor_id",
                schema: "ops",
                table: "activity_timelines_default",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_07_new_values_idx",
                schema: "ops",
                table: "audit_logs_2026_07",
                column: "new_values")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_07_old_values_idx",
                schema: "ops",
                table: "audit_logs_2026_07",
                column: "old_values")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_07_record_id_idx",
                schema: "ops",
                table: "audit_logs_2026_07",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_07_table_name_idx",
                schema: "ops",
                table: "audit_logs_2026_07",
                column: "table_name");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_08_new_values_idx",
                schema: "ops",
                table: "audit_logs_2026_08",
                column: "new_values")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_08_old_values_idx",
                schema: "ops",
                table: "audit_logs_2026_08",
                column: "old_values")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_08_record_id_idx",
                schema: "ops",
                table: "audit_logs_2026_08",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "audit_logs_2026_08_table_name_idx",
                schema: "ops",
                table: "audit_logs_2026_08",
                column: "table_name");

            migrationBuilder.CreateIndex(
                name: "audit_logs_default_new_values_idx",
                schema: "ops",
                table: "audit_logs_default",
                column: "new_values")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "audit_logs_default_old_values_idx",
                schema: "ops",
                table: "audit_logs_default",
                column: "old_values")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "audit_logs_default_record_id_idx",
                schema: "ops",
                table: "audit_logs_default",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "audit_logs_default_table_name_idx",
                schema: "ops",
                table: "audit_logs_default",
                column: "table_name");

            migrationBuilder.CreateIndex(
                name: "idx_booking_items_booking",
                schema: "ticketing",
                table: "booking_items",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "idx_booking_items_tier",
                schema: "ticketing",
                table: "booking_items",
                column: "tier_id");

            migrationBuilder.CreateIndex(
                name: "bookings_booking_number_key",
                schema: "ticketing",
                table: "bookings",
                column: "booking_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "bookings_public_id_key",
                schema: "ticketing",
                table: "bookings",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_bookings_customer",
                schema: "ticketing",
                table: "bookings",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "idx_bookings_event",
                schema: "ticketing",
                table: "bookings",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "idx_bookings_sla_expiry",
                schema: "ticketing",
                table: "bookings",
                column: "sla_payment_due_date",
                filter: "(status = 'AwaitingPayment'::booking_status)");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_voucher_id",
                schema: "ticketing",
                table: "bookings",
                column: "voucher_id");

            migrationBuilder.CreateIndex(
                name: "categories_slug_key",
                schema: "catalog",
                table: "categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent_category_id",
                schema: "catalog",
                table: "categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "discount_vouchers_organization_id_code_key",
                schema: "catalog",
                table: "discount_vouchers",
                columns: new[] { "organization_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_vouchers_org_code",
                schema: "catalog",
                table: "discount_vouchers",
                columns: new[] { "organization_id", "code" },
                filter: "(is_deleted = false)");

            migrationBuilder.CreateIndex(
                name: "IX_discount_vouchers_event_id",
                schema: "catalog",
                table: "discount_vouchers",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_sessions_event_id",
                schema: "catalog",
                table: "event_sessions",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "idx_tiers_event",
                schema: "catalog",
                table: "event_ticket_tiers",
                column: "event_id",
                filter: "(is_deleted = false)");

            migrationBuilder.CreateIndex(
                name: "idx_tiers_session",
                schema: "catalog",
                table: "event_ticket_tiers",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_ticket_tiers_section_id",
                schema: "catalog",
                table: "event_ticket_tiers",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "events_slug_key",
                schema: "catalog",
                table: "events",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_events_category",
                schema: "catalog",
                table: "events",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "idx_events_org",
                schema: "catalog",
                table: "events",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "idx_events_published_upcoming",
                schema: "catalog",
                table: "events",
                column: "start_date",
                filter: "((is_published = true) AND (is_deleted = false))");

            migrationBuilder.CreateIndex(
                name: "idx_events_venue",
                schema: "catalog",
                table: "events",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_approved_by",
                schema: "catalog",
                table: "events",
                column: "approved_by");

            migrationBuilder.CreateIndex(
                name: "IX_events_created_by",
                schema: "catalog",
                table: "events",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "external_logins_provider_provider_key_key",
                schema: "iam",
                table: "external_logins",
                columns: new[] { "provider", "provider_key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_external_logins_user_id",
                schema: "iam",
                table: "external_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_internal_notes_ref",
                schema: "ops",
                table: "internal_notes",
                column: "reference_id");

            migrationBuilder.CreateIndex(
                name: "IX_internal_notes_staff_id",
                schema: "ops",
                table: "internal_notes",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                schema: "ops",
                table: "notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_org_members_org",
                schema: "tenancy",
                table: "organization_members",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "idx_org_members_user",
                schema: "tenancy",
                table: "organization_members",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_organization_members_invited_by",
                schema: "tenancy",
                table: "organization_members",
                column: "invited_by");

            migrationBuilder.CreateIndex(
                name: "IX_organization_members_role_id",
                schema: "tenancy",
                table: "organization_members",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "organization_members_organization_id_user_id_key",
                schema: "tenancy",
                table: "organization_members",
                columns: new[] { "organization_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_settlement_org_event",
                schema: "tenancy",
                table: "organization_settlements",
                columns: new[] { "organization_id", "event_id" });

            migrationBuilder.CreateIndex(
                name: "IX_organization_settlements_event_id",
                schema: "tenancy",
                table: "organization_settlements",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_organizations_owner_user_id",
                schema: "tenancy",
                table: "organizations",
                column: "owner_user_id");

            migrationBuilder.CreateIndex(
                name: "idx_webhook_logs_processed",
                schema: "ticketing",
                table: "payment_webhook_logs",
                column: "processed",
                filter: "(processed = false)");

            migrationBuilder.CreateIndex(
                name: "idx_payments_booking",
                schema: "ticketing",
                table: "payments",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "payments_idempotency_key_key",
                schema: "ticketing",
                table: "payments",
                column: "idempotency_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "payments_public_id_key",
                schema: "ticketing",
                table: "payments",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payout_requests_organization_id",
                schema: "tenancy",
                table: "payout_requests",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "IX_payout_requests_processed_by",
                schema: "tenancy",
                table: "payout_requests",
                column: "processed_by");

            migrationBuilder.CreateIndex(
                name: "payout_requests_public_id_key",
                schema: "tenancy",
                table: "payout_requests",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "permissions_permission_code_key",
                schema: "iam",
                table: "permissions",
                column: "permission_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_refresh_tokens_user",
                schema: "iam",
                table: "refresh_tokens",
                column: "user_id",
                filter: "(revoked_at IS NULL)");

            migrationBuilder.CreateIndex(
                name: "idx_refunds_booking",
                schema: "ticketing",
                table: "refund_requests",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_refund_requests_payment_id",
                schema: "ticketing",
                table: "refund_requests",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_refund_requests_processed_by",
                schema: "ticketing",
                table: "refund_requests",
                column: "processed_by");

            migrationBuilder.CreateIndex(
                name: "IX_refund_requests_requested_by",
                schema: "ticketing",
                table: "refund_requests",
                column: "requested_by");

            migrationBuilder.CreateIndex(
                name: "idx_role_perms_composite",
                schema: "iam",
                table: "role_permissions",
                columns: new[] { "role_id", "permission_id" });

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_permission_id",
                schema: "iam",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_system_settings_updated_by",
                schema: "ops",
                table: "system_settings",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "idx_holds_booking",
                schema: "ticketing",
                table: "ticket_holds",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "idx_holds_expiry",
                schema: "ticketing",
                table: "ticket_holds",
                column: "expires_at",
                filter: "(status = 'Active'::hold_status)");

            migrationBuilder.CreateIndex(
                name: "idx_holds_tier_active",
                schema: "ticketing",
                table: "ticket_holds",
                column: "tier_id",
                filter: "(status = 'Active'::hold_status)");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_holds_seat_id",
                schema: "ticketing",
                table: "ticket_holds",
                column: "seat_id");

            migrationBuilder.CreateIndex(
                name: "uq_active_seat_hold",
                schema: "ticketing",
                table: "ticket_holds",
                columns: new[] { "tier_id", "seat_id" },
                unique: true,
                filter: "((seat_id IS NOT NULL) AND (status = 'Active'::hold_status))");

            migrationBuilder.CreateIndex(
                name: "idx_ticket_scans_staff",
                schema: "ticketing",
                table: "ticket_scans",
                column: "scanned_by");

            migrationBuilder.CreateIndex(
                name: "idx_ticket_scans_ticket",
                schema: "ticketing",
                table: "ticket_scans",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "idx_tickets_booking_item",
                schema: "ticketing",
                table: "tickets",
                column: "booking_item_id");

            migrationBuilder.CreateIndex(
                name: "idx_tickets_seat",
                schema: "ticketing",
                table: "tickets",
                column: "seat_id");

            migrationBuilder.CreateIndex(
                name: "idx_tickets_tier",
                schema: "ticketing",
                table: "tickets",
                column: "tier_id");

            migrationBuilder.CreateIndex(
                name: "tickets_public_id_key",
                schema: "ticketing",
                table: "tickets",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tickets_ticket_number_key",
                schema: "ticketing",
                table: "tickets",
                column: "ticket_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_active_seat_ticket",
                schema: "ticketing",
                table: "tickets",
                columns: new[] { "tier_id", "seat_id" },
                unique: true,
                filter: "((seat_id IS NOT NULL) AND (is_deleted = false))");

            migrationBuilder.CreateIndex(
                name: "idx_user_platform_roles_user",
                schema: "iam",
                table: "user_platform_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_platform_roles_assigned_by",
                schema: "iam",
                table: "user_platform_roles",
                column: "assigned_by");

            migrationBuilder.CreateIndex(
                name: "IX_user_platform_roles_role_id",
                schema: "iam",
                table: "user_platform_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "idx_users_active",
                schema: "iam",
                table: "users",
                column: "id",
                filter: "(is_deleted = false)");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                schema: "iam",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_venue_seats_section",
                schema: "catalog",
                table: "venue_seats",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "venue_seats_section_id_seat_row_seat_number_key",
                schema: "catalog",
                table: "venue_seats",
                columns: new[] { "section_id", "seat_row", "seat_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_venue_sections_venue",
                schema: "catalog",
                table: "venue_sections",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "venue_sections_venue_id_section_name_key",
                schema: "catalog",
                table: "venue_sections",
                columns: new[] { "venue_id", "section_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_venues_active",
                schema: "catalog",
                table: "venues",
                column: "id",
                filter: "(is_deleted = false)");

            migrationBuilder.CreateIndex(
                name: "idx_venues_org",
                schema: "catalog",
                table: "venues",
                column: "organization_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_timelines_2026_07",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "activity_timelines_default",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "audit_logs_2026_07",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "audit_logs_2026_08",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "audit_logs_default",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "external_logins",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "internal_notes",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "knowledge_bases",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "notifications",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "organization_members",
                schema: "tenancy");

            migrationBuilder.DropTable(
                name: "organization_settlements",
                schema: "tenancy");

            migrationBuilder.DropTable(
                name: "payment_webhook_logs",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "payout_requests",
                schema: "tenancy");

            migrationBuilder.DropTable(
                name: "refresh_tokens",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "refund_requests",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "scheduled_job_runs",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "system_settings",
                schema: "ops");

            migrationBuilder.DropTable(
                name: "ticket_holds",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "ticket_scans",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "user_platform_roles",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "payments",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "tickets",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "booking_items",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "venue_seats",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "bookings",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "event_ticket_tiers",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "discount_vouchers",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "venue_sections",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "event_sessions",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "events",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "venues",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "organizations",
                schema: "tenancy");

            migrationBuilder.DropTable(
                name: "users",
                schema: "iam");
        }
    }
}
