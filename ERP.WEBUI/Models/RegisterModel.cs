﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WEBUI.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}