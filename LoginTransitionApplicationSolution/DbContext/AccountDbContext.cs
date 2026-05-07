using Microsoft.EntityFrameworkCore;


namespace Account.DbContext
{
    public class AccountDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Account.DTO.AccountDTO> Account
        {
            get; set;
        }

        public AccountDbContext(DbContextOptions<AccountDbContext> dataBaseContextOptions) : base(dataBaseContextOptions)
        {

        }
    }
}
