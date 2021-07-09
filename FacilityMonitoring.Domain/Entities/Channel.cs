using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityMonitoring.Domain.Entites {

    public enum DiscreteState {
        High=1,
        Low=0
    }

    [Owned]
    public class ModbusAddress {
        public int Address { get; set; }
        public int RegisterLength { get; set; }
        public RegisterType RegisterType { get; set; }
    }

    [Owned]
    public class ChannelAddress {
        public int Channel { get; set; }
        public int ModuleSlot { get; set; }
    }

    public abstract class Channel {
        public int Id { get; set; }
        public int SystemChannel { get; set; }
        public ChannelAddress ChannelAddress { get; set; }
        public ModbusAddress ModbusAddress { get; set; }
        public bool Connected { get; set; }
        public bool BypassAlert { get; set; }

        public int ModbusDeviceId { get; set; }
        public ModbusDevice ModbusDevice { get; set; }

        public ICollection<Alert> Alerts { get; set; }
        public ICollection<ChannelReading> Readings { get; set; }
    }

    public class DiscreteInput :Channel{
        public DiscreteState ChannelState { get; set; }
    }

    public class DiscreteOutput:Channel {
        public DiscreteState StartState { get; set; }
        public DiscreteState ChannelState { get; set; }
    }

    public class AnalogInput:Channel {
        public double CurrentValue { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }

        public AnalogInput() {
            this.BypassAlert = false;
            this.Connected = false;
            this.SystemChannel = 0;
        }
    }
}
