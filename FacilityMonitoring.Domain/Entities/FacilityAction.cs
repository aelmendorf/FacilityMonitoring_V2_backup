using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityMonitoring.Domain.Entites {

    public enum ActionType {
        Okay = 6,
        Alarm = 5,
        Warning = 4,
        SoftWarn = 3,
        Maintenance = 2,
        Custom = 1
    }

    [Owned]
    public class ActionOutput {
        public DiscreteOutput Output { get; set; }
        public DiscreteState OnLevel { get; set; }
        public DiscreteState OffLevel { get; set; }
    }

    public class FacilityAction {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public ActionType ActionType { get; set; }
        bool SendEmail { get; set; }

        public ICollection<ActionOutput> ActionOutputs { get; set; }

        FacilityAction() {
            this.ActionOutputs = new ObservableHashSet<ActionOutput>();
        }
    }


}
