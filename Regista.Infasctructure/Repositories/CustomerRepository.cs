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
    public class CustomerRepository : ICustomerRepository
    {

        private readonly RegistaContext _registaContext;

        public CustomerRepository(RegistaContext dataContext)
        {
            _registaContext = dataContext;
        }

        public async Task<BaseResponse<Customer>> Add(Customer model)
        {
            try
            {
                _registaContext.Customers.Add(model);

                var result = await _registaContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseResponse<Customer>
                    {
                        Message = "Müşteri Ekleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseResponse<Customer>
                {
                    Message = "Müşteri Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseResponse<Customer>
                {
                    Message = "Müşteri Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
        }

        public async Task<BaseResponse<Customer>> Delete(Customer model)
        {
            try
            {
                _registaContext.Customers.Remove(model);

                var result = await _registaContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseResponse<Customer>
                    {
                        Message = "Müşteri Silme Başarılı",
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseResponse<Customer>
                {
                    Message = "Müşteri Silme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseResponse<Customer>
                {
                    Message = "Müşteri Silme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
        }

        public async Task<BaseResponse<Customer>> GetById(int id)
        {
            return new BaseResponse<Customer>
            {
                ResultObject = await _registaContext.Customers.FirstOrDefaultAsync(t => t.id == id)
            };
        }

        public async Task<BaseResponse<Customer>> GetList()
        {

            return new BaseResponse<Customer>
            {
                ResultObjects = await _registaContext.Customers.Where(t => !t.IsDeleted).ToListAsync()
            };
        }

        public async Task<BaseResponse<Customer>> Update(Customer model)
        {
            try
            {
                var currentCustomer = _registaContext.Customers.FirstOrDefault(t => t.id == model.id);

                if (currentCustomer == null)
                {
                    return new BaseResponse<Customer>
                    {
                        Message = "Müşteri Bulunamadı",
                        ResultStatus = Domain.Enums.ResultStatus.Warning
                    };
                }

                currentCustomer.Adress = model.Adress;
                currentCustomer.Name = model.Name;
                currentCustomer.Surname = model.Surname;

                _registaContext.Customers.Update(model);

                var result = await _registaContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseResponse<Customer>
                    {
                        Message = "Müşteri Güncelleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseResponse<Customer>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseResponse<Customer>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
        }
    }
}
