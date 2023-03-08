using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice_Schad.Core.Context;
using Test_Invoice_Schad.Core.Models;
using Test_Invoice_Schad.Infrastructure.Interfaces;

namespace Test_Invoice_Schad.Infrastructure.Repositories
{
    public class CustomersTypesRepository : Repository<CustomerTypes>, ICustomersTypesRepository
    {
        public CustomersTypesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
