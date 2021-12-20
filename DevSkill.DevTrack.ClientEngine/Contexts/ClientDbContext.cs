using Microsoft.EntityFrameworkCore;

namespace DevSkill.DevTrack.ClientEngine.Contexts
{
    public class ClientDbContext : DbContext, IClientDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ClientDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlite(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}