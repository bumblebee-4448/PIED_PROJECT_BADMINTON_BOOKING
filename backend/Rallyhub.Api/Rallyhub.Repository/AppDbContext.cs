    using Microsoft.EntityFrameworkCore;
    using Rallyhub.Repository.Entity;
    using Exception = Rallyhub.Repository.Entity.Exception;


    namespace Rallyhub.Repository;

    public class AppDbContext : DbContext
    {
        
        public static Guid UserId2 = Guid.NewGuid(); //owner
        public static Guid UserId3 = Guid.NewGuid(); //owner
        public static Guid UserId4 = Guid.NewGuid(); //customer
        public static Guid UserId5 = Guid.NewGuid(); //cusomter
        
        public static Guid OwnerId1 = Guid.NewGuid(); 
        public static Guid OwnerId2 = Guid.NewGuid(); 
        
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
            });
            modelBuilder.Entity<Court>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                builder.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(100);
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
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.HasKey(x => x.Id);
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
                        Id = Guid.NewGuid(), 
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
                    new() { Id = Guid.NewGuid(), BankName = "Techcombank", BankAccount = "2345678901", Balance = 12_000_000, Version = 0, UserId = UserId2},
                    new() { Id = Guid.NewGuid(), BankName = "BIDV",        BankAccount = "3456789012", Balance = 8_500_000,  Version = 0, UserId = UserId3},
                    new() { Id = Guid.NewGuid(), BankName = "MB Bank",     BankAccount = "4567890123", Balance = 2_000_000,  Version = 0, UserId = UserId4},
                    new() { Id = Guid.NewGuid(), BankName = "VPBank",      BankAccount = "5678901234", Balance = 3_500_000,  Version = 0, UserId = UserId5},
                };
                builder.HasData(wallets);
            });
        }
    }