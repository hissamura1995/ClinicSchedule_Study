using Clinic.API.Enums;
using Clinic.API.Models;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Clinic.API.Context.Seed
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Users.Any())
            {
                return;
            }

            var passwordHasher = new PasswordHasher<User>();

            var admin = new User
            {
                CPF = "12345678900",
                Name = "Admin",
                Email = "adminuser@test.com",
                Role = UserRoles.Admin,
                Address = new Address
                {
                    Street = "Admin Street",
                    City = "Admin City",
                    State = "Admin State",
                    ZipCode = "12345678",
                }
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}