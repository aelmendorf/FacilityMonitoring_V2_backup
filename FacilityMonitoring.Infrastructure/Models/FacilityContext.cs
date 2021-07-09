using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacilityMonitoring.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FacilityMonitoring.Infrastructure.Model {
    public class FacilityContext:DbContext {
        public DbSet<ModbusDevice> ModbusDevices { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<FacilityAction> Actions { get; set; }
        public DbSet<ChannelReading> Readings { get; set; }

        public FacilityContext(DbContextOptions<FacilityContext> options) : base(options) {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public FacilityContext() {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("server=172.20.4.20;database=FacilityMonitorTesting;User Id=aelmendorf;Password=Drizzle123!;");
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<MonitoringBox>().HasBaseType<ModbusDevice>();
            builder.Entity<DiscreteInput>().HasBaseType<Channel>();
            builder.Entity<AnalogInput>().HasBaseType<Channel>();
            builder.Entity<DiscreteOutput>().HasBaseType<Channel>();
            builder.Entity<AnalogAlert>().HasBaseType<Alert>();
            builder.Entity<DiscreteAlert>().HasBaseType<Alert>();
            builder.Entity<DiscreteChannelReading>().HasBaseType<ChannelReading>();
            builder.Entity<AnalogChannelReading>().HasBaseType<ChannelReading>();

            builder.Entity<Channel>()
                .OwnsOne(p => p.ChannelAddress);

            builder.Entity<Channel>()
                .OwnsOne(p => p.ModbusAddress);

            builder.Entity<FacilityAction>()
                .OwnsMany(p => p.ActionOutputs, a => {
                    a.WithOwner().HasForeignKey("OwnerId");
                    a.Property<int>("Id");
                    a.HasKey("Id");
                });

            builder.Entity<MonitoringBox>()
                .HasMany(e => e.Channels)
                .WithOne(e => e.ModbusDevice as MonitoringBox)
                .HasForeignKey(e => e.ModbusDeviceId)
                .IsRequired(true);

            builder.Entity<Channel>()
                .HasMany(e => e.Readings)
                .WithOne(e => e.Channel)
                .HasForeignKey(e => e.ChannelId)
                .IsRequired(true);
            
            builder.Entity<Sensor>()
                .HasMany(e => e.AnalogChannels)
                .WithOne(e => e.Sensor)
                .HasForeignKey(e => e.SensorId)
                .IsRequired(true);

            builder.Entity<Channel>()
                .HasMany(e => e.Alerts)
                .WithOne(e => e.Channel)
                .HasForeignKey(e => e.ChannelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    
    }

    public class FacilityContextFactory : IDesignTimeDbContextFactory<FacilityContext> {
        public FacilityContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<FacilityContext>();
            //optionsBuilder.UseSqlServer("");
            return new FacilityContext();
        }
    }

}
