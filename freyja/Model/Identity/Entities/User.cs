// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freyja.Model.Journal;
using System.ComponentModel.DataAnnotations;

namespace Freyja.Model.Identity
{
    public class User
    {

        //public string ID { get; set; }

        [Key]
        public string UserName { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public string EmailAddress { get; set; }

        public Currency Currency { get; set; }




        public User(string userName, string emailAddress,  Currency defaultCurrency)
            : this(userName, null, null, null, emailAddress, Currency.GBP) { }



        public User(string userName, string title, string firstName, string familyName, string emailAddress, Currency defaultCurrency)
        {
            //ID = Guid.NewGuid().ToString();
            UserName = userName;
            Title = title;
            FirstName = firstName;
            FamilyName = familyName;
            EmailAddress = emailAddress;
            Currency = defaultCurrency;
        }

    }
}