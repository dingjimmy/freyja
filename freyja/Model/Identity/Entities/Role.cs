// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freyja.Model.Identity
{
    public class Role
    {

        public string Id { get; set; }


        public Role(string roleName)
        {
            Id = roleName;
        }

    }
}