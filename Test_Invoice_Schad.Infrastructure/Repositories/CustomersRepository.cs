using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test_Invoice_Schad.Core.Context;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.Interfaces;

namespace Test_Invoice_Schad.Infrastructure.Repositories
{
    public class CustomersRepository : Repository<Customers>, ICustomersRepository
    {
        public CustomersRepository(AppDbContext context) : base(context)
        {
        }
    }
}
