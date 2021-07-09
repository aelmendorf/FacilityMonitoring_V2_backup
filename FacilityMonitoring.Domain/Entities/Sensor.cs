using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityMonitoring.Domain.Entites {
    public class Sensor {
        public int Id { get; set; }
        public double ZeroValue { get; set; }
        public double Slope { get; set; }
        public double Factor { get; set; }
        public string Units { get; set; }

        public ICollection<AnalogInput> AnalogChannels { get; set; }

        public Sensor() {
            this.AnalogChannels = new ObservableHashSet<AnalogInput>();
        }

    }
}
