using System;
using System.Threading.Tasks;
using FacilityMonitoring.Domain.Entites;
using FacilityMonitoring.Infrastructure.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityMonitoring.ConsoleTesting {
    class Program {
        public static async Task<int> Main(string[] args) {
            //await CreateSensors();
            //await AddAnalogChannel();
            //Console.WriteLine("Analog Inputs Created");
            //Console.WriteLine("Generating Analog Readings");
            //await GenerateAnalogReadings();
            //Console.WriteLine("Adding Discrete Channel");
            //await AddDiscreteChannel();
            //Console.WriteLine("Discrete Channel should be added");
            //Console.WriteLine("Generating Discrete Readings: ");
            //await GenerateDiscreteReadings();
            //Console.WriteLine("Readings SHould be generated");
            //await CreateInitial();
            return 1;
        }

        public static async Task GenerateAnalogReadings() {
            using var context = new FacilityContext();
            var channel = await context.Channels.Include(e => e.ModbusDevice).AsTracking().FirstOrDefaultAsync(chan => chan.Id == 2);

            if (channel != null) {
                Random rand = new Random();
                for (int i = 0; i < 5000; i++) {
                    context.Readings.Add(new AnalogChannelReading() { Channel = channel, Value = rand.NextDouble() });
                }
                await context.SaveChangesAsync();
            } else {
                Console.WriteLine("Error: Channel was null,please check your input");
            }
        }

        public static async Task GenerateDiscreteReadings() {
            using var context = new FacilityContext();
            var channel = await context.Channels
                .Include(e => e.ModbusDevice)
                .AsTracking()
                .FirstOrDefaultAsync(chan => chan.Id == 1);
            if (channel != null) {
                Random rand = new Random();
                for (int i = 0; i < 5000; i++) {
                    int val = rand.Next(0, 1);
                    context.Readings.Add(new DiscreteChannelReading() { Channel = channel, Value = Convert.ToBoolean(val) });
                }
                await context.SaveChangesAsync();
            } else {
                Console.WriteLine("Error: Channel was null,please check your input");
            }
        }

        public static async Task AddAnalogChannel() {
            FacilityContext context = new FacilityContext();
            var device = await context.ModbusDevices.FindAsync(1);
            var sensor = await context.Sensors.FirstOrDefaultAsync(sen => sen.Id == 2);

            AnalogInput aInput = new AnalogInput();
            aInput.ModbusAddress = new ModbusAddress() { Address = 1, RegisterLength = 2, RegisterType = RegisterType.HoldingRegister };
            aInput.ChannelAddress = new ChannelAddress() { Channel = 1, ModuleSlot = 1 };
            aInput.BypassAlert = false;
            aInput.SensorId = sensor.Id;
            aInput.Sensor = sensor;
            aInput.ModbusDeviceId = device.Id;
            aInput.ModbusDevice = device;

            context.Channels.Add(aInput);
            await context.SaveChangesAsync();
        }

        public static async Task AddDiscreteChannel() {
            FacilityContext context = new FacilityContext();
            var device = await context.ModbusDevices.FindAsync(1);

            DiscreteInput aInput = new DiscreteInput();
            aInput.ModbusAddress = new ModbusAddress() { Address = 10, RegisterLength = 2, RegisterType = RegisterType.Coil };
            aInput.ChannelAddress = new ChannelAddress() { Channel = 1, ModuleSlot = 2 };
            aInput.BypassAlert = false;
            aInput.ModbusDeviceId = device.Id;
            aInput.ModbusDevice = device;

            context.Channels.Add(aInput);
            await context.SaveChangesAsync();
        }

        private static void Context_SaveChangesFailed(object sender, Microsoft.EntityFrameworkCore.SaveChangesFailedEventArgs e) {
            Console.WriteLine("Save failed!!!");
        }

        public static async Task<int> CreateSensors() {
            FacilityContext context = new FacilityContext();
            context.SaveChangesFailed += Context_SaveChangesFailed;

            Sensor h2Sensor = new Sensor();
            h2Sensor.ZeroValue = 4;
            h2Sensor.Slope = .006;
            h2Sensor.Units = "PPM";
            h2Sensor.Factor = 1;

            Sensor O2Sensor = new Sensor();
            O2Sensor.ZeroValue = 4;
            O2Sensor.Slope = .006;
            O2Sensor.Units = "PPM";
            O2Sensor.Factor = 1;

            Sensor NSensor = new Sensor();
            NSensor.ZeroValue = 4;
            NSensor.Slope = .006;
            NSensor.Units = "PPM";
            NSensor.Factor = 1;

            Sensor h2ESensor = new Sensor();
            h2ESensor.ZeroValue = 4;
            h2ESensor.Slope = .006;
            h2ESensor.Units = "PPM";
            h2ESensor.Factor = 1;

            await context.AddAsync(h2Sensor);
            await context.AddAsync(O2Sensor);
            await context.AddAsync(NSensor);
            await context.AddAsync(h2ESensor);

            await context.SaveChangesAsync();
            return 1;
        }

        public static async Task CreateInitial() {
            //CreateHostBuilder(args);
            Console.WriteLine("Testing");

            FacilityContext context = new FacilityContext();
            context.SaveChangesFailed += Context_SaveChangesFailed;

            Sensor h2Sensor = new Sensor();
            h2Sensor.ZeroValue = 4;
            h2Sensor.Slope = .006;
            h2Sensor.Units = "PPM";
            h2Sensor.Factor = 1;

            Sensor O2Sensor = new Sensor();
            O2Sensor.ZeroValue = 4;
            O2Sensor.Slope = .006;
            O2Sensor.Units = "PPM";
            O2Sensor.Factor = 1;

            Sensor NSensor = new Sensor();
            NSensor.ZeroValue = 4;
            NSensor.Slope = .006;
            NSensor.Units = "PPM";
            NSensor.Factor = 1;

            Sensor h2ESensor = new Sensor();
            h2ESensor.ZeroValue = 4;
            h2ESensor.Slope = .006;
            h2ESensor.Units = "PPM";
            h2ESensor.Factor = 1;

            await context.AddAsync(h2Sensor);
            await context.AddAsync(O2Sensor);
            await context.AddAsync(NSensor);
            await context.AddAsync(h2ESensor);

            MonitoringBox monitor = new MonitoringBox();
            monitor.Identifier = "Epi Lab 2";
            monitor.DisplayName = "Epi2 Monitoring";

            await context.AddAsync(monitor);
            await context.SaveChangesAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<FacilityContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {   }
    }
}
