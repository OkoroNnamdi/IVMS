﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class UserProfile
    {
        public int UserProfileId {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword {  get; set; }
        public string Address {  get; set; }
        public string PhoneNumber {  get; set; }
        public string OldPassword {  get; set; }
        public string ProfilePicture { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
