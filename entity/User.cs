namespace LabReservationApp.Entity
{
    public class User
    {
       
        public long Id { get; set; }

    
        public string Username { get; set; }

      
        public string RealName { get; set; }

        public string Password { get; set; }

        
        public int Role { get; set; }

       
        public string Email { get; set; }

      
        public string Phone { get; set; }
    }
}