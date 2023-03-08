using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice_Schad.Core.Context;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.Interfaces;
using Test_Invoice_Schad.Infrastructure.Repositories;
using Test_Invoice_Schad.Views.Customers;

namespace Test_Invoice_Schad.UnitTest
{
    public class CustomersTypesTest
    {
        private readonly AppDbContext _context = new AppDbContext();
        private IRepository<CustomerTypes> _customerTypesRepository => new CustomersTypesRepository(_context);

        [Fact]
        public void CreateCustomerTypes()
        {
            //Arrange        
            var customerTypes = new CustomerTypes() 
            { 
                Description = string.Concat("PRUEBA") 
            };

            Frm_Customers c = new Frm_Customers();
            c.fo









            //Act
            _customerTypesRepository.Add(customerTypes);

            //Assert
            var results = _context.Invoices.FirstOrDefault();
            
        }
    }
}
