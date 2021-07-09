using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityMonitoring.Domain.Entites {

    public enum TriggerOn {
        High=1,
        Low=0
    }

    public class Alert {
        public int Id { get; set; }
        public ActionType AlertAction { get; set; }
        public bool Bypass { get; set; }
        public bool Enabled { get; set; }

        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }

    public class AnalogAlert:Alert {
        public double SetPoint { get; set; }
    }

    public class DiscreteAlert : Alert {
        public TriggerOn TriggerOn { get; set; }
    }
}
