namespace AmdarisProject_3.Domain.Models.Dtos
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
