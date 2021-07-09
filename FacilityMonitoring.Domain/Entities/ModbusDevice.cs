using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityMonitoring.Domain.Entites {

    public enum RegisterType {
        Coil,
        DiscreteInput,
        HoldingRegister,
        InputRegister
    }

    public enum DeviceState { OKAY, WARNING, ALARM, MAINTENCE }
    
    public abstract class ModbusDevice {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int SlaveAddress { get; set; }
        public DeviceState State { get; set; }
        public string Status { get; set; }
        public bool BypassAlarms { get; set; }
        public double ReadInterval { get; set; }
        public double SaveInterval { get; set; }
        public ICollection<Channel> Channels { get; set; }

        public ModbusDevice() {
            this.Channels = new ObservableHashSet<Channel>();
            this.Identifier = "Not Set";
            this.DisplayName = "Not Set";
            this.IpAddress = "127.0.0.1";
            this.Port = 502;
            this.SlaveAddress = 1;
            this.State = DeviceState.OKAY;
            this.Status = "Okay";
            this.BypassAlarms = false;
            this.ReadInterval = 500;
            this.SaveInterval = 1000;
        }
    }

    public class MonitoringBox:ModbusDevice {
        public int ModbusComAddr { get; set; }
        public int SoftwareMainAddress { get; set; }
        public int AlarmAddress { get; set; }
        public int StateAddress { get; set; }

        public MonitoringBox() : base() {
            this.ModbusComAddr = 1;
            this.SoftwareMainAddress = 2;
            this.AlarmAddress = 3;
            this.StateAddress = 4;
        }
    }
}
