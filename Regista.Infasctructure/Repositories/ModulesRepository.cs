using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Relational;
using Regista.Application.Repositories;
using Regista.Domain.Dto.ModulesModels;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class ModulesRepository : Repository, IModulesRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SessionModel _session;
        private readonly RegistaContext _context;
        public ModulesRepository(RegistaContext context, SessionModel session,IUnitOfWork uow) : base(context, session)
        {
            _context = context;
            _session = session;
            _unitOfWork = uow;
        }

        public async Task<string> CreateModules(Modules model)
        {
            try
            {
                await _unitOfWork.repository.Add(model);
                await _unitOfWork.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteModules(int ID)
        {
            var modules = GetNonDeletedAndActive<Modules>(t=>t.ID== ID);
            DeleteRange(modules.ToList());
            Delete<Modules>(ID);
            return "";
        }

        public IQueryable<ModulesDTO> GetModules()
        {
            try
            {
                return GetNonDeletedAndActive<Modules>(t => true).Select(s => new ModulesDTO()
                {
                    Description = s.Description,
                    Name = s.Name,
                    Key = s.Key,
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UpdatesModules(Modules model)
        {
            try
            {
                Update(model);
                await _unitOfWork.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
