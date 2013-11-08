// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freyja.Model.Identity
{
    public class Claim
    {

        public string Id { get; set; }


        public Claim(string roleName)
        {
            Id = roleName;
        }

    }
}