﻿using System.Security.Policy;

namespace HamburgerUI.Models.VMs
{
    public class LoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
