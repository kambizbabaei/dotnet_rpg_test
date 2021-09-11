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

        ICharacterRepository IUnitOfWork.Characters => throw new NotImplementedException();

        public UnitOfWork(ILoggerFactory logger, DataContext context) : base(context)
        {

            this.Context = context;
            Logger = logger.CreateLogger("logs");
            /*Users = new UserRepository(context, Logger, context.Users);
            Characters = new CharacterRepository(context, Logger, context.characters);*/
        }

        private CharacterRepository _characterRepository;


        public ICharacterRepository Characters
        {
            get => _characterRepository ??= new CharacterRepository(Context);
        }

        public UserRepository Users => throw new NotImplementedException();

        public async Task Complete()
        {
            await Context.SaveChangesAsync();
        }

    }
}