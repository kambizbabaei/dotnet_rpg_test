using System;
using System.Threading.Tasks;
using cls.majvacore.infra.Repository.DataAccess.UOW;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IConfiguration;
using pr.Core.interfaces.IRepository;
using pr.Core.interfaces.Repository;
using pr.Core.Repository;

namespace pr.Data
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public DataContext Context { get; }

        public UnitOfWork(DataContext context) : base(context)
        {

            this.Context = context;
        }

        #region character repository
        private CharacterRepository _characterRepository;
        public ICharacterRepository Characters
        {
            get => _characterRepository ??= new CharacterRepository(Context);

        }
        #endregion

        #region user repository
        private UserRepository _userRepository;
        public IUserRepository Users
        {
            get => _userRepository ??= new UserRepository(Context);
        }
        #endregion

        #region weapon repository
        private WeaponRepository _weaponRepository;
        public IWeaponRepository Weapons
        {
            get => _weaponRepository ??= new WeaponRepository(Context);
        }
        #endregion

        #region owned weapon repository
        private OwnedWeaponRepository _ownedWeaponRepository;
        public IOwnedWeaponRepository UserWeapons
        {
            get => _ownedWeaponRepository ??= new OwnedWeaponRepository(Context);
        }
        #endregion

        public async Task Complete()
        {
            await Context.SaveChangesAsync();
        }

    }
}
