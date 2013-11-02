// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Freyja.Model.Identity
{
    public class UserSecret
    {

        [Key, Column(Order = 0)]
        public string UserName { get; set; }


        [Key, Column(Order = 1)]
        public string Secret { get; set; }


        public SecretType Type { get; set; }


        public bool Blocked { get; set; }




        public UserSecret(string userName, string secret, SecretType type)
        {
            UserName = userName;
            Secret = secret;
            Type = type;
            Blocked = false;
        }

      
    }


    public enum SecretType
    {
        Password = 2,
        Phrase = 4,
        PIN = 8,
        Thumbprint = 16
    }

}