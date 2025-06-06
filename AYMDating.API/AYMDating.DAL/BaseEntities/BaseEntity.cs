﻿using AYMDating.DAL.BaseEntity;
using AYMDating.DAL.Interfaces;
using AYMDating.DAL.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYMDating.DAL.BaseEntity
{
    public class BaseEntity <T> : Base
    {
        public T ID { get; set; }
        public string? CreatedUserID { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public string? LastUpdateUserID { get; set; }
        public DateTime? LastUpdateDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;       
    }
}
