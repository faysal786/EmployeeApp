using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get;set;} 

        [Required]
        [StringLength(8, MinimumLength = 5,ErrorMessage = "Please specify password between 5 to 8 characters")]
        public string Password {get;set;} 
    }
}