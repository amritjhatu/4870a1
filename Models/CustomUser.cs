using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Code1stUsersRoles.Models
{
    public class CustomUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsApproved { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}