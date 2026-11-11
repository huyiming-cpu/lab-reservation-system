using System;

namespace YourProjectNamespace.Entity
{
    public class Equipment
    {
        public long Id { get; set; }
        public long LabId {  get; set; }
        public string LabName { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime ? PurchaseTime { get; set; }
        public string TechnicalParams { get; set; }
        public int CurrentStatus { get; set; }
        public int FaultCount { get; set; }
        public int UsageCount { get; set; }

       
        public string StatusText
        {
            get
            {
                if (CurrentStatus == 1)
                {
                    return "正常";
                }
                else if (CurrentStatus == 2)
                {
                    return "故障";
                }
                else if (CurrentStatus == 3)
                {
                    return "维护中";
                }
                
                else
                {
                    return "未知";
                }
            }
        }
    }
}