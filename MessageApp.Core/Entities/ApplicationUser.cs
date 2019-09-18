using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageApp.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsVisible { get; set; }
    }
}
