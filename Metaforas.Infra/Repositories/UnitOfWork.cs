using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Infra.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaforas.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServerContext _context;
        private readonly IFraseRepository _fraseRepository;
        private readonly IPensadorRepository _pensadorRepository;
        private readonly IPensadorTimeRepository _pensadorTimeRepository;
        private readonly ITimeRepository _timeRepository;
        private IDbContextTransaction _transatction;

        public UnitOfWork(
            ServerContext context,
            IFraseRepository fraseRepository, 
            IPensadorRepository pensadorRepository,
            IPensadorTimeRepository pesandorTimeRepository,
            ITimeRepository timeRepository
            )
        {
            _context = context;
            _fraseRepository = fraseRepository;
            _pensadorRepository = pensadorRepository;
            _pensadorTimeRepository = pesandorTimeRepository;
            _timeRepository = timeRepository;

        }


        public IFraseRepository FraseRepository => _fraseRepository;
        public IPensadorRepository PensadorRepository => _pensadorRepository;
        public IPensadorTimeRepository PensadorTimeRepository => _pensadorTimeRepository;
        public ITimeRepository TimeRepository => _timeRepository;


        public void BeginTransaction()
        {
            _transatction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transatction.Commit();
        }

        public void Rollback()
        {
            _transatction.Rollback();
        }

    }
}
