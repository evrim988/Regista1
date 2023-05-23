using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.ResponseEntities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly RegistaContext _registaContext;

        public ProjectRepository(RegistaContext dataContext)
        {
            _registaContext = dataContext;
        }

        public async Task<BaseResponse<Project>> Add(Project model)
        {
            try
            {
                _registaContext.Projects.Add(model);

                var result = await _registaContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseResponse<Project>
                    {
                        Message = "Proje Ekleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success,
                    };
                }

                return new BaseResponse<Project>
                {
                    Message = "Proje Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Success,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponse<Project>> Delete(Project model)
        {
            try
            {
                _registaContext.Projects.Remove(model);

                var result = await _registaContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseResponse<Project>
                    {
                        Message = "Müşteri Silme Başarılı",
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }
                return new BaseResponse<Project>
                {
                    Message = "Müşteri Silme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseResponse<Project>> GetById(int id)
        {
            return new BaseResponse<Project>
            {
                ResultObject = await _registaContext.Projects.FirstOrDefaultAsync(t => t.id == id)
            };
        }

        public async Task<BaseResponse<Project>> GetList()
        {
            return new BaseResponse<Project>
            {
                ResultObjects = await _registaContext.Projects.Where(t => !t.IsDeleted).ToListAsync()
            };
        }

        public async Task<BaseResponse<Project>> Update(Project model)
        {
            try
            {
                var projectCustomer = _registaContext.Projects.FirstOrDefault(t => t.id == model.id);

                if (projectCustomer == null)
                {
                    return new BaseResponse<Project>
                    {
                        Message = "Müşteri Bulunamadı",
                        ResultStatus = Domain.Enums.ResultStatus.Warning
                    };
                }

                projectCustomer.ProjeAdı = model.ProjeAdı;
                projectCustomer.ProjeAçıklaması = model.ProjeAçıklaması;

                _registaContext.Projects.Update(model);

                var result = await _registaContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseResponse<Project>
                    {
                        Message = "Müşteri Güncelleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseResponse<Project>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
