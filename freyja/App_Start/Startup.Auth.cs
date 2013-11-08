// Copyright (c) James Dingle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace Freyja
{
    public partial class Startup
    {

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }


        static Startup()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }


        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }

    }
}