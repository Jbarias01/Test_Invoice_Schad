using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice_Schad.Infrastructure.DTOs
{
    public class CustomersDTO
    {
        public int Id { get; set; }

        public string CustName { get; set; }

        public string Adress { get; set; }

        public bool Status { get; set; }
        
        public string Estado { get; set; }

        public int CustomerTypeId { get; set; }

        public string CustomerType { get; set; }
    }
}
