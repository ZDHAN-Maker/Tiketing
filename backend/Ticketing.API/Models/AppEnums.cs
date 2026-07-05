namespace Ticketing.API.Models; // Sesuaikan dengan namespace Anda

public enum RoleScope { Platform, Organization }
public enum UserStatus { Active, Suspended, Banned, PendingVerification }
public enum OrgVerificationStatus { Pending, Verified, Rejected, Suspended }
public enum OrgMemberStatus { Invited, Active, Removed }
public enum PayoutStatus { Requested, Processing, Paid, Rejected }
public enum VenueSectionType { Seated, Standing }
public enum EventType { GeneralAdmission, ReservedSeating, Hybrid }
public enum EventApprovalStatus { Draft, PendingReview, Approved, Rejected, Cancelled }
public enum TierType { GeneralAdmission, Seated }
public enum DiscountType { Percentage, FixedAmount }
public enum BookingStatus { AwaitingPayment, Paid, Cancelled, Expired, Refunded, PartiallyRefunded }
public enum HoldStatus { Active, Released, Converted }
public enum PaymentStatus { Pending, Success, Failed, Expired, Refunded }
public enum RefundStatus { Requested, Approved, Rejected, Processed }
public enum TicketStatus { Issued, Scanned, Refunded, Void }
public enum ScanResult { Success, DuplicateScan, InvalidTicket, WrongEvent }
public enum NotificationChannel { Email, SMS, Push, InApp }
public enum NotificationStatus { Queued, Sent, Failed }
public enum JobRunStatus { Running, Success, Failed }