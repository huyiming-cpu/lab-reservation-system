using System;

namespace LabReservationApp.Entity
{
    public class Laboratory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Area { get; set; }
        public string EquipmentList { get; set; }
        public TimeSpan OpenStart { get; set; }
        public TimeSpan OpenEnd { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string WeekDay { get; set; }

        
        public string IsEnabledText => IsEnabled ? "启用中" : "已禁用";
    }
}