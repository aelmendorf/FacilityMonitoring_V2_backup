﻿// <auto-generated />
using System;
using FacilityMonitoring.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FacilityMonitoring.Infrastructure.Migrations
{
    [DbContext(typeof(FacilityContext))]
    [Migration("20210709192716_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlertAction")
                        .HasColumnType("int");

                    b.Property<bool>("Bypass")
                        .HasColumnType("bit");

                    b.Property<int>("ChannelId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("Alerts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Alert");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BypassAlert")
                        .HasColumnType("bit");

                    b.Property<bool>("Connected")
                        .HasColumnType("bit");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModbusDeviceId")
                        .HasColumnType("int");

                    b.Property<int>("SystemChannel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModbusDeviceId");

                    b.ToTable("Channels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Channel");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.ChannelReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChannelId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("Readings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ChannelReading");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.FacilityAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.ModbusDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BypassAlarms")
                        .HasColumnType("bit");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<double>("ReadInterval")
                        .HasColumnType("float");

                    b.Property<double>("SaveInterval")
                        .HasColumnType("float");

                    b.Property<int>("SlaveAddress")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModbusDevices");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ModbusDevice");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Factor")
                        .HasColumnType("float");

                    b.Property<double>("Slope")
                        .HasColumnType("float");

                    b.Property<string>("Units")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ZeroValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.AnalogAlert", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.Alert");

                    b.Property<double>("SetPoint")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("AnalogAlert");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.DiscreteAlert", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.Alert");

                    b.Property<int>("TriggerOn")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscreteAlert");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.AnalogInput", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.Channel");

                    b.Property<double>("CurrentValue")
                        .HasColumnType("float");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.HasIndex("SensorId");

                    b.HasDiscriminator().HasValue("AnalogInput");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.DiscreteInput", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.Channel");

                    b.Property<int>("ChannelState")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscreteInput");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.DiscreteOutput", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.Channel");

                    b.Property<int>("ChannelState")
                        .HasColumnType("int")
                        .HasColumnName("DiscreteOutput_ChannelState");

                    b.Property<int>("StartState")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscreteOutput");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.AnalogChannelReading", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.ChannelReading");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("AnalogChannelReading");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.DiscreteChannelReading", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.ChannelReading");

                    b.Property<bool>("Value")
                        .HasColumnType("bit")
                        .HasColumnName("DiscreteChannelReading_Value");

                    b.HasDiscriminator().HasValue("DiscreteChannelReading");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.MonitoringBox", b =>
                {
                    b.HasBaseType("FacilityMonitoring.Domain.Entites.ModbusDevice");

                    b.Property<int>("AlarmAddress")
                        .HasColumnType("int");

                    b.Property<int>("ModbusComAddr")
                        .HasColumnType("int");

                    b.Property<int>("SoftwareMainAddress")
                        .HasColumnType("int");

                    b.Property<int>("StateAddress")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("MonitoringBox");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Alert", b =>
                {
                    b.HasOne("FacilityMonitoring.Domain.Entites.Channel", "Channel")
                        .WithMany("Alerts")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Channel", b =>
                {
                    b.HasOne("FacilityMonitoring.Domain.Entites.ModbusDevice", "ModbusDevice")
                        .WithMany("Channels")
                        .HasForeignKey("ModbusDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FacilityMonitoring.Domain.Entites.ChannelAddress", "ChannelAddress", b1 =>
                        {
                            b1.Property<int>("ChannelId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Channel")
                                .HasColumnType("int");

                            b1.Property<int>("ModuleSlot")
                                .HasColumnType("int");

                            b1.HasKey("ChannelId");

                            b1.ToTable("Channels");

                            b1.WithOwner()
                                .HasForeignKey("ChannelId");
                        });

                    b.OwnsOne("FacilityMonitoring.Domain.Entites.ModbusAddress", "ModbusAddress", b1 =>
                        {
                            b1.Property<int>("ChannelId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Address")
                                .HasColumnType("int");

                            b1.Property<int>("RegisterLength")
                                .HasColumnType("int");

                            b1.Property<int>("RegisterType")
                                .HasColumnType("int");

                            b1.HasKey("ChannelId");

                            b1.ToTable("Channels");

                            b1.WithOwner()
                                .HasForeignKey("ChannelId");
                        });

                    b.Navigation("ChannelAddress");

                    b.Navigation("ModbusAddress");

                    b.Navigation("ModbusDevice");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.ChannelReading", b =>
                {
                    b.HasOne("FacilityMonitoring.Domain.Entites.Channel", "Channel")
                        .WithMany("Readings")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.FacilityAction", b =>
                {
                    b.OwnsMany("FacilityMonitoring.Domain.Entites.ActionOutput", "ActionOutputs", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("OffLevel")
                                .HasColumnType("int");

                            b1.Property<int>("OnLevel")
                                .HasColumnType("int");

                            b1.Property<int?>("OutputId")
                                .HasColumnType("int");

                            b1.Property<int>("OwnerId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("OutputId");

                            b1.HasIndex("OwnerId");

                            b1.ToTable("ActionOutput");

                            b1.HasOne("FacilityMonitoring.Domain.Entites.DiscreteOutput", "Output")
                                .WithMany()
                                .HasForeignKey("OutputId");

                            b1.WithOwner()
                                .HasForeignKey("OwnerId");

                            b1.Navigation("Output");
                        });

                    b.Navigation("ActionOutputs");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.AnalogInput", b =>
                {
                    b.HasOne("FacilityMonitoring.Domain.Entites.Sensor", "Sensor")
                        .WithMany("AnalogChannels")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Channel", b =>
                {
                    b.Navigation("Alerts");

                    b.Navigation("Readings");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.ModbusDevice", b =>
                {
                    b.Navigation("Channels");
                });

            modelBuilder.Entity("FacilityMonitoring.Domain.Entites.Sensor", b =>
                {
                    b.Navigation("AnalogChannels");
                });
#pragma warning restore 612, 618
        }
    }
}
