using System;

namespace LabReservationApp.Entity
{
    public class Reservation
    {
      
        public long Id { get; set; }

      
        public long LabId { get; set; }

   
        public long TeacherId { get; set; }

       
        public DateTime ReserveDate { get; set; }

  
        public TimeSpan ReserveStart { get; set; }

   
        public TimeSpan ReserveEnd { get; set; }

        /// <summary>
        /// 状态：0-待审核 1-已通过 2-已驳回 3-已签到 4-已签退，默认值为 0
        /// </summary>
        public byte Status { get; set; } = 0;

      
        public DateTime? SigninTime { get; set; }

        public DateTime? SignoutTime { get; set; }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "待审核";
                    case 1:
                        return "已通过";
                    case 2:
                        return "已驳回";
                    case 3:
                        return "已签到";
                    case 4:
                        return "已签退";
                    default:
                        return "未知状态";
                }
            }
        }

        
        public string ReserveTimeRange
        {
            get
            {
                return $"{ReserveDate:yyyy-MM-dd} {ReserveStart:hh\\:mm} - {ReserveEnd:hh\\:mm}";
            }
        }
    }
}