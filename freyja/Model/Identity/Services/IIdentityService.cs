// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freyja.Model.Identity
{
    interface IIdentityService
    {
        User RegisterUser(string username, string emailaddress, string password);

        void BeginEmailVerification(string username);
        
        void CompleteEmailVerification();


    }
}
