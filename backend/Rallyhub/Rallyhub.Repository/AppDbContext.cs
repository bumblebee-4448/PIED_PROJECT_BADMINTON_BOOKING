using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository.Entity;
using Exception = Rallyhub.Repository.Entity.Exception;

namespace Rallyhub.Repository;

public class AppDbContext : DbContext
{
    // Hardcoded Guids for Seed Data (to ensure consistent migrations)
    public static readonly Guid TestOwnerUserId = Guid.Parse("fe0607c8-2fc3-4288-9b3a-87c958aea79b");
    public static readonly Guid TestOwnerId = Guid.Parse("87a8cc49-08a8-46fa-b793-078017bb4c96");
    public static readonly Guid TestCustomerUserId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid TestCustomerUserId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid TestCustomerId1 = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid TestCustomerId2 = Guid.Parse("44444444-4444-4444-4444-444444444444");
    public static readonly Guid TestCourtId = Guid.Parse("55555555-5555-5555-5555-555555555555");
    public static readonly Guid TestSubCourtId = Guid.Parse("66666666-6666-6666-6666-666666666666");
    public static readonly Guid TestBookingId1 = Guid.Parse("77777777-7777-7777-7777-777777777777");
    public static readonly Guid TestBookingId2 = Guid.Parse("88888888-8888-8888-8888-888888888888");
    public static readonly Guid TestWalletIdOwner = Guid.Parse("99999999-9999-9999-9999-999999999999");
    public static readonly Guid TestWalletIdCus1 = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    public static readonly Guid TestWalletIdCus2 = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
    public static readonly Guid TestTransactionId1 = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
    public static readonly Guid TestTransactionId2 = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingDetail> BookingDetails { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CampaignCourt> CampaignCourts { get; set; }
    public DbSet<ConfigSlot> ConfigSlots { get; set; }
    public DbSet<Court> Courts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Exception> Exceptions { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<LikeListDetail> LikeListDetails { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<OverideSlot> OverideSlots { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<OwnerRequest> OwnerRequests { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<SubCourt> SubCourts { get; set; }
    public DbSet<SystemReport> SystemReports { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Withdrawal> Withdrawals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(50).HasDefaultValue("Customer");
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasMaxLength(11);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50).HasDefaultValue("Active");
            builder.HasOne(x => x.Customer).WithOne(x => x.User).HasForeignKey<Customer>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<User>
            {
                new() { Id = TestCustomerUserId1, Email = "test_cus1@gmail.com", PasswordHash = "hash", Role = "Customer", FirstName = "Customer", LastName = "One", PhoneNumber = "0123456781", Status = "Active", CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) },
                new() { Id = TestCustomerUserId2, Email = "test_cus2@gmail.com", PasswordHash = "hash", Role = "Customer", FirstName = "Customer", LastName = "Two", PhoneNumber = "0123456782", Status = "Active", CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) }
            });
        });

        modelBuilder.Entity<Booking>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DiscountAmount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Status).IsRequired().HasMaxLength(100).HasDefaultValue("Pending");
            builder.Property(x => x.CancellationReason).HasMaxLength(500);
            builder.HasOne(x => x.Campaign).WithMany(x => x.Bookings).HasForeignKey(x => x.CampaignId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Customer).WithMany(x => x.Bookings).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Booking>
            {
                new() { Id = TestBookingId1, TotalPrice = 200000, FinalPrice = 200000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = DateTimeOffset.UtcNow.AddDays(-5), UpdatedAt = DateTimeOffset.UtcNow.AddDays(-5) },
                new() { Id = TestBookingId2, TotalPrice = 300000, FinalPrice = 300000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow }
            });
        });

        modelBuilder.Entity<BookingDetail>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.SubCourtId, x.Date, x.StartTime, x.EndTime }).IsUnique().HasFilter("\"Status\" IN ('Pending', 'Banked')");
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.SubCourt).WithMany(x => x.BookingDetails).HasForeignKey(x => x.SubCourtId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Booking).WithMany(x => x.BookingDetails).HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.StartTime).IsRequired().HasColumnType("time");
            builder.Property(x => x.EndTime).IsRequired().HasColumnType("time");

            builder.HasData(new List<BookingDetail>
            {
                new() { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), SubCourtId = TestSubCourtId, BookingId = TestBookingId1, Date = DateTimeOffset.UtcNow.AddDays(-5), StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(10, 0), Price = 200000, Status = "Banked", CreatedAt = DateTimeOffset.UtcNow.AddDays(-5), UpdatedAt = DateTimeOffset.UtcNow.AddDays(-5) },
                new() { Id = Guid.Parse("20000000-0000-0000-0000-000000000002"), SubCourtId = TestSubCourtId, BookingId = TestBookingId2, Date = DateTimeOffset.UtcNow, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(16, 0), Price = 300000, Status = "Banked", CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow }
            });
        });

        modelBuilder.Entity<Campaign>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.IsGlobal).HasDefaultValue(false);
            builder.Property(x => x.DiscountPercent).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.MaxDiscountAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.MinBookingAmount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.HasOne(x => x.Owner).WithMany(x => x.Campaigns).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CampaignCourt>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Court).WithMany(x => x.CampaignCourts).HasForeignKey(x => x.CourtId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Campaign).WithMany(x => x.Courts).HasForeignKey(x => x.CampaignId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ConfigSlot>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.StartTime).IsRequired().HasColumnType("time");
            builder.Property(x => x.EndTime).IsRequired().HasColumnType("time");
            builder.HasOne(x => x.SubCourtDetail).WithMany(x => x.ConfigSlots).HasForeignKey(x => x.SubCourtDetailId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Court>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureUrl).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50).HasDefaultValue("Active");
            builder.Property(x => x.Latitude).HasColumnType("decimal(18,10)");
            builder.Property(x => x.Longitude).HasColumnType("decimal(18,10)");
            builder.Property(x => x.MapUrl).IsRequired().HasMaxLength(1000);
            builder.HasOne(x => x.Owner).WithMany(x => x.Courts).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new Court { Id = TestCourtId, Name = "Sân Test Dashboard", Address = "Test Address", OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(22, 0), Status = "Active", PictureUrl = "https://example.com/court.jpg", Latitude = 10.0m, Longitude = 106.0m, MapUrl = "https://maps.google.com", OwnerId = TestOwnerId, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) });
        });

        modelBuilder.Entity<Customer>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new List<Customer>
            {
                new() { Id = TestCustomerId1, UserId = TestCustomerUserId1, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) },
                new() { Id = TestCustomerId2, UserId = TestCustomerUserId2, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) }
            });
        });

        modelBuilder.Entity<Exception>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartTime).IsRequired().HasColumnType("time");
            builder.Property(x => x.EndTime).IsRequired().HasColumnType("time");
            builder.HasOne(x => x.SubCourtDetail).WithMany(x => x.Exceptions).HasForeignKey(x => x.SubCourtDetailId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(500);
        });

        modelBuilder.Entity<Feedback>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rating).IsRequired();
            builder.Property(x => x.Comment).HasMaxLength(500);
            builder.HasOne(x => x.Court).WithMany(x => x.Feedbacks).HasForeignKey(x => x.CourtId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Customer).WithMany(x => x.Feedbacks).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Booking).WithMany(x => x.Feedbacks).HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<LikeListDetail>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Court).WithMany(x => x.LikeListDetails).HasForeignKey(x => x.CourtId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Customer).WithMany(x => x.LikeListDetails).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Notification>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsRead).IsRequired().HasDefaultValue(false);
            builder.HasOne(x => x.Booking).WithMany(x => x.Notifications).HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithMany(x => x.Notifications).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Court).WithMany(x => x.Notifications).HasForeignKey(x => x.CourtId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Report).WithMany().HasForeignKey(x => x.ReportId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.SystemReport).WithMany().HasForeignKey(x => x.SystemReportId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.OwnerRequest).WithMany().HasForeignKey(x => x.OwnerRequestId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Feedback).WithMany().HasForeignKey(x => x.FeedbackId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Withdrawal).WithMany().HasForeignKey(x => x.WithdrawalId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OverideSlot>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SubCourtDetail).WithMany(x => x.OverideSlots).HasForeignKey(x => x.SubCourtDetailId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.StartTime).IsRequired().HasColumnType("time");
            builder.Property(x => x.EndTime).IsRequired().HasColumnType("time");
            builder.Property(x => x.IsRecurring).HasDefaultValue(false);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Owner>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BusinessName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.BusinessAddress).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TaxCode).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.TaxCode).IsUnique();
            builder.HasOne(x => x.OwnerRequest).WithOne(x => x.Owner).HasForeignKey<OwnerRequest>(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithOne(x => x.Owner).HasForeignKey<Owner>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OwnerRequest>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BusinessName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.BusinessAddress).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TaxCode).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BusinessLicenseUrl).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IdentityNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.IdentityCardFrontUrl).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IdentityCardBackUrl).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue("Pending").HasMaxLength(50);
            builder.Property(x => x.RejectionReason).HasMaxLength(200);
            builder.HasOne(x => x.Customer).WithMany(x => x.OwnerRequests).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Report>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue("Pending");
            builder.HasOne(x => x.Customer).WithMany(x => x.Reports).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Court).WithMany(x => x.Reports).HasForeignKey(x => x.CourtId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Booking).WithMany(x => x.Reports).HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SubCourt>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.Court).WithMany(x => x.SubCourts).HasForeignKey(x => x.CourtId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new SubCourt { Id = TestSubCourtId, Name = "Sân con Test 1", CourtId = TestCourtId, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) });
        });

        modelBuilder.Entity<SystemReport>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Reason).HasMaxLength(500);
            builder.Property(x => x.Status).HasDefaultValue("Pending");
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.HasOne(x => x.User).WithMany(x => x.SystemReports).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Transaction>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).HasMaxLength(100);
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.BalanceBefore).HasColumnType("decimal(18,2)");
            builder.Property(x => x.BalanceAfter).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SePayId).HasMaxLength(250);
            builder.HasIndex(x => x.SePayId).IsUnique();
            builder.Property(x => x.BankRefCode).HasMaxLength(250);
            builder.HasIndex(x => x.BankRefCode).IsUnique();
            builder.Property(x => x.BankAccountNumber).HasMaxLength(500);
            builder.Property(x => x.TransferContent).HasMaxLength(500);
            builder.Property(x => x.ActionCode).HasMaxLength(250);
            builder.HasIndex(x => x.ActionCode).IsUnique();
            builder.Property(x => x.Signature).HasMaxLength(250);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue("Success");
            builder.HasOne(x => x.Booking).WithMany(x => x.Transactions).HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Wallet).WithMany(x => x.Transactions).HasForeignKey(x => x.WalletId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Transaction>
            {
                new() { Id = TestTransactionId1, Type = "Receive", Amount = 200000, BalanceBefore = 0, BalanceAfter = 200000, Status = "Success", BookingId = TestBookingId1, WalletId = TestWalletIdCus1, CreatedAt = DateTimeOffset.UtcNow.AddDays(-5), UpdatedAt = DateTimeOffset.UtcNow.AddDays(-5), SePayId = "TEST001", BankRefCode = "REF001" },
                new() { Id = TestTransactionId2, Type = "Receive", Amount = 300000, BalanceBefore = 200000, BalanceAfter = 500000, Status = "Success", BookingId = TestBookingId2, WalletId = TestWalletIdCus1, CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, SePayId = "TEST002", BankRefCode = "REF002" }
            });
        });

        modelBuilder.Entity<Wallet>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BankName).HasMaxLength(250);
            builder.Property(x => x.BankAccount).HasMaxLength(100);
            builder.Property(x => x.Balance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Version).IsConcurrencyToken();
            builder.HasOne(x => x.User).WithOne(x => x.Wallet).HasForeignKey<Wallet>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Wallet>
            {
                new() { Id = TestWalletIdCus1, BankName = "TestBank", BankAccount = "222222222", Balance = 1000000, Version = 0, UserId = TestCustomerUserId1, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) },
                new() { Id = TestWalletIdCus2, BankName = "TestBank", BankAccount = "333333333", Balance = 1000000, Version = 0, UserId = TestCustomerUserId2, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) }
            });
        });

        modelBuilder.Entity<Withdrawal>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.BankName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.BankAccountNumber).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BankAccountName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50).HasDefaultValue("Pending");
            builder.Property(x => x.RejectionReason).HasMaxLength(500);
            builder.Property(x => x.AdminNote).HasMaxLength(500);
            builder.HasOne(x => x.Wallet).WithMany(x => x.Withdrawals).HasForeignKey(x => x.WalletId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ProcessedByAdmin).WithMany().HasForeignKey(x => x.ProcessedByAdminId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Transaction).WithMany().HasForeignKey(x => x.TransactionId).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Court>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<SubCourt>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Owner>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);
    }
}
