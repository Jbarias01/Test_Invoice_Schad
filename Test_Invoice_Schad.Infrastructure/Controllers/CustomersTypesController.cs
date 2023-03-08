using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice_Schad.Core.Context;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.DTOs;
using Test_Invoice_Schad.Infrastructure.Interfaces;
using Test_Invoice_Schad.Infrastructure.Repositories;

namespace Test_Invoice_Schad.Infrastructure.Controllers
{
    public class CustomersTypesController
    {
        private readonly AppDbContext _context = new AppDbContext();
        public IRepository<CustomerTypes> _customerTypesRepository => new CustomersTypesRepository(_context);

        public CustomersTypesController() 
        { }

        public List<CustomerTypesDTO> GetAllCustomerTypes()
        {
            var model = new List<CustomerTypesDTO>();
            using (AppDbContext _db = new AppDbContext())
            {
                var entity = _db.CustomerTypes.ToList();
                foreach (var item in entity)
                {
                    var customerTypesDTO = new CustomerTypesDTO()
                    {
                        Id = item.Id,
                        Description = item.Description
                    };

                    model.Add(customerTypesDTO);
                }
            }
            return model;
        }

        public void AddCustomerTypes(CustomerTypesDTO request)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                var customers = new CustomerTypes()
                {
                    Description = request.Description
                };

                _customerTypesRepository.Add(customers);
            }
        }
    }
}
