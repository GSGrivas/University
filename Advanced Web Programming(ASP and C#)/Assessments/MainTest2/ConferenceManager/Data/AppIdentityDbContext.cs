using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManager.Data
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        //For the identity data(users)
        //If you use this, you need to specify the context for the add migration (add-migration -context AppIdentityDbContext)
        //As well as drop-database/add-database -context AppIdentityDbContext
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }
    }
}

