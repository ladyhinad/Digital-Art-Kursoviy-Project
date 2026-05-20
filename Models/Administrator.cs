namespace Digital_Art_Kursoviy_Project.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string FullName { get; set; } 
        public string Email { get; set; }

        public bool IsSuperAdmin { get; set; }
    }
}