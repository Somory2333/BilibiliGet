

using Microsoft.EntityFrameworkCore;

namespace net8
{


    public class UserDb : DbContext
    {
        public UserDb (DbContextOptions<UserDb> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}

