using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityMonitoring.Domain.Entites {
    public abstract class ChannelReading {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }

    public class DiscreteChannelReading:ChannelReading {
        public bool Value { get; set; }
    }

    public class AnalogChannelReading : ChannelReading {
        public double Value { get; set; }
    }
}
