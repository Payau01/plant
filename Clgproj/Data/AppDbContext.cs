using Microsoft.EntityFrameworkCore;
using Clgproj.Model;

namespace Clgproj.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        
        // DbSets
        public DbSet<Plant> Plants { get; set; }
        public DbSet<WateringSchedule> WateringSchedules { get; set; }
        public DbSet<WateringLog> WateringLogs { get; set; }
        public DbSet<PlantGrowthRecord> PlantGrowthRecords { get; set; }
        public DbSet<PlantHistory> PlantHistories { get; set; }
        public DbSet<FertilizerUsage> FertilizerUsages { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<PlantAnalysisResult> PlantAnalysisResults { get; set; }
        public object? WaterRequirementRules { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🌱 Plant
            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Species)
                      .HasMaxLength(100);

                entity.Property(p => p.Location)
                      .HasMaxLength(200);

                entity.HasMany(p => p.WateringSchedules)
                      .WithOne()
                      .HasForeignKey(w => w.PlantId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.WateringLogs)
                      .WithOne()
                      .HasForeignKey(w => w.PlantId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.GrowthRecords)
                      .WithOne()
                      .HasForeignKey(g => g.PlantId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.FertilizerUsages)
                      .WithOne()
                      .HasForeignKey(f => f.PlantId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // 🚿 WateringSchedule
            modelBuilder.Entity<WateringSchedule>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.Property(w => w.LitersRequired)
                      .HasColumnType("numeric(18,2)");

                entity.Property(w => w.Frequency)
                      .HasConversion<string>();
            });

            // 🚿 WateringLog
            modelBuilder.Entity<WateringLog>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.Property(w => w.WaterUsedInLiters)
                      .HasColumnType("numeric(18,2)");

                entity.Property(w => w.WateredAt)
                      .HasColumnType("timestamp with time zone");

                entity.HasIndex(w => w.WateredAt);
            });

            // 🌿 PlantGrowth
            modelBuilder.Entity<PlantGrowthRecord>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.HeightInCm)
                      .HasColumnType("numeric(18,2)");

                entity.Property(g => g.LeafCount)
                      .IsRequired(false);

                entity.Property(g => g.RecordedOn)
                      .HasColumnType("timestamp with time zone");

                entity.HasIndex(g => g.RecordedOn);
            });

            // 🌾 FertilizerUsage
            modelBuilder.Entity<FertilizerUsage>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.FertilizerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(f => f.QuantityInGrams)
                      .HasColumnType("numeric(18,2)");

                entity.Property(f => f.AppliedOn)
                      .HasColumnType("timestamp with time zone");

                entity.HasIndex(f => f.AppliedOn);
            });

            // 🧾 Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(i => i.InvoiceNumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(i => i.FarmerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(i => i.BuyerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(i => i.TotalAmount)
                      .HasColumnType("numeric(18,2)");

                entity.Property(i => i.TaxAmount)
                      .HasColumnType("numeric(18,2)");

                entity.Property(i => i.GrandTotal)
                      .HasColumnType("numeric(18,2)");

                entity.HasMany(i => i.Items)
                      .WithOne()
                      .HasForeignKey(it => it.InvoiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // 🧾 InvoiceItem
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(i => i.ProductName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(i => i.Quantity)
                      .HasColumnType("numeric(18,2)");

                entity.Property(i => i.UnitPrice)
                      .HasColumnType("numeric(18,2)");

                entity.Property(i => i.TotalPrice)
                      .HasColumnType("numeric(18,2)");
            });

            // 🧠 PlantAnalysisResult
            modelBuilder.Entity<PlantAnalysisResult>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.PlantType)
                      .HasMaxLength(100);

                entity.Property(a => a.HealthStatus)
                      .HasMaxLength(50);

                entity.Property(a => a.Confidence)
                      .HasColumnType("numeric(5,2)");
            });

            // 📜 PlantHistory
            modelBuilder.Entity<PlantHistory>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.EventType)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(h => h.Description)
                      .HasMaxLength(500);

                entity.Property(h => h.EventDate)
                      .HasColumnType("timestamp with time zone");

                entity.HasIndex(h => h.EventDate);

                entity.HasOne<Plant>()
                      .WithMany()
                      .HasForeignKey(h => h.PlantId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
