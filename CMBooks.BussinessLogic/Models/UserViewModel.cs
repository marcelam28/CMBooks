using System;
using System.ComponentModel.DataAnnotations;

namespace CMBooks.BusinessLogic.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="This field is required!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Password { get; set; }

        public DataLayer.User CopyTo()
        {
            return new DataLayer.User()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                DateOfBirth = this.DateOfBirth,
                Password = this.Password
            };
        }
    }
}
