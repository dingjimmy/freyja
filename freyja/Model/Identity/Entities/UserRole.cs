﻿// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Freyja.Model.Identity
{
    public class UserRole
    {

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        [Key, Column(Order = 0)]
        public string RoleId { get; set; }        
        
    }
}