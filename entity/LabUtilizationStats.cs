namespace LabReservationApp.Entity
{
   
    public class LabUtilizationStats
    {
        public long LabId { get; set; }
        public string LabName { get; set; }
        public int ReservationCount { get; set; }  
        public int TotalReserveMinutes { get; set; }  
        public int TotalUsedMinutes { get; set; }  
        public double UtilizationRate { get; set; }  
        public int OpenHours { get; internal set; }
        public int UsedHours { get; internal set; }
    }
}