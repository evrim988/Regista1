﻿namespace Regista1.WebApp.Models.SecurityModels
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string uri { get; set; }
    }
}