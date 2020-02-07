using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using EBookStoreContracts.Contracts;
using EBookStoreDAL.DAL;

namespace EBookStoreAPI
{
   
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

            

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            try
            {
                UserDAL userDAL = new UserDAL();
                List<User> listUser = new List<User>();
                string userName = context.UserName.ToString();
                string password = context.Password.ToString();
                listUser = userDAL.GetUserDetails();
                bool userCount= listUser.Any(s => s.UserName== userName && s.Password== password);

                if (userCount)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("User_ID", listUser[0].UserID.ToString()));
                    identity.AddClaim(new Claim("UserName", listUser[0].UserName));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    identity.AddClaim(new Claim("UserType", ""));

                    context.Validated(identity);
                }
                return;
            }
            catch (Exception e)
            {

                throw;
            }

           

        }
    }
}