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
    public class InvoicesController
    {
        private readonly AppDbContext _context = new AppDbContext();
        public IRepository<Invoice> _invoicesRepository => new InvoicesRepository(_context);
        public IRepository<InvoiceDetail> _invoicesDetailsRepository => new InvoicesDetailsRepository(_context);

        public void AddInvoices(InvoicesDTO request)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                var invoice = new Invoice()
                {
                    CustomerId = request.CustomerId,
                    TotalItbis = request.TotalItbis,
                    SubTotal = request.SubTotal,
                    Total = request.Total
                };

                var invoiceRequest = _db.Invoices.Add(invoice);
                _db.SaveChanges();

                foreach (var item in request.InvoicesDetails)
                {
                    var invoiceDetail = new InvoiceDetail()
                    {
                        InvoiceId = invoiceRequest.Id,
                        Qty = item.Qty,
                        Price = item.Price,
                        TotalItbis = item.TotalItbis,
                        SubTotal = item.SubTotal,
                        Total = item.Total
                    };

                    _invoicesDetailsRepository.Add(invoiceDetail);
                }
            }
        }

        public List<InvoicesDTO> GetAllInvoices()
        {
            using (AppDbContext _db = new AppDbContext())
            {
                List<InvoicesDTO> model = (from i in _db.Invoices
                                           select new InvoicesDTO
                                           {
                                               Id = i.Id,
                                               CustomerId = i.CustomerId,
                                               Customer = i.Customers.CustName.ToUpper().Trim(),
                                               SubTotal = i.SubTotal,
                                               TotalItbis = i.TotalItbis,
                                               Total = i.Total
                                           }).ToList();

                return model;
            }
        }

        public InvoicesDTO GetInvoicesByID(int id)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                InvoicesDTO model = (from i in _db.Invoices
                                     select new InvoicesDTO
                                     {
                                         Id = i.Id,
                                         CustomerId = i.CustomerId,
                                         Customer = i.Customers.CustName.ToUpper().Trim(),
                                         SubTotal = i.SubTotal,
                                         TotalItbis = i.TotalItbis,
                                         Total = i.Total
                                     }).FirstOrDefault(c => c.Id == id);

                return model;
            }
        }

        public List<InvoicesDetailsDTO> GetInvoicesDetailsByID(int id)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                List<InvoicesDetailsDTO> model = (from i in _db.InvoiceDetails
                                                  where i.InvoiceId == id
                                                  select new InvoicesDetailsDTO
                                                  {
                                                      Qty = i.Qty,
                                                      Price = i.Price,
                                                      SubTotal = i.SubTotal,
                                                      TotalItbis = i.TotalItbis,
                                                      Total = i.Total
                                                  }).ToList();

                return model;
            }
        }

        public List<InvoicesDTO> GetInvoicesByCustName(string description)
        {
            using (AppDbContext _db = new AppDbContext())
            {
                List<InvoicesDTO> model = (from c in _db.Invoices
                                           where c.Customers.CustName.Contains(description)
                                            select new InvoicesDTO
                                            {
                                                Id = c.Id,
                                                CustomerId = c.CustomerId,
                                                Customer = c.Customers.CustName.ToUpper().Trim(),
                                                SubTotal = c.SubTotal,
                                                TotalItbis = c.TotalItbis,
                                                Total = c.Total
                                            }).ToList();

                return model;
            }
        }
    }
}
