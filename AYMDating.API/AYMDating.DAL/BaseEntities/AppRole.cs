﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYMDating.DAL.BaseEntity
{
    public class AppRole : IdentityRole
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}
