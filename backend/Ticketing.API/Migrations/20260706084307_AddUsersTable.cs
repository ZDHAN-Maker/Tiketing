using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "iam",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "user_platform_roles",
                schema: "iam",
                newName: "user_platform_roles");

            migrationBuilder.RenameTable(
                name: "roles",
                schema: "iam",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                schema: "iam",
                newName: "role_permissions");

            migrationBuilder.RenameTable(
                name: "refresh_tokens",
                schema: "iam",
                newName: "refresh_tokens");

            migrationBuilder.RenameTable(
                name: "permissions",
                schema: "iam",
                newName: "permissions");

            migrationBuilder.RenameTable(
                name: "external_logins",
                schema: "iam",
                newName: "external_logins");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "catalog",
                table: "venue_sections",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "ticketing",
                table: "tickets",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Result",
                schema: "ticketing",
                table: "ticket_scans",
                newName: "result");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "ticketing",
                table: "ticket_holds",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "ticketing",
                table: "refund_requests",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "tenancy",
                table: "payout_requests",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "ticketing",
                table: "payments",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "tenancy",
                table: "organization_members",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "EventType",
                schema: "catalog",
                table: "events",
                newName: "event_type");

            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                schema: "catalog",
                table: "events",
                newName: "approval_status");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "catalog",
                table: "event_ticket_tiers",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "catalog",
                table: "discount_vouchers",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "ticketing",
                table: "bookings",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "users",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Scope",
                table: "roles",
                newName: "scope");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:booking_status", "AwaitingPayment,Paid,Cancelled,Expired,Refunded,PartiallyRefunded")
                .Annotation("Npgsql:Enum:discount_type", "Percentage,FixedAmount")
                .Annotation("Npgsql:Enum:event_approval_status", "Draft,PendingReview,Approved,Rejected,Cancelled")
                .Annotation("Npgsql:Enum:event_type", "GeneralAdmission,ReservedSeating,Hybrid")
                .Annotation("Npgsql:Enum:hold_status", "Active,Released,Converted")
                .Annotation("Npgsql:Enum:job_run_status", "Running,Success,Failed")
                .Annotation("Npgsql:Enum:notification_channel", "Email,SMS,Push,InApp")
                .Annotation("Npgsql:Enum:notification_status", "Queued,Sent,Failed")
                .Annotation("Npgsql:Enum:org_member_status", "Invited,Active,Removed")
                .Annotation("Npgsql:Enum:org_verification_status", "Pending,Verified,Rejected,Suspended")
                .Annotation("Npgsql:Enum:payment_status", "Pending,Success,Failed,Expired,Refunded")
                .Annotation("Npgsql:Enum:payout_status", "Requested,Processing,Paid,Rejected")
                .Annotation("Npgsql:Enum:refund_status", "Requested,Approved,Rejected,Processed")
                .Annotation("Npgsql:Enum:role_scope", "platform,organization")
                .Annotation("Npgsql:Enum:role_scope.role_scope", "platform,organization")
                .Annotation("Npgsql:Enum:scan_result", "Success,DuplicateScan,InvalidTicket,WrongEvent")
                .Annotation("Npgsql:Enum:ticket_status", "Issued,Scanned,Refunded,Void")
                .Annotation("Npgsql:Enum:ticketing.booking_status", "awaiting_payment,paid,cancelled,expired,refunded,partially_refunded")
                .Annotation("Npgsql:Enum:ticketing.payment_status", "pending,success,failed,expired,refunded")
                .Annotation("Npgsql:Enum:tier_type", "GeneralAdmission,Seated")
                .Annotation("Npgsql:Enum:user_status", "Active,Suspended,Banned,PendingVerification")
                .Annotation("Npgsql:Enum:user_status.user_status", "active,suspended,banned,pending_verification")
                .Annotation("Npgsql:Enum:venue_section_type", "Seated,Standing")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .OldAnnotation("Npgsql:Enum:booking_status", "AwaitingPayment,Paid,Cancelled,Expired,Refunded,PartiallyRefunded")
                .OldAnnotation("Npgsql:Enum:discount_type", "Percentage,FixedAmount")
                .OldAnnotation("Npgsql:Enum:event_approval_status", "Draft,PendingReview,Approved,Rejected,Cancelled")
                .OldAnnotation("Npgsql:Enum:event_type", "GeneralAdmission,ReservedSeating,Hybrid")
                .OldAnnotation("Npgsql:Enum:hold_status", "Active,Released,Converted")
                .OldAnnotation("Npgsql:Enum:iam.role_scope", "platform,organization")
                .OldAnnotation("Npgsql:Enum:iam.user_status", "active,suspended,banned,pending_verification")
                .OldAnnotation("Npgsql:Enum:job_run_status", "Running,Success,Failed")
                .OldAnnotation("Npgsql:Enum:notification_channel", "Email,SMS,Push,InApp")
                .OldAnnotation("Npgsql:Enum:notification_status", "Queued,Sent,Failed")
                .OldAnnotation("Npgsql:Enum:org_member_status", "Invited,Active,Removed")
                .OldAnnotation("Npgsql:Enum:org_verification_status", "Pending,Verified,Rejected,Suspended")
                .OldAnnotation("Npgsql:Enum:payment_status", "Pending,Success,Failed,Expired,Refunded")
                .OldAnnotation("Npgsql:Enum:payout_status", "Requested,Processing,Paid,Rejected")
                .OldAnnotation("Npgsql:Enum:refund_status", "Requested,Approved,Rejected,Processed")
                .OldAnnotation("Npgsql:Enum:role_scope", "Platform,Organization")
                .OldAnnotation("Npgsql:Enum:scan_result", "Success,DuplicateScan,InvalidTicket,WrongEvent")
                .OldAnnotation("Npgsql:Enum:ticket_status", "Issued,Scanned,Refunded,Void")
                .OldAnnotation("Npgsql:Enum:ticketing.booking_status", "awaiting_payment,paid,cancelled,expired,refunded,partially_refunded")
                .OldAnnotation("Npgsql:Enum:ticketing.payment_status", "pending,success,failed,expired,refunded")
                .OldAnnotation("Npgsql:Enum:tier_type", "GeneralAdmission,Seated")
                .OldAnnotation("Npgsql:Enum:user_status", "Active,Suspended,Banned,PendingVerification")
                .OldAnnotation("Npgsql:Enum:venue_section_type", "Seated,Standing")
                .OldAnnotation("Npgsql:PostgresExtension:citext", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.AlterColumn<int>(
                name: "scope",
                table: "roles",
                type: "role_scope",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "v_ticket_tier_availabilities",
                columns: table => new
                {
                    tier_id = table.Column<Guid>(type: "uuid", nullable: true),
                    event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tier_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    quota = table.Column<int>(type: "integer", nullable: true),
                    held_count = table.Column<int>(type: "integer", nullable: true),
                    sold_count = table.Column<int>(type: "integer", nullable: true),
                    available_quota = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "v_ticket_tier_availabilities");

            migrationBuilder.EnsureSchema(
                name: "iam");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "iam");

            migrationBuilder.RenameTable(
                name: "user_platform_roles",
                newName: "user_platform_roles",
                newSchema: "iam");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "roles",
                newSchema: "iam");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                newName: "role_permissions",
                newSchema: "iam");

            migrationBuilder.RenameTable(
                name: "refresh_tokens",
                newName: "refresh_tokens",
                newSchema: "iam");

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "permissions",
                newSchema: "iam");

            migrationBuilder.RenameTable(
                name: "external_logins",
                newName: "external_logins",
                newSchema: "iam");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "catalog",
                table: "venue_sections",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "ticketing",
                table: "tickets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "result",
                schema: "ticketing",
                table: "ticket_scans",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "ticketing",
                table: "ticket_holds",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "ticketing",
                table: "refund_requests",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "tenancy",
                table: "payout_requests",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "ticketing",
                table: "payments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "tenancy",
                table: "organization_members",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "event_type",
                schema: "catalog",
                table: "events",
                newName: "EventType");

            migrationBuilder.RenameColumn(
                name: "approval_status",
                schema: "catalog",
                table: "events",
                newName: "ApprovalStatus");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "catalog",
                table: "event_ticket_tiers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "catalog",
                table: "discount_vouchers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "ticketing",
                table: "bookings",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "iam",
                table: "users",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "scope",
                schema: "iam",
                table: "roles",
                newName: "Scope");

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
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .OldAnnotation("Npgsql:Enum:booking_status", "AwaitingPayment,Paid,Cancelled,Expired,Refunded,PartiallyRefunded")
                .OldAnnotation("Npgsql:Enum:discount_type", "Percentage,FixedAmount")
                .OldAnnotation("Npgsql:Enum:event_approval_status", "Draft,PendingReview,Approved,Rejected,Cancelled")
                .OldAnnotation("Npgsql:Enum:event_type", "GeneralAdmission,ReservedSeating,Hybrid")
                .OldAnnotation("Npgsql:Enum:hold_status", "Active,Released,Converted")
                .OldAnnotation("Npgsql:Enum:job_run_status", "Running,Success,Failed")
                .OldAnnotation("Npgsql:Enum:notification_channel", "Email,SMS,Push,InApp")
                .OldAnnotation("Npgsql:Enum:notification_status", "Queued,Sent,Failed")
                .OldAnnotation("Npgsql:Enum:org_member_status", "Invited,Active,Removed")
                .OldAnnotation("Npgsql:Enum:org_verification_status", "Pending,Verified,Rejected,Suspended")
                .OldAnnotation("Npgsql:Enum:payment_status", "Pending,Success,Failed,Expired,Refunded")
                .OldAnnotation("Npgsql:Enum:payout_status", "Requested,Processing,Paid,Rejected")
                .OldAnnotation("Npgsql:Enum:refund_status", "Requested,Approved,Rejected,Processed")
                .OldAnnotation("Npgsql:Enum:role_scope", "platform,organization")
                .OldAnnotation("Npgsql:Enum:role_scope.role_scope", "platform,organization")
                .OldAnnotation("Npgsql:Enum:scan_result", "Success,DuplicateScan,InvalidTicket,WrongEvent")
                .OldAnnotation("Npgsql:Enum:ticket_status", "Issued,Scanned,Refunded,Void")
                .OldAnnotation("Npgsql:Enum:ticketing.booking_status", "awaiting_payment,paid,cancelled,expired,refunded,partially_refunded")
                .OldAnnotation("Npgsql:Enum:ticketing.payment_status", "pending,success,failed,expired,refunded")
                .OldAnnotation("Npgsql:Enum:tier_type", "GeneralAdmission,Seated")
                .OldAnnotation("Npgsql:Enum:user_status", "Active,Suspended,Banned,PendingVerification")
                .OldAnnotation("Npgsql:Enum:user_status.user_status", "active,suspended,banned,pending_verification")
                .OldAnnotation("Npgsql:Enum:venue_section_type", "Seated,Standing")
                .OldAnnotation("Npgsql:PostgresExtension:citext", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.AlterColumn<int>(
                name: "Scope",
                schema: "iam",
                table: "roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "role_scope");
        }
    }
}
