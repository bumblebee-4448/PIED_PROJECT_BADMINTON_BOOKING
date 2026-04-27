    using Microsoft.EntityFrameworkCore;
    using Rallyhub.Repository.Entity;
    using Exception = Rallyhub.Repository.Entity.Exception;


    namespace Rallyhub.Repository;

    public class AppDbContext : DbContext
    {
        public static Guid AdminId = Guid.NewGuid(); //owner
        public static Guid UserId2 = Guid.NewGuid(); //owner
        public static Guid UserId3 = Guid.NewGuid(); //owner
        public static Guid UserId4 = Guid.NewGuid(); //customer
        public static Guid UserId5 = Guid.NewGuid(); //cusomter
        public static Guid UserId6 = Guid.NewGuid();//owner
        // public static Guid UserId7 = Guid.Parse("d97131e9-1699-4efa-9e99-82bda56dfeb9");//owner
        
        public static Guid WalletId1 = Guid.NewGuid(); 
        public static Guid WalletId2 = Guid.NewGuid(); 
        public static Guid WalletId3 = Guid.NewGuid(); 
        public static Guid WalletId4 = Guid.NewGuid(); 
        
        public static Guid OwnerId1 = Guid.NewGuid(); 
        public static Guid OwnerId2 = Guid.NewGuid(); 
        public static Guid OwnerId3 = Guid.NewGuid();
        public static Guid OwnerId4 = Guid.NewGuid();
        
        public static Guid CustomerId1 = Guid.NewGuid(); 
        public static Guid CustomerId2 = Guid.NewGuid();  
        
        public static Guid CourtA = Guid.NewGuid(); 
        public static Guid CourtB = Guid.NewGuid();
        public static Guid CourtC = Guid.NewGuid(); 
        public static Guid CourtD = Guid.NewGuid(); 
        
        public static Guid SubCourt1 = Guid.NewGuid(); 
        public static Guid SubCourt2 = Guid.NewGuid();
        public static Guid SubCourt3 = Guid.NewGuid(); 
        public static Guid SubCourt4 = Guid.NewGuid();
        public static Guid SubCourt5 = Guid.NewGuid(); 
        public static Guid SubCourt6 = Guid.NewGuid();
        public static Guid SubCourt7 = Guid.NewGuid(); 
        public static Guid SubCourt8 = Guid.NewGuid(); 
        
        public static Guid CampaignId1 = Guid.NewGuid(); 
        public static Guid CampaignId2 = Guid.NewGuid(); 
        
        public static Guid BookingId1 = Guid.NewGuid(); 
        public static Guid BookingId2 = Guid.NewGuid();
        public static Guid BookingId3 = Guid.NewGuid(); 
        public static Guid BookingId4 = Guid.NewGuid();
        public static Guid BookingId5 = Guid.NewGuid(); 

        
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        public DbSet<Booking>  Bookings { get; set; }
        public DbSet<BookingDetail>  BookingDetails { get; set; }
        public DbSet<Campaign>   Campaigns { get; set; }
        public DbSet<CampaignCourt>  CampaignCourts { get; set; }
        public DbSet<ConfigSlot>   ConfigSlots { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Customer>  Customers { get; set; }
        public DbSet<Exception> Exceptions { get; set; }
        public DbSet<Feedback>  Feedbacks { get; set; }
        public DbSet<LikeListDetail>  LikeListDetails { get; set; }
        public DbSet<Notification>  Notifications { get; set; }
        public DbSet<OverideSlot>  OverideSlots { get; set; }
        public DbSet<Owner>  Owners { get; set; }
        public DbSet<OwnerRequest>  OwnerRequests { get; set; }
        public DbSet<Report>  Reports { get; set; }
        public DbSet<SubCourt>  SubCourts { get; set; }
        public DbSet<SystemReport>  SystemReports { get; set; }
        public DbSet<Transaction>  Transactions { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<Wallet>  Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.TotalPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                builder.Property(x => x.DiscountAmount)
                    .HasColumnType("decimal(18,2)");
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValue("Pending");
                builder.Property(x => x.CancellationReason)
                    .HasMaxLength(500);
                builder.HasOne(x => x.Campaign)
                    .WithMany(x => x.Bookings)
                    .HasForeignKey(x  => x.CampaignId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Customer)
                    .WithMany(x => x.Bookings)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var bookings = new List<Booking>
                {
                    new() { Id = BookingId1, TotalPrice = 200_000, DiscountAmount = 20_000, FinalPrice = 180_000, Status = "Complete", CampaignId = CampaignId1, CustomerId = CustomerId1},
                    new() { Id = BookingId2, TotalPrice = 300_000, DiscountAmount = 30_000, FinalPrice = 270_000, Status = "Banked",   CampaignId = CampaignId1, CustomerId = CustomerId1},
                    new() { Id = BookingId3, TotalPrice = 150_000, DiscountAmount = 0,      FinalPrice = 150_000, Status = "Complete",  CampaignId = CampaignId2, CustomerId = CustomerId2},
                    new() { Id = BookingId4, TotalPrice = 250_000, DiscountAmount = 50_000, FinalPrice = 200_000, Status = "Cancel",   CancellationReason = "Khách huỷ", CampaignId = CampaignId2, CustomerId = CustomerId2},
                    new() { Id = BookingId5, TotalPrice = 400_000, DiscountAmount = 40_000, FinalPrice = 360_000, Status = "Banked",   CampaignId = CampaignId2, CustomerId = CustomerId2},
                };
                builder.HasData(bookings);

            });
            modelBuilder.Entity<BookingDetail>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                builder.HasOne(x => x.SubCourt)
                    .WithMany(x => x.BookingDetails)
                    .HasForeignKey(x => x.SubCourtId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Booking)
                    .WithMany(x => x.BookingDetails)
                    .HasForeignKey(x => x.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.Property(x => x.Date)
                    .IsRequired();
                builder.Property(x => x.StartTime)
                    .IsRequired()
                    .HasColumnType("time");
                builder.Property(x => x.EndTime)
                    .IsRequired()
                    .HasColumnType("time");
                var bookingDetails = new List<BookingDetail>
                {
                    new() { Id = Guid.NewGuid(), SubCourtId = SubCourt1, BookingId = BookingId1, Date = DateTimeOffset.Now.AddDays(-5), StartTime = new TimeOnly(8,  0), EndTime = new TimeOnly(10, 0), Price = 100_000},
                    new() { Id = Guid.NewGuid(), SubCourtId = SubCourt3, BookingId = BookingId2, Date = DateTimeOffset.Now.AddDays(-5), StartTime = new TimeOnly(6, 0), EndTime = new TimeOnly(7, 0), Price = 100_000},
                    new() { Id = Guid.NewGuid(), SubCourtId = SubCourt5, BookingId = BookingId3, Date = DateTimeOffset.Now.AddDays(-3), StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(8, 0), Price = 150_000},
                    new() { Id = Guid.NewGuid(), SubCourtId = SubCourt7, BookingId = BookingId4, Date = DateTimeOffset.Now.AddDays(-3), StartTime = new TimeOnly(6, 0), EndTime = new TimeOnly(10, 0), Price = 150_000},
                    new() { Id = Guid.NewGuid(), SubCourtId = SubCourt2, BookingId = BookingId5, Date = DateTimeOffset.Now.AddDays(1),  StartTime = new TimeOnly(9,  0), EndTime = new TimeOnly(10, 0), Price = 150_000},
                };
                builder.HasData(bookingDetails);
            });
            modelBuilder.Entity<Campaign>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Code)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.Code)
                    .IsUnique();
                builder.Property(x => x.IsGlobal)
                    .HasDefaultValue(false);
                builder.Property(x => x.DiscountPercent)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                builder.Property(x => x.MaxDiscountAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                builder.Property(x => x.MinBookingAmount)
                    .HasColumnType("decimal(18,2)");
                builder.Property(x => x.UsageLimit);
                builder.Property(x => x.UsedCount);
                builder.Property(x => x.StartDate)
                    .IsRequired();
                builder.Property(x => x.EndDate)
                    .IsRequired();
                builder.HasOne(x => x.Owner)
                    .WithMany(x => x.Campaigns)
                    .HasForeignKey(x => x.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var campaigns = new List<Campaign> 
                {
                    new() { Id = CampaignId1, Code = "SUMMER25",  IsGlobal = false,  DiscountPercent = 10, MaxDiscountAmount = 50_000,  MinBookingAmount = 200_000, UsageLimit = 100, UsedCount = 12, StartDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                                                                                                                                                                                                        EndDate   = new DateTime(2026, 6, 20, 23, 59, 59, DateTimeKind.Utc), OwnerId = OwnerId1},
                    new() { Id = Guid.NewGuid(), Code = "FLASH50",   IsGlobal = false,  DiscountPercent = 50, MaxDiscountAmount = 200_000, MinBookingAmount = 500_000, UsageLimit = 10,  UsedCount = 10, StartDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                                                                                                                                                                                                        EndDate   = new DateTime(2026, 6, 20, 23, 59, 59, DateTimeKind.Utc),  OwnerId = OwnerId1},
                    new() { Id = Guid.NewGuid(), Code = "YEUTH",    IsGlobal = false, DiscountPercent = 5,  MaxDiscountAmount = 30_000,  MinBookingAmount = 100_000, UsageLimit = 500, UsedCount = 87,  StartDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                                                                                                                                                                                                        EndDate   = new DateTime(2026, 6, 20, 23, 59, 59, DateTimeKind.Utc), OwnerId = OwnerId1},
                    new() { Id = CampaignId2, Code = "NEWUSER",   IsGlobal = false, DiscountPercent = 20, MaxDiscountAmount = 100_000, MinBookingAmount = 300_000, UsageLimit = 50,  UsedCount = 5,  StartDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                                                                                                                                                                                                        EndDate   = new DateTime(2026, 6, 20, 23, 59, 59, DateTimeKind.Utc), OwnerId = OwnerId2},
                    new() { Id = Guid.NewGuid(), Code = "WEEKEND10", IsGlobal = false, DiscountPercent = 15, MaxDiscountAmount = 75_000,  MinBookingAmount = 250_000, UsageLimit = 200, UsedCount = 30, StartDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                                                                                                                                                                                                        EndDate   = new DateTime(2026, 6, 20, 23, 59, 59, DateTimeKind.Utc), OwnerId = OwnerId2},
                    new() { Id = Guid.NewGuid(), Code = "LOYAL5",    IsGlobal = false, DiscountPercent = 5,  MaxDiscountAmount = 30_000,  MinBookingAmount = 100_000, UsageLimit = 500, UsedCount = 87, StartDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                                                                                                                                                                                                        EndDate   = new DateTime(2026, 6, 20, 23, 59, 59, DateTimeKind.Utc), OwnerId = OwnerId2},

                };
                builder.HasData(campaigns);
                
            });
            modelBuilder.Entity<CampaignCourt>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasOne(x => x.Court)
                    .WithMany(x => x.CampaignCourts)
                    .HasForeignKey(x => x.CourtId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Campaign)
                    .WithMany(x => x.Courts)
                    .HasForeignKey(x => x.CampaignId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var campaignCourts = new List<CampaignCourt>
                {
                    new() { Id = Guid.NewGuid(), CourtId = CourtA, CampaignId = CampaignId2},
                    new() { Id = Guid.NewGuid(), CourtId = CourtB, CampaignId = CampaignId2},
                    new() { Id = Guid.NewGuid(), CourtId = CourtC, CampaignId = CampaignId1},
                    new() { Id = Guid.NewGuid(), CourtId = CourtD, CampaignId = CampaignId1},
                };
                builder.HasData(campaignCourts);
            });
            modelBuilder.Entity<ConfigSlot>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                builder.Property(x => x.StartTime)
                    .IsRequired()
                    .HasColumnType("time");
                builder.Property(x => x.EndTime)
                    .IsRequired()
                    .HasColumnType("time");
                var configSlots = new List<ConfigSlot>();
                
                var start = new TimeOnly(6, 0);
                var end = new TimeOnly(10, 0);

                while (start < end)
                {
                    var next = start.AddMinutes(30);

                    configSlots.Add(new ConfigSlot
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt1,
                        StartTime = start,
                        EndTime = next,
                        Price = 50000 // base price
                    });
                    configSlots.Add(new ConfigSlot
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt3,
                        StartTime = start,
                        EndTime = next,
                        Price = 70000 // base price
                    });
                    configSlots.Add(new ConfigSlot
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt5,
                        StartTime = start,
                        EndTime = next,
                        Price = 35000 // base price
                    });
                    configSlots.Add(new ConfigSlot
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt7,
                        StartTime = start,
                        EndTime = next,
                        Price = 100000 // base price
                    });

                    start = next;
                }
                builder.HasData(configSlots);   
            });
            modelBuilder.Entity<Court>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.Name).IsUnique();
                builder.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(x => x.PictureUrl)
                    .IsRequired()
                    .HasMaxLength(200);
                builder.Property(x => x.OpenTime);
                builder.Property(x => x.CloseTime);
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Active");
                builder.Property(x => x.Latitude)
                    .HasColumnType("decimal(10,8)");
                builder.Property(x => x.Longitude)
                    .HasColumnType("decimal(11,8)");
                builder.Property(x => x.MapUrl)
                    .IsRequired()
                    .HasMaxLength(200);
                builder.HasOne(x => x.Owner)
                    .WithMany(x => x.Courts)
                    .HasForeignKey(x => x.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                var courts = new List<Court>
                {
                    new() { Id = CourtA, Name = "Sân A - Minh Tuấn", Address = "123 Nguyễn Huệ, Q1, HCM",    OpenTime = new TimeOnly(6, 0),  CloseTime = new TimeOnly(22, 0), Status = "Active",  PictureUrl = "https://images.example.com/courts/go-vap.jpg",Latitude = 10.77m, Longitude = 106.70m, MapUrl = "https://maps.google.com/?q=10.77,106.70", OwnerId = OwnerId1 },
                    new() { Id = CourtB, Name = "Sân B - Minh Tuấn", Address = "123 Nguyễn Huệ, Q1, HCM",    OpenTime = new TimeOnly(6, 0),  CloseTime = new TimeOnly(22, 0), Status = "Active",  PictureUrl = "https://images.example.com/courts/go-vap.jpg",Latitude = 10.77m, Longitude = 106.70m, MapUrl = "https://maps.google.com/?q=10.77,106.70", OwnerId = OwnerId1 },
                    new() { Id = CourtC, Name = "Sân C - Hải Đăng",  Address = "456 Lê Lợi, Q3, HCM",         OpenTime = new TimeOnly(5, 30), CloseTime = new TimeOnly(23, 0), Status = "Active", PictureUrl = "https://images.example.com/courts/go-vap.jpg",Latitude = 10.78m, Longitude = 106.69m, MapUrl = "https://maps.google.com/?q=10.78,106.69", OwnerId = OwnerId2 },
                    new() { Id = CourtD, Name = "Sân D - Hải Đăng",  Address = "456 Lê Lợi, Q3, HCM",         OpenTime = new TimeOnly(5, 30), CloseTime = new TimeOnly(23, 0), Status = "Active", PictureUrl = "https://images.example.com/courts/go-vap.jpg",Latitude = 10.78m, Longitude = 106.69m, MapUrl = "https://maps.google.com/?q=10.78,106.69", OwnerId = OwnerId2 },
                };
                
                builder.HasData(courts);
            });
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.HasKey(x => x.Id);
                
                var customers = new List<Customer>
                {
                    new() { Id = CustomerId1, UserId = UserId4},
                    new() { Id = CustomerId2, UserId = UserId5},
                };
                builder.HasData(customers);
            });
            modelBuilder.Entity<Exception>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Date)
                    .IsRequired();
                builder.Property(x => x.StartTime)
                    .IsRequired()
                    .HasColumnType("time");
                builder.Property(x => x.EndTime)
                    .IsRequired()
                    .HasColumnType("time");
                
                builder.HasOne(x => x.SubCourtDetail)
                    .WithMany(x => x.Exceptions)
                    .HasForeignKey(x => x.SubCourtDetailId)
                    .OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Reason)
                    .IsRequired()
                    .HasMaxLength(500);
                
                var exceptions = new List<Exception>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt1,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Reason = "Bảo trì định kỳ"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt3,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Reason = "Sơn lại mặt sân"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt5,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Reason = "Hỏng đèn chiếu sáng"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt7,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Reason = "Tổ chức sự kiện nội bộ"
                    },
                };

                builder.HasData(exceptions);
            });
            modelBuilder.Entity<Feedback>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Rating)
                    .IsRequired();
                builder.Property(x => x.Comment)
                    .HasMaxLength(500);
                builder.HasOne(x => x.Court)
                    .WithMany(x => x.Feedbacks)
                    .HasForeignKey(x => x.CourtId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Customer)
                    .WithMany(x => x.Feedbacks)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Booking)
                    .WithMany(x => x.Feedbacks)
                    .HasForeignKey(x => x.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var feedbacks = new List<Feedback>
                {
                    new() { Id = Guid.NewGuid(), Rating = 5, Comment = "Sân rất tốt, sẽ quay lại!",       CourtId = CourtA, CustomerId =  CustomerId2, BookingId = BookingId1,},
                    new() { Id = Guid.NewGuid(), Rating = 4, Comment = "Dịch vụ ổn, giá hợp lý.",          CourtId = CourtB, CustomerId = CustomerId2, BookingId = BookingId2,},
                    new() { Id = Guid.NewGuid(), Rating = 3, Comment = "Bình thường, sân hơi cũ.",          CourtId = CourtC, CustomerId = CustomerId1, BookingId = BookingId3,},
                    new() { Id = Guid.NewGuid(), Rating = 5, Comment = "Nhân viên thân thiện, sân sạch.", CourtId = CourtB, CustomerId = CustomerId1, BookingId = BookingId4,},
                    new() { Id = Guid.NewGuid(), Rating = 2, Comment = "Đèn chiếu sáng yếu vào ban đêm.", CourtId = CourtA, CustomerId = CustomerId2, BookingId = BookingId5, },
                };
                builder.HasData(feedbacks);
            });
            modelBuilder.Entity<LikeListDetail>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasOne(x => x.Court)
                    .WithMany(x => x.LikeListDetails)
                    .HasForeignKey(x => x.CourtId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Customer)
                    .WithMany(x => x.LikeListDetails)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                var likeListDetails = new List<LikeListDetail>
                {
                    new() { Id = Guid.NewGuid(), CourtId = CourtA, CustomerId = CustomerId1},
                    new() { Id = Guid.NewGuid(), CourtId = CourtB, CustomerId = CustomerId1},
                    new() { Id = Guid.NewGuid(), CourtId = CourtC, CustomerId = CustomerId2},
                    new() { Id = Guid.NewGuid(), CourtId = CourtD, CustomerId = CustomerId2},
                    new() { Id = Guid.NewGuid(), CourtId = CourtA, CustomerId = CustomerId2},
                };
                builder.HasData(likeListDetails);
            });
            modelBuilder.Entity<Notification>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.Content)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.Type)
                    .IsRequired()
                    .HasMaxLength(10);
                builder.Property(x => x.IsRead)
                    .IsRequired()
                    .HasDefaultValue(false);
                builder.HasOne(x => x.Booking)
                    .WithMany(x => x.Notifications)
                    .HasForeignKey(x => x.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.User)
                    .WithMany(x => x.Notifications)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Court)
                    .WithMany(x => x.Notifications)
                    .HasForeignKey(x => x.CourtId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var notifications = new List<Notification>
                {
                    new() { Id = Guid.NewGuid(), BookingId = BookingId1, UserId = UserId2, Title = "Đặt sân thành công",   Content = "Booking #1 đã được xác nhận.",          Type = "Booking", IsRead = true,  CourtId = CourtA},
                    new() { Id = Guid.NewGuid(), BookingId = BookingId2, UserId = UserId3, Title = "Đặt sân thành công",   Content = "Booking #2 đã được xác nhận.",          Type = "Booking", IsRead = false, CourtId = CourtB},
                    new() { Id = Guid.NewGuid(), BookingId = BookingId3, UserId = UserId4, Title = "Nhắc nhở lịch chơi",   Content = "Bạn có lịch chơi vào ngày mai.",       Type = "Remind",  IsRead = false, CourtId = CourtC},
                    new() { Id = Guid.NewGuid(), BookingId = BookingId4, UserId = UserId5, Title = "Huỷ booking",  Content = "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", Type = "Cancel",  IsRead = true,  CourtId = CourtD},
                    new() { Id = Guid.NewGuid(), BookingId = BookingId5, UserId = UserId2, Title = "Hoàn tiền",    Content = "Đã hoàn 360,000đ vào ví của bạn.",     Type = "Refund",  IsRead = false, CourtId = CourtA},
                };
                builder.HasData(notifications);
            });
            modelBuilder.Entity<OverideSlot>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasOne(x => x.SubCourtDetail)
                    .WithMany(x => x.OverideSlots)
                    .HasForeignKey(x => x.SubCourtDetailId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.Property(x => x.Date)
                    .IsRequired();
                builder.Property(x => x.StartTime)
                    .IsRequired()
                    .HasColumnType("time");
                builder.Property(x => x.EndTime)
                    .IsRequired()
                    .HasColumnType("time");
                builder.Property(x => x.IsRecurring)
                    .HasDefaultValue(false);
                builder.Property(x => x.DayOfWeek);
                builder.Property(x => x.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                
                var overrideSlots = new List<OverideSlot>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt1,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Price = 208400,
                        IsRecurring = false
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt3,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Price = 220500,
                        IsRecurring = false
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt5,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Price = 2054000,
                        IsRecurring = false
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt7,
                        Date = new DateOnly(2026, 4, 25),
                        StartTime = new TimeOnly(12, 0),
                        EndTime = new TimeOnly(17, 0),
                        Price = 220800,
                        IsRecurring = false
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        SubCourtDetailId = SubCourt2,
                        StartTime = new TimeOnly(18, 0),
                        EndTime = new TimeOnly(20, 0),
                        Price = 200000,
                        IsRecurring = true,
                        DayOfWeek = DayOfWeek.Monday
                    }
                };

                builder.HasData(overrideSlots);
            });
            modelBuilder.Entity<Owner>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.BusinessName)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.BusinessAddress)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.TaxCode)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.TaxCode).IsUnique();
                builder.HasOne(x => x.OwnerRequest)
                    .WithOne(x => x.Owner)
                    .HasForeignKey<OwnerRequest>(x => x.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.User)
                    .WithOne(x => x.Owner)
                    .HasForeignKey<Owner>(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                var owners = new List<Owner>
                {
                    new() { Id = OwnerId1, BusinessName = "Sân Cầu Lông Minh Tuấn", TaxCode = "0123456789", BusinessAddress = "123 Nguyễn Huệ, Q1, HCM",  UserId = UserId2},
                    new() { Id = OwnerId2, BusinessName = "Trung Tâm Thể Thao Hải Đăng", TaxCode = "9876543210", BusinessAddress = "456 Lê Lợi, Q3, HCM", UserId = UserId3},
                    new() { Id = OwnerId3, BusinessName = "Sân Cầu Lông Trần Phú", TaxCode = "98765434210", BusinessAddress = "Tôn Đức Thắng, HCM", UserId = UserId6},
                    // new() { Id = OwnerId4, BusinessName = "Sân Cầu Lông Trần Phú 2", TaxCode = "98765434211", BusinessAddress = "Trần Hưng Đạo, HCM", UserId = UserId7},
                };
                builder.HasData(owners);
            });
            modelBuilder.Entity<OwnerRequest>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.BusinessName)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.BusinessAddress)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.TaxCode)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.TaxCode).IsUnique();
                builder.Property(x => x.BusinessLicenseUrl)
                    .IsRequired()
                    .HasMaxLength(200);
                builder.Property(x => x.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(12);
                builder.Property(x => x.IdentityCardFrontUrl)
                    .IsRequired()
                    .HasMaxLength(200);
                builder.Property(x => x.IdentityCardBackUrl)
                    .IsRequired()
                    .HasMaxLength(200);
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasDefaultValue("Pending")
                    .HasMaxLength(15);
                builder.Property(x => x.RejectionReason)
                    .HasMaxLength(200);
                
                builder.HasOne(x => x.Customer)
                    .WithMany(x => x.OwnerRequests)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                var ownerRequests = new List<OwnerRequest>
                {
                    new() { Id = Guid.NewGuid(), BusinessName = "Sân Cầu Lông Minh Tuấn",      TaxCode = "0123456789", BusinessAddress = "123 Nguyễn Huệ, Q1, HCM", BusinessLicenseUrl = "https://cdn.rallyhub.vn/license/1.jpg", IdentityNumber = "079200012345", IdentityCardFrontUrl = "https://cdn.rallyhub.vn/cccd/1_front.jpg", IdentityCardBackUrl = "https://cdn.rallyhub.vn/cccd/1_back.jpg", Status = "Approved", OwnerId = OwnerId1, CustomerId = CustomerId1},
                    new() { Id = Guid.NewGuid(), BusinessName = "Trung Tâm Thể Thao Hải Đăng", TaxCode = "9876543210", BusinessAddress = "456 Lê Lợi, Q3, HCM",      BusinessLicenseUrl = "https://cdn.rallyhub.vn/license/2.jpg", IdentityNumber = "079200054321", IdentityCardFrontUrl = "https://cdn.rallyhub.vn/cccd/2_front.jpg", IdentityCardBackUrl = "https://cdn.rallyhub.vn/cccd/2_back.jpg", Status = "Approved", OwnerId = OwnerId2, CustomerId = CustomerId2},
                };
                builder.HasData(ownerRequests);
            });
            modelBuilder.Entity<Report>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Reason)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasDefaultValue("Pending");
                builder.HasOne(x => x.Customer)
                    .WithMany(x => x.Reports)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Court)
                    .WithMany(x => x.Reports)
                    .HasForeignKey(x => x.CourtId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Booking)
                    .WithMany(x => x.Reports)
                    .HasForeignKey(x => x.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var reports = new List<Report>
                {
                    new() { Id = Guid.NewGuid(), Reason = "Sân không đúng mô tả.",          Status = "Pending",  CustomerId = CustomerId1, CourtId = CourtC, BookingId = BookingId1},
                    new() { Id = Guid.NewGuid(), Reason = "Chủ sân thái độ không tốt.",      Status = "Resolved", CustomerId = CustomerId1, CourtId = CourtA, BookingId = BookingId2},
                    new() { Id = Guid.NewGuid(), Reason = "Cơ sở vật chất xuống cấp.",      Status = "Pending",  CustomerId =CustomerId2, CourtId = CourtB, BookingId = BookingId3},
                    new() { Id = Guid.NewGuid(), Reason = "Không hoàn tiền khi huỷ đúng hạn.", Status = "Rejected", CustomerId = CustomerId2, CourtId = CourtC, BookingId = BookingId4},
                    new() { Id = Guid.NewGuid(), Reason = "Thông tin giờ mở cửa sai.",       Status = "Pending",  CustomerId = CustomerId2, CourtId = CourtD, BookingId = BookingId5},
                };
                builder.HasData(reports);
            });
            modelBuilder.Entity<SubCourt>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasOne(x => x.Court)
                    .WithMany(x => x.SubCourts)
                    .HasForeignKey(x => x.CourtId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                var subCourts = new List<SubCourt>
                {
                    new() { Id = SubCourt1, Name = "Sân nhỏ A1", CourtId = CourtA,},
                    new() { Id = SubCourt2, Name = "Sân nhỏ A2", CourtId = CourtA,},
                    new() { Id = SubCourt3, Name = "Sân nhỏ B1", CourtId = CourtB,},
                    new() { Id = SubCourt4, Name = "Sân nhỏ B2", CourtId = CourtB,},
                    new() { Id = SubCourt5, Name = "Sân nhỏ C1", CourtId = CourtC,},
                    new() { Id = SubCourt6, Name = "Sân nhỏ C2", CourtId = CourtC,},
                    new() { Id = SubCourt7, Name = "Sân nhỏ D1", CourtId = CourtD,},
                    new() { Id = SubCourt8, Name = "Sân nhỏ D2", CourtId = CourtD,},
                };
                builder.HasData(subCourts);
                
            });
            modelBuilder.Entity<SystemReport>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Reason)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasDefaultValue("Pending");
                builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasOne(x => x.User)
                    .WithMany(x => x.SystemReports)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                var systemReports = new List<SystemReport>
                {
                    new() { Id = Guid.NewGuid(), Title = "Lỗi thanh toán",          Reason = "Không thể thanh toán qua ví.",       Status = "Pending",  UserId = UserId2,},
                    new() { Id = Guid.NewGuid(), Title = "Lỗi hiển thị bản đồ",    Reason = "Bản đồ không load được trên iOS.",    Status = "Resolved", UserId =UserId3,},
                    new() { Id = Guid.NewGuid(), Title = "App bị crash",            Reason = "Crash khi mở trang tìm kiếm sân.",   Status = "Pending",  UserId = UserId4,},
                    new() { Id = Guid.NewGuid(), Title = "Không nhận được OTP",    Reason = "OTP không gửi đến số điện thoại.",    Status = "Pending",  UserId = UserId4,},
                    new() { Id = Guid.NewGuid(), Title = "Sai số dư sau giao dịch", Reason = "Số dư hiển thị không khớp lịch sử.", Status = "Resolved", UserId = UserId5},
                };
                builder.HasData(systemReports);
            });
            modelBuilder.Entity<Transaction>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Type)
                    .IsRequired()
                    .HasMaxLength(15);
                builder.Property(x => x.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                builder.Property(x => x.BalanceBefore)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                builder.Property(x => x.BalanceAfter)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                builder.Property(x => x.SePayId)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.SePayId).IsUnique();
                builder.Property(x => x.BankRefCode)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.BankRefCode).IsUnique();
                builder.Property(x => x.BankAccountNumber)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.TransferContent)
                    .IsRequired()
                    .HasMaxLength(500);
                builder.Property(x => x.ActionCode)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.ActionCode).IsUnique();
                
                builder.Property(x => x.Signature)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasDefaultValue("Success");
                builder.HasOne(x => x.Booking)
                    .WithMany(x => x.Transactions)
                    .HasForeignKey(x => x.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(x => x.Wallet)
                    .WithMany(x => x.Transactions)
                    .HasForeignKey(x => x.WalletId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var transactions = new List<Transaction>
                {
                    new() { Id = Guid.NewGuid(), Type = "Payment", Amount = 180_000, BalanceBefore = 2_180_000, BalanceAfter = 2_000_000, SePayId = "SP001", BankRefCode = "REF001", BankAccountNumber = "2345678901", TransferContent = "Thanh toán booking #1", ActionCode = "ACT001", Signature = "SIG001", Status = "Success",  BookingId = BookingId1, WalletId = WalletId1},
                    new() { Id = Guid.NewGuid(), Type = "Payment", Amount = 270_000, BalanceBefore = 3_770_000, BalanceAfter = 3_500_000, SePayId = "SP002", BankRefCode = "REF002", BankAccountNumber = "3456789012", TransferContent = "Thanh toán booking #2", ActionCode = "ACT002", Signature = "SIG002", Status = "Success", BookingId = BookingId2, WalletId = WalletId2},
                    new() { Id = Guid.NewGuid(), Type = "Refund",  Amount = 200_000, BalanceBefore = 2_000_000, BalanceAfter = 2_200_000, SePayId = "SP003", BankRefCode = "REF003", BankAccountNumber = "4567890123", TransferContent = "Hoàn tiền booking #4",   ActionCode = "ACT003", Signature = "SIG003", Status = "Success", BookingId = BookingId3, WalletId = WalletId3},
                    new() { Id = Guid.NewGuid(), Type = "Deposit", Amount = 500_000, BalanceBefore = 1_500_000, BalanceAfter = 2_000_000, SePayId = "SP004", BankRefCode = "REF004", BankAccountNumber = "5678901234", TransferContent = "Nạp tiền vào ví",          ActionCode = "ACT004", Signature = "SIG004", Status = "Success", BookingId = BookingId5, WalletId = WalletId4},
                };
                builder.HasData(transactions);
            });
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.HasIndex(x => x.Email).IsUnique();
                builder.Property(x => x.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(x => x.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Customer");
                builder.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(x => x.PhoneNumber)
                    .HasMaxLength(11);
                builder.Property(x => x.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Active");
                builder.HasOne(x => x.Customer)
                    .WithOne(x => x.User)
                    .HasForeignKey<Customer>(x => x.UserId);
                
                var users  = new  List<User>
                {
                    new()
                    {
                        Id = AdminId, 
                        Email = "admin@rallyhub.vn",   
                        PasswordHash = "hashed_pw_1", 
                        Role = "Admin",    
                        FirstName = "Quản",  
                        LastName = "Trị",    
                        PhoneNumber = "0900000001", 
                        Status = "Active", 
                    },
                    new()
                    {
                        Id = UserId2, 
                        Email = "owner1@rallyhub.vn",  
                        PasswordHash = "hashed_pw_2", 
                        Role = "Owner",    
                        FirstName = "Minh",  
                        LastName = "Tuấn",   
                        PhoneNumber = "0900000002", 
                        Status = "Active", 
                    },
                    new()
                    {
                        Id = UserId3, 
                        Email = "owner2@rallyhub.vn",  
                        PasswordHash = "hashed_pw_3", 
                        Role = "Owner",    
                        FirstName = "Hải",   
                        LastName = "Đăng",   
                        PhoneNumber = "0900000003", 
                        Status = "Active",
                    },
                    new()
                    {
                        Id = UserId4, 
                        Email = "customer1@gmail.com", 
                        PasswordHash = "hashed_pw_4", 
                        Role = "Customer", 
                        FirstName = "Lan",   
                        LastName = "Phương", 
                        PhoneNumber = "0900000004", 
                        Status = "Active",
                    },
                    new()
                    {
                        Id = UserId5, 
                        Email = "customer2@gmail.com", 
                        PasswordHash = "hashed_pw_5", 
                        Role = "Customer", 
                        FirstName = "Bảo",   
                        LastName = "Châu",   
                        PhoneNumber = "0900000005", 
                        Status = "Active"
                    },
                    new()
                    {
                        Id = UserId6, 
                        Email = "owner3@rallyhub.vn", 
                        PasswordHash = "hashed_pw_6", 
                        Role = "Owner", 
                        FirstName = "Trần", 
                        LastName = "Phú", 
                        PhoneNumber = "0900000006", 
                        Status = "Active"
                    },
                };
                builder.HasData(users);
            });
            modelBuilder.Entity<Wallet>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.BankName)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.Property(x => x.BankAccount)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(x => x.Balance)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0);
                builder.Property(x => x.Version);
                builder.HasOne(x => x.User)
                    .WithOne(x => x.Wallet)
                    .HasForeignKey<Wallet> (x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                var wallets = new List<Wallet>
                {
                    new() { Id = WalletId1, BankName = "Techcombank", BankAccount = "2345678901", Balance = 12_000_000, Version = 0, UserId = UserId2},
                    new() { Id = WalletId2, BankName = "BIDV",        BankAccount = "3456789012", Balance = 8_500_000,  Version = 0, UserId = UserId3},
                    new() { Id = WalletId3, BankName = "MB Bank",     BankAccount = "4567890123", Balance = 2_000_000,  Version = 0, UserId = UserId4},
                    new() { Id = WalletId4, BankName = "VPBank",      BankAccount = "5678901234", Balance = 3_500_000,  Version = 0, UserId = UserId5},
                };
                builder.HasData(wallets);
            });
        }
    }
