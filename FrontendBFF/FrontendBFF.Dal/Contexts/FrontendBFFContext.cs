using FrontendBFF.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontendBFF.Dal.Contexts;

public class FrontendBFFContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Kwet> Kwets { get; set; }

    public FrontendBFFContext()
    {
        
    }

    public FrontendBFFContext(DbContextOptions<FrontendBFFContext> options) : base(options)
    {
        
    }
}