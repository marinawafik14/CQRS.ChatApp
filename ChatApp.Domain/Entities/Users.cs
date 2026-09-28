
using ChatApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Domain.Entities
{
    public class Users : IdentityUser<int>
    {
        public string ImageUrl { get; set; }= string.Empty;
        public string Bio {  get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public PrecensStatus PrecensStatus { get; set; }
    }
}
