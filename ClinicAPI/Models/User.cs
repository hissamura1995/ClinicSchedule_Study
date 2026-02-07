using Clinic.API.Enums;
using Clinic.API.Models;

namespace ClinicAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }


        public UserRoles Role { get; set; }
        public Address Address { get; set; }
    }
}
