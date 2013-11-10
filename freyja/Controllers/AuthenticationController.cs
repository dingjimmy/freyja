// Copyright (c) James Dingle

using Freyja.ViewModels;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Freyja.Controllers
{
    public class AuthenticationController : ApiController
    {

        // POST /Authentication/AccessToken
        [HttpPost]
        public HttpResponseMessage AccessToken(LoginViewModel login)
        {

            using (var ctx = new Model.Data.IdentityDbContext())
            {

                // look for the username and password in the secrets table
                var secrets = from s in ctx.Secrets
                              where s.UserName == login.UserName
                              && s.Secret == login.Password
                              && s.Type == Model.Identity.SecretType.Password
                              select s;


                // if match found then users identity is authenticated
                if (secrets.Count() == 1)
                {

                    var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);

                    var claims = from u in ctx.Users
                                 from c in u.Claims
                                 where u.UserName == login.UserName
                                 select c;

                          
                    identity.AddClaim(new Claim(ClaimTypes.Name, login.UserName));


                    var currentUtc = new SystemClock().UtcNow;

                    AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                    ticket.Properties.IssuedUtc = currentUtc;
                    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<object>(new
                        {
                            UserName = login.UserName,
                            AccessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket)
                        }, Configuration.Formatters.JsonFormatter)
                    };
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        } 

    }
}
