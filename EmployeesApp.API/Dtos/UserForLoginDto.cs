using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.API.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Username {get;set;}

        [Required]
        [StringLength(8, MinimumLength=5, ErrorMessage="Password must be between 5 to 8 charcters.")]
        public string Password {get;set;}
    }
}