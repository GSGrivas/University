using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ContosoUniversity.Infrastructure
{
    //All the tests for the password inputs
    public class CustomPasswordValidator : PasswordValidator<IdentityUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager,
            IdentityUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            
            //Creates a list to add errors to or adds errors to list
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            //If you want more tests, just add more if statements
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }

            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot contain numeric sequence"
                });
            }

            return errors.Count == 0 ?
              IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}