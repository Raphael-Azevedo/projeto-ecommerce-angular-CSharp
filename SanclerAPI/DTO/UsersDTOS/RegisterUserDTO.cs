namespace SanclerAPI.DTO
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }    

        public string ConfirmPassword { get; set; }
    }
}