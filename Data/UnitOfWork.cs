using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IConfiguration;
using pr.Core.interfaces.IRepository;
using pr.Core.Repository;

namespace pr.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DataContext Context { get; }
        public ILogger Logger { get; }
        public UserRepository Users { get; }
        public CharacterRepository Characters { get; }
        public WeaponRepository Weapons { get; }
        public UnitOfWork(ILoggerFactory logger, DataContext context)
        {
            this.Context = context;
            Logger = logger.CreateLogger("logs");
            Users = new UserRepository(context, Logger, context.Users);
            Characters = new CharacterRepository(context, Logger, context.characters);
            Weapons = new WeaponRepository(context, Logger, context.Weapons);
        }

        public async Task Complete()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.DisposeAsync();
        }
    }
}