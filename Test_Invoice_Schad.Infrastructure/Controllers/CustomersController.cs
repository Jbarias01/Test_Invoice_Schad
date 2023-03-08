using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice_Schad.Core.Context;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.DTOs;
using Test_Invoice_Schad.Infrastructure.Interfaces;
using Test_Invoice_Schad.Infrastructure.Repositories;

namespace Test_Invoice_Schad.Infrastructure.Controllers
{
    public class CustomersController
    {
        private readonly AppDbContext _context = new AppDbContext();
        public IRepository<Customers> _customersRepository => new CustomersRepository(_context);

        public CustomersController()
        {
        }

        public List<CustomersDTO> GetAllCustomers()
        {
            var entity = _customersRepository.GetAll();
            var model = new List<CustomersDTO>();

            foreach (var item in entity)
            {
                var customerTypesDTO = new CustomersDTO()
                {
                    Id = item.Id,
                    CustName = item.CustName.ToUpper().Trim(),
                    Adress = item.Adress.ToUpper().Trim(),
                    CustomerType = item.CustomerTypes.Description.ToUpper().Trim(),
                    Estado = (item.Status == true ? "ACTIVO" : "INACTIVO")
                };

                model.Add(customerTypesDTO);
            }

            return model;
        }

        public List<CustomersDTO> GetCustomersByCustName(string description)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                List<CustomersDTO> model = (from c in _db.Customers
                                            where c.CustName.Contains(description)
                                            select new CustomersDTO
                                            {
                                                Id = c.Id,
                                                CustName = c.CustName.ToUpper().Trim(),
                                                Adress = c.Adress.ToUpper().Trim(),
                                                CustomerTypeId = c.CustomerTypeId,
                                                CustomerType = c.CustomerTypes.Description.ToUpper().Trim(),
                                                Status = c.Status,
                                                Estado = (c.Status == true ? "ACTIVO" : "INACTIVO")
                                            }).ToList();

                return model;
            }
        }

        public CustomersDTO GetCustomersByID(int id)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                CustomersDTO model = (from c in _db.Customers
                                      select new CustomersDTO
                                      {
                                          Id = c.Id,
                                          CustName = c.CustName.ToUpper().Trim(),
                                          Adress = c.Adress.ToUpper().Trim(),
                                          CustomerTypeId = c.CustomerTypeId,
                                          CustomerType = c.CustomerTypes.Description.ToUpper().Trim(),
                                          Status = c.Status
                                      }).FirstOrDefault(c => c.Id == id);

                return model;
            }
        }

        public void AddCustomer(CustomersDTO request)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                var customers = new Customers()
                {
                    CustName = request.CustName,
                    Adress = request.Adress,
                    CustomerTypeId = request.CustomerTypeId,
                    Status = request.Status
                };

                _customersRepository.Add(customers);
            }
        }

        public void UpdateCustomer(int id, CustomersDTO request)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                var customers = new Customers()
                {
                    Id = id,
                    CustName = request.CustName,
                    Adress = request.Adress,
                    CustomerTypeId = request.CustomerTypeId,
                    Status = request.Status
                };

                _customersRepository.Update(customers);
            }
        }

        public void DeleteCustomer(int id)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                var customer = _db.Customers.FirstOrDefault(c => c.Id == id);
                customer.Status = false;

                _db.Customers.AddOrUpdate(customer);
                _db.SaveChanges();
                //_customersRepository.Update(customer);
            }
        }
    }
}
