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
    public static readonly Guid TestWalletIdOwner = Guid.Parse("ba0ba849-3003-4962-95d1-52da516768aa");
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
                new() { Id = TestBookingId2, TotalPrice = 300000, FinalPrice = 300000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                // Thêm booking cho 3 ngày gần đây cho Sân Test Dashboard
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"), TotalPrice = 150000, FinalPrice = 150000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 14, 8, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 8, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"), TotalPrice = 180000, FinalPrice = 180000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = new DateTimeOffset(2026, 5, 14, 14, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 14, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"), TotalPrice = 200000, FinalPrice = 200000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 15, 9, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 9, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"), TotalPrice = 220000, FinalPrice = 220000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = new DateTimeOffset(2026, 5, 15, 15, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 15, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"), TotalPrice = 250000, FinalPrice = 250000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 15, 18, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 18, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000006"), TotalPrice = 190000, FinalPrice = 190000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = new DateTimeOffset(2026, 5, 16, 7, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 7, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"), TotalPrice = 230000, FinalPrice = 230000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 16, 16, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 16, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"), TotalPrice = 150000, FinalPrice = 150000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 13, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 13, 10, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000009"), TotalPrice = 200000, FinalPrice = 200000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = new DateTimeOffset(2026, 5, 13, 15, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 13, 15, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000010"), TotalPrice = 180000, FinalPrice = 180000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 14, 19, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 19, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000011"), TotalPrice = 220000, FinalPrice = 220000, Status = "Complete", CustomerId = TestCustomerId2, CreatedAt = new DateTimeOffset(2026, 5, 15, 7, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 7, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("b0000000-0000-0000-0000-000000000012"), TotalPrice = 170000, FinalPrice = 170000, Status = "Complete", CustomerId = TestCustomerId1, CreatedAt = new DateTimeOffset(2026, 5, 16, 20, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 20, 0, 0, TimeSpan.Zero) }
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
                new() { Id = Guid.Parse("20000000-0000-0000-0000-000000000002"), SubCourtId = TestSubCourtId, BookingId = TestBookingId2, Date = DateTimeOffset.UtcNow, StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(16, 0), Price = 300000, Status = "Banked", CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                // Thêm booking detail
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000001"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000001"), Date = new DateTimeOffset(2026, 5, 14, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(9, 0), Price = 150000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 14, 8, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 8, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000002"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), Date = new DateTimeOffset(2026, 5, 14, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 0), Price = 180000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 14, 14, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 14, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000003"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000003"), Date = new DateTimeOffset(2026, 5, 15, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(11, 0), Price = 200000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 15, 9, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 9, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000004"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000004"), Date = new DateTimeOffset(2026, 5, 15, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(17, 0), Price = 220000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 15, 15, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 15, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000005"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000005"), Date = new DateTimeOffset(2026, 5, 15, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(18, 0), EndTime = new TimeOnly(20, 0), Price = 250000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 15, 18, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 18, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000006"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000006"), Date = new DateTimeOffset(2026, 5, 16, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(9, 0), Price = 190000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 16, 7, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 7, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000007"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000007"), Date = new DateTimeOffset(2026, 5, 16, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(18, 0), Price = 230000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 16, 16, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 16, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000008"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), Date = new DateTimeOffset(2026, 5, 13, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(11, 0), Price = 150000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 13, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 13, 10, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000009"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000009"), Date = new DateTimeOffset(2026, 5, 13, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(17, 0), Price = 200000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 13, 15, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 13, 15, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000010"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000010"), Date = new DateTimeOffset(2026, 5, 14, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(19, 0), EndTime = new TimeOnly(21, 0), Price = 180000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 14, 19, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 19, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000011"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000011"), Date = new DateTimeOffset(2026, 5, 15, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(9, 0), Price = 220000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 15, 7, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 7, 0, 0, TimeSpan.Zero) },
                new() { Id = Guid.Parse("d0000000-0000-0000-0000-000000000012"), SubCourtId = TestSubCourtId, BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000012"), Date = new DateTimeOffset(2026, 5, 16, 0, 0, 0, TimeSpan.Zero), StartTime = new TimeOnly(20, 0), EndTime = new TimeOnly(22, 0), Price = 170000, Status = "Banked", CreatedAt = new DateTimeOffset(2026, 5, 16, 20, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 20, 0, 0, TimeSpan.Zero) }
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

            builder.HasData(new List<Court>
            {
                new() { Id = TestCourtId, Name = "Sân Test Dashboard", Address = "Test Address", OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(22, 0), Status = "Active", PictureUrl = "https://example.com/court.jpg", Latitude = 10.0m, Longitude = 106.0m, MapUrl = "https://maps.google.com", OwnerId = TestOwnerId, CreatedAt = DateTimeOffset.UtcNow.AddMonths(-1), UpdatedAt = DateTimeOffset.UtcNow.AddMonths(-1) },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"), 
                    Name = "Sân Cầu Lông Tân Bình", 
                    Address = "18 Xuân Hồng, Phường 4, Tân Bình, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(5, 0), CloseTime = new TimeOnly(23, 0), 
                    Status = "Active", PictureUrl = "https://example.com/tanbinh.jpg", 
                    Latitude = 10.7963m, Longitude = 106.6521m, 
                    MapUrl = "https://maps.app.goo.gl/tanbinh", 
                    OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"), 
                    Name = "Sân Cầu Lông Quận 10", 
                    Address = "11 Thành Thái, Phường 14, Quận 10, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(22, 0), 
                    Status = "Active", PictureUrl = "https://example.com/district10.jpg", 
                    Latitude = 10.7745m, Longitude = 106.6635m, 
                    MapUrl = "https://maps.app.goo.gl/district10", 
                    OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"), 
                    Name = "Sân Cầu Lông Phú Thọ", 
                    Address = "219 Lý Thường Kiệt, Phường 15, Quận 11, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(5, 0), CloseTime = new TimeOnly(22, 0), 
                    Status = "Active", PictureUrl = "https://example.com/phutho.jpg", 
                    Latitude = 10.7685m, Longitude = 106.6575m, 
                    MapUrl = "https://maps.app.goo.gl/phutho", 
                    OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"), 
                    Name = "Sân Cầu Lông Chu Văn An", 
                    Address = "110 Chu Văn An, Phường 26, Bình Thạnh, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(23, 0), 
                    Status = "Active", PictureUrl = "https://example.com/chuvanan.jpg", 
                    Latitude = 10.8123m, Longitude = 106.7045m, 
                    MapUrl = "https://maps.app.goo.gl/chuvanan", 
                    OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000005"), 
                    Name = "Sân Cầu Lông Thống Nhất", 
                    Address = "138 Đào Duy Từ, Phường 6, Quận 10, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(5, 0), CloseTime = new TimeOnly(22, 0), 
                    Status = "Active", PictureUrl = "https://example.com/thongnhat.jpg", 
                    Latitude = 10.7612m, Longitude = 106.6655m, 
                    MapUrl = "https://maps.app.goo.gl/thongnhat", 
                    OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000006"), 
                    Name = "Sân Cầu Lông Lan Anh", 
                    Address = "291 Cách Mạng Tháng Tám, Phường 12, Quận 10, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(23, 0), 
                    Status = "Active", PictureUrl = "https://example.com/lananh.jpg", 
                    Latitude = 10.7798m, Longitude = 106.6785m, 
                    MapUrl = "https://maps.app.goo.gl/lananh", 
                    OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000007"), 
                    Name = "Sân Cầu Lông Viettel", 
                    Address = "158 Hoàng Hoa Thám, Phường 12, Tân Bình, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(5, 0), CloseTime = new TimeOnly(22, 0), 
                    Status = "Active", PictureUrl = "https://example.com/viettel.jpg", 
                    Latitude = 10.8012m, Longitude = 106.6456m, 
                    MapUrl = "https://maps.app.goo.gl/viettel", 
                    OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000008"), 
                    Name = "Sân Cầu Lông Bình Thạnh", 
                    Address = "14 Phan Đăng Lưu, Phường 14, Bình Thạnh, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(23, 0), 
                    Status = "Active", PictureUrl = "https://example.com/binhthanh.jpg", 
                    Latitude = 10.8034m, Longitude = 106.6967m, 
                    MapUrl = "https://maps.app.goo.gl/binhthanh", 
                    OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000009"), 
                    Name = "Sân Cầu Lông Quận 1", 
                    Address = "1 Huyền Trân Công Chúa, Phường Bến Thành, Quận 1, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(5, 0), CloseTime = new TimeOnly(22, 0), 
                    Status = "Active", PictureUrl = "https://example.com/district1.jpg", 
                    Latitude = 10.7756m, Longitude = 106.6945m, 
                    MapUrl = "https://maps.app.goo.gl/district1", 
                    OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                new() 
                { 
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000010"), 
                    Name = "Sân Cầu Lông Hoa Lư", 
                    Address = "2 Đinh Tiên Hoàng, Phường Đa Kao, Quận 1, Hồ Chí Minh", 
                    OpenTime = new TimeOnly(6, 0), CloseTime = new TimeOnly(23, 0), 
                    Status = "Active", PictureUrl = "https://example.com/hoalu.jpg", 
                    Latitude = 10.7889m, Longitude = 106.7012m, 
                    MapUrl = "https://maps.app.goo.gl/hoalu", 
                    OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), 
                    CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow 
                },
                // Thủ Đức
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000011"), Name = "Sân Cầu Lông Lan Anh Thủ Đức", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/td1.jpg", Latitude = 10.8523m, Longitude = 106.7589m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000012"), Name = "Sân Cầu Lông Tam Phú", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/td2.jpg", Latitude = 10.8645m, Longitude = 106.7432m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000013"), Name = "Sân Cầu Lông Hiệp Bình Chánh", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/td3.jpg", Latitude = 10.8256m, Longitude = 106.7234m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000014"), Name = "Sân Cầu Lông Linh Trung", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/td4.jpg", Latitude = 10.8712m, Longitude = 106.7789m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000015"), Name = "Sân Cầu Lông Phước Long B", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/td5.jpg", Latitude = 10.8234m, Longitude = 106.7845m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000016"), Name = "Sân Cầu Lông Tăng Nhơn Phú", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/td6.jpg", Latitude = 10.8345m, Longitude = 106.7912m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000017"), Name = "Sân Cầu Lông Long Thạnh Mỹ", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/td7.jpg", Latitude = 10.8456m, Longitude = 106.8234m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000018"), Name = "Sân Cầu Lông Trường Thọ", Address = "Thủ Đức, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/td8.jpg", Latitude = 10.8312m, Longitude = 106.7654m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                // Bình Chánh
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000019"), Name = "Sân Cầu Lông Bình Hưng", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bc1.jpg", Latitude = 10.7123m, Longitude = 106.6789m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000020"), Name = "Sân Cầu Lông Phong Phú", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bc2.jpg", Latitude = 10.6945m, Longitude = 106.6634m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000021"), Name = "Sân Cầu Lông Đa Phước", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/bc3.jpg", Latitude = 10.6612m, Longitude = 106.6856m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000022"), Name = "Sân Cầu Lông Vĩnh Lộc", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bc4.jpg", Latitude = 10.8034m, Longitude = 106.5878m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000023"), Name = "Sân Cầu Lông Lê Minh Xuân", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bc5.jpg", Latitude = 10.7545m, Longitude = 106.5234m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000024"), Name = "Sân Cầu Lông Phạm Văn Hai", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bc6.jpg", Latitude = 10.7812m, Longitude = 106.5123m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000025"), Name = "Sân Cầu Lông Tân Túc", Address = "Bình Chánh, HCM", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/bc7.jpg", Latitude = 10.6912m, Longitude = 106.5845m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                // Bình Dương
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000026"), Name = "Sân Cầu Lông Thuận An", Address = "Thuận An, Bình Dương", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bd1.jpg", Latitude = 10.9012m, Longitude = 106.7034m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000027"), Name = "Sân Cầu Lông Dĩ An", Address = "Dĩ An, Bình Dương", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bd2.jpg", Latitude = 10.9123m, Longitude = 106.7845m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000028"), Name = "Sân Cầu Lông Thủ Dầu Một", Address = "Thủ Dầu Một, Bình Dương", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/bd3.jpg", Latitude = 10.9845m, Longitude = 106.6534m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000029"), Name = "Sân Cầu Lông Bến Cát", Address = "Bến Cát, Bình Dương", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bd4.jpg", Latitude = 11.1234m, Longitude = 106.6012m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000030"), Name = "Sân Cầu Lông Tân Uyên", Address = "Tân Uyên, Bình Dương", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bd5.jpg", Latitude = 11.0545m, Longitude = 106.8234m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000031"), Name = "Sân Cầu Lông Lái Thiêu", Address = "Thuận An, Bình Dương", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bd6.jpg", Latitude = 10.8912m, Longitude = 106.6912m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000032"), Name = "Sân Cầu Lông Sóng Thần", Address = "Dĩ An, Bình Dương", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/bd7.jpg", Latitude = 10.8945m, Longitude = 106.7534m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000033"), Name = "Sân Cầu Lông Mỹ Phước", Address = "Bến Cát, Bình Dương", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/bd8.jpg", Latitude = 11.1012m, Longitude = 106.5845m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                // Vũng Tàu
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000034"), Name = "Sân Cầu Lông Bãi Trước", Address = "Vũng Tàu", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/vt1.jpg", Latitude = 10.3456m, Longitude = 107.0789m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000035"), Name = "Sân Cầu Lông Bãi Sau", Address = "Vũng Tàu", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/vt2.jpg", Latitude = 10.3545m, Longitude = 107.1012m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000036"), Name = "Sân Cầu Lông Chí Linh", Address = "Vũng Tàu", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/vt3.jpg", Latitude = 10.3812m, Longitude = 107.1234m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000037"), Name = "Sân Cầu Lông Rạch Dừa", Address = "Vũng Tàu", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/vt4.jpg", Latitude = 10.4034m, Longitude = 107.1123m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000038"), Name = "Sân Cầu Lông Thắng Nhất", Address = "Vũng Tàu", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/vt5.jpg", Latitude = 10.3912m, Longitude = 107.0945m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000039"), Name = "Sân Cầu Lông Phường 7", Address = "Vũng Tàu", OpenTime = new TimeOnly(6,0), CloseTime = new TimeOnly(22,0), Status = "Active", PictureUrl = "https://example.com/vt6.jpg", Latitude = 10.3645m, Longitude = 107.0856m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("d9035646-41ac-4110-b9d1-d30b1c125ffe"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow },
                new() { Id = Guid.Parse("c0000000-0000-0000-0000-000000000040"), Name = "Sân Cầu Lông Long Sơn", Address = "Vũng Tàu", OpenTime = new TimeOnly(5,0), CloseTime = new TimeOnly(23,0), Status = "Active", PictureUrl = "https://example.com/vt7.jpg", Latitude = 10.4512m, Longitude = 107.0812m, MapUrl = "https://maps.google.com", OwnerId = Guid.Parse("11bdc660-19e9-42cc-a7bb-448453c2852a"), CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow }
            });
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
                new() { Id = TestTransactionId2, Type = "Receive", Amount = 300000, BalanceBefore = 200000, BalanceAfter = 500000, Status = "Success", BookingId = TestBookingId2, WalletId = TestWalletIdCus1, CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow, SePayId = "TEST002", BankRefCode = "REF002" },
                // Giao dịch cho Owner (Receive) dựa trên pattern hôm qua
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000001"), Type = "Receive", Amount = 150000, BalanceBefore = 0, BalanceAfter = 150000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000001"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 14, 8, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 8, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_001", BankRefCode = "REF_OWN_001" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000002"), Type = "Receive", Amount = 180000, BalanceBefore = 150000, BalanceAfter = 330000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 14, 14, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 14, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_002", BankRefCode = "REF_OWN_002" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000003"), Type = "Receive", Amount = 200000, BalanceBefore = 330000, BalanceAfter = 530000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000003"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 15, 9, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 9, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_003", BankRefCode = "REF_OWN_003" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000004"), Type = "Receive", Amount = 220000, BalanceBefore = 530000, BalanceAfter = 750000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000004"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 15, 15, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 15, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_004", BankRefCode = "REF_OWN_004" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000005"), Type = "Receive", Amount = 250000, BalanceBefore = 750000, BalanceAfter = 1000000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000005"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 15, 18, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 18, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_005", BankRefCode = "REF_OWN_005" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000006"), Type = "Receive", Amount = 190000, BalanceBefore = 1000000, BalanceAfter = 1190000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000006"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 16, 7, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 7, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_006", BankRefCode = "REF_OWN_006" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000007"), Type = "Receive", Amount = 230000, BalanceBefore = 1190000, BalanceAfter = 1420000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000007"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 16, 16, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 16, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_007", BankRefCode = "REF_OWN_007" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000008"), Type = "Receive", Amount = 150000, BalanceBefore = 1420000, BalanceAfter = 1570000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 13, 10, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 13, 10, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_008", BankRefCode = "REF_OWN_008" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000009"), Type = "Receive", Amount = 200000, BalanceBefore = 1570000, BalanceAfter = 1770000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000009"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 13, 15, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 13, 15, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_009", BankRefCode = "REF_OWN_009" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000010"), Type = "Receive", Amount = 180000, BalanceBefore = 1770000, BalanceAfter = 1950000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000010"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 14, 19, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 14, 19, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_010", BankRefCode = "REF_OWN_010" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000011"), Type = "Receive", Amount = 220000, BalanceBefore = 1950000, BalanceAfter = 2170000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000011"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 15, 7, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 15, 7, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_011", BankRefCode = "REF_OWN_011" },
                new() { Id = Guid.Parse("e0000000-0000-0000-0000-000000000012"), Type = "Receive", Amount = 170000, BalanceBefore = 2170000, BalanceAfter = 2340000, Status = "Success", BookingId = Guid.Parse("b0000000-0000-0000-0000-000000000012"), WalletId = TestWalletIdOwner, CreatedAt = new DateTimeOffset(2026, 5, 16, 20, 0, 0, TimeSpan.Zero), UpdatedAt = new DateTimeOffset(2026, 5, 16, 20, 0, 0, TimeSpan.Zero), SePayId = "SE_OWN_012", BankRefCode = "REF_OWN_012" }
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
        modelBuilder.Entity<Notification>().HasQueryFilter(x => !x.IsDeleted);
    }
}
