using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cls.majvacore.infra.Domain.Entities;
using cls.majvacore.infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IRepository;
using pr.Data;
using pr.Models.baseClass;

namespace pr.Core.Repository
{
    public class GenericRepository<T, PrimaryKeyType> : Repository<T, PrimaryKeyType> where T : class, IEntity<PrimaryKeyType>
    {
        public readonly DataContext Db;
        public readonly ILogger Logger;
        public readonly DbSet<T> dbset;
        public GenericRepository(DataContext Db, ILogger logger, DbSet<T> dbset) : base(Db)
        {
            this.dbset = dbset;
            this.Logger = logger;
            this.Db = Db;
        }

    }
}