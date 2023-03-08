using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test_Invoice_Schad.Core.Models;

namespace Test_Invoice_Schad.Infrastructure.Interfaces
{
    public interface ICustomersRepository : IRepository<Customers>
    {
    }
}
