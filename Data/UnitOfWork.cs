using System;
using System.Threading.Tasks;
using cls.majvacore.infra.Repository.DataAccess.UOW;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IConfiguration;
using pr.Core.interfaces.IRepository;
using pr.Core.Repository;

namespace pr.Data
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public DataContext Context { get; }
        public ILogger Logger { get; }
        public UserRepository Users { get; }
        public CharacterRepository Characters { get; }
        public UnitOfWork(ILoggerFactory logger, DataContext context) : base(context)
        {

            this.Context = context;
            Logger = logger.CreateLogger("logs");
            Users = new UserRepository(context, Logger, context.Users);
            Characters = new CharacterRepository(context, Logger, context.characters);
        }

        public async Task Complete()
        {
            await Context.SaveChangesAsync();
        }

    }
}